using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearcher.DataManager
{
    public static class SqlConstants
    {
        public const string PRODUCTS_SELECT_QUERY_COUNT = "select count(Product.Id)" +
                                "from Product " +
                                "LEFT JOIN Department ON Product.DepartmentId = Department.Id " +
                                "LEFT JOIN Unit ON Product.UnitId = Unit.Id";
        public const string WHERE = " WHERE ";
        public const string PRODUCTS_SELECT_QUERY_OPEN = "SELECT *" +
                                "FROM(" +
                                "select ROW_NUMBER() OVER(ORDER BY Product.Id) AS RowN," +
                                "Product.Id, Product.Description, LastSold, ShelfLife, Department.Description Department, Price, Unit.Description Unit, xFor, Cost " +
                                "from Product " +
                                "LEFT JOIN Department ON Product.DepartmentId = Department.Id " +
                                "LEFT JOIN Unit ON Product.UnitId = Unit.Id";
        public const string PRODUCTS_SELECT_QUERY_CLOSE = ") AS Products WHERE RowN > @rowStart AND RowN<@rowEnd ";
        public const string ROW_START_PARAMETER_NAME = "@rowStart";
        public const string ROW_END_PARAMETER_NAME = "@rowEnd";
    }
}
