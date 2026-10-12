# Artifact for "Unfolding Continuous Time: Interval-Based Tableaux for Signal Temporal Logic over Finite Signals"

This artifact contains the prototype that compiles robust STL properties into tableau-based hybrid automata, the benchmark inputs, and the scripts that reproduce the evaluation in Section 6 and Appendix B.1 of the paper. References of the form "Paper Section" point to the paper, and "README Section" to this guide.

- **Exp1** runs automata-based model checking with four reachability backends and the STLmc baseline (Figure 17, Tables 2 and 3).
- **Exp2** constructs and reduces tableaux for 170 STL formulas (Figure 18).

> **Hardware requirement: an x86-64 (Intel or AMD) host.** The reachability tools (SpaceEx, Flow*, dReach/dReal, SAT-Reach) are distributed only as x86-64 Linux binaries, and the VM image is an x86-64 guest. It does not run on ARM hosts such as Apple Silicon Macs: VirtualBox on Apple Silicon supports only ARM guests. Full x86-64 emulation (for example with UTM/QEMU) is not supported; it is too slow for the experiments. Intel Macs, and Linux or Windows PCs with an Intel or AMD CPU, can run the VM.

All actions go through the root `./reproduce` script. The commands used in this guide are:

| Command | What it does | Time |
| --- | --- | --- |
| `./reproduce setup` | Install the Python environments and the solver bundle (already done in the VM) | minutes |
| `./reproduce smoke` | Sanity test: one Exp1 case and one Exp2 formula | about 1 minute |
| `./reproduce quick` | Run a representative subset of both experiments and generate all figures and tables | about 30 minutes |
| `./reproduce run exp1` / `run exp2` / `run all` | Run Exp1, Exp2 or both (all cases by default; select cases with `--ids`) | hours (README Section 3) |
| `./reproduce gen fig17` / `fig18` / `table2` / `table3` | Generate a figure or table from existing results; runs no experiment | seconds |

