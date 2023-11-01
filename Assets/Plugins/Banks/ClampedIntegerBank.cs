using Plugins.Banks.Core;
using UnityEngine;

namespace Plugins.Banks
{
    public class ClampedIntegerBank : ClampedBank<int>
    {
        public ClampedIntegerBank() { }

        public ClampedIntegerBank(int value, int maxValue) : base(value, maxValue) { }

        public override void Add(int value)
        {
            value = Mathf.Max(0, value);
            _value.Value = Mathf.Clamp(value + _value.Value, 0, _maxValue.Value);
            UpdateFillAmount();
            UpdateLeftToFill();
        }

        public override bool Spend(int value)
        {
            value = Mathf.Max(0, value);

            if (value > _value.Value)
                return false;

            _value.Value -= value;

            UpdateFillAmount();
            UpdateLeftToFill();
            return true;
        }

        public override void SetValue(int value)
        {
            _value.Value = Mathf.Clamp(value, 0, _maxValue.Value);

            UpdateFillAmount();
            UpdateLeftToFill();
        }

        public override void Clear() => SetValue(0);

        public override bool HasEnough(int value)
        {
            value = Mathf.Max(0, value);

            return _value.Value >= value;
        }

        protected override void UpdateFillAmount() => _fillAmount.Value = CalculateFillAmount();

        protected override float CalculateFillAmount()
        {
            if (_maxValue.Value == 0)
                return 0;

            return _value.Value / (float)_maxValue.Value;
        }

        protected override void ClampValue()
        {
            _value.Value = Mathf.Clamp(_value.Value, 0, _maxValue.Value);
            UpdateFillAmount();
            UpdateLeftToFill();
        }

        public override void SetMaxValue(int value)
        {
            value = Mathf.Max(0, value);
            _maxValue.Value = value;
            ClampValue();
        }

        public override void Fill() => SetValue(_maxValue.Value);

        protected override void UpdateLeftToFill() => _leftToFill.Value = CalculateLeftToFill();

        protected override int CalculateLeftToFill() => _maxValue.Value - _value.Value;
    }
}