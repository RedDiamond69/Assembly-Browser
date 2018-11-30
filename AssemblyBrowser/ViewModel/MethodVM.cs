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
        private MethodDeclaration method;

        public MethodVM(MethodDeclaration method)
        {
            this.method = method;
        }
    }
}
