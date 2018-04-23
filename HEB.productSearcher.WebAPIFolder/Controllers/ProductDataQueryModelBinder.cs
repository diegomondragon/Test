using HEB.ProductSearch.Model;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace HEB.productSearcher.WebAPI.Controllers
{
    public class ProductDataQueryModelBinder :IModelBinder
    {
        static ProductDataQueryModelBinder() {

        }
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(ProductDataQuery))
            {
                return false;
            }

            ValueProviderResult val = bindingContext.ValueProvider.GetValue(
                "PageSize");
            if (val == null)
            {
                return false;
            }

            string key = val.RawValue as string;
            if (key == null)
            {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName, "Wrong value type");
                return false;
            }

            ProductDataQuery result;
                return true;
            //if (_locations.TryGetValue(key, out result) ||  ProductDataQuery.TryParse(key, out result))
            //{
            //    bindingContext.Model = result;
            //    return true;
            //}

            bindingContext.ModelState.AddModelError(
                bindingContext.ModelName, "Cannot convert value to Location");
            return false;
        }

       
    }
}