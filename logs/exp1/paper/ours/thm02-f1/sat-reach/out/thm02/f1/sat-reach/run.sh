#!/usr/bin/env bash
set -o pipefail
exec > ./log/thm02/f1/sat-reach/out-log.txt 2>&1
./../../3rd_party/sat-reach/sat-reach -m log/thm02/f1/sat-reach/model/model.xml -c log/thm02/f1/sat-reach/model/model.cfg -C ../../3rd_party/sat-reach/Model-Translator.jar --time-horizon 7 --time-step 0.5 -v x0,x0 --tmp-path log/thm02/f1/sat-reach -e bmc --depth 5