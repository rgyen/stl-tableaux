from functools import singledispatch

from ..constraints.constraints import *


def pprint(const: Formula, indent: int):
    print(p_string(const, indent))


def indented_str(s: str, indent: int):
    li = [" " for _ in range(indent)]
    li.append(s)
    return "".join(li)


@singledispatch
def p_string(const: Formula, indent: int):
    return indented_str(str(const), indent)


@p_string.register(Leaf)
def _(const: Formula, indent: int):
    return indented_str(str(const), indent)


@p_string.register(Integral)
def _(const: Integral, indent: int):
    s = [
        indented_str("(integral {}".format(const.current_mode_number), indent),
        indented_str("[{}]".format(", ".join([str(v) for v in const.end_vector])), indent + 2),
        indented_str("[{}]".format(", ".join([str(v) for v in const.start_vector])), indent + 2),
        dynamics_p_string(const.dynamics, indent + 2),
        indented_str(")", indent)
    ]
    return "\n".join(s)


@p_string.register(UnaryFormula)
def _(const: UnaryFormula, indent: int):
    s = [
        indented_str("{} (".format(const.type), indent),
        p_string(const.child, indent + 2),
        indented_str(")", indent)
    ]
    return "\n".join(s)


@p_string.register(BinaryFormula)
def _(const: BinaryFormula, indent: int):
    s = [
        indented_str("{} (".format(const.type), indent),
        p_string(const.left, indent + 2),
        p_string(const.right, indent + 2),
        indented_str(")", indent)
    ]
    return "\n".join(s)


@p_string.register(MultinaryFormula)
def _(const: MultinaryFormula, indent: int):
    s = [indented_str("{} (".format(const.type), indent)]
    for e in const.children:
        s.append(p_string(e, indent + 2))
    s.append(indented_str(")", indent))
    return "\n".join(s)


def dynamics_p_string(dynamic: Dynamics, indent: int):
    s = [indented_str("{} (".format(dynamic.type), indent)]
    li = [indented_str("{} = {}".format(v, e), indent + 2) for (v, e) in zip(dynamic.vars, dynamic.exps)]
    s.append("\n".join(li))
    s.append(indented_str(")", indent))
    return "\n".join(s)
