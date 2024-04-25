using Plugins.Banks.Core;

namespace Plugins.Banks.Float
{
    public class FloatBank : BaseBank<float>
    {
        public FloatBank() { }

        public FloatBank(float value) : base(value) { }

        protected override float Add(float a, float b) => a + b;

        protected override float Subtract(float a, float b) => a - b;
    }
}