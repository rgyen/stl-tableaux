from functools import singledispatch
from typing import Dict, Union, Set

from .generator import *
from .constraints import *


class Substitution:
    def __init__(self):
        self._subst_dict: Dict[Formula, Formula] = dict()

    def add(self, src: Formula, dst: Formula):
        self._subst_dict[src] = dst

    def substitute(self, formula: Formula):
        return _substitution(formula, self._subst_dict)


class VarSubstitution:
    def __init__(self):
        self._subst_dict: Dict[Variable, Expr] = dict()

    def add(self, src: Variable, dst: Expr):
        self._subst_dict[src] = dst

    def substitute(self, formula: Formula):
        return _substitution(formula, self._subst_dict)


def inf(interval: Interval) -> Union[Real, RealVal]:
    return interval.left


def sup(interval: Interval) -> Union[Real, RealVal]:
    return interval.right


@singledispatch
def _substitution(const: Union[Formula, Expr], substitution_dict):
    return const


@_substitution.register(Variable)
def _(const: Variable, substitution_dict):
    if const in substitution_dict:
        return substitution_dict[const]
    return const


@_substitution.register(UnaryExpr)
def _(const: UnaryExpr, substitution_dict):
    if const in substitution_dict:
        return substitution_dict[const]
    else:
        child = _substitution(const.child, substitution_dict)
        return unary_expr(child, const.type)


@_substitution.register(BinaryExpr)
def _(const: BinaryExpr, substitution_dict):
    if const in substitution_dict:
        return substitution_dict[const]
    else:
        left = _substitution(const.left, substitution_dict)
        right = _substitution(const.right, substitution_dict)
        return binary_expr(left, right, const.type)


@_substitution.register(UnaryFormula)
def _(const: UnaryFormula, substitution_dict):
    if const in substitution_dict:
        return substitution_dict[const]
    else:
        child = _substitution(const.child, substitution_dict)
        return unary_formula(child, const.type)


@_substitution.register(BinaryFormula)
def _(const: BinaryFormula, substitution_dict):
    if const in substitution_dict:
        return substitution_dict[const]
    else:
        left = _substitution(const.left, substitution_dict)
        right = _substitution(const.right, substitution_dict)
        return binary_formula(left, right, const.type)


@_substitution.register(MultinaryFormula)
def _(const: MultinaryFormula, substitution_dict):
    if const in substitution_dict:
        return substitution_dict[const]
    else:
        children = [_substitution(c, substitution_dict) for c in const.children]
        return multinary_formula(children, const.type)


@_substitution.register(Proposition)
def _(const: Proposition, substitution_dict):
    if const in substitution_dict:
        return substitution_dict[const]
    else:
        if isinstance(const, Binary):
            left = _substitution(const.left, substitution_dict)
            right = _substitution(const.right, substitution_dict)
            return binary_proposition(left, right, const.type)
        else:
            assert isinstance(const, Integral) or isinstance(const, Forall)

            if isinstance(const, Forall):
                e_t = _substitution(const.end_tau, substitution_dict)
                s_t = _substitution(const.start_tau, substitution_dict)
                c = _substitution(const.const, substitution_dict)
                return Forall(const.current_mode_number, e_t, s_t, c)

            if isinstance(const, Integral):
                e_v = [_substitution(v, substitution_dict) for v in const.end_vector]
                s_v = [_substitution(v, substitution_dict) for v in const.start_vector]
                dyn = _dynamics_substitution(const.dynamics, substitution_dict)
                return Integral(const.current_mode_number, e_v, s_v, dyn)


@_substitution.register(UnaryTemporalFormula)
def _(const: UnaryTemporalFormula, substitution_dict):
    if const in substitution_dict:
        return substitution_dict[const]
    else:
        child = _substitution(const.child, substitution_dict)
        return unary_temporal_formula(const.local_time, const.global_time, child, const.type)


@_substitution.register(BinaryTemporalFormula)
def _(const: BinaryTemporalFormula, substitution_dict):
    if const in substitution_dict:
        return substitution_dict[const]
    else:
        left = _substitution(const.left, substitution_dict)
        right = _substitution(const.right, substitution_dict)
    return binary_temporal_formula(const.local_time, const.global_time, left, right, const.type)


def _dynamics_substitution(dyn: Dynamics, substitution_dict):
    vs = [_substitution(var, substitution_dict) for var in dyn.vars]
    es = [_substitution(exp, substitution_dict) for exp in dyn.exps]
    return dynamics(vs, es, dyn.type)




@singledispatch
def get_vars(const: Union[Formula, Expr]):
    return set()


@get_vars.register(Unary)
def _(const: Unary):
    return get_vars(const.child)


@get_vars.register(Binary)
def _(const: Binary):
    left = get_vars(const.left)
    right = get_vars(const.right)
    return left.union(right)


@get_vars.register(Multinary)
def _(const: Multinary):
    result = set()
    for c in const.children:
        result = result.union(get_vars(c))
    return result


@get_vars.register(Variable)
def _(const: Variable):
    return {const}


@get_vars.register(Integral)
def _(const: Integral):
    return set()


@get_vars.register(Forall)
def _(const: Forall):
    return get_vars(const.const)


@singledispatch
def clause(const: Formula):
    return {const}


@clause.register(Not)
def _(const: Not):
    return clause(const.child)


@clause.register(And)
def _(const: And):
    result = set()
    for c in list(const.children):
        result = result.union(clause(c))
    return result


@clause.register(Eq)
def _(const: Eq):
    if isinstance(const.left, Formula):
        return clause(const.left).union(clause(const.right))
    return {const}


@clause.register(Or)
def _(const: Or):
    result = set()
    for c in list(const.children):
        result = result.union(clause(c))
    return result


@clause.register(Not)
def _(const: Not):
    result = set()
    return result.union(clause(const.child))


@clause.register(Implies)
def _(const):
    result = set()
    result = result.union(clause(const.left))
    result = result.union(clause(const.right))
    return result


@clause.register(FinallyFormula)
def _(const):
    return clause(const.child)


@clause.register(GloballyFormula)
def _(const):
    return clause(const.child)


@clause.register(UntilFormula)
def _(const):
    result = set()
    result = result.union(clause(const.left))
    result = result.union(clause(const.right))
    return result


@clause.register(ReleaseFormula)
def _(const):
    result = set()
    result = result.union(clause(const.left))
    result = result.union(clause(const.right))
    return result


def variable_equal(v1: Variable, v2: Variable):
    return v1.type == v2.type and v1.id == v2.id
