using System;
using System.Collections.Generic;
using System.Linq;
using HEB.ProductSearcher.Common;
using System.Data.SqlClient;

namespace HEB.ProductSearch.Model
{
    public class ProductDataQuery
    {
        private List<KeyValuePair<string, ColumnType>> columns = new List<KeyValuePair<string, ColumnType>>() {
                new KeyValuePair<string, ColumnType>("Description", ColumnType.String),
                new KeyValuePair<string, ColumnType>("LastSold", ColumnType.Date),
                new KeyValuePair<string, ColumnType>("ShelLife", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("DepartmentId", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("Price", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("UnitId", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("xFor", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("Cost", ColumnType.Number)

            };

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

            foreach (KeyValuePair<string, ColumnType> column in columns)
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
                                    stringColumnFilters += string.Concat("(Product.", filter.ColumnName, " Like '%' + @" + @filter.ColumnName + parameterIndex + " + '%')");
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

        public SqlParameter[] GetFilterParameters()
        {
            List<SqlParameter> sqlParameterList = new List<SqlParameter>();

            foreach (KeyValuePair<string, ColumnType> column in columns)
            {
                List<Filter> columnFilters = this.Filters.Where(x => column.Key.Equals(x.ColumnName, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(x.Value)).ToList();
                int parameterIndex = 1;

                foreach (Filter filter in columnFilters)
                {
                    if (!string.IsNullOrEmpty(filter.Value))
                        sqlParameterList.Add(new SqlParameter("@" + @filter.ColumnName + parameterIndex, System.Data.SqlDbType.VarChar) { Value = filter.Value });

                    parameterIndex++;
                }
            }

            return sqlParameterList.ToArray();

        }
    }
}
