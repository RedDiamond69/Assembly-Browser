using System.Collections.Generic;
using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class MethodDeclaration : IMember, IGenerical
    {
        private readonly AccessModifiers _accessModifiers;
        private readonly List<string> _genericalParams;
        private readonly List<OptionDeclaration> _options;
        private readonly string _name;
        private readonly string _retTypeName;
        private readonly bool _isGenerical;
        private readonly bool _isConstructor;
        private readonly bool _isExtention;

        public string Name => _name;
        public string RetTypeName => _retTypeName;
        public List<OptionDeclaration> Options => _options;
        public AccessModifiers AccessModifiers => _accessModifiers;
        public bool IsGenerical => _isGenerical;
        public bool IsConstructor => _isConstructor;
        public bool IsExtention => _isExtention;
        public List<string> GenericalParams => _genericalParams;

        public MethodDeclaration(string name, string retTypeName, bool isConstructor, bool isGenerical, bool isExtention,
            AccessModifiers accessModifiers, List<OptionDeclaration> options, List<string> genericalParams)
        {
            _name = name;
            _retTypeName = retTypeName;
            _isConstructor = isConstructor;
            _isGenerical = isGenerical;
            _isExtention = isExtention;
            _accessModifiers = accessModifiers;
            _options = options;
            _genericalParams = genericalParams;
        }
    }
}
