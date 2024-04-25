using Plugins.Banks.Core;
using UnityEngine;

namespace Plugins.Banks.Integer
{
    public class ClampedIntegerBank : BaseClampedBank<int>
    {
        public ClampedIntegerBank() { }

        public ClampedIntegerBank(int value, int maxValue) : base(value, maxValue) { }

        protected override int Add(int a, int b) => a + b;

        protected override int Subtract(int a, int b) => a - b;

        protected override int Clamp(int value, int min, int max) => Mathf.Clamp(value, min, max);

        protected override float Divide(int amount, int maxAmount) => (float)amount / maxAmount;
    }
}