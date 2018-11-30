using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyAnalyzer.Declarations.Members;

namespace AssemblyBrowser.ViewModel
{
    public class FieldVM
    {
        private FieldDeclaration field;

        public FieldVM(FieldDeclaration field)
        {
            this.field = field;
        }
    }
}
