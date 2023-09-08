using Plugins.Banks.Data.Economy.Core;
using UnityEngine;

namespace Plugins.Banks.Data.Economy
{
    public class IntegerBank : Bank<int>
    {
        public IntegerBank(BankType type, int value) : base(type, value)
        {
        }

        public override void Add(int value)
        {
            value = Mathf.Max(0, value);

            _value.Value += value;
        }

        public override bool Spend(int value)
        {
            value = Mathf.Max(0, value);

            if (value > _value.Value) return false;

            _value.Value -= value;

            return true;
        }

        public override bool HasEnough(int value)
        {
            value = Mathf.Max(0, value);

            return _value.Value >= value;
        }
    }
}
