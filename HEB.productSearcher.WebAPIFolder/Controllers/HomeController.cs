using System.Web.Mvc;

namespace HEB.productSearcher.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Searcher API";
            return View();
        }
    }
}
