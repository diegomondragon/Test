
namespace ProductSearcher.Model
{
    public interface IProductsDataDataAccess
    {
        ProductDataQuery GetProducts(ProductDataQuery dataQuery);
        ProductDataQuery GetProducts();
    }
}