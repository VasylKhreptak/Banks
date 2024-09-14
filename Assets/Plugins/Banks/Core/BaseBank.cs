using System;
using UniRx;
using UnityEngine;

namespace Plugins.Banks.Core
{
    public abstract class BaseBank<T> : IBank<T> where T : IComparable<T>
    {
        protected readonly ReactiveProperty<T> _amount = new ReactiveProperty<T>();

        public BaseBank()
        {
            IsEmpty = _amount.Select(x => x.CompareTo(default) == 0).ToReadOnlyReactiveProperty();
        }

        public BaseBank(T value)
        {
            value = Max(default, value);

            _amount.Value = value;

            IsEmpty = _amount.Select(x => x.CompareTo(default) == 0).ToReadOnlyReactiveProperty();
        }

        public IReadOnlyReactiveProperty<T> Amount => _amount;

        public IReadOnlyReactiveProperty<bool> IsEmpty { get; }

        public void Add(T value)
        {
            value = Max(default, value);

            _amount.Value = Add(_amount.Value, value);
        }

        public void Spend(T value)
        {
            value = Max(default, value);

            if (HasEnough(value) == false)
                return;

            Debug.Log($"Value: {value}. Amount: {_amount.Value}");

            _amount.Value = Subtract(_amount.Value, value);

            Debug.Log($" Amount: {_amount.Value}");
        }

        public void SetValue(T value)
        {
            value = Max(default, value);

            _amount.Value = value;
        }

        public void Clear() => _amount.Value = default;

        public bool HasEnough(T value) => _amount.Value.CompareTo(value) is 1 or 0;

        public override string ToString() => _amount.Value.ToString();

        protected T Max(T a, T b) => a.CompareTo(b) >= 0 ? a : b;

        protected abstract T Add(T a, T b);

        protected abstract T Subtract(T a, T b);
    }
}