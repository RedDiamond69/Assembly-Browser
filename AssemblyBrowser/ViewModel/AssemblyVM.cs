using AssemblyAnalyzer.Declarations;
using AssemblyAnalyzer.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.ViewModel
{
    public class AssemblyVM
    {
        private readonly AssemblyInfo _assemblyInfo;

        public string StringPresentation
        {
            get => String.Empty;
            private set { }
        }
        public IEnumerable<NamespaceVM> DeclaratedNamespaces
        {
            get
            {
                foreach(NamespaceDeclaration namespaceDeclaration in _assemblyInfo.NamespaceDeclarations)
                    yield return new NamespaceVM(namespaceDeclaration);
            }
            private set { }
        }

        public AssemblyVM(AssemblyInfo assemblyInfo) => _assemblyInfo = assemblyInfo;
    }
}
