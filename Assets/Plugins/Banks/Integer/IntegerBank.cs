using Plugins.Banks.Core;

namespace Plugins.Banks.Integer
{
    public class IntegerBank : BaseBank<int>
    {
        public IntegerBank() { }

        public IntegerBank(int value) : base(value) { }

        protected override int Add(int a, int b) => a + b;

        protected override int Subtract(int a, int b) => a - b;
    }
}