using UniRx;

namespace Plugins.Banks.Data.Economy.Core
{
    public abstract class Bank<T>
    {
        public readonly BankType BankType;

        protected readonly ReactiveProperty<T> _value;

        public Bank(BankType type, T value)
        {
            BankType = type;
            _value = new ReactiveProperty<T>(value);
        }

        public IReadOnlyReactiveProperty<T> Value => _value;

        public abstract void Add(T value);

        public abstract bool Spend(T value);

        public abstract bool HasEnough(T value);
    }
}
