using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class OptionDeclaration : IMember, IGenerical
    {
        private readonly AccessModifiers _accessModifiers;
        private readonly List<string> _genericalParams;
        
        public string Name
        {
            get;
            private set;
        }
        public AccessModifiers AccessModifiers
        {
            get => _accessModifiers;
            private set { }
        }
        public List<string> GenericalParams
        {
            get => _genericalParams;
            private set { }
        }
        public string TypeName
        {
            get;
            private set;
        }
        public bool IsGenerical
        {
            get;
            private set;
        }
        public bool IsClass
        {
            get;
            private set;
        }

        public OptionDeclaration(string name, string tName, bool isGenerical, bool isClass, 
            AccessModifiers accessModifiers, List<string> genericalParams)
        {
            Name = name;
            TypeName = tName;
            IsGenerical = isGenerical;
            IsClass = isClass;
            AccessModifiers = accessModifiers;
            GenericalParams = genericalParams;
        }
    }
}
