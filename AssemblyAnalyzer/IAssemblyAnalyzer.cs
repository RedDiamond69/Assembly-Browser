﻿using AssemblyAnalyzer.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer
{
    public interface IAssemblyAnalyzer
    {
        AssemblyInfo GetInfo(string asmPath);
    }
}