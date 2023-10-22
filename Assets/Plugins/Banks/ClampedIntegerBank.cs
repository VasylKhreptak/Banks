using Plugins.Banks.Core;
using UnityEngine;

namespace Plugins.Banks
{
    public class ClampedIntegerBank : ClampedBank<int>
    {
        public ClampedIntegerBank() : base() { }

        public ClampedIntegerBank(int value, int maxValue) : base(value, maxValue)
        {
            ClampValue();
        }

        public override void Add(int value)
        {
            value = Mathf.Max(0, value);
            _value.Value = Mathf.Clamp(value + _value.Value, 0, _maxValue.Value);
            UpdateFillAmount();
        }

        public override bool Spend(int value)
        {
            value = Mathf.Max(0, value);

            if (value > _value.Value)
                return false;

            _value.Value -= value;

            UpdateFillAmount();
            return true;
        }

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
        }

        public override void SetMaxValue(int value)
        {
            value = Mathf.Max(0, value);
            _maxValue.Value = value;
            ClampValue();
        }
    }
}