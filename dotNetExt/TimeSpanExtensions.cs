//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace dotNetExt
{
    public static class TimeSpanExtensions
    {
        #region "Ago"

        /// <summary>
        /// Returns the Current DateTime with the specified TimeSpan subtracted from it.
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static System.DateTime Ago(this System.TimeSpan ts)
        {
            return System.DateTime.Now.Subtract(ts);
        }

        /// <summary>
        /// Returns the Current Coordinated Universal Time (UTC) with the specified TimeSpan subtracted from it.
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static System.DateTime UtcAgo(this System.TimeSpan ts)
        {
            return System.DateTime.UtcNow.Subtract(ts);
        }

        #endregion

        #region "FromNow"

        /// <summary>
        /// Returns the Current DateTime with the specified TimeSpan added to it.
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static System.DateTime FromNow(this System.TimeSpan ts)
        {
            return System.DateTime.Now.Add(ts);
        }

        /// <summary>
        /// Returns the Current Coordinated Universal Time (UTC) with the specified TimeSpan added to it.
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static System.DateTime UtcFromNow(this System.TimeSpan ts)
        {
            return System.DateTime.UtcNow.Add(ts);
        }

        #endregion
    }
}
