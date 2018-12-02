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
        private readonly FieldDeclaration _fieldDeclaration;

        public FieldVM(FieldDeclaration fieldDeclaration)
        {
            _fieldDeclaration = fieldDeclaration;
        }
    }
}
