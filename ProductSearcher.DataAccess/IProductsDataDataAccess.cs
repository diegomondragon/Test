using ProductSearch.Model;

namespace ProductSearcher.DataManager
{
    public interface IProductsDataDataAccess
    {
        ProductDataQuery GetProducts(ProductDataQuery dataQuery);
        ProductDataQuery GetProducts();
    }
}