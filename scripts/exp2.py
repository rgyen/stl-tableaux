"""Run Exp2 tableau construction and reduction."""

import json
import argparse
from pathlib import Path
import re
import sys
import hashlib
import csv
import math
from common import (
    ROOT,
    prepare_plotting,
    print_plot_report,
    print_progress,
    SOURCE,
    write,
    config,
    launch,
    parser,
    requested_report,
    validate,
    select_cases,
    run_jobs,
    mark_done,
)

from stl2tableaux.parser.stlmc import STLmcParser
from stl2tableaux.encoding.robust.preprocess import prepare_formula, encode
from stl2tableaux.constraints.constraints import (
    Temporal,
    UnaryFormula,
    BinaryFormula,
    MultinaryFormula,
)


def metrics(formula):
    size = depth = 0
    resolution = 0
    operators = set()
    pending = [(formula, 0)]
    while pending:
        node, nesting = pending.pop()
        size += 1
        if isinstance(node, Temporal):
            nesting += 1
            depth = max(depth, nesting)
            operators.add(type(node).__name__)
            interval = node.local_time
            a, b = float(interval.left.value), float(interval.right.value)
            if math.isfinite(b):
                resolution = max(resolution, math.ceil(b / (b - a)))
        if isinstance(node, UnaryFormula):
            pending.append((node.child, nesting))
        elif isinstance(node, BinaryFormula):
            pending.extend([(node.left, nesting), (node.right, nesting)])
        elif isinstance(node, MultinaryFormula):
            pending.extend((child, nesting) for child in node.children)
    return dict(
        size=size,
        depth=depth,
        resolution=resolution,
        operators=sorted(operators),
        complexity=(size + depth) * (resolution + 1),
    )


def cases_from_pool(pool):
    pool = Path(pool).resolve()
    _, formulas = STLmcParser().parse_from_file(pool)
    cases = []
    for name, raw in formulas.labeled.items():
        prepared = prepare_formula(raw, 0.01, 10)
        cases.append(
            dict(
                id=name,
                formula_file=str(pool.relative_to(ROOT)),
                prepared=str(prepared),
                **metrics(prepared),
                prepared_sha256=hashlib.sha256(encode(prepared).encode()).hexdigest(),
            )
        )
    return cases


def build(case, folder, timeout):
    folder.mkdir(parents=True, exist_ok=True)
    write(folder / "input.json", case)
    pool = ROOT / case.get("formula_file", "benchmarks/exp2/pool.txt")
    command = [
        sys.executable,
        str(SOURCE / "gen"),
        str(pool),
        "-goal",
        case["id"],
        "-default-cfg",
        str(config(folder)),
        "-cfg",
        str(pool.with_suffix(".cfg")),
        "--tableau-only",
    ]
    row = dict(
        id=case["id"],
        implementation="automata",
    )
    row.update(launch(command, folder, folder / "generation.log", timeout))
    text = (folder / "generation.log").read_text(errors="replace")
    sizes = re.findall(r"tableau info: \(# vertex: (\d+), # edge: (\d+)\)", text)
    if row["status"] == "complete":
        if len(sizes) < 2 or re.search(r"^error:|^Traceback", text, re.M):
            row["status"] = "error"
        else:
            row["raw"] = list(map(int, sizes[0]))
            row["reduced"] = list(map(int, sizes[1]))
            times = re.findall(r"running time:\s*([0-9.]+)s", text)
            if len(times) >= 2:
                row.update(
                    generation_seconds=float(times[0]),
                    reduction_seconds=float(times[1]),
                )
    write(folder / "result.json", row)
    return row


