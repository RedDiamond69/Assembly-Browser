using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class OptionBuilder : IMemberBuilder
    {
        private readonly ParameterInfo _pInfo;

        public OptionBuilder(ParameterInfo parameterInfo) => _pInfo = parameterInfo;

        private AccessModifiers GetModifiers()
        {
            List<string> modifiers = new List<string>();
            List<string> sharpModifiers = new List<string>();
            ParameterAttributes parameterAttributes = _pInfo.Attributes;
            modifiers = parameterAttributes.ToString().Split(',').ToList();
            modifiers = modifiers.Select(str => str.Trim().ToLower()).ToList();
            if ((parameterAttributes & ParameterAttributes.In) != 0)
                sharpModifiers.Add("in");
            if ((parameterAttributes & ParameterAttributes.Out) != 0)
                sharpModifiers.Add("out");
            return new AccessModifiers(modifiers, sharpModifiers);
        }

        private List<string> GetGenericOptions()
        {
            List<string> genericOptions = new List<string>();
            List<Type> genericArguments = _pInfo.ParameterType.GetGenericTypeDefinition().GetGenericArguments().ToList<Type>();
            foreach (Type type in genericArguments)
                genericOptions.Add(type.Name);
            return genericOptions;
        }

        public object Build()
        {
            string name = _pInfo.Name;
            string typeName = _pInfo.ParameterType.Name;
            bool isClass = _pInfo.ParameterType.IsClass | _pInfo.ParameterType.IsInterface;
            bool isGeneric = _pInfo.ParameterType.IsGenericType;
            AccessModifiers accessModifiers = GetModifiers();
            List<string> genericOptions = new List<string>();
            if (isGeneric)
                genericOptions = GetGenericOptions();
            return new OptionDeclaration(name, typeName, isGeneric, isClass, accessModifiers, genericOptions);
        }
    }
}
