using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class PropertyBuilder
    {
        private readonly PropertyInfo _propInfo;

        public PropertyBuilder(MemberInfo member) => _propInfo = (PropertyInfo)member;
    }
}
