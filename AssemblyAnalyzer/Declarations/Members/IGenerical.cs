using System.Collections.Generic;

namespace AssemblyAnalyzer.Declarations.Members
{
    public interface IGenerical
    {
        bool IsGenerical { get; }
        List<string> GenericalParams { get; }
    }
}
