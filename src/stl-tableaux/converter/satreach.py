import os
from functools import singledispatch

from .converter import Converter
from .spaceex import _make_model, _make_conf
from ..hybrid_automaton.hybrid_automaton import *
from ..hybrid_automaton.utils import *
from ..constraints.constraints import *
from ..constraints.operations import VarSubstitution
from ..objects.configuration import Configuration


class SatReachConverter(Converter):
    def __init__(self, config: Configuration):
        self._model_string = ""
        self._config_string = ""
        self._config: Configuration = config
        self._single_init = False
        self._single_fine = False

    def convert(self, ha: HybridAutomaton):
        self._reset()
        self._preprocessing_sat_reach(ha)

        # use spaceex converter
        self._model_string, id_map = _make_model(ha)
        self._config_string = _make_conf(ha, self._config, id_map)

    def write(self, file_name: str, dir: str):
        common_section = self._config.get_section("common")
        g_n = common_section.get_value("goal")

        root = "{}/{}/{}/sat-reach".format(dir, file_name, g_n)
        m_dir = "{}/model".format(root)

        o_n = "{}/model.xml".format(m_dir)
        c_n = "{}/model.cfg".format(m_dir)
        s_n = "{}/run.sh".format(root)

        if not os.path.exists(m_dir):
            os.makedirs(m_dir)

        f = open(o_n, "w")
        f.write(self._model_string)
        f.close()
        print(indented_str("model file  : {}".format(o_n), 2))

        f = open(c_n, "w")
        f.write(self._config_string)
        f.close()
        print(indented_str("conf  file  : {}".format(c_n), 2))

        self._create_script(s_n, o_n, c_n, root)
        print(indented_str("script file : {}".format(s_n), 2))

    def jp_bound_needed(self):
        return False
    
    def update_jp_bound(self):
        return

    def _create_script(self, script_name: str, model_file: str, conf_file: str, root: str):
        sr = self._config.get_section("sat-reach")
        exec = sr.get_value("executable-path")
        jar = sr.get_value("converter-path")
        ts = sr.get_value("time-step")
        vs = sr.get_value("output-vars")

        common_section = self._config.get_section("common")
        hz = common_section.get_value("time-horizon")
        b = int(common_section.get_value("bound"))

        if self._single_init:
            b += 1

        if self._single_fine:
            b += 1

        s = "#!/usr/bin/env bash\n"
        s += "set -o pipefail\n"
        s += "exec > ./{}/out-log.txt 2>&1\n".format(root)
        s += "./{} -m {} -c {} -C {} --time-horizon {} --time-step {} -v {} --tmp-path {} -e bmc --depth {}".format(exec, model_file, conf_file, jar, hz, ts, vs, root, b)
        
        # s = "./{} -j {} --time-horizon {} --time-step {} -v {} -m ./{} -c ./{} -e bmc --depth {} >& ./{}/out-log.txt".format(exec, jar, hz, ts, vs, model_file, conf_file, b, root)
        f = open(script_name, "w")
        f.write(s)
        f.close()

        os.chmod(script_name, 0o755)

    def _reset(self):
        self._model_string = ""
        self._config_string = ""
        self._single_init = False
        self._single_fine = False

    def _preprocessing_sat_reach(self, ha: HybridAutomaton):
        self._add_single_init_final(ha)
        self._add_t_var(ha)
        self._apply_non_strictize(ha)
        self._rename_y(ha)

    def _add_single_init_final(self, ha: HybridAutomaton):
        # checking is enough
        assert len(set(filter(lambda x : x.is_initial(), ha.get_modes()))) == 1

        # making single forbidden state if it has more than one forbidden state
        make_single_final(ha)

    @classmethod
    def _apply_non_strictize(cls, ha: HybridAutomaton):
        # SAT Reach requires all conditions to be non-strict.
        for m in ha.get_modes():
            n_inv = [_make_non_strict(inv) for inv in m.invariant]
            
            # update invariant
            m.invariant.clear()
            m.add_invariant(*n_inv)

        for jp in get_jumps(ha):
            n_g = [_make_non_strict(g) for g in jp.guard]
            
            # update guard
            jp.guard.clear()
            jp.add_guard(*n_g)

    @classmethod
    def _rename_y(cls, ha: HybridAutomaton):
        # SAT Reach raises error for using non-local variable named y.
        subst = VarSubstitution()
        subst.add(Real("y"), Real("renamed_y"))

        for m in ha.get_modes():
            n_inv = [subst.substitute(inv) for inv in m.invariant]
            
            # update invariant
            m.invariant.clear()
            m.add_invariant(*n_inv)

            # update flow
            dyn_d: Dict[Variable, Expr] = dict()
            for v in m.dynamics:
                dyn_d[subst.substitute(v)] = subst.substitute(m.dynamics[v])

            m.dynamics.clear()
            m.dynamics.update(dyn_d) 

            if m.is_initial():
                n_init = [_make_non_strict(subst.substitute(init)) for init in m.init]
                m.init.update(n_init)

        for jp in get_jumps(ha):
            n_g = [subst.substitute(g) for g in jp.guard]
            n_r = [(subst.substitute(v), subst.substitute(e)) for v, e in jp.reset]

            # update guard
            jp.guard.clear()
            jp.add_guard(*n_g)

            # update reset
            jp.reset.clear()
            jp.add_reset(*n_r)

    @classmethod
    def _add_t_var(cls, ha: HybridAutomaton):
        # SAT Reach requires a variable named t for CEGAR.
        t, one, zero = Real("t"), RealVal("1.0"), RealVal("0.0")
        
        # add dynamics
        for m in ha.get_modes():
            if m.is_initial():
                # add initial
                m.add_init(t == zero)
            m.add_dynamic((t, one))

        for jp in get_jumps(ha):
            jp.add_reset((t, t))


@singledispatch
def _make_non_strict(const: Formula):
    return const


@_make_non_strict.register(Eq)
def _(const: Eq):
    return And([Geq(const.left, const.right),
                Leq(const.left, const.right)])


@_make_non_strict.register(EqFormula)
def _(const: EqFormula):
    return And([Geq(const.left, const.right),
                Leq(const.left, const.right)])


@_make_non_strict.register(Gt)
def _(const: Gt):
    return Geq(const.left, const.right)


@_make_non_strict.register(Lt)
def _(const: Lt):
    return Leq(const.left, const.right)


@_make_non_strict.register(And)
def _(const: And):
    return And([_make_non_strict(c) for c in const.children])