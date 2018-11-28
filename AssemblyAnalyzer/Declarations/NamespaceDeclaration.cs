using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations
{
    public class NamespaceDeclaration
    {
        private readonly List<TypeDeclaration> _typeDeclarations;

        public string Name
        {
            get;
            private set;
        }
        public List<TypeDeclaration> TypeDeclarations
        {
            get => _typeDeclarations;
            private set { }
        }

        public void AddType(TypeDeclaration typeDeclaration) => _typeDeclarations.Add(typeDeclaration);

        public NamespaceDeclaration(string name)
        {
            Name = name;
            _typeDeclarations = new List<TypeDeclaration>();
        }
    }
}
