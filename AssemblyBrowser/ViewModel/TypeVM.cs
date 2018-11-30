using AssemblyAnalyzer.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.ViewModel
{
    public class TypeVM
    {
        private readonly TypeDeclaration _typeDeclaration;

        public TypeVM(TypeDeclaration typeDeclaration)
        {
            _typeDeclaration = typeDeclaration;
        }
    }
}
