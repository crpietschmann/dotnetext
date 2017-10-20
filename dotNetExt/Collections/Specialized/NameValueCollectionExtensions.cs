//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System.Collections.Generic;
using System.Collections.Specialized;

namespace dotNetExt
{
    public static class NameValueCollectionExtensions
    {
        public static IDictionary<string, object> ToDictionary(this NameValueCollection collection)
        {
            var dict = new Dictionary<string, object>();

            if (collection != null)
            {
                foreach (var key in collection.AllKeys)
                {
                    dict.Add(key, collection[key]);
                }
            }
            
            return dict;
        }
    }
}
