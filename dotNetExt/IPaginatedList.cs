//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System.Collections;
using System.Collections.Generic;

namespace dotNetExt
{
    public interface IPaginatedList : IList, ICollection, IEnumerable
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }

    public interface IPaginatedList<T> : IPaginatedList, IList<T>, ICollection<T>, IEnumerable<T>
    {

    }
}
