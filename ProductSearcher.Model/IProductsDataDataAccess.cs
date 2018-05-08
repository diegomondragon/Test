
namespace ProductSearcher.Model
{
    public interface IProductsDataDataAccess
    {
        ProductDataQuery GetProducts(ProductDataQuery dataQuery);
    }
}