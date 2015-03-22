namespace AspNet.Mvc.Theming.Configuration
{
    internal class ThemingConfiguration : IThemingConfiguration
    {
        public ThemingConfiguration()
        {
            DefaultTheme = "Default";

            ThemeResolver = new DefaultThemeResolver();
        }

        public string ThemeDirectory { get; set; }
        public string DefaultTheme { get; set; }

        public IThemeResolver ThemeResolver { get; set; }
    }
}