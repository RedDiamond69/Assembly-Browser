using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly
{
    public class TestAssembly
    {
        private int _intField;
        private readonly int _intReadonlyField;
        private volatile string _strVolatileField;
        private List<object> _list;
        private readonly Action<object> _action;
        private readonly Predicate<object> _canBeExecuting;
        public delegate void AccountStateHandler(string message);
        public event AccountStateHandler _withdrawn;
        public event AccountStateHandler _added;

        public int IntProperty
        {
            get => _intField;
            private set { }
        }

        public TestAssembly() { }

        public TestAssembly(int param, List<object> list)
        {
            _intField = param;
            _list = list;
        }

        private int GetSum(int a, int b) => a + b;

        public int GetDifference(int a, int b) => a - b;
    }
}
