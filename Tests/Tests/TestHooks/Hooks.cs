using Core.Selenium;
using NUnit.Framework;
using Serilog;
using Tests.Tests.TestHooks;

namespace Tests.Tests
{
    [SetUpFixture]
    public class Hooks
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestHelper.CreateTempDirectory();
            Log.Logger = new LoggerConfiguration()
                .WriteTo.NUnitOutput()
                .WriteTo.Console()
                .CreateLogger();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ThreadDriverManager.Quit();
        }
    }
}
