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

        public FieldBuilder()
        {
        }

        public object Build()
        {
            throw new NotImplementedException();
        }
    }
}
