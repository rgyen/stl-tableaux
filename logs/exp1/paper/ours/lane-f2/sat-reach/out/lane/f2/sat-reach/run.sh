#!/usr/bin/env bash
set -o pipefail
exec > ./log/lane/f2/sat-reach/out-log.txt 2>&1
./../../3rd_party/sat-reach/sat-reach -m log/lane/f2/sat-reach/model/model.xml -c log/lane/f2/sat-reach/model/model.cfg -C ../../3rd_party/sat-reach/Model-Translator.jar --time-horizon 80 --time-step 0.5 -v vx,vx --tmp-path log/lane/f2/sat-reach -e bmc --depth 5