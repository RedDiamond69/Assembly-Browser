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
        public bool IsGenerical
        {
            get;
            private set;
        }
        public List<string> GenericalParams
        {
            get => _genericalParams;
            private set { }
        }

        public FieldDeclaration(string name, string tName, bool isGenerical, AccessModifiers accessModifiers, List<string> genericalParams)
        {
            Name = name;
            TypeName = tName;
            IsGenerical = isGenerical;
            AccessModifiers = accessModifiers;
            GenericalParams = genericalParams;
        }
    }
}
