using Plugins.Banks.Core;
using UnityEngine;

namespace Plugins.Banks
{
    public class IntegerBank : Bank<int>
    {
        public IntegerBank() { }

        public IntegerBank(int value) : base(value) { }

        public override void Add(int value)
        {
            value = Mathf.Max(0, value);

            _value.Value += value;
        }

        public override bool Spend(int value)
        {
            value = Mathf.Max(0, value);

            if (value > _value.Value)
                return false;

            _value.Value -= value;

            return true;
        }

        public override void SetValue(int value)
        {
            value = Mathf.Max(0, value);

            _value.Value = value;
        }

        public override void Clear() => SetValue(0);

        public override bool HasEnough(int value)
        {
            value = Mathf.Max(0, value);

            return _value.Value >= value;
        }
    }
}