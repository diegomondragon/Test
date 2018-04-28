using ProductSearch.Model;
using productSearcher.WebAPI.ModelBinders;
using ProductSearsher.BussinesManager;
using Microsoft.AspNetCore.Mvc;

namespace productSearcher.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        IProductManager _productManager;

        public ProductsController()
        {
            _productManager = new ProductManager();

        }

        [HttpGet]
        public ProductDataQuery Get([ModelBinder(typeof(ProductDataQueryModelBinder))] ProductDataQuery dataQuery)
        {
            return _productManager.GetProducts(dataQuery);
        }      
    }
}