def plot(root, output):
    print_progress("Generating plots: preparing plotting tools...")
    import numpy as np

    prepare_plotting()
    import matplotlib

    matplotlib.use("Agg")
    import matplotlib.pyplot as plt

    print_progress("Reading experiment results...")
    selection = json.loads((root / "selection.json").read_text())
    rows = []
    for case in selection["cases"]:
        path = root / case["id"] / "result.json"
        result = (
            json.loads(path.read_text()) if path.exists() else {"status": "pending"}
        )
        row = dict(
            id=case["id"],
            size=case["size"],
            depth=case["depth"],
            resolution=case["resolution"],
            complexity=case["complexity"],
            status=result["status"],
        )
        for name, key, index in [
            ("states_before", "raw", 0),
            ("transitions_before", "raw", 1),
            ("states_after", "reduced", 0),
            ("transitions_after", "reduced", 1),
        ]:
            row[name] = result.get(key, [None, None])[index]
        row["construction_seconds"] = (
            (result.get("generation_seconds", 0) + result.get("reduction_seconds", 0))
            if result.get("raw")
            else None
        )
        rows.append(row)
    analysis = output
    analysis.mkdir(parents=True, exist_ok=True)
    with (analysis / "exp2.csv").open("w") as file:
        writer = csv.DictWriter(file, fieldnames=list(rows[0]))
        writer.writeheader()
        writer.writerows(rows)
    complete = [
        r for r in rows if r["status"] == "complete" and r["states_before"] is not None
    ]
    plt.rcParams.update({"pdf.fonttype": 42, "font.size": 11})
    specifications = [
        (
            "exp2-fig18",
            "complexity",
            lambda r: r["states_before"] + r["transitions_before"],
            "# State",
        ),
    ]
    for stem, metric, value, ylabel in specifications:
        print_progress("Rendering figure...")
        fig, ax = plt.subplots(figsize=(5.5, 6.1))
        x = np.array([r[metric] for r in complete])
        y = np.array([value(r) for r in complete])
        ax.scatter(
            x,
            y,
            marker="^",
            s=14,
            facecolors="none",
            edgecolors="#80cbb5",
            linewidths=0.22,
            clip_on=False,
            zorder=3,
        )
        # Bezier curve through the mean at each x value.
        points = np.array([[v, y[x == v].mean()] for v in sorted(set(x))])
        curve = []
        for t in np.linspace(0, 1, 100):
            work = points.copy()
            while len(work) > 1:
                work = (1 - t) * work[:-1] + t * work[1:]
            if len(work):
                curve.append(work[0])
        if curve:
            curve = np.array(curve)
            ax.plot(curve[:, 0], curve[:, 1], color="#9b38df", linewidth=1.3)
        ax.set_yscale("log")
        if len(x):
            if x.min() < x.max():
                ax.set_xlim(float(x.min()), float(x.max()))
            ax.set_ylim(
                10 ** np.floor(np.log10(y[y > 0].min())),
                10 ** np.ceil(np.log10(max(y.max(), 1))),
            )
        ax.set_ylim(10, 10000)
        ax.set_yticks([10, 100, 1000, 10000], labels=["10", "100", "1k", "10k"])
        ax.set_box_aspect(1)
        ax.tick_params(which="both", direction="in", top=True, right=True)
        ax.set_xlabel("Complexity")
        ax.set_ylabel(ylabel)
        ax.grid(which="major", alpha=0.45, linewidth=0.6, linestyle=":")
        fig.tight_layout(rect=(0, 0.10, 1, 1))
        fig.text(
            0.5,
            0.025,
            "Fig. 18. Tableau size versus formula complexity.",
            ha="center",
            va="bottom",
            fontsize=10,
            fontfamily="serif",
        )
        print_progress("Saving files...")
        for suffix in ["png", "pdf"]:
            fig.savefig(
                analysis / (stem + "." + suffix),
                dpi=240,
                bbox_inches="tight",
                pad_inches=0.15,
            )
        plt.close(fig)
    print_plot_report(
        "Exp2",
        [
            analysis / (stem + "." + suffix)
            for stem, *_ in specifications
            for suffix in ("png", "pdf")
        ],
        analysis / "exp2.csv",
    )


def main():
    mode = requested_report(["plot"])
    p = parser(
        ("Generate Figure 18 from existing Exp2 results." if mode else __doc__),
        report=bool(mode),
        ids_example="f1 f2",
    )
    p.add_argument("--report", choices=["plot"], help=argparse.SUPPRESS)
    if mode:
        p.add_argument(
            "--input",
            type=Path,
            default=ROOT / "results/exp2-automata",
            help="Exp2 result directory or experiment output root (default: results/exp2-automata/)",
        )
    else:
        p.add_argument(
            "--pool",
            type=Path,
            default=ROOT / "benchmarks/exp2/pool.txt",
            help="Formula pool file (default: benchmarks/exp2/pool.txt)",
        )
    args = p.parse_args()
    if args.worker:
        job = json.loads(args.worker.read_text())
        print(
            json.dumps(build(job["case"], Path(job["folder"]), job["timeout"])),
            flush=True,
        )
        return
    validate(p, args)
    if args.report:
        output = (
            args.output / "reports" if args.output == ROOT / "results" else args.output
        )
        directory = args.input.resolve()
        for candidate in (directory, directory / "exp2-automata"):
            if (candidate / "selection.json").is_file():
                directory = candidate
                break
        plot(directory, output)
        return
    print_progress("Preparing Exp2 formulas...")
    cases = select_cases(cases_from_pool(args.pool), args)
    jobs = [
        dict(
            experiment="exp2",
            case=case,
            tool=None,
            folder=str(args.output / "exp2-automata" / case["id"]),
            timeout=args.timeout or 3600,
            cores=1,
        )
        for case in cases
    ]
    finished = run_jobs(args, jobs, Path(__file__).resolve())
    if finished is not None:
        directory = args.output / "exp2-automata"
        write(
            directory / "selection.json",
            dict(cases=cases),
        )
        mark_done(args.output, finished)


if __name__ == "__main__":
    main()
