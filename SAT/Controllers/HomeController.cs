using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpGet]      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Classes()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
    }
}
