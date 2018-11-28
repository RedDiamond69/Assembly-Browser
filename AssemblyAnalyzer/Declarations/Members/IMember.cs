using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members
{
    public interface IMember
    {
        string Name { get; }
        AccessModifiers AccessModifiers { get; }
    }
}
