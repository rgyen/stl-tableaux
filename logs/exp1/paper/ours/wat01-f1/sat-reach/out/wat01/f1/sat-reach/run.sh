#!/usr/bin/env bash
set -o pipefail
exec > ./log/wat01/f1/sat-reach/out-log.txt 2>&1
./../../3rd_party/sat-reach/sat-reach -m log/wat01/f1/sat-reach/model/model.xml -c log/wat01/f1/sat-reach/model/model.cfg -C ../../3rd_party/sat-reach/Model-Translator.jar --time-horizon 10 --time-step 0.5 -v x1,x1 --tmp-path log/wat01/f1/sat-reach -e bmc --depth 5