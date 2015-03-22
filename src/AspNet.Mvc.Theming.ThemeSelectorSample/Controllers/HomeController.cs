using System.Web.Mvc;
using AspNet.Mvc.Theming.Attributes;
using AspNet.Mvc.Theming.ThemeSelectorSample.Models;

namespace AspNet.Mvc.Theming.ThemeSelectorSample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Session["Theme"] = "Atomic";

            return View(new HomeModel
            {
                Content = "Hello View Model!"
            });
        }
    }
}