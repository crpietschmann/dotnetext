//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;

namespace dotNetExt
{
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// Converts the IDictionary instance into a ExpandoObject.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDict = (IDictionary<string, object>)expando;

            foreach (var item in dictionary)
            {
                if (item.Value is IDictionary<string, object>)
                {
                    var d = (IDictionary<string, object>)item.Value;
                    expandoDict.Add(item.Key, d.ToExpando());
                }
                else
                {
                    expandoDict.Add(item);
                }
            }

            return expando;
        }

        /// <summary>
        /// Converts ths IDictionary instance into a NameValueCollection.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var col = new NameValueCollection();
            foreach (var item in dictionary)
            {
                col.Add(item.Key, item.Value);
            }
            return col;
        }
    }
}
