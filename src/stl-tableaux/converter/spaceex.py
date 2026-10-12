import os
import xml.etree.ElementTree as elemTree

from functools import singledispatch
from typing import List, Union

from .converter import Converter
from ..hybrid_automaton import *
from ..hybrid_automaton.utils import *
from ..constraints.constraints import *
from ..objects.configuration import Configuration


class SpaceExConverter(Converter):
    def __init__(self, config: Configuration):
        self._model_string = ""
        self._config_string = ""
        self._config: Configuration = config

    def convert(self, ha: HybridAutomaton):
        self._reset()
        # set variable declaration string
        self._model_string, id_map = _make_model(ha)
        self._config_string = _make_conf(ha, self._config, id_map)

    def write(self, file_name: str, dir: str):
        common_section = self._config.get_section("common")
        g_n, b = common_section.get_value("goal"), common_section.get_value("bound")

        root = "{}/{}/{}/spaceex".format(dir, file_name, g_n)
        m_dir = "{}/model".format(root)

        o_n = "{}/model.xml".format(m_dir)
        c_n = "{}/model.cfg".format(m_dir)
        s_n = "{}/run.sh".format(root, g_n, b)

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
        sx = self._config.get_section("spaceex")
        exec = sx.get_value("executable-path")

        s = "./{} -m ./{} -g ./{} >& ./{}/out-log.txt".format(exec, model_file, conf_file, root)
        f = open(script_name, "w")
        f.write(s)
        f.close()

        os.chmod(script_name, 0o755)

    def _reset(self):
        self._model_string = ""
        self._config_string = ""


def _make_model(ha: HybridAutomaton):
    elemTree.register_namespace("", "http://www-verimag.imag.fr/xml-namespaces/sspaceex")
    root = elemTree.Element("sspaceex", {"version" : "0.2", "math" : "SpaceEx"})

    ha_id = str(id(ha))

    # make component
    main_comp = elemTree.SubElement(root, "component")
    main_comp.set("id", ha_id)

    # make variable declarations
    v_set = get_ha_vars(ha)
    v_decls: List[elemTree.Element] = list()
    for v in v_set:
        v_d = elemTree.Element("param")
        v_d.set("name", str(v.id))
        v_d.set("type", str(v.type))
        v_d.set("local", "false")
        v_d.set("d1", "1")
        v_d.set("d2", "1")
        v_d.set("dynamics", "any")
        v_decls.append(v_d)
    
    # add variable declarations
    for v_d in v_decls:
        v = elemTree.Element("param")
        v.attrib = v_d.attrib.copy()
        main_comp.append(v)

    id_map = dict()

    # make locations
    for idx, mode in enumerate(ha.get_modes()):
        loc = elemTree.SubElement(main_comp, "location")
        loc.set("id", str(idx))
        loc.set("name", "mode_id_{}".format(idx))
        loc.set("x", "{}".format(200 + 10 * idx))
        loc.set("y", "{}".format(200 + 10 * idx))
        loc.set("width", "100")
        loc.set("height", "100")

        f = elemTree.SubElement(loc, "flow")
        f.text = _make_flow(mode)

        inv = elemTree.SubElement(loc, "invariant")
        inv.text = _make_inv(mode)

        id_map[mode.id] = idx
        
    # make jumps
    for jp in get_jumps(ha):
        tr = elemTree.SubElement(main_comp, "transition")
        tr.set("source", str(id_map[jp.get_src().id]))
        tr.set("target", str(id_map[jp.get_trg().id]))

        g = elemTree.SubElement(tr, "guard")
        g.text = _make_guard(jp)

        r = elemTree.SubElement(tr, "assignment")
        r.text = _make_reset(jp)

    # make automata network
    network = elemTree.SubElement(root, "component")
    network.set("id", "system")

    # add variable declarations
    for v_d in v_decls:
        v = elemTree.Element("param")
        v.attrib = v_d.attrib.copy()
        network.append(v)

    bind = elemTree.SubElement(network, "bind")
    bind.set("component", ha_id)
    bind.set("as", "subsystem")
    for v in v_set:
        map = elemTree.SubElement(bind, "map")
        map.set("key", str(v))
        map.text = str(v)

    xml_pretty_print(root)
    raw = elemTree.tostring(root, encoding="utf-8", xml_declaration=True)
    return str(raw, "utf-8"), id_map


def _make_conf(ha: HybridAutomaton, config: Configuration, id_map):
    common_section = config.get_section("common")
    time_horizon = common_section.get_value("time-horizon")
    if time_horizon == "time-bound":
        time_horizon = common_section.get_value("time-bound")

    sx = config.get_section("spaceex")
    itermax = sx.get_value("iter-max")
    scenario = sx.get_value("scenario")

    v_set = get_ha_vars(ha)

    init_state, final_state = list(), list()
    for mode in ha.get_modes():
        if mode.is_initial():
            init_state.append("loc(subsystem) == mode_id_{}".format(id_map[mode.id]))

        if mode.is_final():
            final_state.append("loc(subsystem) == mode_id_{}".format(id_map[mode.id]))

    init_const = set()
    for m_c in ha.get_modes():
        if m_c.is_initial():
            for c in m_c.init:
                init_const.add(obj2se(c))

    assert len(v_set) > 0
    random_var = v_set.copy().pop()

    conf_dict = dict()
    conf_dict["system"] = "\"system\""
    conf_dict["initially"] = "\"{} & ({})\"".format(" & ".join(init_const), " || ".join(init_state))
    conf_dict["forbidden"] = "\"{}\"".format(" || ".join(final_state))
    conf_dict["scenario"] = "\"{}\"".format(scenario)
    conf_dict["directions"] = "\"oct\""
    conf_dict["set-aggregation"] = "chull"
    conf_dict["flowpipe-tolerance"] = "1"
    conf_dict["flowpipe-tolerance-rel"] = "0"
    conf_dict["time-horizon"] = "{}".format(time_horizon)
    conf_dict["iter-max"] = "{}".format(itermax)
    conf_dict["output-variables"] = "\"{}, {}\"".format(random_var, random_var)
    conf_dict["output-format"] = "\"INTV\""

    conf_str_list = ["{} = {}".format(cf, conf_dict[cf]) for cf in conf_dict]
    return "\n".join(conf_str_list)


