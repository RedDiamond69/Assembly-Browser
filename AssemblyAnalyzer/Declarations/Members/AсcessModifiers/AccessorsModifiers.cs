using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.AсcessModifiers
{
    public class AccessorsModifiers : AccessModifiers
    {
        private readonly List<string> _getters;
        private readonly List<string> _setters;

        public List<string> Getters
        {
            get => _getters;
            private set { }
        }

        public List<string> Setters
        {
            get => _setters;
            private set { }
        }

        public AccessorsModifiers(List<string> modifiers, List<string> sharpModifiers, List<string> getters, List<string> setters) : base(modifiers, sharpModifiers)
        {
            Getters = getters;
            Setters = setters;
        }
    }
}
