# Execution environment

## Re-runs (`logs/exp1/rerun/`, `logs/exp2/`)

| Item | Value |
| --- | --- |
| Machines | Four identical nodes: Intel Xeon Gold 6242 @ 2.80 GHz, 32 logical CPUs, 376 GB memory, Ubuntu 20.04.6 LTS |
| Python | 3.9.2 |
| Packages | `requirements.freeze.txt` (our implementation), `stlmc.freeze.txt` (STLmc) |
| Timeout | 3600 seconds per job |
| Our approach | One run on one node, 32 concurrent jobs (`logs/exp1/rerun/ours-run.json`) |
| STLmc | Five runs spread over the four nodes, 5 cores per job, 6 concurrent jobs per node (`logs/exp1/rerun/stlmc-trials/trial-<i>-run.json`) |

Each `*-run.json` records the host, the command and the job counts of a run; each case directory contains `commands.txt` with the exact commands. The runs used environment directories named `.venv-stlauto-paper` and `.venv-stlmc-paper` and the option name `--cores`, which this artifact now calls `.venv-stl-tableaux`, `.venv-stlmc` and `--stlmc-cores`.

## Paper results (`logs/exp1/paper/`)

As stated in the paper: Intel Xeon 2.8 GHz machine with 256 GB of memory, one-hour timeout, STLmc with dReal, the 2-step algorithm and 5 cores.
