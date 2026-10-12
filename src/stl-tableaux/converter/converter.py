import abc

from ..hybrid_automaton.hybrid_automaton import *


class Converter:
    @abc.abstractmethod
    def convert(self, ha: HybridAutomaton):
        pass

    @abc.abstractmethod
    def jp_bound_needed(self):
        pass

    @abc.abstractmethod
    def update_jp_bound(self):
        pass

    @abc.abstractmethod
    def write(self, file_name: str, dir: str):
        pass
    
    @abc.abstractmethod
    def set_range_info(self, range_info: Dict):
        pass
