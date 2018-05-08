using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using ProductSearcher.Common;

namespace ProductSearcher.Model
{
    public class ProductDataQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IList<Filter> Filters { get; set; }
        public IList<Product> Result { get; set; }
        public int Total { get; set; }
        public ProductDataQuery()
        {
            Filters = new List<Filter>();
            Result = new List<Product>();
        }
        public int StartRow
        {
            get
            {
                return (this.PageNumber - 1) * this.PageSize;
            }
            private set { }
        }
        public int EndRow
        {
            get
            {
                return ((this.PageNumber - 1) * this.PageSize) + this.PageSize + 1;
            }
            private set { }
        }
    }
}
