using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyAnalyzer.Declarations.Members;

namespace AssemblyBrowser.ViewModel
{
    public class EventVM
    {
        private EventDeclaration _eventDeclaration;

        public string StringPresentation
        {
            get => GetPresentation();
            private set { }
        }

        public EventVM(EventDeclaration eventDeclaration)
        {
            _eventDeclaration = eventDeclaration;
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
            string stringPresentation = String.Empty;
            string name = _eventDeclaration.Name;
            string typeName = _eventDeclaration.TypeName;
            stringPresentation = String.Format("{0} event {1} {2}", 
                GetAccessModifiers(_eventDeclaration.AccessModifiers.SharpModifiers), typeName, name);
            return stringPresentation;
        }
    }
}
