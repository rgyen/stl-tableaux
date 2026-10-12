from .graph import *
from functools import singledispatch
from typing import Optional

from .label import ClkAssn, global_clk, tau_max
from ....constraints.operations import VarSubstitution
from ....hybrid_automaton.hybrid_automaton import *
from ....hybrid_automaton.utils import _reset_to_guard, get_jumps
from ....objects.configuration import Configuration


class HAConverter:
    def __init__(self, tau_subst: VarSubstitution):
        self._tau_subst: VarSubstitution = tau_subst
        self._node2mode_dict: Dict[Node, Mode] = dict()

    def clear(self):
        self._node2mode_dict.clear()

    def _get_clocks(self, graph: TableauGraph) -> Set[Real]:
        clk_s = {global_clk()}
        jps = get_node_jumps(graph)
        for jp in jps:
            for ap in jp.get_ap():
                clk_s.update(_get_clocks_(ap))

        return clk_s

    def _make_time_dynamics(self, clock_vars: Set[Real]) -> Set[Tuple[Real, RealVal]]:
        d_s, one = set(), RealVal("1.0")
        for clk in clock_vars:
            d_s.add((clk, one))
        return d_s

    def _make_initial_bounds(self, clock_vars: Set[Real]) -> Set[Formula]:
        f_s = set()
        zero = RealVal("0.0")
        for clk in clock_vars:
            f_s.add(clk == zero)
        return f_s

    def convert(self, graph: TableauGraph):
        self.clear()

        automata = HybridAutomaton()

        # get initial information
        i_map = self._make_initial_info(graph)

        # get all clock variables used in goals
        # and make time dynamics (i.e., d{clk}/dt = 1)
        clk_s = self._get_clocks(graph)
        d_s = self._make_time_dynamics(clk_s)

        # make clock invariants
        # clk_inv_s = self._make_clk_invariants(clk_s)

        # make initial bounds and conditions
        # b_s = self._make_initial_bounds(clk_s)

        # store initial jumps
        i_jps = set()

        for node in graph.get_nodes():

            # ignore dummy initial
            if node.is_initial():
                continue

            mode = self._make_mode(node in i_map, node.is_final())

            # assert node in i_d
            # get non intermediate goals (i.e., invariants)
            inv, r = self._translate_goals(*self._non_intermediate(node.cur_goals))

            # assert no reset exist
            assert len(r) <= 0

            mode.add_invariant(*inv)
            mode.add_dynamic(*d_s)
            # mode.add_invariant(*clk_inv_s)

            if mode.is_initial():
                p_edg = i_map[node]
                
                # store this jump
                i_jps.add(p_edg)

                i_f, i_r = self._translate_goals(*p_edg.get_ap())

                # sanity check
                # there should be no guards by construction
                assert len(i_f) == 0

                # add initial conditions
                mode.add_init(*_reset_to_guard(i_r))

            automata.add_mode(mode)

            self._node2mode_dict[node] = mode

        # get jumps, and make guard, reset information dictionaries
        jumps = get_node_jumps(graph)

        # ignore not real jumps
        jumps.difference_update(i_jps)

        # make transition
        for jp in jumps:
            s, t = jp.get_src(), jp.get_trg()

            assert s in self._node2mode_dict
            assert t in self._node2mode_dict

            s_m, t_m = self._node2mode_dict[s], self._node2mode_dict[t]
            j_inv, j_r = self._translate_goals(*jp.get_ap())

            # there should be no self loop in the tableau
            # assert s != t

            tr = Transition(s_m, t_m)
            tr.add_guard(*j_inv)
            tr.add_reset(*j_r)

            automata.add_transition(tr)

        # self._remove_equiv_transitions(automata)
        return automata

    @classmethod
    def _make_mode(cls, is_initial=False, is_final=False) -> Mode:
        mode = Mode()

        if is_final:
            mode.set_as_final()

        if is_initial:
            mode.set_as_initial()

        return mode
    
    def _make_clk_invariants(self, clocks: Set[Real]) -> Set[Formula]:
        inv_s, tau_subst = set(), self._tau_subst
        zero, tb = RealVal("0.0"), tau_max()
        for clk in clocks:
            inv_s.add(clk >= zero)
            inv_s.add(tau_subst.substitute(clk <= tb))
        return inv_s

    def _translate_goals(self, *goals) -> Tuple[Set[Formula], Set[Tuple[Real, RealVal]]]:
        tau_subst = self._tau_subst

        # get guards (invariants) and time resets from the goals
        guard_s, r_s = set(), set()
        for g in goals:
            if isinstance(g, ClkAssn):
                # Maude emits clock resets separately from ordinary guards.
                r_s.add((tau_subst.substitute(g.clock), g.value))
            elif isinstance(g, Proposition):
                # other propositions go to invariant
                guard_s.add(tau_subst.substitute(g))
            else:
                # ignore other cases
                continue
        return guard_s, r_s
    
    @classmethod
    def _make_initial_info(cls, graph: TableauGraph) -> Dict[Node, Jump]:
        i_nds = set(filter(lambda x : x.is_initial(), graph.get_nodes()))

        # By construction, there must be exactly one single initial node
        assert len(i_nds) == 1
        
        # actual initial nodes is its successors
        i_nd = i_nds.pop()

        i_info = dict()

        for e in graph.get_next_edges(i_nd):
            # actual init
            i_n = e.get_trg()

            assert i_n not in i_info 
            i_info[i_n] = e

        return i_info

    @classmethod
    def _non_intermediate(cls, goals: Set[Formula]) -> Set[Formula]:
        return set(filter(lambda x: isinstance(x, Proposition), goals))

    @classmethod
    def _remove_equiv_transitions(cls, automata: HybridAutomaton):
        # get jumps
        tr_s: Set[Transition] = set()
        for m in automata.get_modes():
            tr_s = tr_s.union(automata.get_next_edges(m))

        # make equivalent transition dictionary
        equiv = dict()
        for tr in tr_s:
            f_g, f_r = frozenset(tr.guard), frozenset(tr.reset)
            h = (tr.get_src(), f_g, f_r, tr.get_trg())

            if h in equiv:
                equiv[h].add(tr)
            else:
                equiv[h] = {tr}

        for h in equiv:
            # save one to be alive
            equiv[h].pop()

            # remove all the others
            for tr in equiv[h]:
                automata.remove_transition(tr)


