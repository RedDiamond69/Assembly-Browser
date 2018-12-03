using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class FieldDeclaration : IMember, IGenerical
    {
        private readonly AccessModifiers _accessModifiers;
        private readonly List<string> _genericalParams;
        private readonly string _name;
        private readonly string _typeName;
        private readonly bool _isGenerical;

        public string Name => _name;
        public string TypeName => _typeName;
        public AccessModifiers AccessModifiers => _accessModifiers;
        public bool IsGenerical => _isGenerical;
        public List<string> GenericalParams => _genericalParams;

        public FieldDeclaration(string name, string tName, bool isGenerical, AccessModifiers accessModifiers, List<string> genericalParams)
        {
            _name = name;
            _typeName = tName;
            _isGenerical = isGenerical;
            _accessModifiers = accessModifiers;
            _genericalParams = genericalParams;
        }
    }
}
