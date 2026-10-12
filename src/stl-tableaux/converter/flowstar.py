import os

from functools import singledispatch
from typing import Union

from .converter import Converter
from ..hybrid_automaton.utils import *
from ..constraints.constraints import *
from ..objects.configuration import Configuration


class FlowStarConverter(Converter):
    def __init__(self, config: Configuration):
        self._string = ""
        self._single_init = False
        self._config: Configuration = config

    def convert(self, ha: HybridAutomaton):
        self._reset()
        self._preprocessing(ha)

        fs = self._config.get_section("flowstar")

        modes_str_list = list()

        initial_modes, final_modes = set(), set()

        id_map = dict()
        for idx, mode in enumerate(ha.get_modes()):
            id_map[mode] = idx

            mode_str = "mode_{}{{\n".format(id_map[mode])
            mode_str += "{}\n{{".format(fs.get_value("ode-type").replace("-", " "))
            # mode_str += "poly ode 1\n{"
            # mode_str += "poly ode 3\n{"

            for v in mode.dynamics:
                e = mode.dynamics[v]
                mode_str += "{}\' = {}\n".format(v, str(obj2fs(e))).replace("**", "^")
            mode_str += "}\n"

            mode_str += "inv {\n"
            for inv in mode.invariant:
                mode_str += "{}\n".format(obj2fs(inv)) \
                    .replace(">", ">=").replace("<", "<=") \
                    .replace(">==", ">=").replace("<==", "<=").replace("**", "^")
            mode_str += "}\n}"
            modes_str_list.append(mode_str)

            if mode.is_initial():
                initial_modes.add(mode)

            if mode.is_final():
                final_modes.add(mode)

        modes_str = "modes {{\n {}\n}}\n".format("\n".join(modes_str_list))

        trans_str_list = list()
        jumps = get_jumps(ha)
        for transition in jumps:
            assert isinstance(transition, Transition)
            t_str = "mode_{} -> mode_{}\n".format(id_map[transition.get_src()], id_map[transition.get_trg()])
            t_str += "guard {\n"
            for guard in transition.guard:
                _str = "{}\n".format(obj2fs(guard))
                t_str += _str.replace(">", ">=").replace("<", "<=").replace(">==", ">=").replace("<==", "<=").replace(
                    "**", "^")
            t_str += "}\n"

            # reset
            t_str += "reset {\n"
            for le, ri in transition.reset:
                assert isinstance(le, Variable)
                _str = "{}\' := {}\n".format(le, obj2fs(ri))
                t_str += _str.replace("**", "^").replace("True", "")
            t_str += "}\n"

            t_str += "parallelotope aggregation { }\n"
            trans_str_list.append(t_str)

        trans_str = "jumps {{\n {} \n }}\n".format("\n".join(trans_str_list))

        var_set = get_ha_vars(ha)

        init_cond_str = ""

        # make init
        for m in initial_modes:
            bound_box = m.get_bound_box()
            for variable in var_set:
                assert variable in bound_box
                bb = bound_box[variable]
                init_cond_str += "{} in [{}, {}]\n".format(variable, bb.left, bb.right)

        init_child_str = ""

        # assert len(initial_modes) == 1
        for start_mode in initial_modes:
            init_child_str += "mode_{} {{".format(id_map[start_mode])
            init_child_str += init_cond_str
            init_child_str += "}\n"

        init_str = "init {{\n {}\n}}\n".format(init_child_str)

        unsafe_str = ""
        terminal_modes_str = list()
        for final_mode in final_modes:
            terminal_modes_str.append("mode_{}".format(id_map[final_mode]))

        for m in ha.get_modes():
            if not m.is_final():
                unsafe_str += "mode_{}{{ ff >= 10 }}\n".format(id_map[m])

            real_name = "mode_{}".format(id_map[m])
            if real_name in terminal_modes_str:
                unsafe_str += "{}{{}}\n".format(real_name)
            # else:
            #     unsafe_str += "{}{{ ff <= 0 }}\n".format(real_name)

        var_str = "state var {}".format(", ".join(map(lambda x: str(x), var_set)))
        assert len(var_set) > 0
        picked = var_set.pop()

        common_section = self._config.get_section("common")
        time_horizon = common_section.get_value("time-horizon")
        if time_horizon == "time-bound":
            time_horizon = common_section.get_value("time-bound")

        bound = common_section.get_value("bound")
        mi, mx = fs.get_value("min-step"), fs.get_value("max-step")
        order = fs.get_value("ode-order")

        # config
        net_dict = dict()
        net_dict["adaptive steps"] = "{{min {}, max {}}}".format(mi, mx)
        net_dict["time"] = time_horizon
        net_dict["remainder estimation"] = "1e-8"
        net_dict["identity precondition"] = ""
        net_dict["gnuplot octagon"] = "{},{} fixed orders {}".format(picked, picked, order)
        net_dict["cutoff"] = "1e-13"
        net_dict["precision"] = "53"
        net_dict["no output"] = ""
        net_dict["max jumps"] = fs.get_value("max-jumps")
        net_dict["print on"] = ""

        conf_str_list = list()
        for k in net_dict:
            conf_str_list.append("{} {}".format(k, net_dict[k]))

        setting_str = "setting {{\n {} \n}}\n".format("\n".join(conf_str_list))

        self._string = "hybrid reachability {{\n {}\n {}\n {}\n {}\n {}\n}}\n unsafe {{\n {} \n }}\n".format(
            var_str,
            setting_str,
            modes_str,
            trans_str,
            init_str,
            unsafe_str)

    def jp_bound_needed(self):
        return False
    
    def update_jp_bound(self):
        common = self._config.get_section("common")
        
        if self._single_init:
            b = int(common.get_value("bound"))
            common.set_value("bound", "{}".format(b + 1))

    def write(self, file_name: str, dir: str):
        common_section = self._config.get_section("common")
        g_n, b = common_section.get_value("goal"), common_section.get_value("bound")

        root = "{}/{}/{}/flowstar".format(dir, file_name, g_n)
        m_dir = "{}/model".format(root)

        o_n = "{}/model.fs".format(m_dir)
        s_n = "{}/run.sh".format(root)

        if not os.path.exists(m_dir):
            os.makedirs(m_dir)

        f = open(o_n, "w")
        f.write(self._string)
        f.close()
        print(indented_str("model file  : {}".format(o_n), 2))

        self._create_script(s_n, o_n, root)
        print(indented_str("script file : {}".format(s_n), 2))

    def _create_script(self, script_name: str, model_file: str, root: str):
        fs = self._config.get_section("flowstar")
        exec = fs.get_value("executable-path")

        s = "./{} ./{} >& ./{}/out-log.txt".format(exec, model_file, root)
        f = open(script_name, "w")
        f.write(s)
        f.close()

        os.chmod(script_name, 0o755)

    def _reset(self):
        self._string = ""
        self._single_init = False

    def _preprocessing(self, ha: HybridAutomaton):
        # checking is enough
        assert len(set(filter(lambda x : x.is_initial(), ha.get_modes()))) == 1
        # self._add_single_init(ha)
        self._add_ff(ha)

    def _add_single_init(self, ha: HybridAutomaton):
        zero, one, delta = RealVal("0.0"), RealVal("1.0"), RealVal("0.001")
        g_clk = Real("gClk")
    
        # get initial and final modes
        init = set()
        for mode in ha.get_modes():
            if mode.is_initial():
                init.add(mode)

        v_s = get_ha_vars(ha)

        if len(init) > 1:
            self._single_init = True

            # make new initial and final mode
            init_m = Mode(100001)
            init_m.set_as_initial()
            init_m.add_invariant(g_clk <= delta)

            for v in v_s:
                if v.id == g_clk.id:
                    init_m.add_dynamic((v, one))
                else:
                    init_m.add_dynamic((v, zero))

            ha.add_mode(init_m)

            for m in init:
                m.set_as_non_initial()
                tr = Transition(init_m, m)
                tr.add_guard(g_clk >= zero)
                ha.add_transition(tr)

    def _add_ff(self, ha: HybridAutomaton):
        ff = Real("ff")
        zero, one = RealVal("0.0"), RealVal("1.0")

        for mode in ha.get_modes():
            if mode.is_initial():
                # add initial conditions for special variables: ff = 1
                mode.add_init(ff == one)
            
            mode.add_dynamic((ff, zero))
            # mode.add_invariant(ff > zero)

        remove_equal_jumps(ha)


