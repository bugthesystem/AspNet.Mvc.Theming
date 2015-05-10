namespace AspNet.Mvc.Theming.Configuration
{
    internal class ThemingConfiguration : IThemingConfiguration
    {
        public ThemingConfiguration()
        {
            DefaultTheme = "Default";
            DefaultLayoutName = "_Layout";
            ThemeResolver = new DefaultThemeResolver();
        }

        public string ThemeDirectory { get; set; }

        public string DefaultTheme { get; set; }

        public string DefaultLayoutName { get; set; }

        public IThemeResolver ThemeResolver { get; set; }
    }
}