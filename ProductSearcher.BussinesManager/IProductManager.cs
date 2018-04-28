using ProductSearch.Model;

namespace ProductSearsher.BussinesManager
{
    public interface IProductManager
    {
        ProductDataQuery GetProducts(ProductDataQuery dataQuery);
    }
}