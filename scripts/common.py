"""Job scheduling, timeouts and result recording for the experiment scripts."""

import argparse
import json
import os
import signal
import subprocess
import shlex
import tempfile
import sys
import time
from collections import Counter
from concurrent.futures import FIRST_COMPLETED, ThreadPoolExecutor, wait
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
SOURCE = ROOT / "src/stl-tableaux"


def prepare_plotting():
    """Reuse a writable font cache across report and experiment runs."""
    os.environ.setdefault("MPLCONFIGDIR", str(ROOT / "results/.matplotlib"))
    Path(os.environ["MPLCONFIGDIR"]).mkdir(parents=True, exist_ok=True)


def print_progress(message):
    """Flush progress messages so they appear while figures are being generated."""
    print(message, flush=True)


def print_generation_report(task, files):
    """Print a completion message and the generated paths in a common format."""
    print_progress(f"{task} generation completed successfully.")
    print_progress("Generated files:")
    for path in files:
        print_progress(f"  {path.resolve()}")


def print_plot_report(experiment, figures, measurements):
    print_generation_report(f"{experiment} plot", [*figures, measurements])


def write(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(value, indent=2) + "\n")


def record_command(folder, command, label):
    """Record the generation and solver commands of a case."""
    with (folder / "commands.txt").open("a") as stream:
        stream.write(f"# {label}\n")
        stream.write(f"cd {shlex.quote(str(folder.resolve()))}\n")
        stream.write(shlex.join([str(part) for part in command]) + "\n\n")


def config(folder):
    text = (
        (SOURCE / "default.cfg")
        .read_text()
        .replace("../../.tools", os.path.relpath(ROOT / ".tools", folder))
    )
    path = folder / "default.cfg"
    path.write_text(text)
    return path


def launch(command, folder, log, timeout):
    env = dict(
        os.environ,
        PWD=str(folder),
        PYTHONHASHSEED="0",
        PYTHONDONTWRITEBYTECODE="1",
        OMP_NUM_THREADS="1",
        OPENBLAS_NUM_THREADS="1",
        MKL_NUM_THREADS="1",
        PYTHONUNBUFFERED="1",
    )
    env["LD_LIBRARY_PATH"] = (
        str(ROOT / ".tools/lib") + ":" + env.get("LD_LIBRARY_PATH", "")
    )
    java = ROOT / ".tools/java/bin"
    if java.exists():
        env["PATH"] = str(java) + ":" + env["PATH"]
    record_command(folder, command, log.stem)
    start = time.monotonic()
    with log.open("w") as f:
        p = subprocess.Popen(
            command,
            cwd=folder,
            env=env,
            stdout=f,
            stderr=subprocess.STDOUT,
            start_new_session=True,
        )
        try:
            code = p.wait(timeout=timeout)
            status = "complete" if code == 0 else "error"
        except subprocess.TimeoutExpired:
            os.killpg(p.pid, signal.SIGKILL)
            code = p.wait()
            status = "timeout"
        finally:
            try:
                os.killpg(p.pid, signal.SIGKILL)
            except ProcessLookupError:
                pass
    return dict(status=status, exit_code=code, wall_seconds=time.monotonic() - start)


def requested_report(choices):
    selector = argparse.ArgumentParser(add_help=False)
    selector.add_argument("--report", choices=choices)
    args, _ = selector.parse_known_args()
    return args.report


def parser(
    description,
    report=False,
    ids_example="lane-f1 lane-f2",
    timeout_help="Timeout in seconds (default: 3600)",
):
    p = argparse.ArgumentParser(
        prog=os.environ.get("STL_TABLEAUX_CLI_PROG"), description=description
    )
    p.add_argument("--worker", type=Path, help=argparse.SUPPRESS)
    if report:
        p.add_argument(
            "--output",
            type=Path,
            default=ROOT / "results/reports",
            help="Directory for generated files (default: results/reports/)",
        )
        return p
    p.add_argument(
        "--workers",
        type=int,
        help="Concurrent jobs (default: automatic from available CPUs and cores per job)",
    )
    p.add_argument(
        "--timeout",
        type=int,
        help=timeout_help,
    )
    p.add_argument("--ids", nargs="+", help="Case IDs to run, e.g. " + ids_example)
    p.add_argument(
        "--output",
        type=Path,
        default=ROOT / "results",
        help="Experiment output root (default: results/)",
    )
    p.add_argument(
        "--dry-run",
        action="store_true",
        help=argparse.SUPPRESS,
    )
    return p


def validate(p, args):
    for name in ("workers", "timeout", "stlmc_cores", "stlmc_timeout"):
        value = getattr(args, name, None)
        if value is not None and value < 1:
            p.error(name + " must be positive")
    args.output = args.output.resolve()
    forbidden = [
        ROOT / "benchmarks",
        ROOT / "src",
        ROOT / "experiments/internal-reference",
    ]
    if args.output == ROOT or any(
        d == args.output or d in args.output.parents for d in forbidden
    ):
        p.error("Output must be a separate result directory")


def select_cases(cases, args):
    if args.ids:
        missing = set(args.ids) - {c["id"] for c in cases}
        if missing:
            raise ValueError("Unknown IDs: " + ", ".join(sorted(missing)))
        cases = [c for c in cases if c["id"] in args.ids]
    return cases


def available_cpus():
    try:
        return max(1, len(os.sched_getaffinity(0)))
    except (AttributeError, OSError):
        return max(1, os.cpu_count() or 1)


