#!/usr/bin/env bash
set -o pipefail
exec > ./out/spac01/f2/sat-reach/out-log.txt 2>&1
./../../../../../.tools/sat-reach/sat-reach -m out/spac01/f2/sat-reach/model/model.xml -c out/spac01/f2/sat-reach/model/model.cfg -C ../../../../../.tools/sat-reach/Model-Translator.jar --time-horizon 75 --time-step 0.5 -v x,x --tmp-path out/spac01/f2/sat-reach -e bmc --depth 5