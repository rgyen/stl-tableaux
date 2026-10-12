#!/usr/bin/env bash
set -euo pipefail
ROOT=$(cd -- "$(dirname -- "$0")/.." && pwd)
TOOLS="$ROOT/.tools"
TOOLS_ONLY=false
BUILD_HYST=false
TOOLS_SOURCE=""
TOOLS_BUNDLE=""
while [ $# -gt 0 ]; do
  case "$1" in
    --tools-only) TOOLS_ONLY=true; shift ;;
    --build-hyst) BUILD_HYST=true; shift ;;
    --tools-source|--tools-bundle)
      if [ $# -lt 2 ]; then printf '%s requires a path\n' "$1" >&2; exit 1; fi
      if [ "$1" = --tools-source ]; then TOOLS_SOURCE="$2"; else TOOLS_BUNDLE="$2"; fi
      shift 2 ;;
    --help|-h)
      printf '%s\n' 'Usage: ./reproduce setup [--tools-source DIR | --tools-bundle ARCHIVE] [--tools-only] [--build-hyst]'
      printf '%s\n' '  --tools-source DIR     Copy an existing solver bundle into .tools/.' '  --tools-bundle ARCHIVE Extract and install a solver bundle into .tools/.' '  --tools-only           Install/check tools without installing Python environments.' '  --build-hyst           Build Hyst from source (requires a JDK).'
      exit 0 ;;
    *) printf 'Unknown setup option: %s\n' "$1" >&2; exit 1 ;;
  esac
done
if [ -n "$TOOLS_SOURCE" ] && [ -n "$TOOLS_BUNDLE" ]; then
  printf '%s\n' 'Choose --tools-source or --tools-bundle.' >&2; exit 1
fi
TEMP_DIR=""
cleanup() { if [ -n "$TEMP_DIR" ]; then rm -rf -- "$TEMP_DIR"; fi; }
trap cleanup EXIT
if [ -n "$TOOLS_BUNDLE" ]; then
  TEMP_DIR=$(mktemp -d)
  tar -xf "$TOOLS_BUNDLE" -C "$TEMP_DIR"
  TOOLS_SOURCE="$TEMP_DIR"
fi
if [ -n "$TOOLS_SOURCE" ]; then
  if [ -d "$TOOLS_SOURCE/3rd_party" ]; then TOOLS_SOURCE="$TOOLS_SOURCE/3rd_party"; fi
  if [ -d "$TOOLS_SOURCE/.tools" ]; then TOOLS_SOURCE="$TOOLS_SOURCE/.tools"; fi
  if [ ! -d "$TOOLS_SOURCE/dreal" ]; then
    printf '%s\n' 'The bundle must contain a dreal directory.' >&2; exit 1
  fi
  mkdir -p "$TOOLS"
  if [ "$(cd "$TOOLS_SOURCE" && pwd -P)" != "$(cd "$TOOLS" && pwd -P)" ]; then
    cp -a "$TOOLS_SOURCE/." "$TOOLS/"
  fi
fi
if "$BUILD_HYST"; then
  command -v git >/dev/null
  command -v java >/dev/null
  if ! command -v javac >/dev/null; then
    printf '%s\n' 'A JDK providing javac is required to build Hyst.' >&2; exit 1
  fi
  if command -v ant >/dev/null; then
    ANT_COMMAND=(ant)
  else
    command -v curl >/dev/null
    ANT_DIR="$TOOLS/build/ant"
    mkdir -p "$ANT_DIR"
    for artifact in ant ant-launcher; do
      case "$artifact" in
        ant) expected=763acda4a69588c9ea8817a952851ff0c2fc4bffa1d081c2565dc407f29d5794 ;;
        ant-launcher) expected=5c8551990307a032336d98ddaed549a39a689f07d4d4c6b950601bf22b3d6a1b ;;
      esac
      jar="$ANT_DIR/$artifact-1.10.15.jar"
      if [ ! -f "$jar" ]; then
        curl -fL "https://repo.maven.apache.org/maven2/org/apache/ant/$artifact/1.10.15/$artifact-1.10.15.jar" -o "$jar"
      fi
      printf '%s  %s\n' "$expected" "$jar" | sha256sum --check --status
    done
    ANT_COMMAND=(java -cp "$ANT_DIR/ant-1.10.15.jar:$ANT_DIR/ant-launcher-1.10.15.jar" org.apache.tools.ant.Main)
  fi
  BUILD_DIR=$(mktemp -d "$ROOT/.tools-hyst-build.XXXXXX")
  if [ -n "$TEMP_DIR" ]; then rm -rf -- "$TEMP_DIR"; fi
  TEMP_DIR="$BUILD_DIR"
  git clone --no-checkout https://github.com/verivital/hyst.git "$BUILD_DIR/hyst"
  git -C "$BUILD_DIR/hyst" checkout --detach a4c226e
  cp "$ROOT/scripts/hyst/Hyst.java" "$BUILD_DIR/hyst/src/java/com/verivital/hyst/main/"
  cp "$ROOT/scripts/hyst/STLmcPrinter.java" "$ROOT/scripts/hyst/DReachPrinter.java" "$BUILD_DIR/hyst/src/java/com/verivital/hyst/printers/"
  (cd "$BUILD_DIR/hyst/src" && "${ANT_COMMAND[@]}" build)
  mkdir -p "$TOOLS/hyst"
  cp "$BUILD_DIR/hyst/src/Hyst.jar" "$TOOLS/hyst/Hyst.jar"
