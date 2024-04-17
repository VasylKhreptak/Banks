using System;
using Plugins.Banks.Core;
using UniRx;

namespace Plugins.Banks.Integer
{
    public class IntegerBank : IBank<int>
    {
        private readonly IntReactiveProperty _amount = new IntReactiveProperty();

        public IntegerBank() { }

        public IntegerBank(int value)
        {
            value = Math.Max(0, value);

            _amount.Value = value;
        }

        public IReadOnlyReactiveProperty<int> Amount => _amount;

        public IReadOnlyReactiveProperty<bool> IsEmpty => _amount.Select(x => x == 0).ToReadOnlyReactiveProperty();

        public void Add(int value)
        {
            value = Math.Max(0, value);

            _amount.Value += value;
        }

        public void Spend(int value)
        {
            value = Math.Max(0, value);

            if (HasEnough(value) == false)
                return;

            _amount.Value -= value;
        }

        public void SetValue(int value)
        {
            value = Math.Max(0, value);

            _amount.Value = value;
        }

        public void Clear() => _amount.Value = 0;

        public bool HasEnough(int value) => _amount.Value >= value;
    }
}