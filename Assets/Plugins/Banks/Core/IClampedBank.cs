using System;

namespace Plugins.Banks.Core
{
    public interface IClampedBank<T> : IReadOnlyClampedBank<T>, IBank<T> where T : IComparable<T>
    {
        public void SetMaxValue(T value);

        public void Fill();
    }
}