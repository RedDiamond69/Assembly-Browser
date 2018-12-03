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
        private readonly string _name;
        private readonly string _typeName;

        public string Name => _name;
        public string TypeName => _typeName;
        public AccessModifiers AccessModifiers => _accessModifiers;

        public EventDeclaration(string name, string tName, AccessModifiers accessModifiers)
        {
            _name = name;
            _typeName = tName;
            _accessModifiers = _accessModifiers;
        }
    }
}
