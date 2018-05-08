﻿using System;
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
        public string GetFiltersAsString()
        {
            string stringFilters = string.Empty;

            foreach (KeyValuePair<string, ColumnType> column in ProductColumns.Columns)
            {
                List<Filter> columnFilters = this.Filters.Where(x => column.Key.Equals(x.ColumnName, StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (columnFilters != null && columnFilters.Count > 0)
                {

                    //Only AND condition is use for search usign multiple columns
                    if (!string.IsNullOrEmpty(stringFilters) && columnFilters.Count > 0)
                        stringFilters += " AND ";

                    ColumnType columnType = column.Value;
                    string stringColumnFilters = string.Empty;
                    int parameterIndex = 1;



                    //Only OR condition is use for search usign multiple filters for one column
                    switch (columnType)
                    {
                        case ColumnType.String:
                            //Since only AND is use, for string only one filter is allow, takes the first one
                            Filter filter = columnFilters.FirstOrDefault();

                            switch (filter.FilterType)
                            {
                                case FilterType.Equal:
                                    stringColumnFilters += string.Concat("(Product.", filter.ColumnName, " = @" + @filter.ColumnName + parameterIndex + ")");
                                    break;
                                case FilterType.Contains:
                                    stringColumnFilters += string.Concat("(Product.", filter.ColumnName, " LIKE CONCAT('%', @" + @filter.ColumnName + parameterIndex + ", '%'))");
                                    break;
                            }
                            break;
                        case ColumnType.Number:
                        case ColumnType.Date:
                            foreach (Filter columnFilter in columnFilters)
                            {
                                if (!string.IsNullOrEmpty(stringColumnFilters))
                                {
                                    stringColumnFilters += " AND ";
                                    parameterIndex++;
                                }
                                string parameterName = "@" + columnFilter.ColumnName + parameterIndex.ToString();

                                switch (columnFilter.FilterType)
                                {
                                    case FilterType.Equal:
                                        stringColumnFilters += string.Concat("Product.", columnFilter.ColumnName, " = " + parameterName);
                                        break;
                                    case FilterType.GreatherEqualThan:
                                        stringColumnFilters += string.Concat("Product.", columnFilter.ColumnName, " >= " + parameterName);
                                        break;
                                    case FilterType.LessEqualThan:
                                        stringColumnFilters += string.Concat("Product.", columnFilter.ColumnName, " <= " + parameterName);
                                        break;
                                }
                            }
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    if (!string.IsNullOrEmpty(stringColumnFilters))
                    {
                        stringFilters += "(" + stringColumnFilters + ")";
                    }
                }
            }
            return stringFilters;
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
