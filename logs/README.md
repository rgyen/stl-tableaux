# Experiment logs

This directory contains the results behind the paper and the re-runs made for this artifact. New runs of `./reproduce` write to `results/` instead.

```text
logs/
├── exp1/
│   ├── paper/                    Exp1 results reported in the paper (paper Figure 17, Tables 2 and 3)
│   │   ├── ours/<case>/<solver>/   Our approach
│   │   └── stlmc/<case>/           STLmc
│   └── rerun/                    Re-runs with this artifact (one-hour timeout)
│       ├── ours/<case>/<solver>/   Our approach, one run
│       ├── ours-run.json           Host, command and job counts of that run
│       └── stlmc-trials/           STLmc, five runs:
│           ├── trial-<i>/<case>/     Results of run i
│           ├── trial-<i>-run.json    Host, command and job counts of run i
│           └── summary.csv           All five runs next to the paper's result
├── exp2/                         Exp2: f1/ ... f170/ and selection.json (paper Figure 18)
└── environment/                  Hardware, software versions and commands
```

Regenerate the paper's figures and tables:

```sh
./reproduce gen fig17 --input logs/exp1/paper
./reproduce gen table2 --input logs/exp1/paper
./reproduce gen table3 --input logs/exp1/paper
./reproduce gen fig18 --input logs/exp2
```

The generated tables have the same values as paper Tables 2 and 3, and the figure has the same points as paper Figure 17.

Every case directory, in `paper/` and `rerun/`, has the layout written by `./reproduce run exp1`:

| File | Contents |
| --- | --- |
| `result.json` | Outcome, solver time and, for our approach, the size of the composed automaton |
| `input.json` | Model, property and dynamics of the case |
| `commands.txt` | Generation and solver commands |
| `generation.log` | Tableau construction, reduction and composition output (our approach) |
| `solver.log` | Output of the reachability backend or STLmc |
| `out/<model>/<property>/<solver>/` | Generated backend input and launch script (our approach) |
| `default.cfg` | Default options used for the case (re-runs of our approach only) |

## Exp1 results of the paper

`exp1/paper/` holds the logs of the experiments reported in the paper, arranged in the layout above. The paths in their `commands.txt` refer to the directory layout of the original experiment scripts. Intermediate dReal query files are not included because of their size.

SAT-Reach aborts on some linear models because the Hyst converter fails on the generated automaton. `./reproduce gen` detects this from `solver.log` (a Hyst exception or an aborted SAT-Reach process) and reports an error, shown as `X` in Table 3 as in the paper.

## Re-runs

`exp1/rerun/ours/` is a complete re-run of our approach. It reproduces the paper's results: the sizes of all composed automata and tableaux (paper Table 2) are identical, and so is every outcome. Times differ by machine load.

STLmc is not deterministic in time: its scenario minimization and parallel path enumeration explore paths in a different order in each run, so a counterexample or the end of the search can be reached early or late. `exp1/rerun/stlmc-trials/` therefore contains five runs of all 48 STLmc cases. `summary.csv` lists, for each case, the paper's result and the time and result of each run. In 43 of the 48 cases every run has the paper's outcome. The other cases are:

| Case | Paper | Five re-runs (seconds) |
| --- | --- | --- |
| `car02-f1` | T/O | 2040, 2288, 2239, 2084, 2218 |
| `rail02-f1` | T/O | 1216, 2176, 3108, 880, 2316 |
| `lovo-f1` | T/O | 1120, T/O, 110, 127, 1319 |
| `lovo-f2` | 1297 (⊤) | 935, 171, 97, T/O, 849 |
| `rail02-f2` | 3199 (⊥) | 1800, 1506, 1103, T/O, T/O |

Whenever both the paper's run and a re-run finish, they report the same outcome; only whether STLmc finishes within the hour varies. A re-run by a reviewer can likewise differ from paper Table 3 in these cases.

To draw a figure or table for one STLmc re-run, copy that trial next to the re-run of our approach:

```sh
mkdir -p results/trial-1 && cp -r logs/exp1/rerun/ours results/trial-1/ours && cp -r logs/exp1/rerun/stlmc-trials/trial-1 results/trial-1/stlmc
./reproduce gen fig17 --input results/trial-1 --output results/trial-1/reports
```
