using AssemblyAnalyzer.Declarations;
using AssemblyAnalyzer.Declarations.Members;
using AssemblyAnalyzer.Declarations.Members.MemberBuilders;
using AssemblyAnalyzer.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer
{
    public class AssemblyAnalyzer : IAssemblyAnalyzer
    {
        private static volatile AssemblyAnalyzer _instance;
        private static readonly object _syncRoot = new object();
        private readonly List<string> _typesWithExtensionMethods = new List<string>();

        private AssemblyAnalyzer() { }

        public static AssemblyAnalyzer GetInstance()
        {
            if (_instance == null)
                lock (_syncRoot)
                    if (_instance == null)
                        _instance = new AssemblyAnalyzer();
            return _instance;
        }

        private Dictionary<string, MethodDeclaration> GetExtMethods(Assembly assembly)
        {
            Dictionary<string, MethodDeclaration> extMethods = new Dictionary<string, MethodDeclaration>();
            foreach (TypeInfo defType in assembly.DefinedTypes)
            {
                if (!defType.IsNested)
                {
                    foreach (MethodInfo method in defType.DeclaredMethods)
                    {
                        ParameterInfo[] parametersInfo = method.GetParameters();
                        Type parameterType = parametersInfo.Count() > 0 ? parametersInfo.First().ParameterType : null;
                        if (parameterType != null)
                        {
                            if (method.IsStatic && (parameterType.IsClass || parameterType.IsInterface))
                            {
                                _typesWithExtensionMethods.Add(defType.Name);

                                Builder builder = new Builder(new MethodBuilder(method));
                                extMethods.Add(parameterType.Name, (MethodDeclaration)builder.Create());
                            }
                        }
                    }
                }
            }
            return extMethods;
        }

        public AssemblyInfo GetInfo(string asmPath)
        {
            AssemblyInfo assemblyInfo = new AssemblyInfo();
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(asmPath);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch(BadImageFormatException ex)
            {
                throw new BadImageFormatException(ex.Message);
            }
            catch (FileLoadException ex)
            {
                throw new FileLoadException(ex.Message);
            }
            Dictionary<string, MethodDeclaration> extMethods = GetExtMethods(assembly);
            foreach (TypeInfo defType in assembly.DefinedTypes)
            {
                if (!defType.IsNested)
                {
                    if (!_typesWithExtensionMethods.Contains(defType.Name))
                    {
                        NamespaceDeclaration namespaceDeclaration = new NamespaceDeclaration(defType.Namespace);
                        Builder builder = new Builder(new TypeBuilder(defType));
                        TypeDeclaration typeDeclaration = (TypeDeclaration)builder.Create(extMethods);
                        namespaceDeclaration.AddType(typeDeclaration);
                        assemblyInfo.AddOrCreateNamespaceDeclaration(namespaceDeclaration);
                    }
                }
            }
            _typesWithExtensionMethods.Clear();
            return assemblyInfo;
        }
    }
}

