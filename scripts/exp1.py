"""Run Exp1 model checking with our approach and STLmc."""

import json
import argparse
import os
from pathlib import Path
import re
import sys
import subprocess
import time
import signal
import hashlib
import csv
import html
from datetime import datetime, timezone
from common import (
    ROOT,
    prepare_plotting,
    print_plot_report,
    print_generation_report,
    print_progress,
    SOURCE,
    write,
    config,
    launch,
    record_command,
    parser,
    requested_report,
    validate,
    select_cases,
    run_jobs,
    mark_done,
)


def benchmark_cases():
    """Read model families and labeled properties directly from the benchmarks."""
    from stl2tableaux.parser.stlmc import STLmcParser

    cases = []
    for dynamics in ("linear", "nonlinear"):
        directory = ROOT / "benchmarks/exp1" / dynamics
        for model_file in sorted(directory.glob("*/*.model")):
            model = model_file.stem
            if model_file.parent.name != model:
                raise ValueError(
                    "Model directory must match its filename: " + str(model_file)
                )
            model_cfg = model_file.with_suffix(".cfg")
            if not model_cfg.is_file():
                raise ValueError("Missing model configuration: " + str(model_cfg))
            _, formulas = STLmcParser().parse_from_file(model_file)
            if not formulas.labeled:
                raise ValueError("No labeled properties in " + str(model_file))
            for formula_id in formulas.labeled:
                case_id = model + "-" + formula_id
                specific_cfg = model_file.parent / (case_id + ".cfg")
                if not specific_cfg.is_file():
                    raise ValueError(
                        "Missing property configuration: " + str(specific_cfg)
                    )
                cases.append(
                    dict(
                        id=case_id,
                        model=model,
                        formula_id=formula_id,
                        dynamics=dynamics,
                    )
                )
    return cases


def verdict(tool, log):
    log = re.sub(r"\x1b\[[0-9;]*m", "", log)
    # dReach can exit successfully and print "all ... unsat" even when its
    # SMT subprocess failed. Backend failures invalidate the final verdict.
    if tool == "dreach" and re.search(
        r"Uncaught exception|SMTException|syntax error|time should be defined once and only once",
        log,
    ):
        return "error"
    # SAT-Reach aborts when Hyst fails to translate the model.
    if tool == "sat-reach" and re.search(
        r"Exception in Hyst|Assertion .* failed|Aborted|core dumped", log
    ):
        return "error"
    # Preserve the raw Flow* verdict, including SAFE after incomplete computation.
    safe = (
        "BMC: The model is SAFE",
        "Forbidden states are not reachable.",
        "Result of the safety verification on the computed flowpipes: SAFE",
    )
    unsafe = (
        "BMC: The model is UNSAFE",
        "Forbidden states are reachable.",
        "Result of the safety verification on the computed flowpipes: UNSAFE",
    )
    if any(text in log for text in unsafe):
        return "unsafe"
    if any(text in log for text in safe):
        return "safe"
    if "UNKNOWN" in log:
        return "unknown"
    if tool == "stlmc":
        if re.search(r"result\s*:\s*True|status\s*:\s*satisfied", log):
            return "safe"
        if re.search(r"result\s*:\s*False|status\s*:\s*violated", log):
            return "unsafe"
    if tool == "dreach":
        if re.search(r"For k = \d+, \[[\d,]+\] -- SAT", log):
            return "unsafe"
        # Bounded unsat is not a proof of unbounded safety.
        if re.search(
            r"For k = \d+, dReach tried \d+ feasible paths, all of them are unsat\.",
            log,
        ):
            return "bounded_unsat"
    return "unclassified"