def worker_settings(requested, jobs, cpu_count):
    automatic = requested is None
    costs = [max(1, job["cores"]) for job in jobs]
    workers = max(1, cpu_count // min(costs)) if automatic else requested
    workers = min(workers, len(jobs))
    budget = cpu_count if automatic else workers * max(costs)
    return workers, budget, automatic


def run_jobs(args, jobs, script):
    if not jobs:
        raise ValueError("No jobs selected")
    cpu_count = available_cpus()
    args.workers, cpu_budget, automatic = worker_settings(args.workers, jobs, cpu_count)
    if args.dry_run:
        print(
            json.dumps(
                dict(
                    jobs=len(jobs),
                    by_experiment=dict(Counter(j["experiment"] for j in jobs)),
                    workers=args.workers,
                    available_cpus=cpu_count,
                    automatic_workers=automatic,
                    timeouts={j["experiment"]: j["timeout"] for j in jobs},
                ),
                indent=2,
            )
        )
        return
    print_progress(
        f"Starting {script.stem}: {len(jobs)} jobs, up to {min(args.workers, len(jobs))} running concurrently."
    )
    output_dirs = sorted(
        {
            Path(job["folder"])
            .resolve()
            .parents[1 if job["experiment"] == "ours" else 0]
            for job in jobs
        }
    )
    for directory in output_dirs:
        print_progress(f"Output dir: {directory}")
    args.output.mkdir(parents=True, exist_ok=True)
    for name in ("manifest.json", "progress.json", "results.json", "DONE.json"):
        (args.output / name).unlink(missing_ok=True)
    for directory in output_dirs:
        (directory / "results.json").unlink(missing_ok=True)
    run_path = args.output / "run.json"
    run = dict(
        experiment=script.stem,
        status="running",
        host=os.uname().nodename,
        python=sys.version.split()[0],
        command=shlex.join([sys.executable, *sys.argv]),
        workers=args.workers,
        worker_mode="automatic" if automatic else "explicit",
        available_cpus=cpu_count,
        total=len(jobs),
        finished=0,
        remaining=len(jobs),
        started=time.time(),
        statuses={},
    )
    write(run_path, run)

    def run_job(job):
        label = job["case"]["id"] + " / " + (job["tool"] or job["experiment"])
        print_progress(f"Started: {label}")
        folder = Path(job["folder"])
        folder.mkdir(parents=True, exist_ok=True)
        for name in (
            "job.json",
            "execution-command.json",
            "command.json",
            "generation.process.json",
            "solver-launch.process.json",
        ):
            (folder / name).unlink(missing_ok=True)
        (folder / "result.json").unlink(missing_ok=True)
        write(folder / "input.json", job["case"])
        (folder / "commands.txt").write_text("")
        env = dict(
            os.environ,
            PYTHONUNBUFFERED="1",
            PYTHONHASHSEED="0",
            OMP_NUM_THREADS="1",
            OPENBLAS_NUM_THREADS="1",
        )
        env["LD_LIBRARY_PATH"] = (
            str(ROOT / ".tools/lib") + ":" + env.get("LD_LIBRARY_PATH", "")
        )
        with tempfile.TemporaryDirectory(prefix="stl2tableaux-job-") as temporary:
            job_path = Path(temporary) / "job.json"
            write(job_path, job)
            command = [
                "timeout",
                "--signal=TERM",
                "--kill-after=15s",
                str(job["timeout"] * (2 if job["experiment"] == "ours" else 1) + 180),
                sys.executable,
                str(script),
                "--worker",
                str(job_path),
            ]
            with (folder / "worker.log").open("w") as log:
                completed = subprocess.run(
                    command, stdout=log, stderr=subprocess.STDOUT, env=env
                )
        result_path = folder / "result.json"
        record = json.loads(result_path.read_text()) if result_path.exists() else {}
        if record.get("status") not in {"complete", "error", "timeout"}:
            record = dict(
                id=job["case"]["id"],
                status="timeout" if completed.returncode == 124 else "error",
                exit_code=completed.returncode,
                error="Worker exited without a final result",
            )
            write(result_path, record)
        return dict(
            experiment=job["experiment"],
            id=job["case"]["id"],
            tool=job["tool"],
            status=record["status"],
            folder=job["folder"],
        )

    finished = []
    with ThreadPoolExecutor(max_workers=args.workers) as pool:
        queued = list(jobs)
        pending = {}
        reserved = 0
        while queued or pending:
            while queued and len(pending) < args.workers:
                index = next(
                    (
                        i
                        for i, job in enumerate(queued)
                        if min(max(1, job["cores"]), cpu_budget)
                        <= cpu_budget - reserved
                    ),
                    None,
                )
                if index is None:
                    break
                job = queued.pop(index)
                cost = min(max(1, job["cores"]), cpu_budget)
                pending[pool.submit(run_job, job)] = cost
                reserved += cost
            completed_futures, _ = wait(
                pending, timeout=15, return_when=FIRST_COMPLETED
            )
            if not completed_futures:
                print_progress(
                    f"Running... {len(finished)}/{len(jobs)} jobs finished; {len(queued) + len(pending)} remaining."
                )
            for future in completed_futures:
                reserved -= pending.pop(future)
                result = future.result()
                finished.append(result)
                label = result["id"] + " / " + (result["tool"] or result["experiment"])
                print_progress(
                    f"Finished: {label} ({result['status']}); {len(finished)}/{len(jobs)} jobs finished."
                )
                run.update(
                    finished=len(finished),
                    remaining=len(jobs) - len(finished),
                    statuses=dict(Counter(item["status"] for item in finished)),
                )
                write(run_path, run)
    run.update(status="jobs_finished")
    write(run_path, run)
    print_progress(f"{script.stem} experiment jobs finished.")
    return finished


def mark_done(output, finished):
    path = output / "run.json"
    run = json.loads(path.read_text())
    run.update(
        status="complete",
        completed=time.time(),
        finished=len(finished),
        remaining=0,
        statuses=dict(Counter(item["status"] for item in finished)),
    )
    write(path, run)
