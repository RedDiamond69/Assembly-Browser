using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;

namespace AssemblyAnalyzer.Declarations.Members
{
    public class MethodDeclaration : IMember, IGenerical
    {
        private readonly AccessModifiers _accessModifiers;
        private readonly List<string> _genericalParams;
        private readonly List<OptionDeclaration> _options;

        public string Name
        {
            get;
            private set;
        }
        public string RetTypeName
        {
            get;
            private set;
        }
        public List<OptionDeclaration> Options
        {
            get => _options;
            private set { }
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
        public bool IsConstructor
        {
            get;
            private set;
        }
        public bool IsExtention
        {
            get;
            private set;
        }
        public List<string> GenericalParams
        {
            get => _genericalParams;
            private set { }
        }

        public MethodDeclaration(string name, string retTypeName, bool isConstructor, bool isGenerical, bool isExtention,
            AccessModifiers accessModifiers, List<OptionDeclaration> options, List<string> genericalParams)
        {
            Name = name;
            RetTypeName = retTypeName;
            IsConstructor = isConstructor;
            IsGenerical = isGenerical;
            IsExtention = isExtention;
            AccessModifiers = accessModifiers;
            Options = options;
            GenericalParams = genericalParams;
        }
    }
}
