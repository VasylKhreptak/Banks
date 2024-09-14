using System;
using UniRx;

namespace Plugins.Banks.Core
{
    public interface IReadOnlyClampedBank<T> : IReadOnlyBank<T> where T : IComparable<T>
    {
        public IReadOnlyReactiveProperty<T> MaxAmount { get; }

        public IReadOnlyReactiveProperty<float> FillAmount { get; }

        public IReadOnlyReactiveProperty<bool> IsFull { get; }
    }
}