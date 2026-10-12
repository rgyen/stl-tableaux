"""Lark parser for the model and STL input syntax.

Builds the Python AST with the operator precedence (including left-associative
implication and the shared and/or precedence).
"""

from dataclasses import dataclass
from functools import lru_cache
from pathlib import Path
from typing import Dict, Tuple
from lark import Lark, Tree
from ..constraints.generator import *
from ..constraints.constraints import *


@lru_cache(maxsize=1)
def _grammar():
    return Lark(
        Path(__file__).parents[1].joinpath("syntax/model.lark").read_text(),
        parser="earley",
        ambiguity="resolve",
        start=["input_file", "stl_mc", "stl_goals"],
    )


@dataclass
class ParsedFormulas:
    """Input properties and their names, before formula preprocessing."""

    labeled: dict
    labels: dict
    propositions: dict


class STLmcParser:
    def __init__(self):
        self.type_context = {}
        self.next_str = "$next"
        self.variable_decls = VariableDeclaration()
        self.range_info = {}
        self.constant_info = {}
        self.proposition_dict = {}
        self.temp_jump = None
        self.init_mode = None

    def parse_from_file(self, file_name):
        """Return (system HA or None, properties) for either input format."""
        from ..encoding.automata.model.stlmc_model import STLmcModel

        # Parse both formats in one grammar; malformed models are not retried
        # as formula files. Each file has an independent declaration context.
        tree = _grammar().parse(Path(file_name).read_text(), start="input_file")
        parser = STLmcParser()
        if tree.data == "stl_goals":
            parser.variable_decls.ignore = True
            named = parser._goals(tree)
            labels = {formula: name for name, formula in named.items()}
            return None, ParsedFormulas(named, labels, {})

        model, propositions, goals = parser._model(tree)
        labels = {formula: name for name, formula in goals.items()}
        ha = STLmcModel(*model).encode()
        return ha, ParsedFormulas(goals, labels, propositions)

    def parse_goal_from_string(self, formula):
        self.variable_decls.ignore = True
        try:
            return self._goals(_grammar().parse(formula, start="stl_goals"))
        finally:
            self.variable_decls.ignore = False

    def _declared(self, name):
        if not self.variable_decls.is_declared(name):
            raise ValueError(name + " is not declared")

    def _expr_name(self, name):
        if name == "t":
            return Real("time")
        self._declared(name)
        return Real(name)

    def _eval(self, node):
        if not isinstance(node, Tree):
            return str(node)
        kind = str(node.data)
        c = node.children
        if kind == "number":
            return RealVal(str(c[0]))
        if kind == "boolean":
            return BoolVal("True" if str(c[0]).lower() == "true" else "False")
        if kind == "expr_name":
            return self._expr_name(str(c[0]))
        if kind == "cond_name":
            name = str(c[0])
            self._declared(name)
            return variable(name, self.variable_decls.get_type(name))
        if kind == "proposition":
            return Bool(str(c[0]))
        if kind == "initial_value":
            return Real(str(c[0])[:-3])
        if kind == "const_name":
            name = str(c[0])
            self._declared(name)
            return self.constant_info[name]
        if kind.startswith("const_"):
            op = {
                "const_add": "+",
                "const_sub": "-",
                "const_mul": "*",
                "const_div": "/",
                "const_pow": "^",
            }[kind]
            return binary_expr(self._eval(c[0]), self._eval(c[1]), op)
        if kind == "binary_expr":
            return binary_expr(self._eval(c[0]), self._eval(c[2]), str(c[1]))
        if kind == "power_expr":
            return Pow(self._eval(c[0]), self._eval(c[1]))
        if kind == "neg_expr":
            return Neg(self._eval(c[-1]))
        if kind == "func_expr":
            return unary_expr(self._eval(c[1]), str(c[0]))
        if kind == "negate":
            return Not(self._eval(c[-1]))
        if kind == "compare":
            return binary_proposition(self._eval(c[0]), self._eval(c[2]), str(c[1]))
        if kind == "condition_compare":
            left, right = self._eval(c[0]), self._eval(c[2])
            if isinstance(left, Int) and left.id == "to":
                self.init_mode = int(right.value)
                return BoolVal("True")
            return binary_formula(left, right, str(c[1]))
        if kind == "prefix_boolean":
            return multinary_formula([self._eval(x) for x in c[1:]], str(c[0]).lower())
        if kind == "binary_boolean":
            return multinary_formula(
                [self._eval(c[0]), self._eval(c[2])], str(c[1]).lower()
            )
        if kind == "implies":
            return Implies(self._eval(c[0]), self._eval(c[1]))
        if kind == "unary_temporal":
            return {"[]": GloballyFormula, "<>": FinallyFormula}[str(c[0])](
                self._eval(c[1]), universeInterval, self._eval(c[2])
            )
        if kind == "binary_temporal":
            return {"U": UntilFormula, "R": ReleaseFormula}[str(c[1])](
                self._eval(c[2]), universeInterval, self._eval(c[0]), self._eval(c[3])
            )
        if kind == "exact_range":
            val = RealVal(str(c[0]))
            return Interval(True, val, val, True)
        if kind in ("range", "time_interval"):
            left, right = str(c[1]), str(c[2])
            if kind == "time_interval":
                left, right = str(float(left)), str(float(right))
            return Interval(
                str(c[0]) == "[", RealVal(left), RealVal(right), str(c[3]) == "]"
            )
        if kind == "jump_name":
            return Bool(str(c[0])[:-1] + self.next_str)
        if kind in ("jump_compare", "jump_boolean"):
            name = str(c[0])[:-1]
            new_name = name + self.next_str
            right = (
                self._eval(c[2])
                if kind == "jump_compare"
                else BoolVal("True" if str(c[2]).lower() == "true" else "False")
            )
            if kind == "jump_boolean":
                return Eq(Bool(new_name), right)
            self._declared(name)
            if name == "to":
                self.temp_jump = int(right.value)
                return BoolVal("True")
            return binary_proposition(
                variable(new_name, self.variable_decls.get_type(name)), right, str(c[1])
            )
        if kind in ("diff_eq", "sol_eq"):
            return Real(str(c[0])), self._eval(c[1])
        if kind in ("mode_decl", "inv_decl", "init_decl"):
            return [self._eval(x) for x in c]
        if kind == "flow_decl":
            values = [self._eval(x) for x in c]
            return (Ode if c[0].data == "diff_eq" else Function)(
                [v for v, e in values], [e for v, e in values]
            )
        if kind == "jump_decl":
            result = []
            targets = {}
            for unit in c:
                pre, post = map(self._eval, unit.children)
                result.append((pre, post))
                if self.temp_jump is not None:
                    targets[pre] = self.temp_jump
                    self.temp_jump = None
            return result, targets
        if kind == "mode_module":
            mode, inv, flow, jump = [self._eval(x) for x in c]
            return dict(mode=mode, inv=inv, flow=flow, jump=jump[0], jp_d=jump[1])
        raise ValueError("Unsupported model syntax: " + kind)

    def _model(self, tree):
        c = tree.children
        # Visit mode, then continuous, then constant declarations.
        for kind in ("mode_var_decl", "variable_var_decl", "const_decl"):
            for node in c:
                if node.data != kind:
                    continue
                a = node.children
                if kind == "mode_var_decl":
                    name, ty = str(a[1]), str(a[0]).lower()
                    group = "mode"
                elif kind == "variable_var_decl":
                    name, ty = str(a[1]), "real"
                    group = "continuous"
                else:
                    name, ty = str(a[0]), "real"
                    group = "constant"
                if kind != "const_decl" and self.variable_decls.is_declared(name):
                    raise ValueError(name + " is already declared")
                self.variable_decls.declare(name, ty, group)
                if group == "continuous":
                    self.range_info[Real(name)] = self._eval(a[0])
                if group == "constant":
                    if isinstance(a[1], Tree) and a[1].data == "boolean":
                        continue
                    self.constant_info[Real(name)] = self._eval(a[1])
        self.variable_decls.unique_checking()
        modules = [self._eval(x) for x in c if x.data == "mode_module"]
        init = self._eval(next(x for x in c if x.data == "init_decl"))
        for node in c:
            if node.data == "props":
                self.proposition_dict = {
                    Bool(str(p.children[0])): self._eval(p.children[1])
                    for p in node.children
                }
        goals = self._goals(next(x for x in c if x.data == "goal_decl"))
        model = (
            modules,
            init,
            self.next_str,
            self.variable_decls.get_declaration(),
            self.range_info,
            self.constant_info,
            self.proposition_dict,
            self.init_mode,
        )
        return model, self.proposition_dict, goals

    def _goals(self, tree):
        return {
            str(node.children[0]): self._eval(node.children[1])
            for node in tree.children
        }


