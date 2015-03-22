using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using AspNet.Mvc.Theming.Configuration;
using AspNet.Mvc.Theming.ViewEngine;

namespace AspNet.Mvc.Theming
{
    public class ThemeManager
    {

        private static readonly Lazy<ThemeManager> ThemeManagerInstance =
            new Lazy<ThemeManager>(() => new ThemeManager(new ThemingConfiguration()));

        private readonly IThemingConfiguration _configuration;

        public ThemeManager(IThemingConfiguration configuration)
        {
            _configuration = configuration;
        }


        public static ThemeManager Instance
        {
            get { return ThemeManagerInstance.Value; }
        }

        public IEnumerable<SelectListItem> Themes(string selectedValue)
        {
            var rootDirectory = new DirectoryInfo(_configuration.ThemeDirectory);
            return rootDirectory.EnumerateDirectories().Select(theme => new SelectListItem
            {
                Selected = (theme.Name == selectedValue),
                Text = theme.Name,
                Value = theme.Name
            });
        }

        public void Configure(Action<IThemingConfiguration> configurator)
        {
            configurator(_configuration);
            SetViewEngine();
        }

        internal void SetViewEngine()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ThemeableRazorViewEngine(_configuration));
        }
    }
}