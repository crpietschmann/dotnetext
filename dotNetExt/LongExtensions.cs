//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;

namespace dotNetExt
{
    public static class LongExtensions
    {
        /// <summary>
        /// Converts a Unix Time Stamp (long / Int64 representing the number of seconds since Jan 1, 1970) to a DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertFromUnixTimestamp(this long timestamp)
        {
            var dt = new DateTime(1970, 1, 1);
            return dt.AddSeconds(timestamp);
        }
    }
}