def run_ours(case, tool, out, timeout):
    folder = out / case["id"] / tool
    folder.mkdir(parents=True, exist_ok=True)
    row = dict(
        id=case["id"],
        tool=tool,
        timeout_seconds=timeout,
        implementation="automata",
    )
    write(folder / "input.json", case)
    model = (
        ROOT
        / "benchmarks/exp1"
        / case["dynamics"]
        / case["model"]
        / (case["model"] + ".model")
    )
    row["model_sha256"] = hashlib.sha256(model.read_bytes()).hexdigest()
    command = [
        sys.executable,
        "-u",
        str(SOURCE / "run"),
        str(model),
        "-goal",
        case["formula_id"],
        "-solver",
        tool,
        "-default-cfg",
        str(config(folder)),
        "-o",
        "out",
    ]
    row["generation"] = launch(command, folder, folder / "generation.log", timeout)
    script = folder / "out" / case["model"] / case["formula_id"] / tool / "run.sh"
    text = (folder / "generation.log").read_text(errors="replace")
    if row["generation"]["status"] == "complete" and re.search(
        r"^verdict: safe$", text, re.M
    ):
        # The composed automaton is empty, so no solver run is needed.
        row.update(
            status="complete",
            phase="generation",
            composed_ha=[0, 0],
            solver_seconds=0.0,
            outcome="safe",
        )
    elif (
        row["generation"]["status"] != "complete"
        or not script.exists()
        or re.search(r"^error:|^Traceback", text, re.M)
    ):
        row.update(
            status="timeout" if row["generation"]["status"] == "timeout" else "error",
            phase="generation",
        )
    else:
        sizes = re.findall(r"automaton info: \(# mode: (\d+), # jump: (\d+)\)", text)
        if sizes:
            row["composed_ha"] = list(map(int, sizes[-1]))
        phase = launch(
            ["bash", str(script)], folder, folder / "solver-launch.log", timeout
        )
        raw = script.parent / "out-log.txt"
        log = raw.read_text(errors="replace") if raw.exists() else ""
        (folder / "solver.log").write_text(log)
        row.update(phase)
        row["solver_seconds"] = phase["wall_seconds"]
        row["phase"] = "solver"
        row["outcome"] = (
            verdict(tool, log) if phase["status"] == "complete" else phase["status"]
        )
        if verdict(tool, log) == "error":
            row.update(status="error", outcome="error")
    write(folder / "result.json", row)
    return row


VENV = ROOT / ".venv-stlmc"


def cleanup_dreal(folder):
    """Reap solver children that escaped STLmc's process group."""
    folder = folder.resolve()
    killed = []
    for entry in Path("/proc").iterdir():
        if not entry.name.isdigit():
            continue
        try:
            args = entry.joinpath("cmdline").read_bytes().split(b"\0")
            if not args or Path(os.fsdecode(args[0])).name.lower() != "dreal":
                continue
            cwd = entry.joinpath("cwd").resolve()
            if cwd != folder and folder not in cwd.parents:
                continue
            os.kill(int(entry.name), signal.SIGKILL)
            killed.append(int(entry.name))
        except (OSError, ValueError):
            continue
    return killed


def run_stlmc(case, out, timeout, cores):
    folder = out / case["id"]
    folder.mkdir(exist_ok=True)
    model = ROOT / "benchmarks/exp1" / case["dynamics"] / case["model"]
    version = subprocess.check_output(
        [
            str(VENV / "bin/python"),
            "-c",
            'import importlib.metadata as m; print(m.version("stlmc"))',
        ],
        text=True,
    ).strip()
    command = [
        str(VENV / "bin/stlmc"),
        str(model / (case["model"] + ".model")),
        "-model-cfg",
        str(model / (case["model"] + ".cfg")),
        "-model-specific-cfg",
        str(model / (case["id"] + ".cfg")),
        "-parallel-core",
        str(cores),
        "-verbose",
        "-executable-path",
        str(VENV / "bin/dreal"),
    ]
    record_command(folder, command, "STLmc solver")
    write(folder / "input.json", case)
    start = time.monotonic()
    row = dict(
        id=case["id"],
        status="running",
        host=os.uname().nodename,
        started_utc=datetime.now(timezone.utc).isoformat(),
        timeout_seconds=timeout,
        parallel_cores=cores,
        stlmc_version=version,
        model_sha256=hashlib.sha256(
            (model / (case["model"] + ".model")).read_bytes()
        ).hexdigest(),
    )
    write(folder / "result.json", row)
    env = dict(
        os.environ,
        PYTHONUNBUFFERED="1",
        PYTHONDONTWRITEBYTECODE="1",
        OMP_NUM_THREADS="1",
        OPENBLAS_NUM_THREADS="1",
        MKL_NUM_THREADS="1",
    )
    with (folder / "solver.log").open("w") as log:
        process = subprocess.Popen(
            command,
            cwd=folder,
            env=env,
            stdout=log,
            stderr=subprocess.STDOUT,
            start_new_session=True,
        )
        try:
            code = process.wait(timeout=timeout)
            row["status"] = "complete" if code == 0 else "error"
        except subprocess.TimeoutExpired:
            row["status"] = "timeout"
            os.killpg(process.pid, signal.SIGKILL)
            code = process.wait()
        finally:
            try:
                os.killpg(process.pid, signal.SIGKILL)
            except ProcessLookupError:
                pass
    cleanup_dreal(folder)
    text = re.sub(
        r"\x1b\[[0-9;]*m", "", (folder / "solver.log").read_text(errors="replace")
    )
    if row["status"] == "complete" and re.search(r"(?m)^error:", text):
        row["status"] = "error"
        row["error"] = next(
            line for line in text.splitlines() if line.startswith("error:")
        )
    verdict = "unknown"
    if row["status"] == "complete":
        if re.search(r"result\s*:\s*True|status\s*:\s*satisfied", text):
            verdict = "bounded-satisfied"
        elif re.search(r"result\s*:\s*False|status\s*:\s*violated", text):
            verdict = "violated-candidate"
    messages = re.findall(r"status\s*:\s*([^\n]+)", text)
    row.update(
        exit_code=code,
        outcome=verdict,
        wall_seconds=time.monotonic() - start,
        solver_status=messages[-1].strip() if messages else None,
    )
    write(folder / "result.json", row)
    return row


