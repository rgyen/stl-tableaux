#!/usr/bin/env bash
set -o pipefail
exec > ./out/oscl/f3/sat-reach/out-log.txt 2>&1
./../../../../../.tools/sat-reach/sat-reach -m out/oscl/f3/sat-reach/model/model.xml -c out/oscl/f3/sat-reach/model/model.cfg -C ../../../../../.tools/sat-reach/Model-Translator.jar --time-horizon 4 --time-step 0.5 -v x,x --tmp-path out/oscl/f3/sat-reach -e bmc --depth 5