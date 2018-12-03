using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System.Collections.Generic;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class PropertyDeclaration : IMember
    {
        private readonly AccessModifiers _accessModifiers;
        private readonly List<string> _genericalParams;
        private readonly string _name;
        private readonly string _typeName;
        private readonly bool _canBeWrite;
        private readonly bool _canBeRead;
        private readonly bool _isGenerical;

        public bool IsGenerical => _isGenerical;
        public bool CanBeRead => _canBeRead;
        public bool CanBeWrite => _canBeWrite;
        public AccessModifiers AccessModifiers => _accessModifiers;
        public string TypeName => _typeName;
        public string Name => _name;
        public List<string> GenericalParams => _genericalParams;

        public PropertyDeclaration(string name, string tName, bool isGenerical, bool canBeRead, bool canBeWrite,
            AccessorsModifiers accessorsModifiers, List<string> genericalParams)
        {
            _name = name;
            _typeName = tName;
            _isGenerical = isGenerical;
            _canBeRead = canBeRead;
            _canBeWrite = canBeWrite;
            _accessModifiers = accessorsModifiers;
            _genericalParams = genericalParams;
        }
    }
}
