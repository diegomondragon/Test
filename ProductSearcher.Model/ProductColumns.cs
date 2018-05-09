using System;
using System.Collections.Generic;
using ProductSearcher.Common;

namespace ProductSearcher.Model
{
    public static class ProductColumns
    {
        public static  List<KeyValuePair<string, ColumnType>> Columns = new List<KeyValuePair<string, ColumnType>>() {
                new KeyValuePair<string, ColumnType>("Description", ColumnType.String),
                new KeyValuePair<string, ColumnType>("LastSold", ColumnType.Date),
                new KeyValuePair<string, ColumnType>("ShelfLife", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("DepartmentId", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("Price", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("UnitId", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("xFor", ColumnType.Number),
                new KeyValuePair<string, ColumnType>("Cost", ColumnType.Number)

            };
    }
}