class VariableDeclaration:
    def __init__(self):
        self._v_decls = dict()
        self._v_decls["mode"] = set()
        self._v_decls["continuous"] = set()
        self._v_decls["constant"] = set()
        self.ignore = False

    def declare(self, v_name: str, v_ty: str, ty: str):
        if self.is_declared(v_name):
            return

        is_mode = ty == "mode"
        is_cont = ty == "continuous"
        is_const = ty == "constant"

        if is_mode:
            self._v_decls["mode"].add(variable(v_name, v_ty))
        elif is_cont:
            self._v_decls["continuous"].add(variable(v_name, v_ty))
        elif is_const:
            self._v_decls["constant"].add(variable(v_name, v_ty))
        else:
            raise Exception("invalid type {}".format(ty))

    def is_declared(self, name: str) -> bool:
        if self.ignore:
            return True

        is_int, is_real, is_bool = self._is_declared(name)
        return is_int or is_real or is_bool

    def _is_declared(self, name: str) -> Tuple[bool, bool, bool]:
        mo_decl = self._v_decls["mode"]
        cs_decl = self._v_decls["continuous"]
        ct_decl = self._v_decls["constant"]

        guess_int = variable(name, "int")
        guess_real = variable(name, "real")
        guess_bool = variable(name, "bool")

        is_int = guess_int in mo_decl or guess_int in cs_decl or guess_int in ct_decl
        is_real = (
            guess_real in mo_decl or guess_real in cs_decl or guess_real in ct_decl
        )
        is_bool = (
            guess_bool in mo_decl or guess_bool in cs_decl or guess_bool in ct_decl
        )

        return is_int, is_real, is_bool

    def get_type(self, name: str) -> str:
        is_int, is_real, is_bool = self._is_declared(name)

        if is_int:
            return "int"
        elif is_real:
            return "real"
        elif is_bool:
            return "bool"
        else:
            raise Exception("{} does not declared".format(name))

    def get_declaration(self):
        return self._v_decls

    def unique_checking(self):
        mo_decl = self._v_decls["mode"]
        cs_decl = self._v_decls["continuous"]
        ct_decl = self._v_decls["constant"]

        # check if there are the same variable names
        intersection = mo_decl.intersection(cs_decl).intersection(ct_decl)
        if len(intersection) > 0:
            raise Exception(
                "there are variables "
                "having the same name "
                "but different types {}".format(" , ".join(intersection))
            )
