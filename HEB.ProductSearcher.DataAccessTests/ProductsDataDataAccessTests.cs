using Microsoft.VisualStudio.TestTools.UnitTesting;
using HEB.ProductSearch.Model;

namespace HEB.ProductSearcher.DataManager.Tests
{
    [TestClass()]
    public class ProductsDataDataAccessTests
    {
        [TestMethod()]
        public void GetProductsTest()
        {
            IProductsDataDataAccess dataAccess = new ProductsDataDataAccess();

            ProductDataQuery productsDataQueryInput = new ProductDataQuery();
            productsDataQueryInput.PageNumber = 1;
            productsDataQueryInput.PageSize = 8;

            productsDataQueryInput.Filters.Add(new Filter { ColumnName = "Description", FilterType = FilterType.Contains , Value = "Prod" });
            //productsDataQueryInput.Filters.Add(new Filter { ColumnName = "LastSold", FilterType = FilterType.GreatherEqualThan, Value = "1/3/2018" });
            productsDataQueryInput.Filters.Add(new Filter { ColumnName = "LastSold", FilterType = FilterType.GreatherEqualThan, Value = "1/3/2018" });
            //productsDataQueryInput.Filters.Add(new Filter { ColumnName = "ShelLife", FilterType = FilterType.Equal, Value = "1" });
            //productsDataQueryInput.Filters.Add(new Filter { ColumnName = "DepartmentId", FilterType = FilterType.GreatherThan, Value = "1" });
            //productsDataQueryInput.Filters.Add(new Filter { ColumnName = "Price", FilterType = FilterType.Between, Value = "5", Value2 ="7" });
            //productsDataQueryInput.Filters.Add(new Filter { ColumnName = "UnitId", FilterType = FilterType.GreatherThan, Value = "1" });
            //productsDataQueryInput.Filters.Add(new Filter { ColumnName = "xFor", FilterType = FilterType.GreatherThan, Value = "1" });
            //productsDataQueryInput.Filters.Add(new Filter { ColumnName = "Cost", FilterType = FilterType.GreatherThan, Value = "1" });

            ProductDataQuery productsDataQueryResult = dataAccess.GetProducts(productsDataQueryInput);
        }
    }
}