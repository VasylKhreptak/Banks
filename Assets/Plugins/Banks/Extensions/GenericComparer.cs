using System;

namespace Plugins.Banks.Extensions
{
    public static class GenericComparer
    {
        public static T Clamp<T>(T value, T minValue, T maxValue) where T : IComparable<T>
        {
            if (value.CompareTo(minValue) < 0)
                return minValue;

            if (value.CompareTo(maxValue) > 0)
                return maxValue;

            return value;
        }

        public static T Min<T>(T value1, T value2) where T : IComparable<T> => value1.CompareTo(value2) < 0 ? value1 : value2;

        public static T Max<T>(T value1, T value2) where T : IComparable<T> => value1.CompareTo(value2) > 0 ? value1 : value2;

        public static bool Equals<T>(T value1, T value2) where T : IComparable<T> => value1.CompareTo(value2) == 0;
    }
}