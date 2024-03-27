using Plugins.Banks.Core;
using UniRx;
using UnityEngine;

namespace Plugins.Banks
{
    public class ClampedIntegerBank : IClampedBank<int>
    {
        private readonly IntReactiveProperty _amount = new IntReactiveProperty();
        private readonly IntReactiveProperty _maxAmount = new IntReactiveProperty();
        private readonly FloatReactiveProperty _fillAmount = new FloatReactiveProperty();

        public ClampedIntegerBank() { }

        public ClampedIntegerBank(int value, int maxValue)
        {
            maxValue = Mathf.Max(0, maxValue);
            value = Mathf.Clamp(value, 0, maxValue);

            _amount.Value = value;
            _maxAmount.Value = maxValue;
            
            UpdateFillAmount();
        }

        public IReadOnlyReactiveProperty<int> Amount => _amount;

        public IReadOnlyReactiveProperty<int> MaxAmount => _maxAmount;

        public IReadOnlyReactiveProperty<bool> IsEmpty => _amount.Select(x => x == 0).ToReadOnlyReactiveProperty();

        public IReadOnlyReactiveProperty<bool> IsFull => _amount.Select(x => x == _maxAmount.Value).ToReadOnlyReactiveProperty();

        public IReadOnlyReactiveProperty<float> FillAmount => _fillAmount;

        public void Add(int value)
        {
            value = Mathf.Max(0, value);

            _amount.Value = Mathf.Clamp(value + _amount.Value, 0, _maxAmount.Value);

            UpdateFillAmount();
        }

        public bool Spend(int value)
        {
            value = Mathf.Max(0, value);

            if (HasEnough(value) == false)
                return false;

            _amount.Value -= value;

            UpdateFillAmount();
            return true;
        }

        public void SetValue(int value)
        {
            value = Mathf.Clamp(value, 0, _maxAmount.Value);

            _amount.Value = value;

            UpdateFillAmount();
        }

        public void SetMaxValue(int value)
        {
            value = Mathf.Max(0, value);

            _maxAmount.Value = value;

            SetValue(_amount.Value);
        }

        public void Clear() => SetValue(0);

        public bool HasEnough(int value) => _amount.Value >= value;

        private void UpdateFillAmount() => _fillAmount.Value = CalculateFillAmount();

        private float CalculateFillAmount()
        {
            if (_maxAmount.Value == 0)
                return 0;

            return _amount.Value / (float)_maxAmount.Value;
        }
    }
}