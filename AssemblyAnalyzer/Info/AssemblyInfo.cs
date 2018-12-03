using AssemblyAnalyzer.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Info
{
    public class AssemblyInfo
    {
        private readonly List<NamespaceDeclaration> _namespaceDeclarations;

        public List<NamespaceDeclaration> NamespaceDeclarations => _namespaceDeclarations;

        public void AddOrCreateNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
        {
            NamespaceDeclaration declaration = _namespaceDeclarations.Find(n => n.Name == namespaceDeclaration.Name);
            if (declaration != null)
                foreach (TypeDeclaration typeDeclaration in namespaceDeclaration.TypeDeclarations)
                    declaration.AddType(typeDeclaration);
            else
                _namespaceDeclarations.Add(namespaceDeclaration);
        }

        public AssemblyInfo() => _namespaceDeclarations = new List<NamespaceDeclaration>();
    }
}
