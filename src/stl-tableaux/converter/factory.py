from stl2tableaux.objects.configuration import Configuration
from .dreach import DreachConverter
from .flowstar import FlowStarConverter
from .spaceex import SpaceExConverter
from .satreach import SatReachConverter


class ConverterFactory:
    def __init__(self, config: Configuration):
        self._config = config

    def createConverter(self):

        common_section = self._config.get_section("common")
        solver_ty = common_section.get_value("solver")

        if solver_ty == "flowstar":
            return FlowStarConverter(self._config)
        elif solver_ty == "spaceex":
            return SpaceExConverter(self._config)
        elif solver_ty == "dreach":
            return DreachConverter(self._config)
        elif solver_ty == "sat-reach":
            return SatReachConverter(self._config)
        else:
            raise Exception("{} is not a valid reachable solver".format(solver_ty))
