using System;
using UniRx;

namespace Plugins.Banks.Core
{
    public abstract class BaseClampedBank<T> : BaseBank<T>, IClampedBank<T> where T : IComparable<T>
    {
        private readonly ReactiveProperty<T> _maxAmount = new ReactiveProperty<T>();
        private readonly FloatReactiveProperty _fillAmount = new FloatReactiveProperty();

        public BaseClampedBank()
        {
            IsFull = _amount.Select(x => x.CompareTo(_maxAmount.Value) == 0).ToReadOnlyReactiveProperty();
        }

        public BaseClampedBank(T value, T maxValue)
        {
            maxValue = Max(default, maxValue);
            value = Clamp(value, default, maxValue);

            _amount.Value = value;
            _maxAmount.Value = maxValue;

            IsFull = _amount.Select(x => x.CompareTo(_maxAmount.Value) == 0).ToReadOnlyReactiveProperty();

            UpdateFillAmount();
        }

        public IReadOnlyReactiveProperty<T> MaxAmount => _maxAmount;

        public IReadOnlyReactiveProperty<bool> IsFull { get; }

        public IReadOnlyReactiveProperty<float> FillAmount => _fillAmount;

        public new void Add(T value)
        {
            value = Max(default, value);

            _amount.Value = Clamp(Add(_amount.Value, value), default, _maxAmount.Value);

            UpdateFillAmount();
        }

        public new void Spend(T value)
        {
            value = Max(default, value);

            if (HasEnough(value) == false)
                return;

            _amount.Value = Subtract(_amount.Value, value);

            UpdateFillAmount();
        }

        public new void SetValue(T value)
        {
            value = Clamp(value, default, _maxAmount.Value);

            _amount.Value = value;

            UpdateFillAmount();
        }

        public new void Clear()
        {
            base.Clear();
            UpdateFillAmount();
        }

        public void SetMaxValue(T value)
        {
            value = Max(default, value);

            _maxAmount.Value = value;

            SetValue(_amount.Value);
        }

        public void Fill() => SetValue(_maxAmount.Value);

        private void UpdateFillAmount() => _fillAmount.Value = CalculateFillAmount();

        private float CalculateFillAmount()
        {
            if (_maxAmount.Value.CompareTo(default) == 0)
                return 0;

            return Divide(_amount.Value, _maxAmount.Value);
        }

        protected abstract T Clamp(T value, T min, T max);

        protected abstract float Divide(T amount, T maxAmount);
    }
}