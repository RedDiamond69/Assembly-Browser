using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations.Members.MemberBuilders
{
    public class TypeBuilder : IMemberBuilder
    {
        private readonly TypeInfo _tInfo;

        public TypeBuilder(TypeInfo typeInfo) => _tInfo = typeInfo;

        public object Build() => null;

        public object Build(TypeBuilder typeBuilder, Dictionary<string, MethodDeclaration> extMethods) => typeBuilder.Build(extMethods);

        public object Build(Dictionary<string, MethodDeclaration> extMethods)
        {

        }

        private List<string> GetGenericOptions()
        {
            List<string> genericOptions = new List<string>();
            IEnumerable<Type> genericArgs = _tInfo.GetGenericTypeDefinition().GetGenericArguments();
            foreach (Type arg in genericArgs)
                genericOptions.Add(arg.Name);
            return genericOptions;
        }

        private List<string> GetAccessModifiers(TypeAttributes attributes)
        {

        }

        private AccessModifiers GetModifiers()
        {

        }
    }
}
