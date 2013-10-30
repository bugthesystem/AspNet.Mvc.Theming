using System.Web.Mvc;
using System.Web.Routing;
using JustImpact.Mvc.Theming.Sample.App_Start;

namespace JustImpact.Mvc.Theming.Sample {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ThemeManager.Instance.Configure(config => {
                config.ThemeDirectory = "~/Themes";
                config.DefaultTheme = "Other";
            });
        }
    }
}