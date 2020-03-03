using System.Linq;
using System.Threading;
using Core.Selenium.BrowserFactory;
using OpenQA.Selenium;
using Serilog;

namespace Core.Selenium
{
    public static class ThreadDriverManager
    {
        private static readonly ThreadLocal<IWebDriver> LocalWebDriver = new ThreadLocal<IWebDriver>(true);

        public static IWebDriver GetWebDriver() => LocalWebDriver.Value ?? (LocalWebDriver.Value = DriverBuilder.GetDriver());
        public static void Close()
        {
            LocalWebDriver.Value.Quit();
            LocalWebDriver.Value=null;
        }

        public static void Quit()
        {
            Log.Information("Close browsers");
            LocalWebDriver.Values.ToList().ForEach(wd => wd?.Quit());
        }
    }
}
