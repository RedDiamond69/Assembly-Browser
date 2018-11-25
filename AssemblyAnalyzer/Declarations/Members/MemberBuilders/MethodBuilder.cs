using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class MethodBuilder : IMemberBuilder
    {
        private readonly MethodBase _mInfo;

        public MethodBuilder(MemberInfo member) => _mInfo = (MethodBase)member;

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

        private AccessModifiers GetModifiers()
        {
            List<string> modifiers = new List<string>();
            List<string> sharpModifiers = new List<string>();
            MethodAttributes methodAttributes = _mInfo.Attributes & ~MethodAttributes.VtableLayoutMask;
            modifiers = methodAttributes.ToString().Split(',').ToList();
            modifiers = modifiers.Select(str => str.Trim().ToLower()).ToList();
            MethodAttributes accessAttributes = methodAttributes & MethodAttributes.MemberAccessMask;
            sharpModifiers = GetAccessModifiers(accessAttributes);
            if ((methodAttributes & MethodAttributes.Abstract) != 0)
                sharpModifiers.Add("abstract");
            if ((methodAttributes & MethodAttributes.Final) != 0)
                sharpModifiers.Add("sealed");
            if ((methodAttributes & MethodAttributes.Virtual) != 0)
                sharpModifiers.Add("virtual");
            if ((methodAttributes & MethodAttributes.Static) != 0)
                sharpModifiers.Add("static");
            return new AccessModifiers(modifiers, sharpModifiers);
        }

        public object Build()
        {
            throw new NotImplementedException();
        }
    }
}
