using System;
using Plugins.Banks.Core;
using UniRx;

namespace Plugins.Banks
{
    public class FloatBank : IBank<float>
    {
        private readonly FloatReactiveProperty _amount = new FloatReactiveProperty();

        public FloatBank() { }

        public FloatBank(float value)
        {
            value = Math.Max(0, value);

            _amount.Value = value;
        }

        public IReadOnlyReactiveProperty<float> Amount => _amount;

        public IReadOnlyReactiveProperty<bool> IsEmpty => _amount.Select(x => x == 0).ToReadOnlyReactiveProperty();

        public void Add(float value)
        {
            value = Math.Max(0, value);

            _amount.Value += value;
        }

        public bool Spend(float value)
        {
            value = Math.Max(0, value);

            if (HasEnough(value) == false)
                return false;

            _amount.Value -= value;
            return true;
        }

        public void SetValue(float value)
        {
            value = Math.Max(0, value);

            _amount.Value = value;
        }

        public void Clear() => _amount.Value = 0;

        public bool HasEnough(float value) => _amount.Value >= value;
    }
}