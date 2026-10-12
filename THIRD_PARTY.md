# Third-party software

The solver bundle (`tools-bundle.tar.gz`, installed into `.tools/`) and the VM contain existing tools that are not part of this artifact's contribution. They keep their own licenses; the license texts are in `.tools/licenses/`, and the Java runtime's notices are in `.tools/java/legal/`. Source code is available from the listed locations.

| Component | Version | Used for | License | Source |
| --- | --- | --- | --- | --- |
| dReal / dReach | 3.16.06.02 (commit `d6645637507b`) | Nonlinear backend of our approach; SMT solver of STLmc | GPL-3.0 | https://github.com/dreal/dreal3 |
| Flow* | as built for the paper's experiments | Nonlinear backend of our approach | GPL-3.0 | https://github.com/chenxin415/flowstar |
| SpaceEx (core executable) | 0.9.8f | Linear backend of our approach | GPL-3.0 | http://spaceex.imag.fr |
| SAT-Reach | as built for the paper's experiments | Linear backend of our approach | No license stated in the public repository | https://gitlab.com/Atanukundu/SAT-Reach |
| Model-Translator.jar (Hyst build shipped with SAT-Reach) | – | Model translation for SAT-Reach | LGPL-3.0 | https://gitlab.com/Atanukundu/SAT-Reach |
| Hyst | commit `a4c226e` with the patches in `scripts/hyst/` | Model translation for dReach | LGPL-3.0 | https://github.com/verivital/hyst |
| Yices (`libyices`) | 2.6.4 | SMT solver used by STLmc | GPL-3.0 | https://github.com/SRI-CSL/yices2 |
| libpoly | 0.1.11 | Library required by Yices | LGPL-3.0 | https://github.com/SRI-CSL/libpoly |
| SUNDIALS CVODE (`libsundials_cvode`) | 5.6.1 | Library required by SAT-Reach | BSD-3-Clause | https://github.com/LLNL/sundials |
| Java runtime | 17.0.15 (Ubuntu build) | Runs Hyst and Model-Translator | GPL-2.0 with Classpath Exception | `.tools/java/legal/` |

Modifications made for this artifact:

- SAT-Reach: an input-parser fix and a library search path set to the bundle's `lib/` directory (`.tools/sat-reach/provenance.json`).
- Flow*, SAT-Reach and SUNDIALS: build paths removed from debugging information and library search paths. The program code is unchanged.

Python packages are installed from PyPI by `./reproduce setup` and are not redistributed here; the versions are pinned in `requirements.txt` and `scripts/setup.sh`. The STLmc baseline (`stlmc==1.0.0.dev3`) is distributed under GPL-3.0.
