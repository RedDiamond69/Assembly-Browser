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
    }
}
