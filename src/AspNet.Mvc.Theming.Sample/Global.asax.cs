using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.Mvc.Theming.Sample
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ThemeManager.Instance.Configure(config =>
            {
                config.ThemeDirectory = "~/Themes";
                config.DefaultTheme = "Other";
            });
        }
    }
}