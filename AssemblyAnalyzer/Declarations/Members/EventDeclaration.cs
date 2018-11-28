using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class EventDeclaration : IMember
    {
        private readonly AccessModifiers _accessModifiers;

        public string Name
        {
            get;
            private set;
        }
        public string TypeName
        {
            get;
            private set;
        }
        public AccessModifiers AccessModifiers
        {
            get => _accessModifiers;
            private set { }
        }

        public EventDeclaration(string name, string tName, AccessModifiers accessModifiers)
        {
            Name = name;
            TypeName = tName;
            AccessModifiers = _accessModifiers;
        }
    }
}
