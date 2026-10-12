#!/usr/bin/env bash
set -o pipefail
exec > ./out/rail02/f1/sat-reach/out-log.txt 2>&1
./../../../../../.tools/sat-reach/sat-reach -m out/rail02/f1/sat-reach/model/model.xml -c out/rail02/f1/sat-reach/model/model.cfg -C ../../../../../.tools/sat-reach/Model-Translator.jar --time-horizon 2 --time-step 0.5 -v vb,vb --tmp-path out/rail02/f1/sat-reach -e bmc --depth 5