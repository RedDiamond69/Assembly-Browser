﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members
{
    public interface IGenerical
    {
        bool IsGenerical { get; }
        List<string> GenericalParams { get; }
    }
}