class HaBoundProcessor:
    def __init__(self, config: Configuration):
        self._common = config.get_section("common")

    def _make_tb_invariant(self) -> Formula:
        _tb = float(self._common.get_value("time-bound"))
        tb, zero = RealVal(str(_tb)), RealVal("0.0")
        return {global_clk() >= zero, global_clk() <= tb}

    def _make_jp_bound_conditions(self) -> Optional[Tuple[Formula, Tuple[Real, Expr], Tuple[Real, Expr], Formula]]:
        _bound = int(self._common.get_value("bound"))
        one, zero, b_val = RealVal("1.0"), RealVal("0.0"), RealVal(str(_bound))
        jb_c = self._jump_bound_counter()

        # jump-bound condition
        if _bound < 0:
            return None
        else:
            jb_f = {jb_c >= zero, jb_c <= b_val}
            jb_r = (jb_c, jb_c + one)
            jb_d = (jb_c, zero)
            jb_i = jb_c == zero

            return jb_f, jb_r, jb_d, jb_i

    def add_time_bound(self, ha: HybridAutomaton):
        # make time bound invariant
        tb_inv = self._make_tb_invariant()

        # add time bound invariant and jump bound condition
        for m in ha.get_modes():
            m.add_invariant(*tb_inv)

    def add_jump_bound(self, ha: HybridAutomaton):
        # make jump bound invariant
        jb_c = self._make_jp_bound_conditions()

        # add time bound invariant and jump bound condition
        for m in ha.get_modes():

            if m.is_initial() and jb_c is not None:
                # if jump bound conditions exists
                _, _, _, jb_i = jb_c
                m.add_init(jb_i)

            # if jump bound condition exists
            if jb_c is not None:
                jb_f, _, jb_d, _ = jb_c
                m.add_dynamic(jb_d)
                m.add_invariant(*jb_f)

        # add jump bound to the resets and guards
        for jp in get_jumps(ha):
            # add jump bound condition if any exists
            if jb_c is not None:
                jb_f, jb_r, _, _ = jb_c
                jp.add_guard(*jb_f)
                jp.add_reset(jb_r)

    @classmethod
    def _jump_bound_counter(cls):
        return Real("jbc")


@singledispatch
def _get_clocks_(f: Formula) -> Set[Real]:
    raise Exception("failed to get clocks {}".format(f))


@_get_clocks_.register(Binary)
def _(f: Binary) -> Set[Real]:
    if not isinstance(f, Proposition):
        raise Exception("failed to get clocks {}".format(f))

    clk_s = set()

    if isinstance(f.left, Real):
        if f.left.id != tau_max().id:
            clk_s.add(f.left)

    if isinstance(f.right, Real):
        if f.right.id != tau_max().id:
            clk_s.add(f.right)

    return clk_s


@_get_clocks_.register(ClkAssn)
def _(f: ClkAssn) -> Set[Real]:
    return {f.clock}
