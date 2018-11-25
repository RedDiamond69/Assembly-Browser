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

        public object Build()
        {
            throw new NotImplementedException();
        }
    }
}
