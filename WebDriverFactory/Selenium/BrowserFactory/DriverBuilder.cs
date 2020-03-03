using System;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Core.Selenium.BrowserFactory
{
    public static class DriverBuilder
    {
        private static readonly string PathToDriverBinary = TryGetSolutionDirectoryInfo()+ @"\WebDriverFactory\bin\Debug\netcoreapp2.2";
        private static Uri BaseRemoteDriverUri { get; } = new Uri("http://localhost:4444/wd/hub");
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

        public static IWebDriver GetDriver()
        {
            var browser = ConfigManager.Browser;
            var options = DriverOptionsManager.GetDriverOptions();

            if (ConfigManager.IsDriverRemote)
            {
                return new RemoteWebDriver(BaseRemoteDriverUri, options);
            }

            switch (browser)
            {
                case BrowserType.Chrome:
                    
                    return new ChromeDriver(PathToDriverBinary, options as ChromeOptions);

                case BrowserType.Firefox:

                    return new FirefoxDriver(PathToDriverBinary, options as FirefoxOptions);

                case BrowserType.Ie:

                    return new InternetExplorerDriver(PathToDriverBinary, options as InternetExplorerOptions);

                default:
                    throw new Exception($"Driver type not found in configuration. Actual browser type: {browser}");
            }
        }
    }
}
