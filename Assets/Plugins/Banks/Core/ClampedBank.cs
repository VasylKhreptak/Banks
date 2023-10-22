using UniRx;

namespace Plugins.Banks.Core
{
    public abstract class ClampedBank<T> : Bank<T>
    {
        protected readonly ReactiveProperty<T> _maxValue;
        protected readonly ReactiveProperty<float> _fillAmount;

        public IReadOnlyReactiveProperty<T> MaxValue => _maxValue;
        public IReadOnlyReactiveProperty<float> FillAmount => _fillAmount;

        public ClampedBank()
        {
            _maxValue = new ReactiveProperty<T>();
            _fillAmount = new ReactiveProperty<float>();
        }

        public ClampedBank(T value, T maxValue) : base(value)
        {
            _maxValue = new ReactiveProperty<T>(maxValue);
            _fillAmount = new ReactiveProperty<float>(CalculateFillAmount());
        }

        protected abstract void UpdateFillAmount();

        protected abstract float CalculateFillAmount();

        protected abstract void ClampValue();

        public abstract void SetMaxValue(T value);
    }
}