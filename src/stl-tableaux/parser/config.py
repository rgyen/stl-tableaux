from typing import Union

from functools import lru_cache
from pathlib import Path
from lark import Lark, Transformer

from ..objects.configuration import *


@lru_cache(maxsize=1)
def _grammar():
    return Lark(
        Path(__file__).parents[1].joinpath("syntax/config.lark").read_text(),
        parser="lalr",
    )


class _ConfigTree(Transformer):
    def string_value(self, items):
        text = str(items[0])
        return (
            ",".join(part.strip() for part in text[1:-1].split(","))
            if "," in text
            else text
        )

    def number_value(self, items):
        return str(items[0])

    def run_value(self, items):
        return str(items[0])

    def parents(self, items):
        return [str(x) for x in items]

    def assignment(self, items):
        return str(items[0]), items[1] if len(items) > 1 else ""

    def section(self, items):
        name = str(items[0])
        parents = items[1] if len(items) > 1 and isinstance(items[1], list) else []
        return name, parents, dict(items[2:] if parents else items[1:])

    def start(self, items):
        return items


class ConfigParser:

    def __init__(self):
        # reference
        self.config: Configuration = Configuration()
        self.section_boolean_argument_dict = dict()
        self.section_argument_dict = dict()
        self.type_check_dict = dict()

        self.section_argument_dict["common"] = {
            "threshold",
            "bound",
            "time-bound",
            "solver",
            "goal",
            "time-horizon",
            "file",
        }
        self.section_argument_dict["z3"] = {"logic"}
        self.section_argument_dict["yices"] = {"logic"}
        self.section_argument_dict["dreal"] = {
            "ode-order",
            "ode-step",
            "executable-path",
        }
        self.section_argument_dict["flowstar"] = {
            "max-jumps",
            "ode-type",
            "ode-order",
            "min-step",
            "max-step",
            "executable-path",
        }
        self.section_argument_dict["spaceex"] = {
            "executable-path",
            "iter-max",
            "scenario",
        }
        self.section_argument_dict["dreach"] = {"converter-path", "executable-path"}
        self.section_argument_dict["sat-reach"] = {
            "converter-path",
            "executable-path",
            "time-step",
            "output-vars",
        }

        self.type_check_dict["common"] = {
            ("threshold", "float"),
            ("bound", "integer"),
            ("time-bound", "float"),
            ("file", "str"),
            (
                "solver",
                frozenset(
                    {
                        "z3",
                        "yices",
                        "dreal",
                        "flowstar",
                        "spaceex",
                        "dreach",
                        "sat-reach",
                    }
                ),
            ),
            ("goal", "string"),
            ("time-horizon", "float"),
        }
        self.type_check_dict["z3"] = {("logic", frozenset({"qf_nra", "qf_lra"}))}
        self.type_check_dict["yices"] = {("logic", frozenset(["qf_nra", "qf_lra"]))}
        self.type_check_dict["dreal"] = {
            ("ode-order", "float"),
            ("ode-step", "float"),
            ("executable-path", "path"),
        }
        self.type_check_dict["flowstar"] = {
            ("max-jumps", "integer"),
            ("ode-type", "str"),
            ("ode-order", "integer"),
            ("min-step", "float"),
            ("max-step", "float"),
            ("executable-path", "path"),
        }
        self.type_check_dict["spaceex"] = {
            ("executable-path", "path"),
            ("iter-max", "integer"),
            ("scenario", "str"),
        }
        self.type_check_dict["dreach"] = {
            ("converter-path", "path"),
            ("executable-path", "path"),
        }
        self.type_check_dict["sat-reach"] = {
            ("converter-path", "path"),
            ("executable-path", "path"),
            ("time-step", "float"),
            ("output-vars", "str"),
        }

        self.section_boolean_argument_dict["common"] = {
            "two-step",
            "parallel",
            "visualize",
            "verbose",
            "dump",
        }
        self.section_boolean_argument_dict["z3"] = set()
        self.section_boolean_argument_dict["yices"] = set()
        self.section_boolean_argument_dict["dreal"] = set()
        self.section_boolean_argument_dict["flowstar"] = set()
        self.section_boolean_argument_dict["spaceex"] = set()
        self.section_boolean_argument_dict["dreach"] = set()
        self.section_boolean_argument_dict["sat-reach"] = set()

        self.section_names: List[str] = [
            "common",
            "z3",
            "yices",
            "dreal",
            "flowstar",
            "spaceex",
            "dreach",
            "sat-reach",
        ]

        self.section_mandatory_dict = dict()
        self.section_mandatory_dict["common"] = {"bound", "time-bound"}
        self.section_mandatory_dict["z3"] = set()
        self.section_mandatory_dict["yices"] = set()
        self.section_mandatory_dict["dreal"] = {
            "ode-step",
            "ode-order",
            "executable-path",
        }
        self.section_mandatory_dict["flowstar"] = {
            "max-jumps",
            "ode-type",
            "ode-order",
            "min-step",
            "max-step",
            "executable-path",
        }
        self.section_mandatory_dict["spaceex"] = {
            "executable-path",
            "iter-max",
            "scenario",
        }
        self.section_mandatory_dict["dreach"] = {"converter-path", "executable-path"}
        self.section_mandatory_dict["sat-reach"] = {
            "converter-path",
            "executable-path",
            "time-step",
            "output-vars",
        }

        self.section_selectable_dict: Dict[str, List[Set[str]]] = dict()
        self.section_selectable_dict["common"] = list()
        self.section_selectable_dict["z3"] = list()
        self.section_selectable_dict["yices"] = list()
        self.section_selectable_dict["dreal"] = list()
        self.section_selectable_dict["flowstar"] = list()
        self.section_selectable_dict["spaceex"] = list()
        self.section_selectable_dict["dreach"] = list()
        self.section_selectable_dict["sat-reach"] = list()

    def get_missing_arguments(self, config: Configuration) -> Dict[str, Set[str]]:
        missing_dict = dict()
        for section in config.sections:
            if section.name not in self.section_names:
                raise Exception('"{}" is not a valid section name'.format(section.name))

            mandatory = self.section_argument_dict[section.name]

            is_skip = False
            choices = self.section_selectable_dict[section.name]
            for choice in choices:
                if choice.issubset(set(section.arguments.keys())):
                    is_skip = True
                    break

            if is_skip:
                continue

            missing = mandatory.difference(set(section.arguments.keys()))
            if len(missing) > 0:
                missing_dict[section.name] = missing
        return missing_dict

    def generate_cmd_args(self):
        cmds = set()
        for section_name in self.section_argument_dict:
            cmds.update(self.section_argument_dict[section_name])

        bool_cmds = set()
        for section_name in self.section_boolean_argument_dict:
            bool_cmds.update(self.section_boolean_argument_dict[section_name])
        return cmds, bool_cmds

    def read(
        self, file_name: str, base: Union[Configuration, None] = None
    ) -> Configuration:
        self.config = Configuration()
        if base is not None:
            self.config = base

        f = open(file_name, "r")
        raw_model = f.read()
        f.close()

        raw_model = raw_model.replace("#@", "")
        for name, parent_names, arguments in _ConfigTree().transform(
            _grammar().parse(raw_model)
        ):
            if name not in self.section_names:
                raise ValueError('"' + name + '" is not a valid section name')
            if "encoding" in arguments:
                raise ValueError(
                    "encoding is no longer supported; remove it from the configuration"
                )
            section = Section()
            section.name = name
            section.parent_names.extend(parent_names)
            section.mandatory.extend(self.section_mandatory_dict.get(name, set()))
            for parent_name in parent_names:
                parent = self.find_parent(parent_name)
                if parent is None:
                    raise ValueError(
                        "cannot find definition of a parent " + parent_name
                    )
                section.arguments.update(parent.arguments)
            section.arguments.update(arguments)
            self.config.add_section(section)

        for section in self.config.sections:
            section.arguments = {k: v for k, v in section.arguments.items() if v != ""}

        # set mandatory information
        self.config.set_section_mandatory_dict(self.section_mandatory_dict)
        # set type check information
        self.config.set_type_check_dict(self.type_check_dict)
        return self.config

    def find_parent(self, name: str):
        if name in self.config.sections_by_name:
            return self.config.sections_by_name[name]
        return None
