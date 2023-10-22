using UniRx;

namespace Plugins.Banks.Core
{
    public abstract class Bank<T>
    {
        protected readonly ReactiveProperty<T> _value;

        public IReadOnlyReactiveProperty<T> Value => _value;

        public Bank()
        {
            _value = new ReactiveProperty<T>();
        }

        public Bank(T value)
        {
            _value = new ReactiveProperty<T>(value);
        }

        public abstract void Add(T value);

        public abstract bool Spend(T value);

        public abstract bool HasEnough(T value);
    }
}