@singledispatch
def obj2fs(const: Union[Formula, Expr]):
    raise Exception("fail to translate to flowstar object ({})".format(const))


@obj2fs.register(Variable)
def _(const: Variable):
    return const.id


@obj2fs.register(Constant)
def _(const: Constant):
    return const.value


@obj2fs.register(And)
def _(const: And):
    return '\n'.join([obj2fs(c) for c in const.children])


@obj2fs.register(Geq)
def _(const: Geq):
    return obj2fs(const.left - const.right) + " >= 0.0"


@obj2fs.register(Gt)
def _(const: Gt):
    return obj2fs(const.left - const.right) + " >= 0.0"


@obj2fs.register(Leq)
def _(const: Leq):
    return obj2fs(const.left - const.right) + " <= 0.0"


@obj2fs.register(Lt)
def _(const: Geq):
    return obj2fs(const.left - const.right) + " <= 0.0"


@obj2fs.register(Eq)
def _(const: Eq):
    return "{} - {} = 0.0".format(obj2fs(const.left), obj2fs(const.right))


# cannot support this
@obj2fs.register(Neq)
def _(const: Geq):
    c1 = obj2fs(const.left - const.right) + " >= 0.0"
    c2 = obj2fs(const.left - const.right) + " <= 0.0"
    return c1 + "\n" + c2


@obj2fs.register(Add)
def _(const: Add):
    return "(" + obj2fs(const.left) + " + " + obj2fs(const.right) + ")"


@obj2fs.register(Sub)
def _(const: Sub):
    return "(" + obj2fs(const.left) + " - " + obj2fs(const.right) + ")"


@obj2fs.register(Neg)
def _(const: Neg):
    return "(-" + obj2fs(const.child) + ")"


@obj2fs.register(Mul)
def _(const: Mul):
    return "(" + obj2fs(const.left) + " * " + obj2fs(const.right) + ")"


@obj2fs.register(Div)
def _(const: Div):
    return "(" + obj2fs(const.left) + " / " + obj2fs(const.right) + ")"


@obj2fs.register(Pow)
def _(const: Pow):
    return "(" + obj2fs(const.left) + " ** " + obj2fs(const.right) + ")"


@obj2fs.register(Sqrt)
def _(const: Sqrt):
    return "(sqrt ({}))".format(obj2fs(const.child))


@obj2fs.register(Sin)
def _(const: Sin):
    return "(sin ({}))".format(obj2fs(const.child))


@obj2fs.register(Cos)
def _(const: Cos):
    return "(cos ({}))".format(obj2fs(const.child))


@obj2fs.register(Tan)
def _(const: Tan):
    return "(tan ({}))".format(obj2fs(const.child))


@obj2fs.register(Forall)
def _(const: Forall):
    return obj2fs(const.const)
