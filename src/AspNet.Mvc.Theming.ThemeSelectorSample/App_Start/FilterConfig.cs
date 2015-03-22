using System.Web.Mvc;

namespace AspNet.Mvc.Theming.ThemeSelectorSample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}