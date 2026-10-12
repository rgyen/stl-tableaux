#!/usr/bin/env bash
set -o pipefail
exec > ./log/rail02/f1/sat-reach/out-log.txt 2>&1
./../../3rd_party/sat-reach/sat-reach -m log/rail02/f1/sat-reach/model/model.xml -c log/rail02/f1/sat-reach/model/model.cfg -C ../../3rd_party/sat-reach/Model-Translator.jar --time-horizon 2 --time-step 0.5 -v vb,vb --tmp-path log/rail02/f1/sat-reach -e bmc --depth 5