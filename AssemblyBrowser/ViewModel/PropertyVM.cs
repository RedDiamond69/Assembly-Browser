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
        private readonly PropertyDeclaration _propertyDeclaration;

        public string StringPresentation
        {
            get => GetPresentation();
            private set { }
        }

        private string GetPresentation()
        {
            throw new NotImplementedException();
        }

        public PropertyVM(PropertyDeclaration property)
        {
            _propertyDeclaration = property;
        }
    }
}
