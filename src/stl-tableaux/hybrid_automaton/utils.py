from itertools import product
from typing import FrozenSet

from ..constraints.operations import get_vars
from ..encoding.automata.goal.label import global_clk
from ..hybrid_automaton.hybrid_automaton import *
from ..smt.abstract_solver import SMTSolver
from ..smt.z3 import Z3Solver
from ..objects.configuration import *


def compose(tableau_ha: HybridAutomaton, system_ha: HybridAutomaton) -> HybridAutomaton:    
    # first add self loops before composition    
    add_self_loop(tableau_ha)
    add_self_loop(system_ha)
    
    ha = HybridAutomaton()

    # assert that there is exactly one initial states in system hybrid automaton
    sys_i_ms = set(filter(lambda x : x.is_initial(), system_ha.get_modes()))
    assert len(sys_i_ms) == 1

    sys_i = sys_i_ms.pop()

    # make unique single initial
    init_mode = Mode()

    tab_v_s = get_ha_vars(tableau_ha)
    tab_v_s.add(global_clk())

    sys_v_s = get_ha_vars(system_ha)

    clk_v_s = tab_v_s.difference(sys_v_s)
    one, zero = RealVal("1.0"), RealVal("0.0")

    # add zero dynamics and initial conditions of system hybrid automaton
    init_mode.add_dynamic(*[(v, zero) for v in sys_v_s])
    init_mode.add_init(*sys_i.init) 

    # set initial for tableau automaton similar to the system hybrid automaton
    # Give the initial region positive duration by advancing the global clock,
    # then resetting it when entering the composed automaton.
    for v in clk_v_s:
        if v.id == global_clk().id:
            init_mode.add_dynamic((v, one))
        else:
            init_mode.add_dynamic((v, zero))
    
    init_mode.add_init(*[(v == zero) for v in clk_v_s])

    # add to hybrid automata
    init_mode.set_as_initial()    
    ha.add_mode(init_mode)

    # make modes
    mode_dict = dict()
    for (mode1, mode2) in product(tableau_ha.get_modes(), system_ha.get_modes()):
        mode = Mode()

        mode.add_dynamic(*{(v, mode1.dynamics[v]) for v in mode1.dynamics})
        mode.add_dynamic(*{(v, mode2.dynamics[v]) for v in mode2.dynamics})

        mode.add_invariant(*mode1.invariant)
        mode.add_invariant(*mode2.invariant)

        ha.add_mode(mode)

        # connect to real initial mode
        if mode1.is_initial() and mode2.is_initial():
            tr = Transition(init_mode, mode)
            tr.add_reset(*_guard_to_reset(mode1.init))
            tr.add_reset((global_clk(), zero))
            ha.add_transition(tr)

        if mode1.is_final() and mode2.is_final():
            mode.set_as_final()

        mode_dict[(mode1, mode2)] = mode

    # make transitions
    for k in mode_dict:
        src = mode_dict[k]
        if src.is_initial():
            continue

        m1, m2 = k
        
        # calculate all possible combination of outgoing edges
        for (jp1, jp2) in product(tableau_ha.get_next_edges(m1), system_ha.get_next_edges(m2)):
            trg_pair = (jp1.get_trg(), jp2.get_trg())

            # sanity check
            # assert that out going state exists
            assert trg_pair in mode_dict
            
            # by construction, there is no incoming edges to 
            # initial state of tableau hybrid automaton 
            # assert not jp1.get_trg().is_initial()

            trg = mode_dict[trg_pair]

            tr = Transition(src, trg)

            tr.add_guard(*jp1.guard)
            tr.add_guard(*jp2.guard)

            tr.add_reset(*jp1.reset)
            tr.add_reset(*jp2.reset)

            ha.add_transition(tr)

    # for set structural properties: assoc, comm 
    remove_equal_jumps(ha)

    # remove self loops
    for m in ha.get_modes():
        for e in ha.get_next_edges(m):
            # self loop
            if e.get_trg() == m and _is_redundant_self_loop(e):
                ha.remove_transition(e)

    return ha


def add_self_loop(ha: HybridAutomaton):
    for m in ha.get_modes():
        tr = Transition(m, m)
        ha.add_transition(tr)


def _is_redundant_self_loop(tr: Transition):
    for (v, e) in tr.reset:
        if not isinstance(e, Real):
            return False
        
        if v.id != e.id:
            return False
        
    return True

def remove_unreachable(ha: HybridAutomaton):
    _remove_unreachable_to_final(ha)
    _remove_unreachable_from_initial(ha)


def _remove_unreachable_from_initial(ha: HybridAutomaton):
    f_ns = set(filter(lambda x: x.is_initial(), ha.get_modes()))
    new_states, reachable = f_ns.copy(), f_ns.copy()

    while len(new_states) > 0:
        temp = set()
        for s in new_states:
            temp.update(ha.get_next_vertices(s))
        new_states = temp.difference(reachable)
        reachable.update(new_states)

    unreachable = ha.get_modes().difference(reachable)
    for s in unreachable:
        ha.remove_mode(s)


