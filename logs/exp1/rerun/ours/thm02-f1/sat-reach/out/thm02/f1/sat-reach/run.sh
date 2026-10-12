#!/usr/bin/env bash
set -o pipefail
exec > ./out/thm02/f1/sat-reach/out-log.txt 2>&1
./../../../../../.tools/sat-reach/sat-reach -m out/thm02/f1/sat-reach/model/model.xml -c out/thm02/f1/sat-reach/model/model.cfg -C ../../../../../.tools/sat-reach/Model-Translator.jar --time-horizon 7 --time-step 0.5 -v x0,x0 --tmp-path out/thm02/f1/sat-reach -e bmc --depth 5