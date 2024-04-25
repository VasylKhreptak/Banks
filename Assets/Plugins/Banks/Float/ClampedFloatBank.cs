using Plugins.Banks.Core;
using UnityEngine;

namespace Plugins.Banks.Float
{
    public class ClampedFloatBank : BaseClampedBank<float>
    {
        public ClampedFloatBank() { }

        public ClampedFloatBank(float value, float maxValue) : base(value, maxValue) { }

        protected override float Add(float a, float b) => a + b;

        protected override float Subtract(float a, float b) => a - b;

        protected override float Clamp(float value, float min, float max) => Mathf.Clamp(value, min, max);

        protected override float Divide(float amount, float maxAmount) => amount / maxAmount;
    }
}