def logged_error(folder, tool):
    """Detect backend failures from the solver log."""
    log = folder / "solver.log"
    return (
        tool != "stlmc"
        and log.exists()
        and verdict(tool, log.read_text(errors="replace")) == "error"
    )


def report_input(directory, experiment):
    """Accept a method result directory or a root containing exp1-ours/exp1-stlmc or ours/stlmc."""
    pattern = "*/*/result.json" if experiment == "exp1-ours" else "*/result.json"
    names = [experiment, "ours" if experiment == "exp1-ours" else "stlmc"]
    candidates = [directory / name for name in names] + [directory]
    for candidate in candidates:
        if next(candidate.glob(pattern), None) is not None:
            return candidate
    return directory


def report(a):
    print_progress("Generating plots: reading experiment results...")
    rows = []
    baselines = []
    for path in sorted(a.ours.glob("*/*/result.json")):
        model, formula = path.parent.parent.name.rsplit("-", 1)
        baselines.append(dict(model=model, formula=formula, solver=path.parent.name))
    for path in sorted(a.stlmc.glob("*/result.json")):
        model, formula = path.parent.name.rsplit("-", 1)
        baselines.append(dict(model=model, formula=formula, solver="stlmc"))
    if not baselines:
        raise ValueError(
            "No experiment results found under the --input directory. Specify an experiment output root or a result directory."
        )
    for b in baselines:
        case = b["model"] + "-" + b["formula"]
        tool = b["solver"]
        f = (a.stlmc if tool == "stlmc" else a.ours) / case
        if tool != "stlmc":
            f = f / tool
        data = (
            json.loads((f / "result.json").read_text())
            if (f / "result.json").exists()
            else {}
        )
        state = (
            "error"
            if logged_error(f, tool)
            else data.get("outcome", data.get("status", "pending"))
            if data.get("status") == "complete"
            else data.get("status", "pending")
        )
        if tool == "sat-reach" and state == "safe":
            state = "bounded_safe"
        rows.append(
            dict(
                id=case,
                solver=tool,
                current=state,
                seconds=data.get("solver_seconds", data.get("wall_seconds")),
            )
        )
    out = a.output
    out.mkdir(parents=True, exist_ok=True)
    with (out / "exp1.csv").open("w") as f:
        w = csv.DictWriter(f, fieldnames=rows[0])
        w.writeheader()
        w.writerows(rows)
    if a.action == "plot":
        print_progress("Preparing figure...")
        prepare_plotting()
        import matplotlib

        matplotlib.use("Agg")
        import matplotlib.pyplot as plt

        inputs = [
            dict(
                id=case,
                dynamics=(
                    "linear"
                    if any(
                        r["id"] == case and r["solver"] in ("spaceex", "sat-reach")
                        for r in rows
                    )
                    else "nonlinear"
                ),
            )
            for case in sorted({r["id"] for r in rows if r["solver"] != "stlmc"})
        ]
        lookup = {(r["id"], r["solver"]): r for r in rows}
        backend_labels = {
            "sat-reach": "SAT-Reach",
            "spaceex": "SpaceEx",
            "dreach": "dReach",
            "flowstar": "Flow*",
            "portfolio": "Best",
        }
        cap = 3600.0
        fig, axes = plt.subplots(2, 3, figsize=(9, 6.4), constrained_layout=True)
        for i, (dynamics, tools) in enumerate(
            [
                ("linear", ["sat-reach", "spaceex"]),
                ("nonlinear", ["dreach", "flowstar"]),
            ]
        ):
            for j, tool in enumerate(tools + ["portfolio"]):
                ax = axes[i, j]
                ax.set(
                    xscale="log",
                    yscale="log",
                    xlim=(0.01, cap),
                    ylim=(0.01, cap),
                    xlabel="STLmc" if i == 1 else "",
                    ylabel=f"Automata ({backend_labels[tool]})",
                )
                ax.set_box_aspect(1)
                ax.tick_params(
                    which="both", direction="in", top=True, right=True, labelsize=9
                )
                ax.grid(which="major", color="#dddddd", linestyle=":", linewidth=0.5)
                ax.plot([0.01, cap], [0.01, cap], color="#b0b0b0", lw=0.8)
                for c in inputs:
                    if c["dynamics"] != dynamics:
                        continue

                    def result(tool):
                        return lookup.get(
                            (c["id"], tool), dict(current="pending", seconds=None)
                        )

                    sm = result("stlmc")
                    if sm["current"] == "pending":
                        continue
                    candidates = (
                        [result(t) for t in tools]
                        if tool == "portfolio"
                        else [result(tool)]
                    )
                    eligible = [
                        r
                        for r in candidates
                        if r["current"]
                        in ("safe", "bounded_safe", "bounded_unsat", "unsafe")
                        and r["seconds"] is not None
                    ]
                    r = (
                        min(eligible, key=lambda r: r["seconds"])
                        if eligible
                        else next(
                            (r for r in candidates if r["current"] != "pending"),
                            candidates[0],
                        )
                    )
                    if r["current"] == "pending":
                        continue
                    x = cap if sm["current"] in ("timeout", "error") else sm["seconds"]
                    y = (
                        r["seconds"]
                        if r["current"]
                        in (
                            "safe",
                            "bounded_safe",
                            "bounded_unsat",
                            "unsafe",
                            "unknown",
                            "unclassified",
                        )
                        else cap
                    )
                    if x is None or y is None:
                        continue
                    ax.scatter(
                        max(0.01, min(cap, x)),
                        max(0.01, min(cap, y)),
                        facecolors="none",
                        edgecolors=(
                            "#d62728"
                            if r["current"] == "error"
                            else (
                                "#ff7f0e"
                                if r["current"] in ("unknown", "unclassified")
                                else "#1f77b4"
                            )
                        ),
                        marker=(
                            "^"
                            if r["current"] == "error"
                            else (
                                "s"
                                if r["current"] in ("unknown", "unclassified")
                                else "o"
                            )
                        ),
                        linewidths=0.8,
                        clip_on=False,
                        s=50,
                    )
        fig.get_layout_engine().set(rect=(0, 0.10, 1, 0.90))
        fig.text(
            0.04,
            0.02,
            "Fig. 17. Runtime comparison with STLmc (log-log scale). Top: linear; bottom: nonlinear.\n"
            "Left/middle: individual backends; right: best per instance.",
            ha="left",
            va="bottom",
            fontsize=10,
            fontfamily="serif",
        )
        print_progress("Rendering figure...")
        fig.canvas.draw()
        fig.set_layout_engine(None)
        print_progress("Saving files...")
        for ext in ("png", "pdf"):
            fig.savefig(
                out / f"exp1-fig17.{ext}",
                dpi=180,
                bbox_inches="tight",
                pad_inches=0.15,
            )
        plt.close(fig)
        print_plot_report(
            "Exp1",
            [out / f"exp1-fig17.{ext}" for ext in ("png", "pdf")],
            out / "exp1.csv",
        )


