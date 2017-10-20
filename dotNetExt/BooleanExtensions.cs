//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotNetExt
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// Returns a binary (or "bit") representation of the Boolean value. True returns 1; False returns 0
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int ToBinary(this bool b)
        {
            return b ? 1 : 0;
        }

        /// <summary>
        /// Executes the Action if the Boolean value is True
        /// </summary>
        /// <param name="b"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool IfTrue(this bool b, Action action)
        {
            if (b)
            {
                action();
            }
            return b;
        }

        /// <summary>
        /// Executes the Action if the Boolean value is False
        /// </summary>
        /// <param name="b"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool IfFalse(this bool b, Action action)
        {
            if (!b)
            {
                action();
            }
            return b;
        }
    }
}
