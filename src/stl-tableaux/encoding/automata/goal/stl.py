import time
import pickle

from .graph import *
from .ha_converter import HAConverter
from .label import tau_max
from .maude import *
from ...robust.preprocess import prepare_formula
from ....constraints.operations import *
from ....hybrid_automaton.hybrid_automaton import *
from ....objects.goal import Goal
from ....objects.configuration import Configuration
from stl2tableaux.hybrid_automaton.utils import *


class StlGoal(Goal):
    def __init__(self, formula: Formula, config: Configuration):
        super().__init__(formula)

        # set configuration
        self._config = config
        common = self._config.get_section("common")

        # check configuration
        assert common.is_argument_in("prop_dict")

        self.threshold = float(common.get_value("threshold"))
        self.prop_dict: Dict = common.arguments["prop_dict"]
        self.tau_max = float(common.get_value("time-bound"))
        self.bound = int(common.get_value("bound"))

        # build substitution for user-defined propositions
        subst = Substitution()
        for p in self.prop_dict:
            subst.add(p, self.prop_dict[p])

        self.tau_subst = VarSubstitution()
        self.tau_subst.add(tau_max(), RealVal(str(self.tau_max)))

        # Normalize and weaken the negated property in Maude
        self._formula = prepare_formula(subst.substitute(self.formula), self.threshold, self.tau_max)
        self._hybrid_converter = HAConverter(self.tau_subst)

        self._is_dump = True if common.get_value("dump") == "true" else False

        self._maude_helper = MaudeTableauGenerator()

    def encode(self, tableau_only=False):

        self._hybrid_converter.clear()
        alg_s_t = time.time()

        self._maude_helper.clear()
        self._maude_helper.make_graph(self._formula)

        alg_e_t = time.time()
        
        graph = self._maude_helper.get_graph()
        
        print()
        print(indented_str("finish construction", 2))
        print(indented_str("running time: {:.3f}s".format(alg_e_t - alg_s_t), 4))
        print(indented_str("tableau info: ({})".format(get_graph_info(graph)), 4)) 

        # save pickle
        if self._is_dump:
            # with open("out-non-tableau.pickle","wb") as fw:
            #     pickle.dump(graph, fw)
            self._maude_helper.dump("out-non-tableau")

        print()
        print("Applying tableau reduction")
        # print(indented_str("removing unreachable states", 2))
        # u_t_s = time.time()
        # graph.remove_unreachable()
        # u_t_e = time.time()
        # print(indented_str("running time: {:.3f}s".format(u_t_e - u_t_s), 4))
        # print(indented_str("tableau info: ({})".format(get_graph_info(graph)), 4))

        print()
        print(indented_str("merging states with prefix and postfix equivalence", 2))
        p_t_s = time.time()

        self._maude_helper.reduce()

        p_t_e = time.time()
 
        graph = self._maude_helper.get_graph()

        print(indented_str("running time: {:.3f}s".format(p_t_e - p_t_s), 4))
        print(indented_str("tableau info: ({})".format(get_graph_info(graph)), 4))

        # print()
        # print(indented_str("removing redundant self loop", 2))
        # s_t_s = time.time()
        # graph.remove_self_loop()
        # e_t_s = time.time()
        # print(indented_str("running time: {:.3f}s".format(e_t_s - s_t_s), 2))
        # print(indented_str("tableau info: ({})".format(get_graph_info(graph)), 2))

        # save pickle
        if self._is_dump:
            # with open("out-fin-tableau.pickle","wb") as fw:
            #     pickle.dump(graph, fw)
            self._maude_helper.dump("out-fin-tableau")

        if tableau_only:
            return graph

        print()
        print("-----------------------------------")
        print("- Tableau to Automata Translation -")
        print("-----------------------------------")
        print()

        t_t_s = time.time()
        ha = self._hybrid_converter.convert(graph)
        t_t_e = time.time()

        print(indented_str("running time: {:.3f}s".format(t_t_e - t_t_s), 2))
        print(indented_str("automaton info: ({})".format(get_ha_size(ha)), 2))
        return ha


def get_graph_info(graph: TableauGraph):
    return "# vertex: {}, # edge: {}".format(len(graph.get_nodes()), len(get_node_jumps(graph)))
