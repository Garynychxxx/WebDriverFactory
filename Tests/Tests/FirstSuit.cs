using System.Linq;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Tests.Tests.TestHooks;

namespace Tests.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("GoogleTests")]
    [AllureDisplayIgnored]
    public class FirstSuit : BaseTest
    {
        [AllureTag("CI")]
        [Test]
        public void GoogleImageIsDisplayed()
        {
            MainPageService.GotoBasePage();
            Assert.That(MainPageService.GetPage().GoogleImage.Displayed(), "Google image isn't displayed or isn't found");
        }

        [AllureTag("CI")]
        [Test]
        public void AllResultsHaveSearchingInTitle()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("Rammstein");
            var x = SearchResultsPage.GetSearchTitles();
            Assert.That(x.All(el => el.Contains("rammstein")), "The element without search word is exist");
        }

        [AllureTag("CI")]
        [Test]
        public void MachDescriptionOfResult()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("stack overflow");
            Assert.That(SearchResultsPage.GetDescriptionResultByIndex(0).Contains("Stack Overflow is the largest, most trusted online community for"), "The description of result of searching string doesn't match");
        }

        [AllureTag("CI")]
        [Test]
        public void MatchLinkOfResult()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("linkedin");
            Assert.That(SearchResultsPage.GetSearchLinks()[0].Contains("www.linkedin.com"), "The link of result of searching string doesn't match");
        }

        [AllureTag("CI")]
        [Test]
        public void TwoPageSearchResultsAreDifferent()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("reddit");
            var searchResultFromFirstPage = SearchResultsPage.GetSearchTitles();
            SearchResultsPage.GoToNextSearchResultPage();
            CollectionAssert.AreNotEquivalent(searchResultFromFirstPage, SearchResultsPage.GetSearchTitles(), "Search results are the same on two pages");
        }

        [AllureTag("CI")]
        [Test]
        public void RecommendedSearchHasSearchString()
        {
            MainPageService.GotoBasePage();
            MainPageService.Search("GitHub");
            Assert.That(SearchResultsPage.RecommendedSearchList().All(el => el.Contains("github")), "The element without search word is exist");
        }
    }
}
