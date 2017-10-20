//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System.Text;

namespace dotNetExt
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Replaces one of more format items in the specified string with the string representation of a corresponding object of a specified array, and then Appends that to this instance followed by the default line terminator
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void AppendLineFormat(this StringBuilder builder, string format, params object[] args)
        {
            builder.AppendLine(string.Format(format, args));
        }
    }
}
