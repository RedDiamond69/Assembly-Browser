using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class EventBuilder : IMemberBuilder
    {
        private readonly EventInfo _eInfo;

        public EventBuilder(MemberInfo member) => _eInfo = (EventInfo)member;

        public object Build()
        {
            throw new NotImplementedException();
        }
    }
}
