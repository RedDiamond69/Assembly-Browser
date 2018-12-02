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

        public string StringPresentation
        {
            get => GetPresentation();
            private set { }
        }

        public FieldVM(FieldDeclaration fieldDeclaration)
        {
            _fieldDeclaration = fieldDeclaration;
        }

        public string GetAccessModifiers(List<string> accessModifiers)
        {
            string modifiersPresentation = String.Empty;
            foreach (string modifier in accessModifiers)
                modifiersPresentation += String.Format("{0} ", modifier);
            return modifiersPresentation.TrimEnd();
        }

        private string GetPresentation()
        {
            string typeName = _fieldDeclaration.TypeName;
            if (_fieldDeclaration.IsGenerical)
                typeName += String.Format("<{0}>", GetAccessModifiers(_fieldDeclaration.GenericalParams));
            return String.Format("{0} {1} {2}", GetAccessModifiers(_fieldDeclaration.AccessModifiers.SharpModifiers),
                typeName, _fieldDeclaration.Name);
        }
    }
}
