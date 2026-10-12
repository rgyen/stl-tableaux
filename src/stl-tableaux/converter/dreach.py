import os
import re
import random
import subprocess
from typing import Optional, Tuple, Dict

from .converter import Converter
from .spaceex import _make_model, _make_conf
from ..hybrid_automaton.hybrid_automaton import *
from ..hybrid_automaton.utils import *
from ..constraints.constraints import *
from ..objects.configuration import Configuration


class DreachConverter(Converter):
    def __init__(self, config: Configuration):
        self._model_string = ""
        self._config_string = ""
        self._config: Configuration = config
        self._names: Optional[Tuple[str, str]] = None
        self._range_info = dict()
        self._single_init = False
        self._single_fine = False

    def convert(self, ha: HybridAutomaton):
        self._reset()
        self._preprocessing_hyst(ha)

        # use spaceex converter
        self._model_string, id_map = _make_model(ha)
        self._config_string = _make_conf(ha, self._config, id_map)

        # generate intermediate files
        self._names = self._write_tmp()

    def jp_bound_needed(self):
        return False
    
    def update_jp_bound(self):
        return

    def _write_tmp(self) -> Tuple[str, str] :
        common_section = self._config.get_section("common")
        g_n, b = common_section.get_value("goal"), common_section.get_value("bound")

        rand = random.random()

        m_n = "tmp{}$$_{}_b{}_se_drh.xml".format(rand, g_n, b)
        c_n = "tmp{}$$_{}_b{}_se_drh.cfg".format(rand, g_n, b)

        f = open(m_n, "w")
        f.write(self._model_string)
        f.close()

        f = open(c_n, "w")
        f.write(self._config_string)
        f.close()
        # print("write tmp hybrid automaton to {} and {}".format(m_n, c_n))
        return m_n, c_n

    def write(self, file_name: str, dir: str):
        assert self._names is not None
        m_n, c_n = self._names[0], self._names[1]

        common_section = self._config.get_section("common")
        g_n, b = common_section.get_value("goal"), common_section.get_value("bound")

        root = "{}/{}/{}/dreach".format(dir, file_name, g_n)
        m_dir = "{}/model".format(root)

        o_n = "{}/model.drh".format(m_dir)
        s_n = "{}/run.sh".format(root)

        if not os.path.exists(m_dir):
            os.makedirs(m_dir)

        # get dreach converter binary
        dreach_section = self._config.get_section("dreach")
        hyst_path = dreach_section.get_value("converter-path")
        hyst_jar = "{}/Hyst.jar".format(hyst_path)

        proc = subprocess.Popen(
            ["java", "-jar", hyst_jar, "-input", m_n,
             "-t", "dreach", "\"\"", "-o", o_n],
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE)

        stdout, stderr = proc.communicate()

        self._remove_tmp()

        if stdout:
            print(f'\n{stdout.decode()}')

        if stderr:
            print()
            print("error occurred during hyst dreach converting")
            print(f'{stderr.decode()}')
        else:
            self._update_range(o_n)
            print(indented_str("model file  : {}".format(o_n), 2))
            
            self._create_script(s_n, o_n, root)
            print(indented_str("script file : {}".format(s_n), 2))
    
    def _create_script(self, script_name: str, model_file: str, root: str):
        common_section = self._config.get_section("common")
        b = int(common_section.get_value("bound"))

        dr = self._config.get_section("dreach")
        exec = dr.get_value("executable-path")

        if self._single_init:
            b += 1

        if self._single_fine:
            b += 1

        s = "/usr/bin/time ./{} -l 0 -u {} ./{} >& ./{}/out-log.txt".format(exec, b, model_file, root)
        f = open(script_name, "w")
        f.write(s)
        f.close()

        os.chmod(script_name, 0o755)

    def set_range_info(self, range_info: Dict):
        self._range_info = range_info.copy()

    def _reset(self):
        self._model_string = ""
        self._config_string = ""
        self._names = None
        self._single_init = False
        self._single_fine = False

    def _remove_tmp(self):
        if self._names is not None:
            m_n, c_n = self._names[0], self._names[1]
            if os.path.isfile(m_n):
                os.remove(m_n)

            if os.path.isfile(c_n):
                os.remove(c_n)

    def _preprocessing_hyst(self, ha: HybridAutomaton):
        # checking is enough
        assert len(set(filter(lambda x : x.is_initial(), ha.get_modes()))) == 1
        
        # making single forbidden state if it has more than one forbidden state
        make_single_final(ha)

    def _update_range(self, file_name: str):
        common = self._config.get_section("common")
        trh, tb = common.get_value("time-horizon"), common.get_value("time-bound")
        if trh == "time-bound":
            trh = common.get_value("time-bound")

        # read file
        f = open(file_name, "r")
        input_str = f.read()
        f.close()

        pre = input_str.split("//Vars")
        post = pre[1].split("// start modes")

        c_decls, t_decls = get_decls(post[0])

        decls = list()

        # replace cont range
        for v in c_decls:
            if v in self._range_info:
                decls.append("{} {};".format(self._range_info[v], v))
        
        # replace time range
        decls.append("[0,{}] time;".format(trh))
        for t in t_decls:
            decls.append("[0,{}] {};".format(tb, t))

        # clear range info
        self._range_info.clear()

        # write file
        f = open(file_name, "w")
        input_str = f.write("\n".join([pre[0], "\n".join(decls), post[1]]))
        f.close()



def get_decls(input_string: str):
    result = re.findall(r'\[(\s)*(-?[0-9]*)(\s)*,(\s)*(-?[0-9]*)(\s)*\](\s)*(.*)\;', input_string)
    if result:
        cont_v, time_v = list(), list()
        for r in result:
            # l, u, v = r[1], r[4], r[7]
            v = r[7]
            # print("[{},{}] {}".format(l, u, v))
            if v == "time":
                continue
            elif v == "gClk" or "clk" in v:
                time_v.append(v)
            else:
                cont_v.append(Real(r[7]))
        return cont_v, time_v
    else:
        raise Exception("failed to create an automaton")
