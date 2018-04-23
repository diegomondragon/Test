using HEB.ProductSearch.Model;

namespace HEB.ProductSearsher.BussinesManager
{
    public interface IProductManager
    {
        ProductDataQuery GetProducts(ProductDataQuery dataQuery);
    }
}