using System.Linq;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Tests.Tests.TestHooks;

namespace Tests.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("SecondGoogleTests")]
    [AllureDisplayIgnored]
    public class SecondSuit : BaseTest
    {
        [AllureTag("CI")]
        [Test]
        public void TheDescriptionOfSearchIsMatched()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("films 2010");
            Assert.AreEqual(SearchResultsPage.GetDescriptionByCategories("Toy Story 3"), "Comedy");
        }

        [AllureTag("CI")]
        [Test]
        public void AllSearchResultsHaveDescription()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("films 2010");
            Assert.That(SearchResultsPage.SearchCategories().All(el => el.Description.Length > 0), "Any search result doesn't have a description" );
        }

        [AllureTag("CI")]
        [Test]
        public void SearchCategoryDisplayed()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("films 2010");
            Assert.That(SearchResultsPage.SearchCategories().All(el => el.WrappedElement.Displayed), "Search category isn't displayed");
        }

        [AllureTag("CI")]
        [Test]
        public void TakeAllFilmsByDescription()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("Comedies");
            Assert.That(SearchResultsPage.GetNamesByDescription("2004").Count == 6, "Not enough films in category");
        }

        [AllureTag("CI")]
        [Test]
        public void FirstFailedTest()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("actions films");
            Assert.That(SearchResultsPage.GetNamesByDescription("2015").Count != 2, "Not enough films in category");
        }

        [AllureTag("CI")]
        [Test]
        public void SecondFailedTest()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("films 2010");
            Assert.AreEqual(SearchResultsPage.GetDescriptionByCategories("Toy Story 3"), "action");
        }
    }
}


