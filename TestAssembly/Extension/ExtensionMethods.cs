using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly.Extension
{
    public static class ExtensionMethods
    {
        public static int GetMultiplication(this TestAssembly testAssembly, int a, int b) => a * b;
    }
}
