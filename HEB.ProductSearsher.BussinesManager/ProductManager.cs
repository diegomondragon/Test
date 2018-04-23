using HEB.ProductSearch.Model;
using HEB.ProductSearcher.DataManager;
using System.Collections.Generic;

namespace HEB.ProductSearsher.BussinesManager
{
    public class ProductManager : IProductManager
    {
        private IProductsDataDataAccess _productDataAccess;

        public ProductManager() : this(new ProductsDataDataAccess())
        {
        }
        public ProductManager(IProductsDataDataAccess productsDataDataAccess)
        {
            _productDataAccess = productsDataDataAccess;
        }
        public ProductDataQuery GetProducts(ProductDataQuery dataQuery)
        {
            try
            {
                //TODO: Add  bussines rules return an error message
                if (dataQuery != null)
                {
                    dataQuery = _productDataAccess.GetProducts(dataQuery);
                }
            }
            catch (System.Exception Ex)
            {
                //TODO: Log to file for make easy debbuging
                throw;
            }
            return dataQuery;
        }

    }
}
