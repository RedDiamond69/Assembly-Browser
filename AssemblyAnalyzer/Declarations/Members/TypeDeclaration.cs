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
        private readonly string _baseType;
        private readonly bool _isInterface;
        private readonly bool _isGenerical;
        private readonly string _name;
        private readonly string _fullName;

        public string BaseType => _baseType;
        public bool IsInterface => _isInterface;
        public bool IsGenerical => _isGenerical;
        public string Name => _name;
        public string FullName => _fullName;
        public AccessModifiers AccessModifiers => _accessModifiers;
        public List<string> ImplementedInterfaces => _implementedInterfaces;
        public List<string> GenericalParams => _genericalParams;
        public List<FieldDeclaration> FieldsDeclaration => _fieldsDeclaration;
        public List<PropertyDeclaration> PropertyDeclarations => _propertiesDeclaration;
        public List<MethodDeclaration> MethodDeclarations => _methodsDeclaration;
        public List<EventDeclaration> EventDeclarations => _eventsDeclaration;
        public IEnumerable<IMember> Members => ((IEnumerable<IMember>)_fieldsDeclaration).Concat(_propertiesDeclaration).Concat(_methodsDeclaration).Concat(_eventsDeclaration);
        public List<TypeDeclaration> TypeDeclarations => _nestedTypesDeclaration;

        public TypeDeclaration(string name, string fullName, string baseType, bool isInterface, bool isGenerical,
            AccessModifiers accessModifiers, List<string> implementedInterfaces, List<string> genericalParams,
            List<FieldDeclaration> fieldDeclarations, List<PropertyDeclaration> propertyDeclarations,
            List<MethodDeclaration> methodDeclarations, List<EventDeclaration> eventDeclarations,
            List<TypeDeclaration> typeDeclarations)
        {
            _name = name;
            _fullName = fullName;
            _baseType = baseType;
            _isInterface = isInterface;
            _isGenerical = isGenerical;
            _accessModifiers = accessModifiers;
            _implementedInterfaces = implementedInterfaces;
            _genericalParams = genericalParams;
            _fieldsDeclaration = fieldDeclarations;
            _propertiesDeclaration = propertyDeclarations;
            _methodsDeclaration = methodDeclarations;
            _eventsDeclaration = eventDeclarations;
            _nestedTypesDeclaration = typeDeclarations;
        }
    }
}