`run` only executes experiments and writes measurements; `gen` only reads measurements and draws figures or tables. Every command accepts `--help`. All options are described in [Command-line options](#command-line-options), and output files in [Output files](#output-files).

## Artifact contents

```text
stl-tableaux/
├── reproduce                       Entry point: setup, smoke, quick, run and gen commands
├── README.md                       This guide
├── LICENSE                         License of this artifact (GPL-3.0)
├── THIRD_PARTY.md                  Versions, licenses and sources of the bundled tools
├── requirements.txt                Python dependencies of our implementation
├── pyproject.toml                  Python package definition of our implementation
├── src/stl-tableaux/               Our implementation (Python package stl2tableaux)
│   ├── gen                         Command line: build and reduce the tableau of a formula
│   ├── run                         Command line: build the property automaton, compose it
│   │                               with a model, and write the input of a backend
│   ├── encoding/automata/goal/     Tableau construction and reduction, and translation
│   │   │                           of the tableau into a property hybrid automaton
│   │   └── rule.maude              Tableau expansion and reduction rules
│   ├── encoding/automata/model/    Hybrid automaton of the system model
│   ├── encoding/robust/            Negation and robustness weakening of the formula
│   ├── hybrid_automaton/           Hybrid automata and their composition
│   ├── converter/                  Writers for SpaceEx, SAT-Reach, dReach, Flow* inputs
│   ├── parser/, syntax/            Parsers and grammars for models, formulas, options
│   ├── constraints/, smt/, graph/,
│   │   tree/, objects/, util/      Supporting data structures
│   └── default.cfg                 Default options (backend paths and parameters)
├── benchmarks/
│   ├── exp1/
│   │   ├── linear/<model>/         8 linear models
│   │   └── nonlinear/<model>/      8 nonlinear models
│   │       Each model directory contains:
│   │         <model>.model         System hybrid automaton and properties f1-f3
│   │         <model>.cfg           Options for the model (time bound, bound)
│   │         <model>-f<i>.cfg      Options for property f<i> (robustness threshold)
│   └── exp2/
│       ├── pool.txt                The 170 formulas of Exp2
│       └── pool.cfg                Options for these formulas
├── examples/                       Example formula file for trying new inputs
├── scripts/
│   ├── exp1.py, exp2.py            Experiment runners and figure/table generation
│   ├── common.py                   Job scheduling, timeouts and result recording
│   ├── setup.sh                    Environment and solver installation
│   └── hyst/                       Patches for the Hyst model converter
├── logs/                           Paper results and re-runs (README Section 3.2)
├── results/                        Created by the commands: new runs and reports
├── .tools/                         Created by setup: reachability tools and libraries
├── .venv-stl-tableaux/             Created by setup: Python environment of our tool
└── .venv-stlmc/                    Created by setup: Python environment of STLmc
```

The STLmc baseline is not part of this directory; setup installs the released package `stlmc==1.0.0.dev3` into `.venv-stlmc`. SpaceEx, SAT-Reach, dReach/dReal, Flow* and Hyst are existing tools distributed in the solver bundle; [THIRD_PARTY.md](THIRD_PARTY.md) lists their versions, licenses and sources. Our code is Copyright (C) 2026 Geunyeol Yu and licensed under GPL-3.0 (`LICENSE`). The new contribution of this artifact is the implementation in `src/stl-tableaux/` and the experiment scripts.

## 1. Claims supported by the artifact

| Paper claim | Location | Experiment | Generated output |
| --- | --- | --- | --- |
| The automata-based approach is faster than STLmc on most linear instances; on nonlinear instances STLmc times out on most instances while the best backend of our approach completes | Paper Section 6, Figure 17 | Exp1 | `exp1-fig17.png` |
| Sizes of the tableaux and composed hybrid automata for the 48 model/property pairs | Paper Appendix B.1, Table 2 | Exp1 | `table2.html` |
| Per-instance solver times and outcomes for all tools | Paper Appendix B.1, Table 3 | Exp1 | `table3.html` |
| Tableau construction succeeds for all 170 formulas, and tableau size grows mildly with formula complexity | Paper Section 6, Figure 18 | Exp2 | `exp2-fig18.png` |

Each claim is checked in two steps: run the experiment, then generate the figure or table from its results. README Section 3 gives three ways to do this, from a 30-minute subset (`./reproduce quick`, which performs both steps) to the full one-hour-timeout runs. The figures and tables can also be regenerated directly from the logs of the paper's runs (README Section 3.2).

Absolute times depend on the machine. The paper used an Intel Xeon 2.8 GHz machine with 256 GB of memory and a one-hour timeout. The claims concern relative performance (which points lie below the diagonal in Figure 17) and the outcomes, which do not depend on the machine except where an instance is close to the timeout.

The artifact does not cover the theoretical results (Paper Sections 3 to 5); these are proved in the paper.

## 2. Getting started (about 30 minutes)

The artifact consists of three files: the VM image `popl27-artifact.ova`, the solver bundle `tools-bundle.tar.gz` (needed only for a native installation), and the source directory `stl-tableaux/` (also included in the VM).

### 2.1 Virtual machine (recommended)

The VirtualBox image `popl27-artifact.ova` contains Ubuntu 20.04 with every dependency installed and `./reproduce setup` already run.

| Item | Value |
| --- | --- |
| Host | x86-64 (Intel or AMD) with hardware virtualization (VT-x/AMD-V) enabled; not Apple Silicon |
| Format | OVA for VirtualBox 7.1 or later |
| Default resources | 4 CPUs, 8 GB memory, 15 GB disk (dynamically allocated) |
| Login | user `artifact`, password `artifact` (passwordless `sudo`) |
| Artifact directory | `~/stl-tableaux` |

1. Import the image with *File → Import Appliance*, or:
   ```sh
   VBoxManage import popl27-artifact.ova
   ```
2. Optional: forward SSH and an HTTP port to view the generated figures from the host:
   ```sh
   VBoxManage modifyvm popl27-artifact --natpf1 "ssh,tcp,,2222,,22" --natpf1 "http,tcp,,8000,,8000"
   ```
3. Start the VM and log in on the console, or with `ssh -p 2222 artifact@localhost`. The VM has no desktop environment: the VirtualBox window shows a text login console. View the generated figures and tables from the host browser as described below.
4. More CPUs shorten the experiments, because jobs run in parallel (see [Concurrency](#concurrency-and-progress-output)). Increase *Settings → System → Processor* when the host allows it.

To view generated figures and tables from the host browser, run inside the VM:

```sh
cd ~/stl-tableaux && python3 -m http.server 8000 -d results/reports
```

and open `http://localhost:8000`. For the output of `./reproduce quick`, serve `results/quick/reports` instead. Alternatively copy the files with `scp -P 2222 -r artifact@localhost:stl-tableaux/results/reports .`.

### 2.2 Sanity test

```sh
cd ~/stl-tableaux
./reproduce smoke
```

This runs Exp2 formula `f4`, and Exp1 case `lane-f1` with SpaceEx, SAT-Reach and STLmc, with a 60-second timeout. It takes about a minute. Expected output (order of the Exp1 completions may vary):

```text
Starting exp2: 1 jobs, up to 1 running concurrently.
Started: f4 / exp2
Finished: f4 / exp2 (complete); 1/1 jobs finished.
...
Starting exp1: 3 jobs, up to 3 running concurrently.
Finished: lane-f1 / stlmc (complete); 1/3 jobs finished.
Finished: lane-f1 / spaceex (complete); 2/3 jobs finished.
Finished: lane-f1 / sat-reach (complete); 3/3 jobs finished.
exp1 experiment jobs finished.
```

The outcomes are in `results/smoke-exp1/exp1-ours/lane-f1/{spaceex,sat-reach}/result.json` (`"outcome": "safe"`) and `results/smoke-exp1/exp1-stlmc/lane-f1/result.json` (`"outcome": "bounded-satisfied"`).

The nonlinear backends are not part of `smoke`. To check them (about 2 minutes):

```sh
./reproduce run exp1 --method ours --ids card-f1 --timeout 120 --output results/check
```

dReach reports `unsafe` after about 15 seconds; Flow* reaches the 120-second timeout, as it does with the paper's one-hour limit.

### 2.3 Native installation (alternative to the VM)

An x86-64 Linux machine is required (ARM machines, including Apple Silicon, are not supported). The tested environment is Ubuntu 20.04 with Python 3.9. Supply the solver bundle `tools-bundle.tar.gz` distributed with the artifact.

```sh
sudo apt-get update && sudo apt-get install -y python3.9 python3.9-venv libgmpxx4ldbl
./reproduce setup --tools-bundle /path/to/tools-bundle.tar.gz
./reproduce smoke
```

Setup downloads Python packages from PyPI. It creates `.venv-stl-tableaux` (our implementation) and `.venv-stlmc` (STLmc), and records installed package versions in `results/environment/`. It installs the bundle into `.tools/` and stops with an explanation if an executable or shared library is missing. Set `PYTHON39` if Python 3.9 is not on `PATH` as `python3.9`.

Pinned versions:

| Component | Version |
| --- | --- |
| Our implementation | Python 3.9, Z3 `4.15.4.0`, Lark `1.3.1`, SymPy `1.14.0` |
| STLmc | `1.0.0.dev3`, Z3 `4.13.2.0`, Yices Python binding `1.1.4` with native Yices `2.6.4` |
| dReal / dReach | `3.16.06.02` (commit `d6645637507b`) |
| Hyst | commit `a4c226e` with the patches in `scripts/hyst/` |

Setup verifies the SHA-256 hashes of the dReal and native Yices binaries. SpaceEx, Flow* and SAT-Reach are taken from the bundle.

## 3. Evaluation instructions

### 3.1 Quick evaluation (about 30 minutes)

```sh
./reproduce quick
```

This runs 12 Exp1 cases with both methods and 21 Exp2 formulas with a 300-second timeout, and then generates all figures and tables into `results/quick/reports/`. The cases are chosen to cover linear and nonlinear models, instances where STLmc finishes and where it times out, and the whole complexity range of Figure 18:

- Exp1: `lane-f1 lane-f2 thm02-f2 oscl-f1 wat01-f1 rail02-f3 spac01-f1` (linear), `wat02-f1 car02-f2 robe03-f1 lovo-f1 vand-f1` (nonlinear)
- Exp2: `f5 f6 f7 f9 f10 f11 f13 f15 f19 f22 f34 f42 f43 f57 f58 f61 f83 f104 f114 f125 f168`

On a 4-CPU VM it takes about 30 minutes; the terminal shows each job as it starts and finishes.

Compare `results/quick/reports/exp1-fig17.png` with Figure 17: most linear points lie below the diagonal, STLmc reaches the timeout on `spac01-f1` and `vand-f1`, and dReach completes every nonlinear case within seconds. Flow* reaches the timeout on `robe03-f1` and `lovo-f1`, and SAT-Reach reports an error on `oscl-f1` and `spac01-f1`, as in the paper. STLmc's time on `lovo-f1` varies between runs (it timed out in the paper's run and took 110 to 1320 seconds in four of five re-runs), so it can also reach the 300-second timeout here. Timeouts are drawn at the plot boundary, as in the paper, regardless of the timeout used. The rows of `table2.html` and `table3.html` match the corresponding rows of Tables 2 and 3, except that times capped by the shorter timeout appear as timeouts.

### 3.2 Regenerate the figures and tables from the logs (minutes)

`logs/exp1/paper/` contains the Exp1 results reported in the paper, and `logs/exp2/` the Exp2 results (see [logs/README.md](logs/README.md)). Regenerating the figures and tables from them does not run any solver:

```sh
./reproduce gen fig17 --input logs/exp1/paper
./reproduce gen table2 --input logs/exp1/paper
./reproduce gen table3 --input logs/exp1/paper
./reproduce gen fig18 --input logs/exp2
```

Outputs are written to `results/reports/`. The values in Tables 2 and 3 match the paper exactly, and Figure 17 shows the same points as the paper; compare Figure 18 with the paper as well.

`logs/exp1/rerun/` contains re-runs made with this artifact: one run of our approach, which reproduces every size and outcome of the paper, and five runs of STLmc. STLmc's running time varies between runs, because its scenario minimization and parallel path enumeration explore paths in a different order each time. In 43 of the 48 cases all five STLmc runs agree with the paper. In `car02-f1`, `rail02-f1`, `lovo-f1`, `lovo-f2` and `rail02-f2`, whether STLmc finishes within the hour differs between the paper's run and the re-runs, or among the re-runs; whenever two runs both finish, they report the same outcome. `logs/exp1/rerun/stlmc-trials/summary.csv` lists every run, and [logs/README.md](logs/README.md) explains how to draw the figures for a single run.

### 3.3 Reduced re-execution (a few hours)

With a 300-second timeout instead of one hour, the experiments need about 2 CPU-hours for our approach, about 3 hours of STLmc jobs, and at most 5.5 CPU-hours for Exp2. With 4 CPUs this takes roughly 4 to 6 hours in total:

```sh
./reproduce run exp1 --method ours --timeout 300 --output results/reduced
./reproduce run exp1 --method stlmc --timeout 300 --stlmc-cores 4 --output results/reduced
./reproduce run exp2 --timeout 300 --output results/reduced
./reproduce gen fig17 --input results/reduced --output results/reduced-reports
./reproduce gen table3 --input results/reduced --output results/reduced-reports
./reproduce gen table2 --input results/reduced --output results/reduced-reports
./reproduce gen fig18 --input results/reduced --output results/reduced-reports
```

Expected differences from the paper:

- Instances that need more than 300 seconds appear as timeouts. In the one-hour runs in `logs/`, 17 (paper) and 18 (re-run) of the 96 runs of our approach took longer than 300 seconds, and 34 (paper) and 31 to 33 (five re-runs) of the 48 STLmc runs. The relative position of the remaining points in Figure 17 is unchanged.
- Exp2 formulas that need more than 300 seconds are missing from Figure 18. In our runs 142 of the 170 formulas finish within 60 seconds and the slowest takes about 43 minutes.
- STLmc with fewer cores (`--stlmc-cores 4`, the paper uses 5) is slower.
- STLmc's time varies between runs (README Section 3.2), so an instance can finish in one run and time out in another.

Individual cases can be run with `--ids`, for example `--ids lane-f1 card-f2` (Exp1) or `--ids f1 f2` (Exp2).

### 3.4 Full re-execution (machine with many cores)

The paper's configuration uses a one-hour timeout for every job:

```sh
./reproduce run exp1 --timeout 3600
./reproduce run exp2 --timeout 3600
```

or both in sequence with `./reproduce run all --timeout 3600`. In our runs, Exp1 needed about 16 CPU-hours for our approach and 27 hours of STLmc jobs with 5 cores each; Exp2 needed about 5.5 CPU-hours. On a 32-CPU machine, the whole run takes about one day. This is not expected to be feasible in the VM; see README Sections 3.1 and 3.2 instead.

Then generate the figures and tables with `./reproduce gen fig17`, `gen table2`, `gen table3` and `gen fig18`; they read `results/` by default.

## 4. Additional description

### Command-line options

Every command prints its options with `--help`, for example `./reproduce run exp1 --help` or `./reproduce gen --help`.

Options of `run exp1`, `run exp2` and `run all`:

| Option | Applies to | Meaning |
| --- | --- | --- |
| `--timeout SEC` | all | Time limit, default 3600 (one hour, as in the paper). Our approach: separate limits for generation and solver phases; STLmc: limit per job; Exp2: limit per formula |
| `--ids ID ...` | `run exp1`, `run exp2` | Run only the selected cases, e.g. `lane-f1 card-f2` (Exp1) or `f1 f2` (Exp2); default: all cases |
| `--output DIR` | all | Output root, default `results/` |
| `--workers N` | all | Fixed maximum number of concurrent jobs instead of the automatic value (see below) |
| `--method M` | Exp1 | `ours`, `stlmc` or `all` (default) |
| `--tools TOOL ...` | Exp1 | Backends for our approach: `spaceex`, `sat-reach` (linear), `dreach`, `flowstar` (nonlinear); default: all for the model's dynamics |
| `--stlmc-timeout SEC` | Exp1 | STLmc time limit, overriding `--timeout` for STLmc |
| `--stlmc-cores N` | Exp1 | STLmc `parallel-core` value, default 5; also used for the automatic concurrency |
| `--pool FILE` | Exp2 | Formula file inside the artifact directory, default `benchmarks/exp2/pool.txt` |

`run all` passes its options to both experiments, so it accepts only `--timeout`, `--output` and `--workers`; use separate commands for case selection and experiment-specific options.

Options of `gen fig17`, `gen fig18`, `gen table2` and `gen table3`:

| Option | Meaning |
| --- | --- |
| `--input DIR` | Result root to read: default `results/` (`results/exp2-automata/` for `fig18`) |
| `--output DIR` | Directory for the generated files, default `results/reports/` |

`setup` options are described in [External tools](#external-tools). `smoke` and `quick` take no options.

Examples:

```sh
./reproduce run exp1 --method ours --ids lane-f1 card-f2 --timeout 1200 --output results/exp1-sample
./reproduce run exp2 --ids f1 f2 --timeout 3600 --output results/exp2-sample
./reproduce gen table3 --input results/exp1-sample --output results/exp1-sample/reports
```

### Concurrency and progress output

By default, the runner counts the logical CPUs available through the process's CPU affinity. Our approach and Exp2 reserve one CPU per job. STLmc reserves `--stlmc-cores` CPUs per job, matching its `parallel-core` setting; the default is five.

On a 32-CPU node, this gives up to 32 concurrent ours/Exp2 jobs, or six concurrent STLmc jobs with five cores each. An Exp1 run using both methods shares the same CPU budget. Workers are separate Python processes.

The terminal displays case preparation, the calculated job concurrency, actual output directories, and each job's start and completion. During longer jobs it prints progress every 15 seconds. Detailed construction and solver output goes to the case logs.

### Exp1: model checking

Exp1 reads the models and labeled properties under `benchmarks/exp1/linear/` and `benchmarks/exp1/nonlinear/`, together with their model and property configuration files. There are 16 models with three properties each.

`--method` selects the model checking method:

| Method | Work performed |
| --- | --- |
| `all` (default) | 96 jobs for our approach and 48 STLmc jobs |
| `ours` | Generate each property automaton, compose it with the system, and run the model family's reachability backends |
| `stlmc` | Run the 48 properties with the separate STLmc environment |

Our approach uses SpaceEx and SAT-Reach for linear models, and dReach and Flow* for nonlinear models. The backend inputs are generated from the benchmark files on each run.

### Exp2: tableau construction

Exp2 reads `benchmarks/exp2/pool.txt` (`f1` through `f170`) and `benchmarks/exp2/pool.cfg`. It constructs the tableau of each formula and applies reduction. It records the raw and reduced numbers of states and transitions, plus construction and reduction times. No reachability solver is invoked in Exp2.

### Output files

Directories are created automatically. With the default output root:

```text
results/
├── run.json
├── exp1-ours/<case>/<solver>/
├── exp1-stlmc/<case>/
├── exp2-automata/
│   ├── selection.json
│   └── f1/ ... f170/
└── reports/
```

`--output results/my-run` changes the root of an experiment run: for example, its Exp1 results are written under `results/my-run/exp1-ours/` and `results/my-run/exp1-stlmc/`.

| File | Contents |
| --- | --- |
| `run.json` | Host, Python version, invocation, CPU allocation, progress and final status for the current/latest experiment invocation |
| `input.json` | The case's model/formula information and metrics |
| `result.json` | Measured sizes, timings, outcome, timeout or failure information |
| `commands.txt` | Actual generation/solver commands with their working directories |
| `generation.log` | Tableau construction, reduction and HA generation output |
| `solver.log` | Raw model checking solver output (Exp1) |
| `worker.log` | Worker output and Python errors |
| `default.cfg` | Default configuration used for the case |
| `out/` | Generated solver inputs for our approach |
| `selection.json` | Exp2 formula list and plotting metrics, stored at `exp2-automata/` |

Re-running into the same output root replaces the selected cases; use a new `--output` root to keep an earlier run.

### Generated figures and tables

`gen` writes into `results/reports/` unless `--output` is given.

| Target | Default input | Generated files |
| --- | --- | --- |
| `fig17` | `results/` | `exp1-fig17.png`, `.pdf`, and `exp1.csv` |
| `fig18` | `results/exp2-automata/` | `exp2-fig18.png`, `.pdf`, and `exp2.csv` |
| `table2` | `results/` | `table2.png`, `.html`, and `.csv` |
| `table3` | `results/` | `table3.png`, `.html`, and `.csv` |

Table 2 uses composed HA modes/jumps (M/J) and reduced tableau vertices/edges (V/E). Table 3 reports composed HA size, solver time and outcome. CSV outcomes use explicit labels; HTML and PNG use the paper symbols `⊤`, `⊥`, `*`, `−` and `X`. Open the HTML files in a browser to inspect the tables.

### External tools

`setup.sh` installs the supplied solver bundle into `.tools/` and checks the required executables, converters and shared libraries. The bundle must contain `dreal`, `flowstar`, `spaceex`, `sat-reach`, `hyst` and `lib` directories (`lib/` holds `libyices.so`, `libpoly.so.0` and `libsundials_cvode.so.5`), directly or under `3rd_party/` or `.tools/`. Include `java/` for the bundled Java runtime, or install Java on the host.

```sh
# Install tools from an unpacked bundle, without reinstalling Python environments.
./reproduce setup --tools-source /path/to/bundle --tools-only

# Check an existing installation.
./reproduce setup --tools-only

# Rebuild the modified Hyst converter (requires Git, a JDK and network access).
./reproduce setup --build-hyst --tools-only
```

Hyst is cloned at commit `a4c226e`, patched with the Java sources in `scripts/hyst/`, and built into `.tools/hyst/Hyst.jar`. Other solvers are installed from the supplied binary bundle to preserve the reproduction versions. Their source builds are not automated. Hyst rebuilding is optional. If Ant is not installed, setup downloads Apache Ant 1.10.15 into `.tools/build/ant` and verifies its SHA-256 hashes.

### Trying new inputs

#### New STL formulas (tableau construction)

Write named formulas in a file inside the artifact directory, using the syntax of `benchmarks/exp2/pool.txt`, and put a configuration file with the same name next to it. `examples/my-formulas.txt` and `examples/my-formulas.cfg` are an example:

```text
[g1]: [][0, 4] (x < 3 -> <>[1, 2] x > 5);
[g2]: (x > 1) U[0, 5] (y < 2);
[g3]: <>[0, 3] ([][1, 2] (and (x > 0) (y < 4)));
```

Each line `[name]: formula;` defines one formula: `name` is the identifier used in `--ids` and in the result directory, and every formula ends with `;`. Text after `#` is a comment. Formulas are built from:

| Syntax | Meaning |
| --- | --- |
| `x > 5`, `x - y <= 2`, `x = 0` | Atomic proposition: comparison (`<`, `<=`, `>`, `>=`, `=`, `!=`) of arithmetic expressions over signal variables |
| `true`, `false` | Boolean constants |
| `~ p` or `not p` | Negation |
| `p and q`, `p or q`, or prefix `(and p q ...)`, `(or p q ...)` | Conjunction and disjunction |
| `p -> q` | Implication |
| `[][a, b] p` | Always (globally) `p` during `[a, b]` |
| `<>[a, b] p` | Eventually `p` within `[a, b]` |
| `p U[a, b] q` | `p` until `q`, with `q` occurring within `[a, b]` |
| `p R[a, b] q` | `p` releases `q` within `[a, b]` |

Time intervals may be closed or open on each side, for example `[1, 2]`, `(0, 3]`, and the upper bound may be `inf`, as in `[2, inf)`. Use parentheses to group subformulas. Variables need no declaration in a formula file.

The configuration sets the time bound of the signals (`time-bound`). The `bound` entry is used only in model checking (Exp1), where it limits the number of discrete jumps explored by the bounded backends; it does not affect the tableau. Run:

```sh
./reproduce run exp2 --pool examples/my-formulas.txt --output results/my-formulas
./reproduce gen fig18 --input results/my-formulas --output results/my-formulas/reports
```

Each `results/my-formulas/exp2-automata/<name>/result.json` contains the numbers of states and transitions before (`raw`) and after (`reduced`) reduction, and the construction and reduction times. For the example, `g1` gives 26 states and 80 transitions before reduction, and 13 and 33 after.

#### New properties for a benchmark model (model checking)

Add a named property to the `goal:` section at the end of a model file, and a property configuration next to it. For example, to add `f4` to the `lane` model, append on a new line of `benchmarks/exp1/linear/lane/lane.model`:

```text
[f4]: <>[10, 40] ([] [2, 5] sx < 25);
```

create `benchmarks/exp1/linear/lane/lane-f4.cfg` by copying `lane-f1.cfg` and changing `goal = "f1"` to `goal = "f4"`, and run:

```sh
./reproduce run exp1 --ids lane-f4 --timeout 300 --output results/new-property
```

This runs SpaceEx, SAT-Reach and STLmc on the new property (`safe` for both backends of our approach, `bounded-satisfied` for STLmc). If no behavior of the composed automaton can violate the property, the automaton is empty after composition; the result is then reported as `safe` without running the backend. New models can be added in the same way, as a directory `benchmarks/exp1/{linear,nonlinear}/<model>/` containing `<model>.model`, `<model>.cfg` and one `<model>-<property>.cfg` per property.
