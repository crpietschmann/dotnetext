using System;

namespace dotNetExt
{
    public static class IComparableExtensions
    {
        /// <summary>
        /// Returns a boolean indicating whether the Source value is within the specified Min and Max range (inclusive).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source value to check.</param>
        /// <param name="min">The min value of the range to check.</param>
        /// <param name="max">The max value of the range to check.</param>
        /// <returns></returns>
        public static bool InRange<T>(this T source, T min, T max)
            where T : IComparable
        {
            return source.CompareTo(min) >= 0 && source.CompareTo(max) <= 0;
        }
    }
}
