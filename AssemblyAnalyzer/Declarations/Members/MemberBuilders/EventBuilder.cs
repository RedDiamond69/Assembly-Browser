using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;
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
            EventAttributes eventAttributes = _eInfo.Attributes;
            modifiers = eventAttributes.ToString().Split(',').ToList();
            modifiers = modifiers.Select(str => str.Trim().ToLower()).ToList();
            MethodAttributes visibily = _eInfo.AddMethod.Attributes & MethodAttributes.MemberAccessMask;
            sharpModifiers = GetAccessModifiers(visibily);
            if ((_eInfo.AddMethod.Attributes & MethodAttributes.Abstract) != 0)
                sharpModifiers.Add("abstract");
            if ((_eInfo.AddMethod.Attributes & MethodAttributes.Final) != 0)
                sharpModifiers.Add("sealed");
            if ((_eInfo.AddMethod.Attributes & MethodAttributes.Virtual) != 0)
                sharpModifiers.Add("virtual");
            if ((_eInfo.AddMethod.Attributes & MethodAttributes.Static) != 0)
                sharpModifiers.Add("static");
            return new AccessModifiers(modifiers, sharpModifiers);
        }

        public object Build()
        {
            string name = _eInfo.Name;
            string typeName = _eInfo.EventHandlerType.Name;
            AccessModifiers modifiers = GetModifiers();
            return new EventDeclaration(name, typeName, modifiers);
        }
    }
}
