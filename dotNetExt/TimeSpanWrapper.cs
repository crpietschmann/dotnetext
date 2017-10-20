//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace dotNetExt
{
    public class TimeSpanWrapper
    {
        public TimeSpanWrapper(System.TimeSpan ts)
        {
            this.TimeSpan = ts;
        }

        public System.TimeSpan TimeSpan { get; private set; }

        public static implicit operator TimeSpanWrapper(System.TimeSpan ts)
        {
            return new TimeSpanWrapper(ts);
        }

        public static System.TimeSpan operator *(TimeSpanWrapper tsoe, int i)
        {
            var ts = tsoe.TimeSpan;
            var r = ts;
            for (var a = 1; a < i; a++)
            {
                r = r + ts;
            }
            return r;
        }
    }
}
