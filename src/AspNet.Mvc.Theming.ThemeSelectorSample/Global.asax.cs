using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.Mvc.Theming.ThemeSelectorSample
{
    public class SessionThemeResover : IThemeResolver
    {
        public string Resolve(ControllerContext controllerContext, string theme)
        {
            string result;

            if (controllerContext.HttpContext.Session != null && controllerContext.HttpContext.Session["Theme"] != null)
            {
                result = controllerContext.HttpContext.Session["Theme"].ToString();
            }
            else
            {
                result = (!string.IsNullOrEmpty(theme) ? theme : "Default");
            }

            return result;
        }
    }

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
                config.DefaultTheme = "Default";
                config.ThemeResolver = new SessionThemeResover();
            });
        }
    }
}