def export_tables(args):
    """Export appendix-style tables from measured results and generation logs."""
    methods = {
        "spaceex": "Autm (SX)",
        "sat-reach": "Autm (SR)",
        "flowstar": "Autm (Flow*)",
        "dreach": "Autm (DRH)",
        "stlmc": "STLmc (DRL)",
    }
    outcomes = {
        "safe": "TRUE",
        "bounded_safe": "TRUE",
        "bounded_unsat": "TRUE",
        "bounded-satisfied": "TRUE",
        "unsafe": "FALSE",
        "violated-candidate": "FALSE",
        "unknown": "UNKNOWN",
        "unclassified": "UNKNOWN",
        "error": "ERROR",
        "timeout": "TIMEOUT",
        "pending": "PENDING",
        "running": "RUNNING",
    }
    number_requested = int(args.action[-1])
    print_progress("Generating table: reading experiment results...")
    records = {}
    families = {}
    sources = [(args.ours, "*/*/result.json")]
    if number_requested == 3:
        sources.append((args.stlmc, "*/result.json"))
    for directory, pattern in sources:
        for path in sorted(directory.glob(pattern)):
            data = json.loads(path.read_text())
            tool = data.get("tool", "stlmc")
            if tool not in methods:
                continue
            case = data["id"]
            model, formula = case.rsplit("-", 1)
            input_file = path.parent / "input.json"
            input_data = (
                json.loads(input_file.read_text()) if input_file.exists() else {}
            )
            dynamics = input_data.get("dynamics")
            if not dynamics and tool != "stlmc":
                dynamics = "linear" if tool in ("spaceex", "sat-reach") else "nonlinear"
            if dynamics:
                if model in families and families[model] != dynamics:
                    raise ValueError("Conflicting dynamics for " + model)
                families[model] = dynamics
            state = (
                "error"
                if logged_error(path.parent, tool)
                else data.get("outcome", "unknown")
                if data["status"] == "complete"
                else data["status"]
            )
            status = outcomes.get(state, "UNKNOWN")
            seconds = data.get("solver_seconds", data.get("wall_seconds"))
            timing = (
                "T/O"
                if status == "TIMEOUT"
                else (
                    "-"
                    if status in ("ERROR", "PENDING", "RUNNING") or seconds is None
                    else f"{seconds:.2f}"
                )
            )
            size = data.get("composed_ha")
            tableau = None
            log_file = path.parent / "generation.log"
            if tool != "stlmc" and log_file.exists():
                log = log_file.read_text(errors="replace")
                ha_sizes = re.findall(
                    r"automaton info: \(# mode: (\d+), # jump: (\d+)\)", log
                )
                tableau_sizes = re.findall(
                    r"tableau info: \(# vertex: (\d+), # edge: (\d+)\)", log
                )
                if len(ha_sizes) >= 4:
                    size = list(map(int, ha_sizes[-1]))
                if len(tableau_sizes) >= 2:
                    tableau = list(map(int, tableau_sizes[1]))
            records[case, tool] = dict(
                size=size, tableau=tableau, time=timing, result=status
            )
    if not records:
        raise ValueError(
            "No experiment results found under the --input directory. Specify an experiment output root or a result directory."
        )
    models = sorted(families, key=lambda m: (families[m] != "linear", m))
    formulas = sorted(
        {case.rsplit("-", 1)[1] for case, _ in records},
        key=lambda name: [
            int(part) if part.isdigit() else part for part in re.split(r"(\d+)", name)
        ],
    )
    pair = lambda value: "/".join(map(str, value)) if value is not None else "-/-"
    table2 = []
    table3 = []
    for model in models:
        tools = (
            ["sat-reach", "spaceex"]
            if families[model] == "linear"
            else ["dreach", "flowstar"]
        )
        size_row = dict(dynamics=families[model], model=model)
        for formula in formulas:
            case = model + "-" + formula
            values = [records[case, t] for t in tools if (case, t) in records]
            for key in ("size", "tableau"):
                measured = {tuple(v[key]) for v in values if v[key] is not None}
                if len(measured) > 1:
                    raise ValueError("Inconsistent " + key + " across solvers: " + case)
                size_row[formula + ("_MJ" if key == "size" else "_VE")] = pair(
                    next(iter(measured), None)
                )
        table2.append(size_row)
        for tool in tools + ["stlmc"]:
            row = dict(dynamics=families[model], model=model, method=methods[tool])
            for formula in formulas:
                value = records.get(
                    (model + "-" + formula, tool),
                    dict(size=None, time="-", result="PENDING"),
                )
                row.update(
                    {
                        formula + "_ME": pair(value["size"]),
                        formula + "_time": value["time"],
                        formula + "_result": value["result"],
                    }
                )
            table3.append(row)
    args.output.mkdir(parents=True, exist_ok=True)
    selected_tables = (
        [("table2", table2)] if number_requested == 2 else [("table3", table3)]
    )

    width = 1 + 2 * len(formulas)
    prepare_plotting()
    import matplotlib

    matplotlib.use("Agg")
    import matplotlib.pyplot as plt

    print_progress("Preparing table...")

    def render_table2():
        caption = "Table 2. Sizes of the composed hybrid automata and the corresponding property automata generated by our approach."
        style = "body{font-family:'Times New Roman',serif;margin:32px;color:black}.panels{display:flex;gap:40px;overflow:auto}table{border-collapse:collapse;text-align:center;white-space:nowrap}th,td{padding:4px 9px;font-weight:normal}thead tr:first-child th{font-weight:bold;border-bottom:1.5px solid black}thead tr:last-child th{border-bottom:1px solid black}thead th[rowspan]{border-bottom:1px solid black}th.formula{border-bottom:1px solid black;font-style:italic}tbody tr:last-child td{border-bottom:1.5px solid black}"
        page = (
            "<!doctype html><html lang='en'><meta charset='utf-8'><title>Table 2</title><style>"
            + style
            + "</style><p>"
            + caption
            + "</p><div class='panels'>"
        )
        fig = plt.figure(figsize=(15, 3.8))
        fig.text(
            0.04, 0.95, caption, fontsize=11, fontfamily="serif", va="top", wrap=True
        )
        for index, dynamics in enumerate(("linear", "nonlinear")):
            selected = [row for row in table2 if row["dynamics"] == dynamics]
            heading = dynamics.capitalize() + " models"
            page += f"<table><thead><tr><th colspan='{width}'>{heading}</th></tr><tr><th rowspan='2'>Model</th>"
            for formula in formulas:
                match = re.fullmatch(r"f(\d+)", formula)
                label = (
                    "f<sub>" + match[1] + "</sub>" if match else html.escape(formula)
                )
                page += "<th class='formula' colspan='2'>" + label + "</th>"
            page += (
                "</tr><tr>"
                + "<th>M/J</th><th>V/E</th>" * len(formulas)
                + "</tr></thead><tbody>"
            )
            for row in selected:
                values = [row["model"]] + [
                    row[f + suffix] for f in formulas for suffix in ("_MJ", "_VE")
                ]
                page += (
                    "<tr>"
                    + "".join("<td>" + html.escape(v) + "</td>" for v in values)
                    + "</tr>"
                )
            page += "</tbody></table>"
            ax = fig.add_axes([0.04 + index * 0.49, 0.06, 0.43, 0.78])
            ax.set_xlim(0, width)
            ax.set_ylim(0, len(selected) + 3.5)
            ax.axis("off")
            top = len(selected) + 3

            def text(x, y, value, **kwargs):
                ax.text(
                    x,
                    y,
                    value,
                    ha="center",
                    va="center",
                    fontsize=11,
                    fontfamily="serif",
                    **kwargs,
                )

            text(width / 2, top, heading, weight="bold")
            ax.hlines(top - 0.5, 0, width, color="black", linewidth=1)
            text(0.5, top - 1.5, "Model")
            for i, formula in enumerate(formulas):
                match = re.fullmatch(r"f(\d+)", formula)
                label = "$f_{" + match[1] + "}$" if match else formula
                text(2 + i * 2, top - 1, label)
                ax.hlines(
                    top - 1.5, 1.1 + i * 2, 2.9 + i * 2, color="black", linewidth=0.6
                )
                text(1.5 + i * 2, top - 2, "M/J")
                text(2.5 + i * 2, top - 2, "V/E")
            ax.hlines(top - 2.5, 0, width, color="black", linewidth=0.8)
            for i, row in enumerate(selected):
                values = [row["model"]] + [
                    row[f + suffix] for f in formulas for suffix in ("_MJ", "_VE")
                ]
                for j, value in enumerate(values):
                    text(j + 0.5, top - 3 - i, value)
            ax.hlines(0.5, 0, width, color="black", linewidth=1)
        page += "</div></html>"
        print_progress("Saving files...")
        (args.output / "table2.html").write_text(page)
        fig.savefig(
            args.output / "table2.png", dpi=200, bbox_inches="tight", facecolor="white"
        )
        plt.close(fig)

    if number_requested == 2:
        render_table2()

    def render_table3():
        caption = "Table 3. Detailed model checking results. M/E: number of tableau modes/edges; Time: seconds; R: ⊤ unreachable, ⊥ reachable, * unknown, − timeout, X solver error."
        labels = {
            "TRUE": "⊤",
            "FALSE": "⊥",
            "UNKNOWN": "*",
            "TIMEOUT": "−",
            "ERROR": "X",
            "PENDING": "pending",
            "RUNNING": "running",
        }
        style = "body{font-family:'Times New Roman',serif;margin:32px;color:black}table{border-collapse:collapse;text-align:center;margin:auto;white-space:nowrap}th,td{padding:3px 8px;font-weight:normal}thead{border-top:2px solid black;border-bottom:1px solid black}th.formula{font-style:italic;border-bottom:1px solid black}tr.model-end td{border-bottom:1px solid black}table{border-bottom:2px solid black}.dynamics{writing-mode:vertical-rl;transform:rotate(180deg)}.family-start td{border-top:2px solid black}"
        page = (
            "<!doctype html><html lang='en'><meta charset='utf-8'><title>Table 3</title><style>"
            + style
            + "</style><p>"
            + caption
            + "</p><table><thead><tr><th rowspan='2'>Dyn.</th><th rowspan='2'>Model</th><th rowspan='2'>Method (Solver)</th>"
        )
        for f in formulas:
            match = re.fullmatch(r"f(\d+)", f)
            name = "f<sub>" + match[1] + "</sub>" if match else html.escape(f)
            page += "<th class='formula' colspan='3'>" + name + "</th>"
        page += (
            "</tr><tr>"
            + "<th>M/E</th><th>Time</th><th>R</th>" * len(formulas)
            + "</tr></thead><tbody>"
        )
        widths = [0.5, 1.0, 1.9] + [1.1, 1.1, 0.45] * len(formulas)
        edges = [0]
        for w in widths:
            edges.append(edges[-1] + w)
        centers = [(a + b) / 2 for a, b in zip(edges, edges[1:])]
        fig, ax = plt.subplots(figsize=(11, 1.7 + len(table3) * 0.24))
        fig.subplots_adjust(left=0.03, right=0.97, bottom=0.02, top=0.93)
        fig.text(
            0.03,
            0.98,
            "Table 3. Detailed model checking results.\nM/E: number of tableau modes/edges; Time: seconds; R: ⊤ unreachable, ⊥ reachable,\n* unknown, − timeout, X solver error.",
            va="top",
            fontsize=10,
            fontfamily="serif",
        )
        ax.set_xlim(0, edges[-1])
        ax.set_ylim(-0.6, len(table3) + 2.5)
        ax.axis("off")

        def text(x, y, value, **kwargs):
            ax.text(
                x,
                y,
                value,
                ha="center",
                va="center",
                fontsize=10,
                fontfamily="serif",
                **kwargs,
            )

        top = len(table3) + 2
        ax.hlines(top + 0.5, 0, edges[-1], color="black", linewidth=1)
        for i, name in enumerate(("Dyn.", "Model", "Method (Solver)")):
            text(centers[i], top - 0.5, name)
        for i, f in enumerate(formulas):
            start = 3 + i * 3
            match = re.fullmatch(r"f(\d+)", f)
            name = "$f_{" + match[1] + "}$" if match else f
            text((edges[start] + edges[start + 3]) / 2, top, name)
            ax.hlines(
                top - 0.5,
                edges[start] + 0.05,
                edges[start + 3] - 0.05,
                color="black",
                linewidth=0.6,
            )
            for j, name in enumerate(("M/E", "Time", "R")):
                text(centers[start + j], top - 1, name)
        ax.hlines(top - 1.5, 0, edges[-1], color="black", linewidth=0.8)
        offset = 0
        for dynamics in ("linear", "nonlinear"):
            selected = [r for r in table3 if r["dynamics"] == dynamics]
            if not selected:
                continue
            text(
                centers[0],
                len(table3) - offset - (len(selected) - 1) / 2,
                dynamics,
                rotation=90,
            )
            for model_index, model in enumerate(
                dict.fromkeys(r["model"] for r in selected)
            ):
                group = [r for r in selected if r["model"] == model]
                text(centers[1], len(table3) - offset - (len(group) - 1) / 2, model)
                for i, row in enumerate(group):
                    y = len(table3) - offset
                    text(centers[2], y, row["method"])
                    classes = "model-end" if i == len(group) - 1 else ""
                    if model_index == 0 and i == 0 and offset:
                        classes += " family-start"
                    page += "<tr class='" + classes + "'>"
                    if model_index == 0 and i == 0:
                        page += f"<td class='dynamics' rowspan='{len(selected)}'>{dynamics}</td>"
                    if i == 0:
                        page += f"<td rowspan='{len(group)}'>{html.escape(model)}</td>"
                    page += "<td>" + html.escape(row["method"]) + "</td>"
                    for j, f in enumerate(formulas):
                        values = [
                            row[f + "_ME"],
                            row[f + "_time"],
                            labels[row[f + "_result"]],
                        ]
                        for k, value in enumerate(values):
                            text(centers[3 + j * 3 + k], y, value)
                            page += "<td>" + html.escape(value) + "</td>"
                    page += "</tr>"
                    offset += 1
                ax.hlines(
                    len(table3) - offset + 0.5,
                    edges[1],
                    edges[-1],
                    color="black",
                    linewidth=0.6,
                )
            ax.hlines(
                len(table3) - offset + 0.5, 0, edges[-1], color="black", linewidth=1
            )
        print_progress("Saving files...")
        (args.output / "table3.html").write_text(page + "</tbody></table></html>")
        fig.savefig(
            args.output / "table3.png", dpi=180, bbox_inches="tight", facecolor="white"
        )
        plt.close(fig)

    if number_requested == 3:
        render_table3()
    for name, rows in selected_tables:
        with (args.output / (name + ".csv")).open("w", newline="") as stream:
            writer = csv.DictWriter(stream, fieldnames=list(rows[0]))
            writer.writeheader()
            writer.writerows(rows)

    print_generation_report(
        f"Table {number_requested}",
        [
            args.output / f"table{number_requested}.{suffix}"
            for suffix in ("png", "html", "csv")
        ],
    )


