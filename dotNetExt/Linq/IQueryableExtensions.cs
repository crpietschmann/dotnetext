//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System.Linq;

namespace dotNetExt
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Returns a PaginatedList based on the specified IQueryable and page index and page size. The total count is gathered from the query itself.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PaginatedList<T> ToPaginatedList<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            return new PaginatedList<T>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// Returns a PaginatedList based on the specified IQueryable with the specified page index, page size and total count set. This is for using when the IQueryable already contains a known subset of the full query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static PaginatedList<T> ToPaginatedList<T>(this IQueryable<T> query, int pageIndex, int pageSize, int totalCount)
        {
            return new PaginatedList<T>(query, pageIndex, pageSize, totalCount);
        }
    }
}
