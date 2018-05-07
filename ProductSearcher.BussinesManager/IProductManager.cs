using ProductSearcher.Model;

namespace ProductSearcher.BussinesManager
{
    public interface IProductManager
    {
        ProductDataQuery GetProducts(ProductDataQuery dataQuery);
    }
}