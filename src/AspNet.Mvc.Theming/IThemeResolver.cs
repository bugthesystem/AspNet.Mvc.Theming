using System.Web.Mvc;

namespace AspNet.Mvc.Theming
{
    public interface IThemeResolver
    {
        string Resolve(ControllerContext controllerContext, string theme);
    }
}