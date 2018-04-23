using HEB.ProductSearch.Model;
using System.Collections.Generic;

namespace HEB.ProductSearcher.DataManager
{
    public class ProductsDataManager
    {

        //TODO: Create a verion with ORM
        public ProductsDataManager() {

        }

        public ProductDataQuery GetProducts(ProductDataQuery dataQuery)
        {
            try
            {

            }
            catch (System.Exception)
            {
                //TODO: Log to file for make easy debbuging
                throw;
            }
            return new ProductDataQuery();
        }
    }
}
