using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class PropertyBuilder : IMemberBuilder
    {
        private readonly PropertyInfo _propInfo;

        public PropertyBuilder(MemberInfo member) => _propInfo = (PropertyInfo)member;

        private List<string> GetAccessModifiers(MethodAttributes attributes)
        {
            List<string> accessModifiers = new List<string>();
            switch (attributes)
            {
                case MethodAttributes.Public:
                    accessModifiers.Add("public");
                    break;
                case MethodAttributes.Private:
                    accessModifiers.Add("private");
                    break;
                case MethodAttributes.Assembly:
                    accessModifiers.Add("internal");
                    break;
                case MethodAttributes.Family:
                    accessModifiers.Add("protected");
                    break;
                case MethodAttributes.FamANDAssem:
                    accessModifiers.Add("private protected");
                    break;
                case MethodAttributes.FamORAssem:
                    accessModifiers.Add("protected internal");
                    break;
            }
            return accessModifiers;
        }

        private AccessorsModifiers GetAccessorsModifiers()
        {
            List<string> getters = new List<string>();
            List<string> setters = new List<string>();
            List<string> modifiers = new List<string>();
            List<string> sharpModifiers = new List<string>();
            PropertyAttributes propertyAttributes = _propInfo.Attributes;
            modifiers = propertyAttributes.ToString().Split(',').ToList();
            modifiers = modifiers.Select(str => str.Trim().ToLower()).ToList();
            MethodInfo get = _propInfo.GetGetMethod(nonPublic: true);
            MethodInfo set = _propInfo.GetSetMethod(nonPublic: true);
            if (get == null)
            {
                MethodAttributes visibily = set.Attributes & MethodAttributes.MemberAccessMask;
                setters = GetAccessModifiers(visibily);
            }
            else
            {
                if (set == null)
                {
                    MethodAttributes visibily = get.Attributes & MethodAttributes.MemberAccessMask;
                    getters = GetAccessModifiers(visibily);
                }
                else
                {
                    MethodAttributes getterVisibile = get.Attributes & MethodAttributes.MemberAccessMask;
                    MethodAttributes setterVisibile = set.Attributes & MethodAttributes.MemberAccessMask;
                    getters = GetAccessModifiers(getterVisibile);
                    setters = GetAccessModifiers(setterVisibile);
                    if (get.IsStatic && set.IsStatic)
                        sharpModifiers.Add("static");
                    if (get.IsVirtual && set.IsVirtual)
                        sharpModifiers.Add("virtual");
                    if (get.IsFinal && set.IsFinal)
                        sharpModifiers.Add("sealed");
                    if (get.IsAbstract && set.IsAbstract)
                        sharpModifiers.Add("abstract");
                }
            }
            return new AccessorsModifiers(modifiers, sharpModifiers, getters, setters);
        }

        private List<string> GetGenericOptions()
        {
            List<string> genericOptions = new List<string>();
            List<Type> genericArgs = _propInfo.PropertyType.GetGenericTypeDefinition().GetGenericArguments().ToList<Type>();
            foreach (Type type in genericArgs)
                genericOptions.Add(type.Name);
            return genericOptions;
        }

        public object Build()
        {
            string name = _propInfo.Name;
            string typeName = _propInfo.PropertyType.Name;
            bool canRead = _propInfo.CanRead;
            bool canWrite = _propInfo.CanWrite;
            bool isGeneric = _propInfo.PropertyType.IsGenericType;
            AccessorsModifiers accessorsModifiers = GetAccessorsModifiers();
            List<string> genericOptions = new List<string>();
            if (isGeneric)
                genericOptions = GetGenericOptions();
            return new PropertyDeclaration(name, typeName, isGeneric, canRead, canWrite, accessorsModifiers, genericOptions);
        }
    }
}
