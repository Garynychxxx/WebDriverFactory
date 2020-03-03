using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Core.Selenium.BrowserFactory
{
    public static class DriverOptionsManager
    {
        public static DriverOptions GetDriverOptions()
        {
            DriverOptions options;
            switch (ConfigManager.Browser)
            {
                case BrowserType.Chrome:
                    options = CromeOptions();
                    break;
                case BrowserType.Firefox:
                    options = FirefoxOptions();
                    break;
                case BrowserType.Ie:
                    options = InternetExplorerOptions();
                    break;
                default:
                    throw new Exception();
            }
           
            return options;
        }

        private static ChromeOptions CromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "en-Gb");
            chromeOptions.BrowserVersion = "80.0";
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddAdditionalCapability("enableVNC", true, true);
            chromeOptions.AddAdditionalCapability("enableVideo", true, true);
            chromeOptions.AddAdditionalCapability("videoName", $"{TestContext.CurrentContext.Test.Name}.mp4",true);
            return chromeOptions;
        }

        private static FirefoxOptions FirefoxOptions()
        {
            var firefoxOptions = new FirefoxOptions();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            firefoxOptions.Profile = new FirefoxProfile();
            firefoxOptions.Profile.SetPreference("intl.accept_languages", "en-GB");
            firefoxOptions.AddAdditionalCapability("enableVNC", true, true);
            firefoxOptions.AddAdditionalCapability("enableVideo", true, true);
            firefoxOptions.AddAdditionalCapability("videoName", $"{TestContext.CurrentContext.Test.Name}.mp4",true);
            return firefoxOptions;
        }

        private static InternetExplorerOptions InternetExplorerOptions()
        {
            var internetExplorerOptions = new InternetExplorerOptions();
            internetExplorerOptions.AddAdditionalCapability("intl.accept_languages", "en-Gb");
            internetExplorerOptions.BrowserCommandLineArguments = "--start-maximized";
            //internetExplorerOptions.AddAdditionalCapability("videoName", $"{TestContext.CurrentContext.Test.Name}.mp4",true);
            return internetExplorerOptions;
        }
    }
}
