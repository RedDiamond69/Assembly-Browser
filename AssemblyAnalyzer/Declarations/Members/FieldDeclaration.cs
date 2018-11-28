using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class FieldDeclaration : IMember, IGenerical
    {
        private readonly AccessModifiers _accessModifiers;
        private readonly List<string> _genericalParams;

        public string Name
        {

        }
        public AccessModifiers AccessModifiers
        {
            get => _accessModifiers;
            private set { }
        }
        public bool IsGenerical
        {

        }
        public List<string> GenericalParams
        {
            get => _genericalParams;
            private set { }
        }

        public FieldDeclaration(string name)
        {
        }
    }
}
