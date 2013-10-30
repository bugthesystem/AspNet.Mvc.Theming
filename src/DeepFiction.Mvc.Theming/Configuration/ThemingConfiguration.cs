namespace DeepFiction.Mvc.Theming.Configuration {
    internal class ThemingConfiguration : IThemingConfiguration {
        public string ThemeDirectory { get; set; }
        public string DefaultTheme { get; set; }
    }
}