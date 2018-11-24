using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.AсcessModifiers
{
    public class AccessModifiers
    {
        private readonly List<string> _modifiers;
        private readonly List<string> _sharpModifiers;

        public List<string> Modifiers
        {
            get => _modifiers;
            private set { }
        }
        public List<string> SharpModifiers
        {
            get => _sharpModifiers;
            private set { }
        }

        public AccessModifiers(List<string> modifiers, List<string> sharpModifiers)
        {
            Modifiers = modifiers;
            SharpModifiers = sharpModifiers;
        }
    }
}
