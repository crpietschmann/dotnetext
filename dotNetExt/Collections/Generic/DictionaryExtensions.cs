//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System.Collections.Generic;

namespace dotNetExt
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Returns a new instance of System.Collections.Generic.SortedDictionary<TKey,TValue> that is based on the specified Dictionary<TKey,TValue> and uses the default System.Collections.Generic.IComparer<T> implementation for the key type
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static SortedDictionary<TKey, TValue> Sort<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            return new SortedDictionary<TKey, TValue>(dict);
        }

        /// <summary>
        /// Returns a new instance of System.Collections.Generic.SortedDictionary<TKey,TValue> that is based on the specified Dictionary<TKey,TValue> and uses the specified System.Collections.Generic.IComparer<T> to compare keys
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static SortedDictionary<TKey, TValue> Sort<TKey, TValue>(this Dictionary<TKey, TValue> dict, IComparer<TKey> comparer)
        {
            return new SortedDictionary<TKey, TValue>(dict, comparer);
        }
    }
}
