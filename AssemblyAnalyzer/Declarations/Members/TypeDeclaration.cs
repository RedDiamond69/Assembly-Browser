using AssemblyAnalyzer.Declarations.Members;
using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations
{
    public class TypeDeclaration : IGenerical
    {
        private readonly AccessModifiers _accessModifiers;
        private readonly List<string> _genericalParams;
        private readonly List<string> _implementedInterfaces;
        private readonly List<FieldDeclaration> _fieldsDeclaration;
        private readonly List<PropertyDeclaration> _propertiesDeclaration;
        private readonly List<MethodDeclaration> _methodsDeclaration;
        private readonly List<EventDeclaration> _eventsDeclaration;
        private readonly List<TypeDeclaration> _nestedTypesDeclaration;

        public string BaseType
        {
            get;
            private set;
        }
        public bool IsInterface
        {
            get;
            private set;
        }
        public bool IsGenerical
        {
            get;
            private set;
        }
        public string Name
        {
            get;
            private set;
        }
        public string FullName
        {
            get;
            private set;
        }
        public AccessModifiers AccessModifiers
        {
            get => _accessModifiers;
            private set { }
        }
        public List<string> ImplementedInterfaces
        {
            get => _implementedInterfaces;
            private set { }
        }
        public List<string> GenericalParams
        {
            get => _genericalParams;
            private set { }
        }
        public List<FieldDeclaration> FieldsDeclaration
        {
            get => _fieldsDeclaration;
            private set { }
        }
        public List<PropertyDeclaration> PropertyDeclarations
        {
            get => _propertiesDeclaration;
            private set { }
        }
        public List<MethodDeclaration> MethodDeclarations
        {
            get => _methodsDeclaration;
            private set { }
        }
        public List<EventDeclaration> EventDeclarations
        {
            get => _eventsDeclaration;
            private set { }
        }
        public IEnumerable<IMember> Members
        {
            get => ((IEnumerable<IMember>)_fieldsDeclaration).Concat(_propertiesDeclaration).Concat(_methodsDeclaration).Concat(_eventsDeclaration);
            private set { }
        }
        public List<TypeDeclaration> TypeDeclarations
        {
            get => _nestedTypesDeclaration;
            private set { }
        }

        public TypeDeclaration(string name, string fullName, string baseType, bool isInterface, bool isGenerical,
            AccessModifiers accessModifiers, List<string> implementedInterfaces, List<string> genericalParams,
            List<FieldDeclaration> fieldDeclarations, List<PropertyDeclaration> propertyDeclarations, 
            List<MethodDeclaration> methodDeclarations, List<EventDeclaration> eventDeclarations, 
            List<TypeDeclaration> typeDeclarations)
        {
            Name = name;
            FullName = fullName;
            BaseType = baseType;
            IsInterface = isInterface;
            IsGenerical = isGenerical;
            AccessModifiers = accessModifiers;
            ImplementedInterfaces = implementedInterfaces;
            GenericalParams = genericalParams;
            FieldsDeclaration = fieldDeclarations;
            PropertyDeclarations = propertyDeclarations;
            MethodDeclarations = methodDeclarations;
            EventDeclarations = eventDeclarations;
            TypeDeclarations = typeDeclarations;
        }
    }
}
