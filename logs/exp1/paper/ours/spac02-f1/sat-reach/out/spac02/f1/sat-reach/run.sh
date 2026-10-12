#!/usr/bin/env bash
set -o pipefail
exec > ./log/spac02/f1/sat-reach/out-log.txt 2>&1
./../../3rd_party/sat-reach/sat-reach -m log/spac02/f1/sat-reach/model/model.xml -c log/spac02/f1/sat-reach/model/model.cfg -C ../../3rd_party/sat-reach/Model-Translator.jar --time-horizon 1.5 --time-step 0.5 -v x,x --tmp-path log/spac02/f1/sat-reach -e bmc --depth 5