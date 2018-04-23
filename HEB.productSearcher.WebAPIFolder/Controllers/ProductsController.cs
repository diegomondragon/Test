using HEB.ProductSearch.Model;
using HEB.productSearcher.WebAPI.ModelBinders;
using HEB.ProductSearsher.BussinesManager;
using System.Web.Http;
using System.Web.Mvc;

namespace HEB.productSearcher.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        IProductManager _productManager;

        public ProductsController(): this(new ProductManager())
        {          
        }

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }     

        // GET api/products
        public ProductDataQuery Get([ModelBinder(typeof(ProductDataQueryModelBinder))] ProductDataQuery dataQuery)
        {
            return _productManager.GetProducts(dataQuery);
        }      
    }
}
