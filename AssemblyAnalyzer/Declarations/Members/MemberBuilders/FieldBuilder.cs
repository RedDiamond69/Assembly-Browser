using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class FieldBuilder : IMemberBuilder
    {
        private readonly FieldInfo _fInfo;

        public FieldBuilder(MemberInfo member) => _fInfo = (FieldInfo)member;

        private List<string> GetAccessModifiers(FieldAttributes attributes)
        {
            List<string> accessModifiers = new List<string>();
            switch (attributes)
            {
                case FieldAttributes.Public:
                    accessModifiers.Add("public");
                    break;
                case FieldAttributes.Private:
                    accessModifiers.Add("private");
                    break;
                case FieldAttributes.Assembly:
                    accessModifiers.Add("internal");
                    break;
                case FieldAttributes.Family:
                    accessModifiers.Add("protected");
                    break;
                case FieldAttributes.FamANDAssem:
                    accessModifiers.Add("private protected");
                    break;
                case FieldAttributes.FamORAssem:
                    accessModifiers.Add("protected internal");
                    break;
            }
            return accessModifiers;
        }

        private AccessModifiers GetModifiers()
        {
            List<string> modifiers = new List<string>();
            List<string> sharpModifiers = new List<string>();
            FieldAttributes fieldAttributes = _fInfo.Attributes;
            modifiers = fieldAttributes.ToString().Split(',').ToList();
            modifiers = modifiers.Select(str => str.Trim().ToLower()).ToList();
            FieldAttributes accessAttributes = fieldAttributes & FieldAttributes.FieldAccessMask;
            sharpModifiers = GetAccessModifiers(accessAttributes);
            if ((fieldAttributes & FieldAttributes.Literal) != 0)
                sharpModifiers.Add("const");
            if ((fieldAttributes & FieldAttributes.Static) != 0)
                sharpModifiers.Add("static");
            if ((fieldAttributes & FieldAttributes.InitOnly) != 0)
                sharpModifiers.Add("readonly");
            return new AccessModifiers(modifiers, sharpModifiers);
        }

        private List<string> GetGenericOptions()
        {
            List<string> genericOptions = new List<string>();
            List<Type> genericArgs = _fInfo.FieldType.GetGenericTypeDefinition().GetGenericArguments().ToList<Type>();
            foreach (Type type in genericArgs)
                genericOptions.Add(type.Name);
            return genericOptions;
        }

        public object Build()
        {
            throw new NotImplementedException();
        }
    }
}
