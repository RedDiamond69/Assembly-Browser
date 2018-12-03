using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;

namespace AssemblyAnalyzer.Declarations.Members
{
    public interface IMember
    {
        string Name { get; }
        AccessModifiers AccessModifiers { get; }
    }
}
