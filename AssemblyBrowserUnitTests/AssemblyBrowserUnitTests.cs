using AssemblyAnalyzer.Info;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyBrowserUnitTests
{
    [TestClass]
    public class AssemblyBrowserUnitTests
    {
        private readonly AssemblyAnalyzer.AssemblyAnalyzer _assemblyAnalyzer = 
            AssemblyAnalyzer.AssemblyAnalyzer.GetInstance();
        private AssemblyInfo _assemblyInfo;

        [TestInitialize]
        public void Initialize() => _assemblyInfo = 
            _assemblyAnalyzer.GetInfo("..\\..\\..\\TestAssembly\\bin\\Debug\\TestAssembly.dll");

        [TestMethod]
        public void NamespaceCountTest() => Assert.AreEqual(2, 
            _assemblyInfo.NamespaceDeclarations.Count);

        [TestMethod]
        public void NamespaceDeclareNameTest() => Assert.AreEqual("TestAssembly", 
            _assemblyInfo.NamespaceDeclarations[0].Name);

        [TestMethod]
        public void NamespaceMembersCountTest() => Assert.AreEqual(1,
            _assemblyInfo.NamespaceDeclarations[0].TypeDeclarations.Count);

        [TestMethod]
        public void ClassMemberCountTest() => Assert.AreEqual(1,
            _assemblyInfo.NamespaceDeclarations[0].TypeDeclarations[0].
            TypeDeclarations.Count);

        [TestMethod]
        public void ExtensionMethodTest() => Assert.IsTrue(_assemblyInfo.NamespaceDeclarations[0].
            TypeDeclarations[0].MethodDeclarations.
            Find(item => item.Name == "GetMultiplication").IsExtention);

        [TestMethod]
        public void EventsCountTest() => Assert.AreEqual(2,
            _assemblyInfo.NamespaceDeclarations[0].TypeDeclarations[0].
            EventDeclarations.Count);

        [TestMethod]
        public void PropertiesCountTest() => Assert.AreEqual(1,
            _assemblyInfo.NamespaceDeclarations[0].TypeDeclarations[0].
            PropertyDeclarations.Count);

        [TestMethod]
        public void FieldsCountTest() => Assert.AreEqual(8,
            _assemblyInfo.NamespaceDeclarations[0].TypeDeclarations[0].
            FieldsDeclaration.Count);

        [TestMethod]
        public void MethodsCountTest() => Assert.AreEqual(11,
            _assemblyInfo.NamespaceDeclarations[0].TypeDeclarations[0].
            MethodDeclarations.Count);

        [TestMethod]
        public void MethodsFirstOptionTest() => Assert.AreEqual("a",
            _assemblyInfo.NamespaceDeclarations[0].TypeDeclarations[0].
            MethodDeclarations.Find(item => item.Name == "GetSum").Options[0].Name);
    }
}