def _remove_unreachable_to_final(ha: HybridAutomaton):
    f_ns = set(filter(lambda x: x.is_final(), ha.get_modes()))
    new_states, reachable = f_ns.copy(), f_ns.copy()

    while len(new_states) > 0:
        temp = set()
        for s in new_states:
            temp.update(ha.get_pred_vertices(s))
        new_states = temp.difference(reachable)
        reachable.update(new_states)

    unreachable = ha.get_modes().difference(reachable)
    for s in unreachable:
        ha.remove_mode(s)


def remove_contradiction(ha: HybridAutomaton):
    # make solver config
    config = Configuration()
    section = Section()
    section.name = "z3"
    section.arguments["logic"] = "QF_LRA"
    config.add_section(section)

    # initialize solver
    solver = Z3Solver(config)
    to_be_removed_modes = set()

    # 1) invariant contradiction checking
    for m in ha.get_modes():
        r = solver.check_sat(*m.invariant)
        
        # contradiction
        if r == SMTSolver.unsat:
            to_be_removed_modes.add(m)
    
    for m in to_be_removed_modes:
        ha.remove_mode(m)
    
    jp_s = get_jumps(ha)
    to_be_removed_jp_s = set()

    # 2) jump guard contradiction checking
    for jp in jp_s:
        r = solver.check_sat(*jp.guard)

        # contradiction
        if r == SMTSolver.unsat:
            to_be_removed_jp_s.add(jp)

    for jp in to_be_removed_jp_s:
        ha.remove_transition(jp)

    to_be_removed_jp_s.clear()

    # 3) incoming/outgoing guards and invariant contradiction
    for m in ha.get_modes():

        # incoming
        for jp in ha.get_pred_edges(m):
            r = solver.check_sat(*m.invariant.union(jp.guard))
            
            # contradiction
            if r == SMTSolver.unsat:
                to_be_removed_jp_s.add(jp)

        # outgoing
        for jp in ha.get_next_edges(m):
            r = solver.check_sat(*m.invariant.union(jp.guard))
            
            # contradiction
            if r == SMTSolver.unsat:
                to_be_removed_jp_s.add(jp)

    for jp in to_be_removed_jp_s:
        ha.remove_transition(jp)
    
    import time
    t = time.time()
    remove_unreachable(ha)
    e = time.time()
    print("  removing unreachable: {:.3f}s".format(e - t))


def remove_equal_jumps(ha: HybridAutomaton):
    eq_dict: Dict[Tuple[int, int, FrozenSet[Formula], FrozenSet[Tuple[Variable, Formula]]], Set[Transition]] = dict()
    jp_s = get_jumps(ha)
    for jp in jp_s:
        k = (jp.get_src().id, jp.get_trg().id, frozenset(jp.guard), frozenset(jp.reset))
        if k in eq_dict:
            eq_dict[k].add(jp)
        else:
            eq_dict[k] = {jp}

    for eq in eq_dict:
        eq_dict[eq].pop()
        for o_jp in eq_dict[eq]:
            ha.remove_transition(o_jp)


def get_ha_vars(ha: HybridAutomaton) -> Set[Variable]:
    var_set = set()
    for m in ha.get_modes():
        for v in m.dynamics:
            var_set.add(v)
            var_set.update(get_vars(m.dynamics[v]))

        for inv in m.invariant:
            var_set.update(get_vars(inv))

    jp_s = get_jumps(ha)

    for jp in jp_s:
        for guard in jp.guard:
            var_set.update(get_vars(guard))

        for v, e in jp.reset:
            var_set.add(v)
            var_set.update(get_vars(e))

    return var_set


def get_jumps(ha: HybridAutomaton) -> Set[Transition]:
    jp_s: Set[Transition] = set()
    for m in ha.get_modes():
        jp_s = jp_s.union(ha.get_next_edges(m))

    return jp_s


def get_ha_size(ha: HybridAutomaton):
    return "# mode: {}, # jump: {}".format(len(ha.get_modes()), len(get_jumps(ha)))


def _reset_to_guard(resets):
    return set([(v == val) for (v, val) in resets])


def _guard_to_reset(guards):
    resets = set()

    for guard in guards:
        assert isinstance(guard, Eq)
        resets.add((guard.left, guard.right))

    return resets


def make_single_final(ha: HybridAutomaton):

    if len(set(filter(lambda x : x.is_final(), ha.get_modes()))) == 1:
        return

    v_s = get_ha_vars(ha)
    zero = RealVal("0.0")

    final = Mode()
    final.add_dynamic(*[(v, zero) for v in v_s])
    final.set_as_final()

    ha.add_mode(final)

    i_r = [(v, v) for v in v_s]

    for m in ha.get_modes():
        if m.is_final() and m != final:
            m.set_as_non_final()

            tr = Transition(m, final)
            tr.add_reset(*i_r)

            ha.add_transition(tr)