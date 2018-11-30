using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyAnalyzer.Declarations.Members;

namespace AssemblyBrowser.ViewModel
{
    public class PropertyVM
    {
        private PropertyDeclaration property;

        public PropertyVM(PropertyDeclaration property)
        {
            this.property = property;
        }
    }
}