def main():
    mode = requested_report(["plot", "table2", "table3"])
    description = {
        "plot": "Generate Figure 17 from existing Exp1 results.",
        "table2": "Generate Table 2 from existing tableau and HA construction results.",
        "table3": "Generate Table 3 from existing Exp1 model checking results.",
    }.get(mode, __doc__)
    p = parser(description, report=bool(mode))
    p.add_argument(
        "--report",
        dest="action",
        choices=["plot", "table2", "table3"],
        help=argparse.SUPPRESS,
    )
    if mode:
        p.add_argument(
            "--input",
            type=Path,
            default=ROOT / "results",
            help="Exp1 result root (default: results/); reads results under this directory",
        )
    else:
        p.add_argument(
            "--stlmc-cores",
            type=int,
            default=5,
            help="Cores per STLmc job (default: 5)",
        )
        p.add_argument(
            "--stlmc-timeout",
            type=int,
            help="STLmc timeout in seconds; overrides --timeout (default: 3600)",
        )
        p.add_argument(
            "--method",
            choices=["ours", "stlmc", "all"],
            default="all",
            help="Exp1 model checking method (default: all)",
        )
        p.add_argument(
            "--tools",
            nargs="+",
            choices=["spaceex", "sat-reach", "flowstar", "dreach"],
            help="Select reachability solvers (default: both backends for each model family)",
        )
    args = p.parse_args()
    if args.worker:
        job = json.loads(args.worker.read_text())
        folder = Path(job["folder"])
        if job["experiment"] == "ours":
            row = run_ours(
                job["case"], job["tool"], folder.parent.parent, job["timeout"]
            )
        else:
            row = run_stlmc(job["case"], folder.parent, job["timeout"], job["cores"])
        print(json.dumps(row), flush=True)
        return
    validate(p, args)
    if args.action:
        args.ours = report_input(args.input.resolve(), "exp1-ours")
        if args.action != "table2":
            args.stlmc = report_input(args.input.resolve(), "exp1-stlmc")
        if args.output == ROOT / "results":
            args.output /= "reports"
        if args.action in ("table2", "table3"):
            export_tables(args)
        else:
            report(args)
        return
    print_progress("Preparing Exp1 cases...")
    cases = select_cases(benchmark_cases(), args)
    jobs = []
    for case in cases:
        if args.method in ("ours", "all"):
            tools = (
                ["spaceex", "sat-reach"]
                if case["dynamics"] == "linear"
                else ["flowstar", "dreach"]
            )
            for tool in tools:
                if args.tools and tool not in args.tools:
                    continue
                jobs.append(
                    dict(
                        experiment="ours",
                        case=case,
                        tool=tool,
                        folder=str(args.output / "exp1-ours" / case["id"] / tool),
                        timeout=args.timeout or 3600,
                        cores=1,
                    )
                )
        if args.method in ("stlmc", "all"):
            jobs.append(
                dict(
                    experiment="stlmc",
                    case=case,
                    tool=None,
                    folder=str(args.output / "exp1-stlmc" / case["id"]),
                    timeout=args.stlmc_timeout or args.timeout or 3600,
                    cores=args.stlmc_cores,
                )
            )
    finished = run_jobs(args, jobs, Path(__file__).resolve())
    if finished is not None:
        mark_done(args.output, finished)


if __name__ == "__main__":
    main()
