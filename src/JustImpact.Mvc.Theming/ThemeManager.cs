using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using JustImpact.Mvc.Theming.Configuration;
using JustImpact.Mvc.Theming.ViewEngine;

namespace JustImpact.Mvc.Theming {
    public class ThemeManager {
        static readonly Lazy<ThemeManager> Lazy = new Lazy<ThemeManager>(() => new ThemeManager(new ThemingConfiguration()));
        private readonly IThemingConfiguration _configuration;

        internal Func<ControllerContext, string> ThemeSelector {
            get {
                Func<ControllerContext, string> routeFunc = x => x.RouteData.Values.ContainsKey("Theme") ? x.RouteData.Values["Theme"].ToString() : null;
                Func<ControllerContext, string> siteFunc = x => !string.IsNullOrEmpty(_configuration.DefaultTheme) ? _configuration.DefaultTheme : "Default";
                return x => routeFunc.Invoke(x) ?? siteFunc.Invoke(x);
            }
        }

        public ThemeManager(IThemingConfiguration configuration) {
            _configuration = configuration;
        }

        public static ThemeManager Instance {
            get { return Lazy.Value; }
        }

        public IEnumerable<SelectListItem> Themes(string selectedValue) {
            DirectoryInfo rootDirectory = new DirectoryInfo(_configuration.ThemeDirectory);
            return rootDirectory.EnumerateDirectories().Select(theme => new SelectListItem {
                Selected = (theme.Name == selectedValue),
                Text = theme.Name,
                Value = theme.Name
            });
        }

        public void Configure(Action<IThemingConfiguration> configurator) {
            configurator(_configuration);
            SetViewEngine();
        }

        internal void SetViewEngine() {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ThemeableRazorViewEngine(ThemeSelector));
        }
    }
}