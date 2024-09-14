using UniRx;

namespace Plugins.Banks.Core
{
    public interface IReadOnlyBank<T>
    {
        public IReadOnlyReactiveProperty<T> Amount { get; }

        public IReadOnlyReactiveProperty<bool> IsEmpty { get; }
    }
}