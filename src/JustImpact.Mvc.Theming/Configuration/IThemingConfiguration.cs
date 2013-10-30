using System;
using System.Web.Mvc;

namespace JustImpact.Mvc.Theming.Configuration {
    public interface IThemingConfiguration {
        string ThemeDirectory { get; set; }
        string DefaultTheme { get; set; }
    }
}