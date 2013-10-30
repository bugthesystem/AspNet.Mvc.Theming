using System.Web.Mvc;
using JustImpact.Mvc.Theming.Attributes;
using JustImpact.Mvc.Theming.Sample.Models;

namespace JustImpact.Mvc.Theming.Sample.Controllers {
    [Theme("Default")]
    public class WorkController : Controller {

        [HttpGet]
        public ActionResult Index() {
            return View(new HomeModel {
                Content = "Hello View Model Factory!"
            });
        }

    }
}
