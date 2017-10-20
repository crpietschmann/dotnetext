//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace dotNetExt
{
    /// <summary>
    /// A page of IPaginatedList data, with the list exposed via 'Data' property and page index and count values exposed as additional properties.
    /// The primary purpose of this is to serve as a vehicle for delivery data to be serialized for transfer (likely using JSON in ASP.NET MVC or Web API.)
    /// </summary>
    public class DataPage<T> : IDataPage<T>
    {
        public DataPage(IPaginatedList<T> paginatedList)
        {
            this.Data = paginatedList;
        }

        public IPaginatedList<T> Data { get; private set; }

        IPaginatedList IDataPage.Data
        {
            get { return this.Data; }
        }

        public int PageIndex
        {
            get
            {
                return this.Data.PageIndex;
            }
        }

        public int TotalCount
        {
            get
            {
                return this.Data.TotalCount;
            }
        }

        public int TotalPages
        {
            get
            {
                return this.Data.TotalPages;
            }
        }
    }

    /// <summary>
    /// A page of IPaginatedList data, with the list exposed via 'Data' property and page index and count values exposed as additional properties.
    /// The primary purpose of this is to serve as a vehicle for delivery data to be serialized for transfer (likely using JSON in ASP.NET MVC or Web API.)
    /// </summary>
    public class DataPage : IDataPage
    {
        public DataPage(IPaginatedList paginatedList)
        {
            this.Data = paginatedList;
        }

        public IPaginatedList Data { get; private set; }

        public int PageIndex
        {
            get
            {
                return this.Data.PageIndex;
            }
        }

        public int TotalCount
        {
            get
            {
                return this.Data.TotalCount;
            }
        }

        public int TotalPages
        {
            get
            {
                return this.Data.TotalPages;
            }
        }
    }
}
