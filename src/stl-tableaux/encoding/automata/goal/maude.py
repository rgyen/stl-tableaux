import re
from functools import singledispatch
from typing import Dict, Set
from stl2tableaux.constraints.operations import Substitution
import maude
import xml.etree.ElementTree as ElemTree
from stl2tableaux.constraints.constraints import *
from stl2tableaux.encoding.automata.goal.label import (
    ClkAssn,
    global_clk,
    tau_max,
    TableauLabel,
    TEGloballyUp,
    TEGloballyUpDown,
    TEFinallyUp,
    TEFinallyUpDown,
)
from stl2tableaux.encoding.automata.goal.graph import *
from pathlib import Path

def getChild(term, n):
    for idx, t in enumerate(term.arguments()):
        if idx == n:
            return t

    raise Exception("failed")


class MaudeHelper:
    def __init__(self):

        # initialize Maude and load Tableau gen module
        maude.init(advise=False)
        self.module = maude.getModule('TABLEAU-GEN-TEST')

        if self.module is None:
            maude.load(str(Path(__file__).parent / 'rule.maude'))
            self.module = maude.getModule('TABLEAU-GEN-TEST')

        assert self.module is not None

        self.sort_list = [
            "Bool", "Number", "Interval", "Float", "Formula", "Prop", "IntvPred", "CIntvPred", "Tableau",
            "Clock", "Judgement", "NeSet{Judgement}", "Set{Judgement}", "ClkReset", "NeSet{ClkReset}", "Set{ClkReset}",
            "TState", "Set{TState}", "Nat", "String", "Set{TTrans}", "TTrans",
        ]
        self.symb_list = [
            ("|_,_,_,_|", ["Bool", "Number", "Number", "Bool"], "Interval"),
            ("Num", ["String"], "Number"),
            ("true", [], "Bool"), ("false", [], "Bool"),
            ("<Floats>", [], "Float"), ("infty", [], "Number"),

            # formula
            ("_/\\_" , ["Formula"  , "Formula"] , "Formula"),
            ("_\\/_" , ["Formula"  , "Formula"] , "Formula"),
            ("_U_"  , ["Formula"  , "Formula"] , "Formula"),
            ("_R_"  , ["Formula"  , "Formula"] , "Formula"),
            ("[]__" , ["Interval" , "Formula"] , "Formula"),
            ("<>__" , ["Interval" , "Formula"] , "Formula"),
            ("[]_" , ["Formula"] , "Formula"),
            ("<>_" , ["Formula"] , "Formula"),

            # Clock
            ("_:=_", ["Clock", "Number"], "ClkReset"),

            # Interval predicate
            ("[_]",  ["Formula"], "IntvPred"),
            ("(_,_)-(_,_)[]__", ["Bool", "Clock", "Clock", "Bool", "Interval", "Formula"], "CIntvPred"),
            ("(_,_)-(_,_)<>__", ["Bool", "Clock", "Clock", "Bool", "Interval", "Formula"], "CIntvPred"),
            ("(_,_)-()[]__", ["Bool", "Clock", "Interval", "Formula"], "CIntvPred"),
            ("(_,_)-()<>__", ["Bool", "Clock", "Interval", "Formula"], "CIntvPred"),

            # simple version
            ("(_)-(_)[]__", ["Clock", "Clock", "Interval", "Formula"], "CIntvPred"),
            ("(_)-(_)<>__", ["Clock", "Clock", "Interval", "Formula"], "CIntvPred"),
            ("(_)-()[]__", ["Clock", "Interval", "Formula"], "CIntvPred"),
            ("(_)-()<>__", ["Clock", "Interval", "Formula"], "CIntvPred"),

            # Judgement
            ("*", [], "Judgement"),
            ("lc?", ["Bool"], "Judgement"),
            ("X_", ["Set{Judgement}"], "Judgement"),
            ("_._", ["Set{ClkReset}", "Set{Judgement}"], "Judgement"),

            ("_<=[_]_", ["Clock", "Bool", "Number"], "Judgement"),
            ("_>=[_]_", ["Clock", "Bool", "Number"], "Judgement"),
            ("_<=_", ["Clock", "Number"], "Judgement"),
            ("_>=_", ["Clock", "Number"], "Judgement"),

            # Aux function
            ("gen", ["Formula"], "Tableau"), ("initDummy", [], "TState"),
            ("isFinalState", ["TState", "Set{TTrans}"], "Bool"),
            ("getStateLabel", ["TState"], "Set{Judgement}"),
            ("simplify", ["Tableau"], "Tableau"),
            ("prop", ["Nat"], "Prop"),
        ]
        self.sort_dict = dict()
        self.symb_dict = dict()

        self._make_sort_dict()
        self._make_symb_dict()

    def _make_sort_dict(self):
        assert self.module != None

        for sort in self.sort_list:
            self.sort_dict[sort] = self.module.findSort(sort)

    def _make_symb_dict(self):
        assert self.module != None

        for (symb, dom, ran) in self.symb_list:
            self.symb_dict[symb] = self.module.findSymbol(symb, list(map(lambda x : self.sort_dict[x].kind(), dom)), self.sort_dict[ran].kind())

    def maude2py(self, term):
        # Currently, only support translation for simple Decomp rules
        if self.module is None:
            raise Exception("no module set")

        symb, sort = term.symbol(), term.getSort()

        if sort == self.sort_dict["Prop"]:
            return Bool(str(term))

        if sort == self.sort_dict["Clock"]:
            # rename clk(N) to clkN
            rn = re.sub(r'\bclk\s*\(\s*([A-Za-z0-9_]+)\s*\)', r'clk\1', str(term))
            return Real(rn)

        if symb == self.symb_dict["true"]:
            return BoolVal("True")

        if symb == self.symb_dict["false"]:
            return BoolVal("False")

        if symb == self.symb_dict["Num"]:
            return RealVal(str(getChild(term, 0)).replace("\"",""))

        if symb == self.symb_dict["infty"]:
            return RealVal("inf")

        if symb == self.symb_dict["|_,_,_,_|"]:
            l, lv, rv, r = [child for child in term.arguments()]
            return Interval(str(l).lower() == "true", *map(lambda x : self.maude2py(x), [lv, rv]), str(r).lower() == "true")

        if symb == self.symb_dict["_/\\_"]:
            return And([self.maude2py(child) for child in term.arguments()])

        if symb == self.symb_dict["_\\/_"]:
            return Or([self.maude2py(child) for child in term.arguments()])

        if symb == self.symb_dict["[]__"]:
            iv, f = [child for child in term.arguments()]
            return GloballyFormula(self.maude2py(iv), universeInterval, self.maude2py(f))

        if symb == self.symb_dict["<>__"]:
            iv, f = [child for child in term.arguments()]
            return FinallyFormula(self.maude2py(iv), universeInterval, self.maude2py(f))

        if symb == self.symb_dict["[]_"]:
            return GloballyFormula(universeInterval, universeInterval, self.maude2py(getChild(term, 0)))

        if symb == self.symb_dict["<>_"]:
            return FinallyFormula(universeInterval, universeInterval, self.maude2py(getChild(term, 0)))

        if symb == self.symb_dict["_U_"]:
            l, r = [child for child in term.arguments()]
            return UntilFormula(universeInterval, universeInterval, self.maude2py(l), self.maude2py(r))

        if symb == self.symb_dict["_R_"]:
            l, r = [child for child in term.arguments()]
            return ReleaseFormula(universeInterval, universeInterval, self.maude2py(l), self.maude2py(r))

        # Judgement
        if sort in [self.sort_dict["NeSet{Judgement}"], self.sort_dict["Set{Judgement}"],
                    self.sort_dict["NeSet{ClkReset}"], self.sort_dict["Set{ClkReset}"]]:
            return set(map(lambda x : self.maude2py(x), [child for child in term.arguments()]))

        if symb == self.symb_dict["*"]:
            return global_clk() >= tau_max()

        if symb == self.symb_dict["[_]"]:
            return self.maude2py(getChild(term, 0))

        if symb == self.symb_dict["_:=_"]:
            return ClkAssn(*[self.maude2py(c) for c in term.arguments()])

        if symb == self.symb_dict["_<=_"]:
            return Leq(*[self.maude2py(c) for c in term.arguments()])

        if symb == self.symb_dict["_>=_"]:
            return Geq(*[self.maude2py(c) for c in term.arguments()])

        if symb == self.symb_dict["(_)-(_)[]__"]:
            c, d, intv, f = [self.maude2py(child) for child in term.arguments()]
            return TEGloballyUpDown(c, d, intv, f)

        if symb == self.symb_dict["(_)-()[]__"]:
            c, intv, f = [self.maude2py(child) for child in term.arguments()]
            return TEGloballyUp(c, intv, f)

        if symb == self.symb_dict["(_)-(_)<>__"]:
            c, d, intv, f = [self.maude2py(child) for child in term.arguments()]
            return TEFinallyUpDown(c, d, intv, f)

        if symb == self.symb_dict["(_)-()<>__"]:
            c, intv, f = [self.maude2py(child) for child in term.arguments()]
            return TEFinallyUp(c, intv, f)

        raise Exception("failed to translate {}".format(term))

    def py2maude(self, formula):
        # Convert a formula AST to a Maude term.
        return self.module.parseTerm(obj2maude(formula))

    def getSymbol(self, string: str):
        return self.symb_dict[string]

    def isSort(self, term, string: str):
        return term.getSort() == self.sort_dict[string]

    def gen(self, formula: Formula):
        gen_query = self.symb_dict["gen"].makeTerm([self.py2maude(formula)])
        gen_query.reduce()

        return gen_query


