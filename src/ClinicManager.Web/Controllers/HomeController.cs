using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Web.Controllers
{
    public class HomeController : ClinicManagerControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}