using System;

namespace Plugins.Banks.Core
{
    public interface IBank<T> : IReadOnlyBank<T> where T : IComparable<T>
    {
        public void Add(T value);

        public void Spend(T value);

        public void SetValue(T value);

        public void Clear();

        public bool HasEnough(T value);
    }
}