class MaudeTableauGenerator:
    def __init__(self):
        self.maude_helper = MaudeHelper()
        self._formula = None
        self._tableau = None
        self._prop_subst = Substitution()
        self._dumper = TableauDumper(self.maude_helper)

    def make_graph(self, formula: Formula):
        prop_dict = dict()

        self._formula = abst_formula(formula, prop_dict, uid())
        for k, v in prop_dict.items():
            self._prop_subst.add(v, k)

        self._tableau = self.maude_helper.gen(self._formula)

    def get_graph(self) -> TableauGraph:
        # initial states
        init = self.maude_helper.getSymbol("initDummy").makeTerm([])

        c1, c2 = getChild(self._tableau, 0), getChild(self._tableau, 1)

        if self.maude_helper.isSort(c1, "TState"):
            sts = {c1}
        else:
            sts = set([state for state in c1.arguments()])

        if self.maude_helper.isSort(c2, "TTrans"):
            jps = {c2}
        else:
            jps = set([tr for tr in c2.arguments()])

        # convert to Python Tableau graph
        is_final_symbol = self.maude_helper.getSymbol("isFinalState")
        get_state_label = self.maude_helper.getSymbol("getStateLabel")

        node2v_dict: Dict[Node, 'Term'] = dict()

        graph = TableauGraph(self._formula)

        for node in sts:
            final_check = is_final_symbol.makeTerm([node, c2])
            final_check.reduce()

            is_init = node == init
            is_final = str(final_check).lower() == "true"

            lb = get_state_label.makeTerm([node])
            lb.reduce()

            lb = self.maude_helper.maude2py(lb)

            if not isinstance(lb, Set):
                lbs = {self._prop_subst.substitute(lb)}
            else:
                lbs = set(map(lambda x : self._prop_subst.substitute(x), lb))

            node2v_dict[node] = Node(lbs, set(), set(), is_initial=is_init, is_final=is_final)

            graph.add_node(node2v_dict[node])

        for jp in jps:
            jp_src, jp_trg = getChild(jp, 0), getChild(jp, 3)
            guard, reset = getChild(jp, 1), getChild(jp, 2)

            gs = self.maude_helper.maude2py(guard)
            rs = self.maude_helper.maude2py(reset)

            if not isinstance(gs, Set):
                gs = {gs}

            if not isinstance(rs, Set):
                rs = {rs}

            prev_v = node2v_dict[jp_src]
            succ_v = node2v_dict[jp_trg]

            graph.add_jump(Jump(prev_v, succ_v, gs.union(rs)))

        # The graph includes a dummy initial state for the converter interface.
        # Remove states unreachable from this initial state.
        graph.remove_unreachable()

        return graph

    def reduce(self):
        assert self._tableau is not None

        rm_symb = self.maude_helper.getSymbol("simplify")

        self._tableau = rm_symb.makeTerm([self._tableau])
        self._tableau.reduce()

    def clear(self):
        self._formula = None
        self._tableau = None
        self._prop_subst = Substitution()

    def dump(self, name: str):
        self._dumper.dump(self._tableau, name)


