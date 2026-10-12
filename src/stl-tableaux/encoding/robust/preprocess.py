"""Formula preprocessing in Maude and conversion back to the Python AST.

Python substitutes proposition definitions, encodes the formula as a Maude term,
and decodes the rewritten result. All logical and temporal rewrites run in Maude.
"""

import json
import math
from pathlib import Path
import maude
from ...constraints.constraints import *
from ..automata.goal.label import global_clk

_MODULE = None
_BINARY = {
    Add: "+",
    Sub: "-",
    Mul: "*",
    Div: "/",
    Pow: "^",
    Lt: "<",
    Leq: "<=",
    Gt: ">",
    Geq: ">=",
    Eq: "=",
    Neq: "!=",
}
_UNARY = {
    Neg: "-",
    Sqrt: "sqrt",
    Sin: "sin",
    Cos: "cos",
    Tan: "tan",
    Arcsin: "asin",
    Arccos: "acos",
    Arctan: "atan",
}


def _number(value):
    n = float(value)
    if not math.isfinite(n):
        raise ValueError("Non-finite expression literal: " + str(value))
    return repr(n)


def _interval(i):
    lower = float(i.left.value)
    upper = float(i.right.value)
    if lower < 0 or not math.isfinite(lower) or upper <= lower:
        raise ValueError("Invalid temporal interval: " + str(i))
    if math.isinf(upper):
        if upper < 0 or i.right_end:
            raise ValueError("Infinite interval must have an open right endpoint")
        right = "infty"
    else:
        right = _number(i.right.value)
    return (
        "| "
        + str(i.left_end).lower()
        + ", "
        + _number(i.left.value)
        + ", "
        + right
        + ", "
        + str(i.right_end).lower()
        + " |"
    )


def encode(f):
    if isinstance(f, BoolVal):
        return str(f.value).lower()
    if isinstance(f, Bool):
        return "prop(" + json.dumps(f.id) + ")"
    if isinstance(f, (Real, Int)):
        return "var(" + json.dumps(f.id) + ")"
    if isinstance(f, (RealVal, IntVal)):
        return _number(f.value)
    if isinstance(f, (And, Or)):
        identity = "true" if isinstance(f, And) else "false"
        values = [encode(c) for c in f.children]
        if not values:
            return identity
        op = " /\\ " if isinstance(f, And) else " \\/ "
        result = values[-1]
        for child in reversed(values[:-1]):
            result = "(" + child + op + result + ")"
        return result
    if isinstance(f, Not):
        return "(~ " + encode(f.child) + ")"
    if isinstance(f, Implies):
        return "(" + encode(f.left) + " -> " + encode(f.right) + ")"
    if isinstance(f, (GloballyFormula, FinallyFormula)):
        return (
            "("
            + ("[] " if isinstance(f, GloballyFormula) else "<> ")
            + _interval(f.local_time)
            + " ("
            + encode(f.child)
            + "))"
        )
    if isinstance(f, (UntilFormula, ReleaseFormula)):
        op = "U" if isinstance(f, UntilFormula) else "R"
        return (
            "("
            + encode(f.left)
            + " "
            + op
            + "["
            + _interval(f.local_time)
            + "] "
            + encode(f.right)
            + ")"
        )
    if type(f) in _BINARY:
        return (
            "(" + encode(f.left) + " " + _BINARY[type(f)] + " " + encode(f.right) + ")"
        )
    if type(f) in _UNARY:
        return _UNARY[type(f)] + "(" + encode(f.child) + ")"
    raise TypeError("Unsupported preprocessing AST: " + type(f).__name__)


def _module():
    global _MODULE
    if _MODULE is None:
        maude.init(advise=False)
        if not maude.load(str(Path(__file__).with_name("preprocess.maude"))):
            raise RuntimeError("Cannot load local Maude preprocessing module")
        _MODULE = maude.getModule("PP-STL-FORMULA-OPERATIONS")
        if _MODULE is None:
            raise RuntimeError("Missing preprocessing module")
    return _MODULE


def _horizon(term, time_bound, negated=False):
    offset = float(tuple(term.arguments())[0])
    return (Geq if negated else Lt)(
        global_clk(), Sub(RealVal(str(time_bound)), RealVal(str(offset)))
    )


def decode(term, time_bound):
    symbol = str(term.symbol()).replace("`", "")
    args = list(term.arguments())
    if symbol == "var":
        return Real(json.loads(str(args[0])))
    if symbol == "prop":
        return Bool(json.loads(str(args[0])))
    if symbol == "horizon":
        return _horizon(term, time_bound)
    if symbol == "~_":
        if str(args[0].symbol()) == "horizon":
            return _horizon(args[0], time_bound, True)
        raise ValueError(
            "Negated unresolved symbolic proposition is unsupported by the tableau construction: "
            + str(term)
        )
    if symbol == "true":
        return Geq(RealVal("0.0"), RealVal("0.0"))
    if symbol == "false":
        return Gt(RealVal("0.0"), RealVal("0.0"))
    if symbol == "universe":
        return universeInterval
    if symbol == "infty":
        return RealVal("inf")
    if symbol == "|_,_,_,_|":
        return Interval(
            str(args[0].symbol()) == "true",
            decode(args[1], time_bound),
            decode(args[2], time_bound),
            str(args[3].symbol()) == "true",
        )
    if not args:
        return RealVal(repr(float(term)))
    if symbol in ["_/\\_", "_\\/_"]:
        return (And if symbol == "_/\\_" else Or)([decode(x, time_bound) for x in args])
    if symbol in ["[]__", "<>__"]:
        return (GloballyFormula if symbol == "[]__" else FinallyFormula)(
            decode(args[0], time_bound), universeInterval, decode(args[1], time_bound)
        )
    if symbol in ["_U[_]_", "_R[_]_"]:
        return (UntilFormula if symbol == "_U[_]_" else ReleaseFormula)(
            decode(args[1], time_bound),
            universeInterval,
            decode(args[0], time_bound),
            decode(args[2], time_bound),
        )
    operators = {"_" + op + "_": cls for cls, op in _BINARY.items()}
    if symbol in operators:
        return operators[symbol](*[decode(a, time_bound) for a in args])
    unary = {op if op != "-" else "-_": cls for cls, op in _UNARY.items()}
    if symbol in unary:
        return unary[symbol](decode(args[0], time_bound))
    raise ValueError("Unsupported rewritten term: " + str(term))


def prepare_formula(formula, threshold, time_bound, *, negate_property=True):
    """Compute weakening(NNF(not phi), epsilon) in Maude, then decode."""
    threshold = float(threshold)
    time_bound = float(time_bound)
    if not math.isfinite(threshold) or threshold < 0:
        raise ValueError("threshold must be finite and nonnegative")
    if not math.isfinite(time_bound) or time_bound <= 0:
        raise ValueError("time bound must be finite and positive")
    module = _module()
    text = encode(formula)
    term = module.parseTerm("(~ " + text + ")" if negate_property else text)
    if term is None:
        raise ValueError("Cannot import formula into Maude preprocessing")
    term.reduce()
    rewritten = module.parseTerm(
        "weaken((" + str(term) + "), " + _number(threshold) + ")"
    )
    if rewritten is None:
        raise ValueError("Cannot apply Maude robustness preprocessing")
    rewritten.reduce()
    ready = module.parseTerm("tableauReady(" + str(rewritten) + ")")
    ready.reduce()
    if str(ready.symbol()) != "true":
        raise ValueError(
            "Unsupported temporal formula after Maude preprocessing: " + str(rewritten)
        )
    return decode(rewritten, time_bound)
