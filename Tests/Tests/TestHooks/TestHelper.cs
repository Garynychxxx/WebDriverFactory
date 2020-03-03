using System;
using System.IO;
using System.Reflection;
using Allure.Commons;
using Core.Selenium;
using Core.Selenium.BrowserFactory;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.Extensions;
using Serilog;
using SmartWait;

namespace Tests.Tests.TestHooks
{
    public static class TestHelper
    {
        public static string SaveLocation;
        public static void CreateTempDirectory()
        {
            SaveLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Screenshots\";
            var dirExists = Directory.Exists(SaveLocation);
            if (dirExists)
            {
                Directory.Delete(SaveLocation, true);
            }
            Directory.CreateDirectory(SaveLocation);
        }
        
        private static string CreateFilename()
        {
            var fileName = TestContext.CurrentContext.Test.FullName;
            var timeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            const string ext = ".png";
            return SaveLocation + fileName + timeStamp + ext;
        }

        public static void SnapIfTestFalse()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Failure) return;
            var screenShotName = CreateFilename();
            ThreadDriverManager.GetWebDriver().TakeScreenshot().SaveAsFile(screenShotName);
            TestContext.AddTestAttachment(screenShotName);
            AllureLifecycle.Instance.AddAttachment(screenShotName);
        }

        public static void SaveVideoIfTestFalse()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Failure) return;
            var pathToVideo = DriverBuilder.TryGetSolutionDirectoryInfo() +
                              $@"\WebDriverFactory\selenoid\video\{TestContext.CurrentContext.Test.Name}.mp4";

            WaitFor.Condition(() => File.Exists(pathToVideo),
                builder => builder.SetMaxWaitTime(TimeSpan.FromSeconds(10)).Build(),
                "File not exist after 10 seconds"
                );
            TestContext.AddTestAttachment(pathToVideo);
            AllureLifecycle.Instance.AddAttachment(pathToVideo);
        }
    }
}
