namespace TestAssembly.Extension
{
    internal class TestClass
    {
        public TestClass()
        {
        }

        protected internal float Generate(int a, int b, int c) => a * b * c;

        public float Generate(int a, float b) => a * b;
    }
}
