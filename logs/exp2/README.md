# Exp2 results

Results of the tableau construction for the 170 formulas of `benchmarks/exp2/pool.txt`, with a one-hour timeout per formula. Each `f<i>/` contains `result.json` (states and transitions before and after reduction, construction and reduction times), `generation.log`, `input.json`, `commands.txt` and `default.cfg`. `selection.json` lists the formulas and their metrics for plotting (paper Figure 18).

```sh
./reproduce gen fig18 --input logs/exp2
```
