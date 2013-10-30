using System.Web.Mvc;

namespace JustImpact.Mvc.Theming.Sample.App_Start {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}