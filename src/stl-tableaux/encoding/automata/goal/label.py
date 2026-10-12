"""Tableau labels, clock resets and time-bound variables used by the tableau construction."""

from typing import Union

from ....constraints.constraints import Formula, Proposition, Real, RealVal


class ClkAssn(Proposition):
    def __init__(self, clock: Real, value: Union[RealVal, Real]):
        super().__init__()
        self.clock, self.value = clock, value
        self._name = "{} := {}".format(clock, value)

    def __hash__(self):
        return hash(self._name)

    def __eq__(self, other):
        return hash(self) == hash(other)

    def __repr__(self):
        return self._name


def tau_max():
    return Real("tau_max")


def global_clk():
    return Real("gClk")


# dummy class for graph generation
class TableauLabel(Formula):
    def __init__(self, label: str):
        self._str = label

    def __hash__(self):
        return hash(self._str)

    def __eq__(self, other):
        return hash(self) == hash(other)

    def __repr__(self):
        return self._str


# current version


class TEGloballyUp(TableauLabel):
    def __init__(self, clk, interval, formula):
        super().__init__("({})-()[]{}{}".format(clk, interval, formula))


class TEGloballyUpDown(TableauLabel):
    def __init__(self, clk1, clk2, interval, formula):
        super().__init__("({})-({})[]{}{}".format(clk1, clk2, interval, formula))


class TEFinallyUp(TableauLabel):
    def __init__(self, clk, interval, formula):
        super().__init__("({})-()<>{}{}".format(clk, interval, formula))


class TEFinallyUpDown(TableauLabel):
    def __init__(self, clk1, clk2, interval, formula):
        super().__init__("({})-({})<>{}{}".format(clk1, clk2, interval, formula))
