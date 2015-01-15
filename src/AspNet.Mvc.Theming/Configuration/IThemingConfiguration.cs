namespace AspNet.Mvc.Theming.Configuration {
    public interface IThemingConfiguration {
        string ThemeDirectory { get; set; }
        string DefaultTheme { get; set; }
    }
}