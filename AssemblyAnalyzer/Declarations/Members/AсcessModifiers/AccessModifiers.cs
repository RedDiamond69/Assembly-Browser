using System.Collections.Generic;

namespace AssemblyAnalyzer.Declarations.Members.AсcessModifiers
{
    public class AccessModifiers
    {
        private readonly List<string> _modifiers;
        private readonly List<string> _sharpModifiers;

        public List<string> Modifiers => _modifiers;
        public List<string> SharpModifiers => _sharpModifiers;

        public AccessModifiers(List<string> modifiers, List<string> sharpModifiers)
        {
            _modifiers = modifiers;
            _sharpModifiers = sharpModifiers;
        }
    }
}
