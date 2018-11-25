using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class OptionBuilder : IMemberBuilder
    {
        private readonly ParameterInfo _pInfo;

        public OptionBuilder(ParameterInfo parameterInfo) => _pInfo = parameterInfo;

        public object Build()
        {
            throw new NotImplementedException();
        }
    }
}