# for debugging purpose
class TableauDumper:
    def __init__(self, maude_helper):
        self.maude_helper = maude_helper

    def dump(self, raw_tableau, o_name: str):
        init = self.maude_helper.getSymbol("initDummy").makeTerm([])
        empty_g = self.maude_helper.module.parseTerm("(empty).Set{Judgement}")
        empty_r = self.maude_helper.module.parseTerm("(empty).Set{ClkReset}")

        c1, c2 = getChild(raw_tableau, 0), getChild(raw_tableau, 1)

        if self.maude_helper.isSort(c1, "TState"):
            sts = {c1}
        else:
            sts = set([state for state in c1.arguments()])

        if self.maude_helper.isSort(c2, "TTrans"):
            jps = {c2}
        else:
            jps = set([tr for tr in c2.arguments()])

        sts.add(init)

        # convert to Python Tableau graph
        is_final_symbol = self.maude_helper.getSymbol("isFinalState")

        node2v_dict: Dict[Node, ElemTree.Element] = dict()
        node_id_dict: Dict[Node, int] = dict()

        # print(ha)
        root = ElemTree.Element("automata")
        root.set("name", "am:{}".format(o_name))
        root.set("visible", "true")

        # print("========= node =========")
        # print()
        for node_id, node in enumerate(sts):
            v = ElemTree.Element("vertex")
            node2v_dict[node] = v
            node_id_dict[node] = node_id
            root.append(v)

            final_check = is_final_symbol.makeTerm([node, c2])
            final_check.reduce()

            v.set("id", str(node_id))
            v.set("x", str(node_id * 10))
            v.set("y", str(node_id * 10))
            v.set("initial", str(node == init).lower())
            v.set("final", str(final_check))

            if node == init:
                continue

            prop = ElemTree.SubElement(v, "atom")
            prop.text = str(getChild(node, 0))

        for jp in jps:
            jp_src, jp_trg = getChild(jp, 0), getChild(jp, 3)
            guard, reset = getChild(jp, 1), getChild(jp, 2)

            e = ElemTree.Element("edge")
            root.append(e)

            e.set("id", str(id(jp)))
            p = ElemTree.SubElement(e, "pred")
            s = ElemTree.SubElement(e, "succ")

            p.text = str(node_id_dict[jp_src])
            s.text = str(node_id_dict[jp_trg])

            if guard != empty_g:
                g_c = str(guard).split(",")
                for g_cstr in g_c:
                    prop = ElemTree.SubElement(e, "guard")
                    prop.text = g_cstr

            if reset != empty_r:
                r_c = str(reset).split(",")
                for r_cstr in r_c:
                    prop = ElemTree.SubElement(e, "reset")
                    prop.text = r_cstr

            prev_v = node2v_dict[jp_src]
            p = ElemTree.SubElement(prev_v, "succ")
            p.text = str(id(jp))

            succ_v = node2v_dict[jp_trg]
            p = ElemTree.SubElement(succ_v, "pred")
            p.text = str(id(jp))

        _pretty_print(root)
        tree = ElemTree.ElementTree(root)

        with open("{}.atm".format(o_name), "wb") as file:
            tree.write(file)



