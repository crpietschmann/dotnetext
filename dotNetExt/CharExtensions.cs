using System;

namespace dotNetExt
{
    public static class CharExtensions
    {
        /// <summary>
        /// Returns a String that is a concatenation of the source Char repeated the specified number of times.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="count">The number of times to repeat the Char in the returned concatenation.</param>
        /// <returns></returns>
        public static string Repeat(this char c, int count)
        {
            return new String(c, count);
        }
    }
}
