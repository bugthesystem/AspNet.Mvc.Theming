using System.Web.Mvc;
using DeepFiction.Mvc.Theming.Attributes;
using DeepFiction.Mvc.Theming.Sample.Models;

namespace DeepFiction.Mvc.Theming.Sample.Controllers {
    [Theme("Default")]
    public class WorkController : Controller {

        [HttpGet]
        public ActionResult Index() {
            return View(new WorkModel {
                Content = "Hello View Model Factory!"
            });
        }

    }
}