fi
for executable in dreal/dReal dreal/dReach flowstar/flowstar spaceex/spaceex_exe/spaceex sat-reach/sat-reach; do
  if [ ! -x "$TOOLS/$executable" ]; then
    printf 'Missing executable: %s. Supply --tools-source or --tools-bundle.\n' "$TOOLS/$executable" >&2; exit 1
  fi
done
for converter in hyst/Hyst.jar sat-reach/Model-Translator.jar; do
  if [ ! -f "$TOOLS/$converter" ]; then printf 'Missing converter: %s\n' "$converter" >&2; exit 1; fi
done
if [ ! -d "$TOOLS/lib" ]; then printf '%s\n' 'Missing .tools/lib directory.' >&2; exit 1; fi
if [ ! -x "$TOOLS/java/bin/java" ] && ! command -v java >/dev/null; then
  printf '%s\n' 'Java is required for Hyst and SAT-Reach converters.' >&2; exit 1
fi
# Older bundles call `python` in dReach, which minimal Ubuntu images lack.
if grep -q 'python -c' "$TOOLS/dreal/dReach"; then
  sed -i 's|^SCRIPT_PATHNAME=.*|SCRIPT_PATHNAME=$(readlink -f "$0")|' "$TOOLS/dreal/dReach"
fi
# Report shared libraries that neither the bundle nor the host provides.
MISSING=$(for binary in dreal/bmc_main.native flowstar/flowstar sat-reach/sat-reach lib/libyices.so spaceex/spaceex_exe/bin/sspaceex; do
  LD_LIBRARY_PATH="$TOOLS/lib:$TOOLS/spaceex/spaceex_exe/lib" ldd "$TOOLS/$binary" 2>/dev/null | awk '/not found/ {print $1}'
done | sort -u)
if [ -n "$MISSING" ]; then
  printf 'Missing shared libraries: %s\n' $MISSING >&2
  printf '%s\n' 'On Ubuntu 20.04: sudo apt-get install libgmpxx4ldbl. libpoly.so.0 must be in the bundle lib/ directory.' >&2
  exit 1
fi
# Keep the native solvers identical to the validated reproduction binaries.
for spec in \
  'e045a64dbcd2bc7518a310f6c97a0680b813d754b165e3a40021946dea01b728 dreal/dReal' \
  'd09fb1c123887306c8609cd01ec30c77c087865d9d84d0b3efeba1887628b296 lib/libyices.so'; do
  expected=${spec%% *}
  binary=${spec#* }
  if ! printf '%s  %s\n' "$expected" "$TOOLS/$binary" | sha256sum --check --status; then
    printf 'Solver binary differs from the reproduction version: %s\n' "$binary" >&2; exit 1
  fi
done
printf 'External tools ready: %s\n' "$TOOLS"
if [ -d "$ROOT/.venv-stlmc/bin" ]; then
  ln -sfn "$TOOLS/dreal/dReal" "$ROOT/.venv-stlmc/bin/dreal"
fi
if "$TOOLS_ONLY"; then exit 0; fi
# Both environments use Python 3.9 (matplotlib 3.9.4 does not support 3.8).
PYTHON39=${PYTHON39:-python3.9}
if ! "$PYTHON39" --version >/dev/null 2>&1; then
  if command -v pyenv >/dev/null 2>&1 && PREFIX=$(pyenv prefix 3.9.2 2>/dev/null); then
    PYTHON39="$PREFIX/bin/python"
  else
    printf '%s\n' 'Python 3.9 is required (Ubuntu 20.04: sudo apt-get install python3.9 python3.9-venv). Set PYTHON39 to its executable.' >&2
    exit 1
  fi
fi
PYTHON=${PYTHON:-$PYTHON39}
"$PYTHON" -m venv --clear "$ROOT/.venv-stl-tableaux"
"$ROOT/.venv-stl-tableaux/bin/python" -m pip install --upgrade pip
"$ROOT/.venv-stl-tableaux/bin/python" -m pip install -r "$ROOT/requirements.txt" "matplotlib==3.9.4"
PROJECT="$ROOT"
"$ROOT/.venv-stl-tableaux/bin/python" -m pip install -e "$PROJECT"
mkdir -p "$ROOT/results/environment"
"$ROOT/.venv-stl-tableaux/bin/python" -m pip freeze --exclude-editable > "$ROOT/results/environment/requirements.freeze.txt"

# Install STLmc in its separate Python 3.9 environment.
"$PYTHON39" -m venv --clear "$ROOT/.venv-stlmc"
"$ROOT/.venv-stlmc/bin/python" -m pip install --upgrade 'pip<26'
"$ROOT/.venv-stlmc/bin/python" -m pip install "stlmc==1.0.0.dev3" "z3-solver==4.13.2.0" "yices==1.1.4"
mkdir -p "$ROOT/results/environment"
ln -sfn "$ROOT/.tools/dreal/dReal" "$ROOT/.venv-stlmc/bin/dreal"
"$ROOT/.venv-stlmc/bin/python" -m pip freeze > "$ROOT/results/environment/stlmc.freeze.txt"

LD_LIBRARY_PATH="$TOOLS/lib${LD_LIBRARY_PATH:+:$LD_LIBRARY_PATH}" "$ROOT/.venv-stlmc/bin/python" - <<'PYTHON_CHECK'
from importlib.metadata import version
from yices import Yices
assert version("stlmc") == "1.0.0.dev3"
assert version("z3-solver") == "4.13.2.0"
assert version("yices") == "1.1.4"
assert Yices.version == "2.6.4", Yices.version
print("STLmc solver versions verified: Z3 4.13.2.0, Yices Python 1.1.4 / native 2.6.4")
PYTHON_CHECK
