from functools import singledispatch

import z3
from ..constraints.constraints import *
from ..objects.configuration import Configuration
from ..smt.abstract_solver import SMTSolver
from ..smt.assignment import Assignment


class Z3Solver(SMTSolver):
    def __init__(self, config: Configuration):
        SMTSolver.__init__(self)

        z3_section = config.get_section("z3")
        logic = z3_section.get_value("logic")

        self._solver = z3.SolverFor(logic)
        self._model = None

    def check_sat(self, *assumption, **information):
        self._clear_model()

        if len(assumption) > 0:
            result = self._solver.check(translate(And([c for c in assumption])))
        else:
            result = self._solver.check()

        if result == z3.sat:
            self._model = self._solver.model()
            return SMTSolver.sat
        elif result == z3.unsat:
            return SMTSolver.unsat
        elif result == z3.unknown:
            return SMTSolver.unknown
        else:
            raise Exception("Z3 solver error occurred during check sat")

    def push(self):
        self._solver.push()

    def pop(self):
        self._solver.pop()

    def reset(self):
        self._solver.reset()
        self._clear_model()

    def add(self, const: Formula):
        self._solver.add(translate(const))

    def make_assignment(self):
        if self._model is None:
            raise Exception("Z3 solver error occurred during making assignment (no model exists)")
        return Z3Assignment(self._model)

    def assert_and_track(self, formula: Formula, track_id: str):
        self._solver.assert_and_track(translate(formula), track_id)

    def unsat_core(self):
        u_core = self._solver.unsat_core()
        return [str(literal) for literal in u_core]

    def _clear_model(self):
        self._model = None


class Z3Assignment(Assignment):
    def __init__(self, z3_model):
        self._z3_model: z3.ModelRef = z3_model
        Assignment.__init__(self)

    # solver_model_to_generalized_model
    def _get_assignments(self):
        if self._z3_model is None:
            return dict()
        new_dict = dict()
        op_var_dict = {'bool': Bool, 'int': Int, 'real': Real}
        op_dict = {'bool': BoolVal, 'int': IntVal, 'real': RealVal}
        for d in self._z3_model.decls():
            var_type_str = str(d.range()).lower()
            new_var = op_var_dict[var_type_str](d.name())
            z3_val = self._z3_model[d]
            new_dict[new_var] = op_dict[var_type_str](str(z3_val))
        return new_dict

    def eval(self, const):
        if self._z3_model is None:
            raise Exception("Z3 has no model")
        val = self._z3_model.eval(translate(const))
        if z3.is_true(val):
            return Assignment.true
        elif z3.is_false(val):
            return Assignment.false
        else:
            return Assignment.any


@singledispatch
def translate(const: Formula):
    raise Exception("fail to translate \"{}\" to Z3 object ".format(const))


@translate.register(RealVal)
def _(const: RealVal):
    if const.value == "inf":
        return z3.RealVal("99999")
    return z3.RealVal(const.value)


@translate.register(IntVal)
def _(const: IntVal):
    if const.value == "inf":
        return z3.IntVal("99999")
    return z3.IntVal(const.value)


@translate.register(BoolVal)
def _(const: BoolVal):
    if const.value == 'True':
        return z3.BoolVal(True)
    elif const.value == 'False':
        return z3.BoolVal(False)
    else:
        raise Exception("Z3 solver cannot translate this")


@translate.register(Variable)
def _(const: Variable):
    op = {'bool': z3.Bool, 'real': z3.Real, 'int': z3.Int}
    return op[const.type](const.id)


@translate.register(Geq)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x >= y


@translate.register(Gt)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x > y


@translate.register(Leq)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x <= y


@translate.register(Lt)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x < y


@translate.register(Eq)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x == y


@translate.register(Neq)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x != y


@translate.register(Add)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x + y


@translate.register(Sub)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x - y


@translate.register(Pow)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x ** y


@translate.register(Mul)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x * y


@translate.register(Div)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x / y


@translate.register(Neg)
def _(const):
    x = translate(const.child)
    return -x


@translate.register(And)
def _(const):
    z3args = [translate(c) for c in const.children]
    if len(z3args) < 1:
        return z3.BoolVal(True)
    elif len(z3args) < 2:
        return z3args[0]
    else:
        return z3.And(z3args)


@translate.register(Or)
def _(const):
    z3args = [translate(c) for c in const.children]
    if len(z3args) < 1:
        return z3.BoolVal(True)
    elif len(z3args) < 2:
        return z3args[0]
    else:
        return z3.Or(z3args)


@translate.register(Implies)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return z3.Implies(x, y)


@translate.register(Not)
def _(const):
    x = translate(const.child)
    return z3.Not(x)


@translate.register(EqFormula)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x == y


@translate.register(NeqFormula)
def _(const):
    x = translate(const.left)
    y = translate(const.right)
    return x != y
