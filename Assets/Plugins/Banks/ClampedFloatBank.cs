using Plugins.Banks.Core;
using UnityEngine;

namespace Plugins.Banks
{
    public class ClampedFloatBank : ClampedBank<float>
    {
        public ClampedFloatBank() { }

        public ClampedFloatBank(float value, float maxValue) : base(value, maxValue) { }

        public override void Add(float value)
        {
            value = Mathf.Max(0, value);
            _value.Value = Mathf.Clamp(value + _value.Value, 0, _maxValue.Value);
            UpdateFillAmount();
            UpdateLeftToFill();
        }

        public override bool Spend(float value)
        {
            value = Mathf.Max(0, value);

            if (value > _value.Value)
                return false;

            _value.Value -= value;

            UpdateFillAmount();
            UpdateLeftToFill();
            return true;
        }

        public override void SetValue(float value)
        {
            _value.Value = Mathf.Clamp(value, 0, _maxValue.Value);

            UpdateFillAmount();
            UpdateLeftToFill();
        }

        public override void Clear() => SetValue(0);

        public override bool HasEnough(float value)
        {
            value = Mathf.Max(0, value);

            return _value.Value >= value;
        }

        protected override void UpdateFillAmount() => _fillAmount.Value = CalculateFillAmount();

        protected override float CalculateFillAmount()
        {
            if (Mathf.Approximately(_maxValue.Value, 0))
                return 0;

            return _value.Value / _maxValue.Value;
        }

        protected override void ClampValue()
        {
            _value.Value = Mathf.Clamp(_value.Value, 0, _maxValue.Value);
            UpdateFillAmount();
            UpdateLeftToFill();
        }

        public override void SetMaxValue(float value)
        {
            value = Mathf.Max(0, value);
            _maxValue.Value = value;
            ClampValue();
        }

        public override void Fill() => SetValue(_maxValue.Value);

        protected override void UpdateLeftToFill() => _leftToFill.Value = CalculateLeftToFill();

        protected override float CalculateLeftToFill() => _maxValue.Value - _value.Value;
    }
}