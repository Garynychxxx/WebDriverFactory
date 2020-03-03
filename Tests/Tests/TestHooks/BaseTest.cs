using Allure.Commons;
using Core;
using Core.Selenium;
using NUnit.Framework;
using PageObject.Services;

[assembly: LevelOfParallelism(5)]

namespace Tests.Tests.TestHooks
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class BaseTest
    {
        public GoogleMainPageService MainPageService;
        public GoogleSearchResultsPageService SearchResultsPage;

        [SetUp]
        public void Setup()
        {
            MainPageService = new GoogleMainPageService();
            SearchResultsPage = new GoogleSearchResultsPageService();
        }

        [TearDown]
        public void TearDown()
        {
            TestHelper.SnapIfTestFalse();
            if (!ConfigManager.IsDriverRemote) return;
            ThreadDriverManager.Close();
            TestHelper.SaveVideoIfTestFalse();
        }
    }
}

