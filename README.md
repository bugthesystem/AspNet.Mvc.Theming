AspNet.Mvc.Theming
======================

Enables implementing themes for ASP.NET MVC.

[![Build status](https://ci.appveyor.com/api/projects/status/phs4m7tiwyy48jd9?svg=true)](https://ci.appveyor.com/project/ziyasal/aspnet-mvc-theming)

* [Nuget Package - AspNet.Mvc.Theming](https://www.nuget.org/packages/AspNet.Mvc.Theming/)

To install AspNet.Mvc.Theming, 
```bash
Install-Package AspNet.Mvc.Theming
```
>_**Area theme customization not implemented yet!**_

How to use;
-----------------------------

  Create [**Themes**](https://github.com/ziyasal/AspNet.Mvc.Theming/tree/master/src/AspNet.Mvc.Theming.Sample/Themes) (or what you want) folder and put your themes to folder and initialize [**ThemeManager**](https://github.com/ziyasal/AspNet.Mvc.Theming/blob/master/src/AspNet.Mvc.Theming/ThemeManager.cs) to use this folder to apply theme and set default theme;

```csharp
 public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
        
           //Omitted for brevity..

            ThemeManager.Instance.Configure(config => {
                config.ThemeDirectory = "~/Themes";
                config.DefaultTheme = "Other";
            });
        }
    }
```

Put [**Theme**](https://github.com/ziyasal/AspNet.Mvc.Theming/blob/master/src/AspNet.Mvc.Theming/Attributes/ThemeAttribute.cs) attribute to your controller to use theme you want.
```csharp
 [Theme("Default")]
    public class WorkController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View(new WorkModel
            {
                Content = "Hello World!"
            });
        }

    }
```

**Custom theme resolver**

To implement your custom theme resolver [see](https://github.com/ziyasal/AspNet.Mvc.Theming/blob/master/src/AspNet.Mvc.Theming.ThemeSelectorSample/Global.asax.cs#L7)

Sample: SessionThemeResolver
```csharp
   public class SessionThemeResolver : IThemeResolver
   {
        public string Resolve(ControllerContext controllerContext, string theme)
        {
            string result;

            if (controllerContext.HttpContext.Session != null && controllerContext.HttpContext.Session["Theme"] != null)
            {
                result = controllerContext.HttpContext.Session["Theme"].ToString();
            }
            else
            {
                result = (!string.IsNullOrEmpty(theme) ? theme : "Default");
            }

            return result;
        }
    }
```

init
```csharp
 ThemeManager.Instance.Configure(config =>
 {
    config.ThemeDirectory = "~/Themes";
    config.DefaultTheme = "Default";
    config.ThemeResolver = new SessionThemeResolver();
 });
```

Save theme to sesion
```csharp
 Session["Theme"] = "YourTheme";
```
