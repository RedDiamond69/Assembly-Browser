using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class FieldDeclaration : IMember
    {
        public string Name => throw new NotImplementedException();
        public AccessModifiers AccessModifiers => throw new NotImplementedException();

        public FieldDeclaration(string name)
        {
        }
    }
}
