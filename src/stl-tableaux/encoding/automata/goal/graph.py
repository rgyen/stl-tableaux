from typing import FrozenSet

from ....constraints.constraints import Real, Formula
from ....graph.graph import *
from ....util.printer import indented_str


class TableauGraph(Graph["Node", "Jump"]):
    def __init__(self, formula: Formula):
        Graph.__init__(self)
        self._formula = formula
        self._dummy_node = Node(set(), set(), set())
        self.add_node(self._dummy_node)

    def get_nodes(self):
        return self.vertices

    def add_node(self, node: "Node"):
        self.add_vertex(node)

    def remove_node(self, node: "Node"):
        self.remove_vertex(node)

    def add_jump(self, jump: "Jump"):
        self.add_edge(jump)

    def remove_jump(self, jump: "Jump"):
        self.remove_edge(jump)

    def remove_unreachable(self):
        self._remove_unreachable_to_final()
        self._remove_unreachable_from_initial()

    def _remove_unreachable_from_initial(self):
        f_ns = set(filter(lambda x: x.is_initial(), self.get_nodes()))
        new_states, reachable = f_ns.copy(), f_ns.copy()

        while len(new_states) > 0:
            temp = set()
            for s in new_states:
                temp.update(self.get_next_vertices(s))
            new_states = temp.difference(reachable)
            reachable.update(new_states)

        unreachable = self.get_nodes().difference(reachable)
        for s in unreachable:
            self.remove_node(s)

    def _remove_unreachable_to_final(self):
        f_ns = set(filter(lambda x: x.is_final(), self.get_nodes()))
        new_states, reachable = f_ns.copy(), f_ns.copy()

        while len(new_states) > 0:
            temp = set()
            for s in new_states:
                temp.update(self.get_pred_vertices(s))
            new_states = temp.difference(reachable)
            reachable.update(new_states)

        unreachable = self.get_nodes().difference(reachable)
        for s in unreachable:
            self.remove_node(s)

    def __repr__(self):
        node_str = "node:\n{}".format("\n".join([str(node) for node in self.vertices]))
        edges_str = "jump:\n{}".format(
            "\n".join([str(jp) for jp in get_node_jumps(self)])
        )
        return "\n".join([node_str, edges_str])


class Node:
    def __init__(
        self,
        cur_goals: Set[Formula],
        nxt_goals: Set[Formula],
        invariant: Set[Formula],
        is_initial=False,
        is_final=False,
    ):
        self.cur_goals, self.nxt_goals = cur_goals.copy(), nxt_goals.copy()
        self.invariant = invariant.copy()

        self._is_initial = is_initial
        self._is_final = is_final

    def __repr__(self):
        goal_str = [list(), list()]
        for g in self.cur_goals:
            goal_str[0].append(indented_str(str(g), 6))

        for g in self.nxt_goals:
            goal_str[1].append(indented_str(str(g), 6))

        inv_str = list()
        for f in self.invariant:
            inv_str.append(indented_str(str(f), 6))

        id_info = indented_str("id: {}".format(hash(self)), 4)
        is_initial = indented_str("initial: {}".format(self._is_initial), 4)
        is_final = indented_str("final: {}".format(self._is_final), 4)
        inv = indented_str("inv:\n{}".format("\n".join(inv_str)), 4)
        c_goal_info = indented_str("cur goal:\n{}".format("\n".join(goal_str[0])), 4)
        n_goal_info = indented_str("nxt goal:\n{}".format("\n".join(goal_str[1])), 4)

        return "( Node\n{}\n)".format(
            "\n".join([id_info, is_initial, is_final, inv, c_goal_info, n_goal_info])
        )

    def is_final(self):
        return self._is_final

    def is_initial(self):
        return self._is_initial


class Jump(Edge[Node]):
    def __init__(self, src: Node, trg: Node, ap: Set[Formula]):
        self._src, self._trg = src, trg
        self._ap = frozenset(ap)
        self._hash = hash((src, trg, self._ap))

    def get_ap(self):
        return self._ap

    def __hash__(self):
        return self._hash

    def __eq__(self, other):
        return hash(self) == hash(other)

    def get_src(self) -> Node:
        return self._src

    def get_trg(self) -> Node:
        return self._trg

    def __repr__(self):
        jp_ap = indented_str(
            "ap:\n{}".format("\n".join([indented_str(str(f), 6) for f in self._ap])), 4
        )
        jp_body = indented_str("{} -> {}".format(hash(self._src), hash(self._trg)), 4)

        return "( jump \n{}\n{}\n  )".format(jp_ap, jp_body)


def get_node_jumps(graph: TableauGraph) -> Set[Jump]:
    jp_s: Set[Jump] = set()
    for node in graph.get_nodes():
        jp_s.update(graph.get_next_edges(node))

    return jp_s
