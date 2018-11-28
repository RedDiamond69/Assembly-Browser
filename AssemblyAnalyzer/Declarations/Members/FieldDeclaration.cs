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

        }

        public FieldDeclaration(string name)
        {
        }
    }
}
