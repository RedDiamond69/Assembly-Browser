using AssemblyAnalyzer.Info;

namespace AssemblyAnalyzer
{
    public interface IAssemblyAnalyzer
    {
        AssemblyInfo GetInfo(string asmPath);
    }
}