def _make_flow(mode: Mode):
    flows = ["{}\' == {}".format(v, obj2se(mode.dynamics[v])) for v in mode.dynamics]
    return " & \n".join(flows)


def _make_inv(mode: Mode):
    inv_s = [obj2se(inv) for inv in mode.invariant]
    return " & \n".join(inv_s)


def _make_guard(jp: Transition):
    guard_s = [obj2se(guard) for guard in jp.guard]
    return " & \n".join(guard_s)


def _make_reset(jp: Transition):
    reset_s = ["{} := {}".format(v, obj2se(e)) for v, e in jp.reset]
    return " & \n".join(reset_s)


@singledispatch
def obj2se(const: Union[Formula, Expr]):
    raise Exception("cannot support translation of {} for spaceex".format(const))


@obj2se.register(Variable)
def _(const: Variable):
    return const.id


@obj2se.register(Constant)
def _(const: Constant):
    return const.value


@obj2se.register(And)
def _(const: And):
    return ' & '.join([obj2se(c) for c in const.children])


@obj2se.register(Geq)
def _(const: Geq):
    return obj2se(const.left) + " >= " + obj2se(const.right)


@obj2se.register(Gt)
def _(const: Gt):
    return obj2se(const.left) + " > " + obj2se(const.right)


@obj2se.register(Leq)
def _(const: Leq):
    return obj2se(const.left) + " <= " + obj2se(const.right)


@obj2se.register(Lt)
def _(const: Lt):
    return obj2se(const.left) + " < " + obj2se(const.right)


@obj2se.register(Eq)
def _(const: Eq):
    return obj2se(const.left) + " == " + obj2se(const.right)


# cannot support this
@obj2se.register(Neq)
def _(const: Neq):
    raise Exception("neq not supported {}".format(const))


@obj2se.register(Add)
def _(const: Add):
    return "(" + obj2se(const.left) + " + " + obj2se(const.right) + ")"


@obj2se.register(Sub)
def _(const: Sub):
    return "(" + obj2se(const.left) + " - " + obj2se(const.right) + ")"


@obj2se.register(Neg)
def _(const: Neg):
    child = const.child

    # optimized expression generation
    # if -(c * expr) and c is a constant: 
    if isinstance(child, Mul):
        left_s  = obj2se(child.left)
        right_s = obj2se(child.right)
        # left is constant
        if isinstance(child.left, Constant) and _is_number(left_s):
            return _neg_literal(left_s) + " * " + right_s
        # right is constant
        if isinstance(child.right, Constant) and _is_number(right_s):
            return _neg_literal(right_s) + " * " + left_s

    # -(const)
    if isinstance(child, Constant):
        return _neg_literal(obj2se(child))

    # -(variable)
    if isinstance(child, Variable):
        return "-" + obj2se(child)

    # otherwise
    return "-(" + obj2se(child) + ")"


@obj2se.register(Mul)
def _(const: Mul):
    return obj2se(const.left) + " * " + obj2se(const.right)


@obj2se.register(Div)
def _(const: Div):
    return "(" + obj2se(const.left) + " / " + obj2se(const.right) + ")"


@obj2se.register(Pow)
def _(const: Pow):
    return "(" + obj2se(const.left) + " ^ " + obj2se(const.right) + ")"


@obj2se.register(Sqrt)
def _(const: Sqrt):
    return "(sqrt ({}))".format(obj2se(const.child))


@obj2se.register(Sin)
def _(const: Sin):
    return "(sin ({}))".format(obj2se(const.child))


@obj2se.register(Cos)
def _(const: Cos):
    return "(cos ({}))".format(obj2se(const.child))


@obj2se.register(Tan)
def _(const: Tan):
    return "(tan ({}))".format(obj2se(const.child))


def xml_pretty_print(current, parent=None, index=-1, depth=0):
    for i, node in enumerate(current):
        xml_pretty_print(node, current, i, depth + 1)
    if parent is not None:
        if index == 0:
            parent.text = '\n' + ('\t' * depth)
        else:
            parent[index - 1].tail = '\n' + ('\t' * depth)
        if index == len(parent) - 1:
            current.tail = '\n' + ('\t' * (depth - 1))


def _is_number(s: str) -> bool:
    try:
        float(s)
        return True
    except:
        return False


def _neg_literal(s: str) -> str:
    s = s.strip()
    # remove "-" sign if it is already negative
    if s.startswith("-"):
        return s[1:].lstrip()
    # remove "+"" sign 
    if s.startswith("+"):
        s = s[1:].lstrip()

    return "-" + s