@singledispatch
def obj2maude(const: Union[Formula, Expr]):
    raise Exception("fail to translate to Maude object ({})".format(const))


@obj2maude.register(Bool)
def _(const: Bool):
    return const.id


@obj2maude.register(And)
def _(const: And):
    assert len(const.children) == 2
    return "({} /\\ {})".format(*[obj2maude(c) for c in const.children])


@obj2maude.register(Or)
def _(const: Or):
    assert len(const.children) == 2
    return "({} \\/ {})".format(*[obj2maude(c) for c in const.children])


@obj2maude.register(Interval)
def _(const: Interval):
    le, re = str(const.left_end).lower(), str(const.right_end).lower()

    assert isinstance(const.left, RealVal) and isinstance(const.right, RealVal)

    lv = "infty" if const.left.value == "inf" else "Num(\"{}\")".format(const.left.value)
    rv = "infty" if const.right.value == "inf" else "Num(\"{}\")".format(const.right.value)

    return "| {},{},{},{} |".format(le, lv, rv, re)


@obj2maude.register(GloballyFormula)
def _(const: GloballyFormula):
    if const.local_time == universeInterval:
        return "([] {})".format(obj2maude(const.child))
    return "([] {} {})".format(obj2maude(const.local_time), obj2maude(const.child))


@obj2maude.register(FinallyFormula)
def _(const: FinallyFormula):
    if const.local_time == universeInterval:
        return "(<> {})".format(obj2maude(const.child))
    return "(<> {} {})".format(obj2maude(const.local_time), obj2maude(const.child))


@obj2maude.register(UntilFormula)
def _(const: UntilFormula):
    assert const.local_time == universeInterval
    return "({} U {})".format(obj2maude(const.left), obj2maude(const.right))


@obj2maude.register(ReleaseFormula)
def _(const: ReleaseFormula):
    assert const.local_time == universeInterval
    return "({} R {})".format(obj2maude(const.left), obj2maude(const.right))



