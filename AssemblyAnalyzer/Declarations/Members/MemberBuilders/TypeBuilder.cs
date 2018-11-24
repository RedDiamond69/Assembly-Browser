using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class TypeBuilder : IMemberBuilder
    {
        private readonly TypeInfo _tInfo;

        public TypeBuilder(TypeInfo typeInfo) => _tInfo = typeInfo;

        public object Build() => null;

        public object Build(TypeBuilder typeBuilder, Dictionary<string, MethodDeclaration> extMethods) => typeBuilder.Build(extMethods);

        public object Build(Dictionary<string, MethodDeclaration> extMethods)
        {
            string name = _tInfo.Name;
            string fullName = _tInfo.FullName;
            string baseType = _tInfo.BaseType?.FullName;
            bool isInterface = _tInfo.IsInterface;
            bool isGeneric = _tInfo.IsGenericType;
            AccessModifiers modifiers = GetModifiers();
            List<string> implInterfaces = _tInfo.ImplementedInterfaces.Select(type => type.Name).ToList();
            List<string> genericOptions = new List<string>();
            if (isGeneric)
                genericOptions = GetGenericOptions();
            List<FieldDeclaration> fields = new List<FieldDeclaration>();
            List<PropertyDeclaration> properties = new List<PropertyDeclaration>();
            List<MethodDeclaration> methods = new List<MethodDeclaration>();
            List<EventDeclaration> events = new List<EventDeclaration>();
            List<TypeDeclaration> nestedTypes = new List<TypeDeclaration>();
            foreach (MemberInfo member in _tInfo.DeclaredMembers)
            {
                if (member is FieldInfo)
                {
                    Builder builder = new Builder(new FieldBuilder(member));
                    fields.Add((FieldDeclaration)builder.Create());
                }
                else if (member is PropertyInfo)
                {
                    Builder builder = new Builder(new PropertyBuilder(member));
                    properties.Add((PropertyDeclaration)builder.Create());
                }
                else if (member is MethodBase)
                {
                    Builder builder = new Builder(new MethodBuilder(member));
                    methods.Add((MethodDeclaration)builder.Create());
                }
                else if (member is EventInfo)
                {
                    Builder builder = new Builder(new EventBuilder(member));
                    events.Add((EventDeclaration)builder.Create());
                }
            }
            foreach (KeyValuePair<string, MethodDeclaration> method in extMethods)
                if (name == method.Key)
                    methods.Add(method.Value);
            foreach (TypeInfo nestedType in _tInfo.DeclaredNestedTypes)
            {
                Builder builder = new Builder(new TypeBuilder(nestedType));
                nestedTypes.Add((TypeDeclaration)builder.Create(extMethods));
            }
            return new TypeDeclaration(name, fullName, baseType, isInterface, 
                isGeneric, modifiers, implInterfaces, genericOptions, 
                fields, properties, methods, events, nestedTypes);
        }

        private List<string> GetGenericOptions()
        {
            List<string> genericOptions = new List<string>();
            IEnumerable<Type> genericArgs = _tInfo.GetGenericTypeDefinition().GetGenericArguments();
            foreach (Type arg in genericArgs)
                genericOptions.Add(arg.Name);
            return genericOptions;
        }

        private List<string> GetAccessModifiers(TypeAttributes attributes)
        {

        }

        private AccessModifiers GetModifiers()
        {
            List<string> modifiers = new List<string>();
            List<string> sharpModifiers = new List<string>();
            TypeAttributes typeAttributes = _tInfo.Attributes & ~TypeAttributes.ClassSemanticsMask;
            modifiers = typeAttributes.ToString().Split(',').ToList();
            modifiers = modifiers.Select(str => str.Trim().ToLower()).ToList();
            TypeAttributes accessAttributes = typeAttributes & TypeAttributes.VisibilityMask;
            sharpModifiers.AddRange(GetAccessModifiers(accessAttributes));
            if ((typeAttributes & TypeAttributes.Sealed) != 0)
                sharpModifiers.Add("sealed");
            if ((typeAttributes & TypeAttributes.Abstract) != 0)
                sharpModifiers.Add("abstract");
            return new AccessModifiers(modifiers, sharpModifiers);
        }
    }
}
