using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class PropertyDeclaration : IMember
    {
        private readonly AccessModifiers _accessModifiers;
        private readonly List<string> _genericalParams;

        public bool IsGenerical
        {
            get;
            private set;
        }
        public bool CanBeRead
        {
            get;
            private set;
        }
        public bool CanBeWrite
        {
            get;
            private set;
        }
        public AccessModifiers AccessModifiers
        {
            get => _accessModifiers;
            private set { }
        }
        public string TypeName
        {
            get;
            private set;
        }
        public string Name
        {
            get;
            private set;
        }
        public IEnumerable<string> GenericalParams
        {
            get => _genericalParams;
            private set { }
        }

        public PropertyDeclaration(string name, string tName, bool isGenerical, bool canBeRead, bool canBeWrite, 
            AccessorsModifiers accessorsModifiers, List<string> genericalParams)
        {
            Name = name;
            TypeName = tName;
            IsGenerical = isGenerical;
            CanBeRead = canBeRead;
            CanBeWrite = canBeWrite;
            AccessModifiers = accessorsModifiers;
            GenericalParams = genericalParams;
        }
    }
}
