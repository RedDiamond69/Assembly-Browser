using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyAnalyzer.Declarations.Members;

namespace AssemblyBrowser.ViewModel
{
    public class MethodVM
    {
        private readonly MethodDeclaration _methodDeclaration;

        public MethodVM(MethodDeclaration methodDeclaration)
        {
            _methodDeclaration = methodDeclaration;
        }
    }
}
