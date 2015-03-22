using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AspNet.Mvc.Theming.Configuration;

namespace AspNet.Mvc.Theming.ViewEngine
{
    public class ThemeableRazorViewEngine : RazorViewEngine
    {
        private readonly IThemingConfiguration _configuration;

        public ThemeableRazorViewEngine(IThemingConfiguration configuration)
        {
            _configuration = configuration;

            ViewLocationFormats = new[]
            {
                "~/Themes/$Theme/Views/Shared/{0}.cshtml",
                "~/Themes/$Theme/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

            PartialViewLocationFormats = new[]
            {
                "~/Themes/$Theme/Views/Shared/{0}.cshtml",
                "~/Themes/$Theme/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
        }

        private string GetTheme(ControllerContext context)
        {
            var theme = _configuration.ThemeResolver.Resolve(context, _configuration.DefaultTheme);
            return theme;
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            if (!partialPath.Contains("Areas"))
            {
                return base.CreatePartialView(controllerContext,
               partialPath.Replace("$Theme", GetTheme(controllerContext)));
            }

            return base.CreatePartialView(controllerContext, partialPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            if (!viewPath.Contains("Areas"))
            {
                masterPath = String.Format("~/Themes/{0}/Views/Shared/_Layout.cshtml", GetTheme(controllerContext));

                return base.CreateView(controllerContext,
                    viewPath.Replace("$Theme", GetTheme(controllerContext)),
                    masterPath);
            }

            return base.CreateView(controllerContext, viewPath, masterPath);
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            if (!virtualPath.Contains("Areas"))
            {
                return base.FileExists(controllerContext,
                virtualPath.Replace("$Theme", GetTheme(controllerContext)));
            }

            return base.FileExists(controllerContext, virtualPath);
        }
    }
}