//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;
using System.ComponentModel;
using System.Linq;

namespace dotNetExt
{
    public static class EnumExtensions
    {
        /// <summary>
        /// If the specified Enumeration has a System.ComponentModel.DescriptionAttribute defined, the defined description is returned. Otherwise ".ToString()" is called on the Enumeration value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescriptionString(this Enum value)
        {
            var attr = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return (attr != null) ? attr.Description : value.ToString();
        } 
    }
}
