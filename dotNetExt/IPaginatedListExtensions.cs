//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace dotNetExt
{
    public static class IPaginatedListExtensions
    {
        public static DataPage ToDataPage(this IPaginatedList paginatedList)
        {
            return new DataPage(paginatedList);
        }

        public static DataPage<T> ToDataPage<T>(this IPaginatedList<T> paginatedList)
        {
            return new DataPage<T>(paginatedList);
        }
    }
}
