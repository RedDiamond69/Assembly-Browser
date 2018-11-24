using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class Builder
    {
        private readonly IMemberBuilder _memberBuilder;

        public Builder(IMemberBuilder memberBuilder) => _memberBuilder = memberBuilder;

        public object Create() => _memberBuilder.Build();

        public object Create(Dictionary<string, MethodDeclaration> extMethods) => ((TypeBuilder)_memberBuilder).Build(extMethods);
    }
}
