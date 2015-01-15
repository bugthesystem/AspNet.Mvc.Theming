using System.Web.Mvc;
using AspNet.Mvc.Theming.Attributes;
using AspNet.Mvc.Theming.Sample.Models;

namespace AspNet.Mvc.Theming.Sample.Controllers {
    [Theme("Other")]
    public class HomeController : Controller {

        [HttpGet]
        public ActionResult Index() {
            return View(new HomeModel {
                Content = "Hello View Model!"
            });
        }

    }
}
