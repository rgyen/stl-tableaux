import abc

from ..constraints.constraints import *
from ..encoding.base_encoder import Encoder


class Goal(Encoder):
    def __init__(self, formula: Formula):
        self.formula = formula

    @abc.abstractmethod
    def encode(self):
        pass

    # Return the input formula before encoding.
    def get_formula(self):
        return self.formula