@singledispatch
def abst_formula(const: Union[Formula, Expr], abst_dict, id_gen) -> Formula:
    raise Exception("fail to abstract ({})".format(const))


@abst_formula.register(Proposition)
def _(const: Proposition, abst_dict, id_gen):
    if const in abst_dict:
        return abst_dict[const]

    b = Bool("p({})".format(next(id_gen)))
    abst_dict[const] = b

    return b


@abst_formula.register(And)
def _(const: And, abst_dict, id_gen):
    assert len(const.children) == 2
    return And([abst_formula(c, abst_dict, id_gen) for c in const.children])


@abst_formula.register(Or)
def _(const: Or, abst_dict, id_gen):
    assert len(const.children) == 2
    return Or([abst_formula(c, abst_dict, id_gen) for c in const.children])


@abst_formula.register(GloballyFormula)
def _(const: GloballyFormula, abst_dict, id_gen):
    return GloballyFormula(const.local_time, const.global_time, abst_formula(const.child, abst_dict, id_gen))


@abst_formula.register(FinallyFormula)
def _(const: FinallyFormula, abst_dict, id_gen):
    return FinallyFormula(const.local_time, const.global_time, abst_formula(const.child, abst_dict, id_gen))


@abst_formula.register(UntilFormula)
def _(const: UntilFormula, abst_dict, id_gen):
    assert hash(const.local_time) == hash(universeInterval)
    return UntilFormula(const.local_time, const.global_time, abst_formula(const.left, abst_dict, id_gen), abst_formula(const.right, abst_dict, id_gen))


@abst_formula.register(ReleaseFormula)
def _(const: ReleaseFormula, abst_dict, id_gen):
    assert hash(const.local_time) == hash(universeInterval)
    return ReleaseFormula(const.local_time, const.global_time, abst_formula(const.left, abst_dict, id_gen), abst_formula(const.right, abst_dict, id_gen))


def uid():
    i = 0
    while True:
        yield i
        i += 1


# @obj2maude.register(Geq)
# def _(const: Geq):
#     return obj2maude(const.left) + " >= " + obj2maude(const.right)


# @obj2maude.register(Gt)
# def _(const: Gt):
#     return obj2maude(const.left) + " > " + obj2maude(const.right)


# @obj2maude.register(Leq)
# def _(const: Leq):
#     return obj2maude(const.left) + " <= " + obj2maude(const.right)


# @obj2maude.register(Lt)
# def _(const: Geq):
#     return obj2maude(const.left) + " < " + obj2maude(const.right)


# @obj2maude.register(Eq)
# def _(const: Eq):
#     return "{} = {}".format(obj2maude(const.left), obj2maude(const.right))


# @obj2maude.register(Add)
# def _(const: Add):
#     return "(" + obj2maude(const.left) + " + " + obj2maude(const.right) + ")"


# @obj2maude.register(Sub)
# def _(const: Sub):
#     return "(" + obj2maude(const.left) + " - " + obj2maude(const.right) + ")"


# @obj2maude.register(Neg)
# def _(const: Neg):
#     return "(-" + obj2maude(const.child) + ")"


# @obj2maude.register(Mul)
# def _(const: Mul):
#     return "(" + obj2maude(const.left) + " * " + obj2maude(const.right) + ")"


# @obj2maude.register(Div)
# def _(const: Div):
#     return "(" + obj2maude(const.left) + " / " + obj2maude(const.right) + ")"


# @obj2maude.register(Pow)
# def _(const: Pow):
#     return "(" + obj2maude(const.left) + " ** " + obj2maude(const.right) + ")"


# @obj2maude.register(Sqrt)
# def _(const: Sqrt):
#     return "(sqrt ({}))".format(obj2maude(const.child))


# @obj2maude.register(Sin)
# def _(const: Sin):
#     return "(sin ({}))".format(obj2maude(const.child))


# @obj2maude.register(Cos)
# def _(const: Cos):
#     return "(cos ({}))".format(obj2maude(const.child))


# @obj2maude.register(Tan)
# def _(const: Tan):
#     return "(tan ({}))".format(obj2maude(const.child))


def _pretty_print(current, parent=None, index=-1, depth=0):
    for i, node in enumerate(current):
        _pretty_print(node, current, i, depth + 1)
    if parent is not None:
        if index == 0:
            parent.text = '\n' + ('\t' * depth)
        else:
            parent[index - 1].tail = '\n' + ('\t' * depth)
        if index == len(parent) - 1:
            current.tail = '\n' + ('\t' * (depth - 1))
