using System;
using UniRx;

namespace Plugins.Banks.Core
{
    public interface IClampedBank<T> : IBank<T> where T : IComparable<T>
    {
        public IReadOnlyReactiveProperty<T> MaxAmount { get; }

        public IReadOnlyReactiveProperty<float> FillAmount { get; }

        public IReadOnlyReactiveProperty<bool> IsFull { get; }

        public void SetMaxValue(T value);

        public void Fill();
    }
}