#!/usr/bin/env bash
set -o pipefail
exec > ./out/bat/f3/sat-reach/out-log.txt 2>&1
./../../../../../.tools/sat-reach/sat-reach -m out/bat/f3/sat-reach/model/model.xml -c out/bat/f3/sat-reach/model/model.cfg -C ../../../../../.tools/sat-reach/Model-Translator.jar --time-horizon 3 --time-step 0.5 -v d1,d1 --tmp-path out/bat/f3/sat-reach -e bmc --depth 5