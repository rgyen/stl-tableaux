#!/usr/bin/env bash
set -o pipefail
exec > ./log/bat/f2/sat-reach/out-log.txt 2>&1
./../../3rd_party/sat-reach/sat-reach -m log/bat/f2/sat-reach/model/model.xml -c log/bat/f2/sat-reach/model/model.cfg -C ../../3rd_party/sat-reach/Model-Translator.jar --time-horizon 3 --time-step 0.5 -v d1,d1 --tmp-path log/bat/f2/sat-reach -e bmc --depth 5