#!/usr/bin/env bash
set -o pipefail
exec > ./log/oscl/f2/sat-reach/out-log.txt 2>&1
./../../3rd_party/sat-reach/sat-reach -m log/oscl/f2/sat-reach/model/model.xml -c log/oscl/f2/sat-reach/model/model.cfg -C ../../3rd_party/sat-reach/Model-Translator.jar --time-horizon 2 --time-step 0.5 -v x,x --tmp-path log/oscl/f2/sat-reach -e bmc --depth 5