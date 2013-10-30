using System;
using System.Web.Mvc;

namespace DeepFiction.Mvc.Theming.ViewEngine {
    public class ThemeableRazorViewEngine : RazorViewEngine {
        private Func<ControllerContext, string> ThemeSelector { get; set; }

        public ThemeableRazorViewEngine(Func<ControllerContext, string> themeSelector) {
            ThemeSelector = themeSelector;

            ViewLocationFormats = new[] {
                                            "~/Themes/$Theme/Views/Shared/{0}.cshtml",
                                            "~/Themes/$Theme/Views/{1}/{0}.cshtml",                                                                                              
                                            "~/Views/{1}/{0}.cshtml",                                            
                                            "~/Views/Shared/{0}.cshtml"                                          
                                        };

            PartialViewLocationFormats = new[] {
                                                   "~/Themes/$Theme/Views/Shared/{0}.cshtml",
                                                   "~/Themes/$Theme/Views/{1}/{0}.cshtml",                
                                                   "~/Views/{1}/{0}.cshtml",
                                                   "~/Views/Shared/{0}.cshtml"
                                               };
        }

        private string GetTheme(ControllerContext context) {
            var theme = ThemeSelector.Invoke(context);
            return theme;
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath) {
            return base.CreatePartialView(controllerContext,
                partialPath.Replace("$Theme", GetTheme(controllerContext)));
        }


        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath) {
            masterPath = String.Format("~/Themes/{0}/Views/Shared/_Layout.cshtml", GetTheme(controllerContext));

            return base.CreateView(controllerContext,
                viewPath.Replace("$Theme", GetTheme(controllerContext)),
                masterPath);
        }


        protected override bool FileExists(ControllerContext controllerContext, string virtualPath) {
            return base.FileExists(controllerContext,
                virtualPath.Replace("$Theme", GetTheme(controllerContext)));
        }
    }
}