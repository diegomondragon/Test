using HEB.ProductSearch.Model;

namespace HEB.ProductSearcher.DataManager
{
    public interface IProductsDataDataAccess
    {
        ProductDataQuery GetProducts(ProductDataQuery dataQuery);
        ProductDataQuery GetProducts();
    }
}