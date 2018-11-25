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

        public object Build()
        {
            throw new NotImplementedException();
        }
    }
}
