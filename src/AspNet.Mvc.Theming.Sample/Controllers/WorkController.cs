using System.Web.Mvc;
using AspNet.Mvc.Theming.Attributes;
using AspNet.Mvc.Theming.Sample.Models;

namespace AspNet.Mvc.Theming.Sample.Controllers
{
    [Theme("Default")]
    public class WorkController : Controller
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
