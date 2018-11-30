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
        private EventDeclaration eventDeclaration;

        public EventVM(EventDeclaration eventDeclaration)
        {
            this.eventDeclaration = eventDeclaration;
        }
    }
}
