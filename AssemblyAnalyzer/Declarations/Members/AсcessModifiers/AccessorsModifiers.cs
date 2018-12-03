using System.Collections.Generic;

namespace AssemblyAnalyzer.Declarations.Members.AсcessModifiers
{
    public class AccessorsModifiers : AccessModifiers
    {
        private readonly List<string> _getters;
        private readonly List<string> _setters;

        public List<string> Getters => _getters;
        public List<string> Setters => _setters;

        public AccessorsModifiers(List<string> modifiers, List<string> sharpModifiers, List<string> getters, List<string> setters) : base(modifiers, sharpModifiers)
        {
            _getters = getters;
            _setters = setters;
        }
    }
}
