using System.Web.Mvc;
using AspNet.Mvc.Theming.ThemeSelectorSample.Models;

namespace AspNet.Mvc.Theming.ThemeSelectorSample.Controllers
{
    public class DummyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new WorkModel
            {
                Content = "Hello View Model Factory!"
            });
        }
    }
}