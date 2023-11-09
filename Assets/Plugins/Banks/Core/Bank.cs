using UniRx;

namespace Plugins.Banks.Core
{
    public abstract class Bank<T>
    {
        protected readonly ReactiveProperty<T> _value;
        public readonly IReadOnlyReactiveProperty<bool> IsEmpty;

        public IReadOnlyReactiveProperty<T> Value => _value;

        public Bank()
        {
            _value = new ReactiveProperty<T>();
            IsEmpty = _value.Select(value => value.Equals(default)).ToReadOnlyReactiveProperty();
        }

        public Bank(T value)
        {
            _value = new ReactiveProperty<T>(value);
            IsEmpty = _value.Select(value => value.Equals(default)).ToReadOnlyReactiveProperty();
        }

        public abstract void Add(T value);

        public abstract bool Spend(T value);

        public abstract void SetValue(T value);

        public abstract void Clear();

        public abstract bool HasEnough(T value);
    }
}