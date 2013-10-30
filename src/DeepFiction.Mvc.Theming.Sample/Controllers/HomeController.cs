using System.Web.Mvc;
using DeepFiction.Mvc.Theming.Attributes;
using DeepFiction.Mvc.Theming.Sample.Models;

namespace DeepFiction.Mvc.Theming.Sample.Controllers {
    [Theme("Other")]
    public class HomeController : Controller {

        [HttpGet]
        public ActionResult Index() {
            return View(new HomeModel {
                Content = "Hello View Model Factory!"
            });
        }

    }
}
