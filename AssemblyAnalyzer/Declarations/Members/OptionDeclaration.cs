using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System.Collections.Generic;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class OptionDeclaration : IMember, IGenerical
    {
        private readonly AccessModifiers _accessModifiers;
        private readonly List<string> _genericalParams;
        private readonly string _name;
        private readonly string _typeName;
        private readonly bool _isGenerical;
        private readonly bool _isClass;

        public string Name => _name;
        public AccessModifiers AccessModifiers => _accessModifiers;
        public List<string> GenericalParams => _genericalParams;
        public string TypeName => _typeName;
        public bool IsGenerical => _isGenerical;
        public bool IsClass => _isClass;

        public OptionDeclaration(string name, string tName, bool isGenerical, bool isClass,
            AccessModifiers accessModifiers, List<string> genericalParams)
        {
            _name = name;
            _typeName = tName;
            _isGenerical = isGenerical;
            _isClass = isClass;
            _accessModifiers = accessModifiers;
            _genericalParams = genericalParams;
        }
    }
}
