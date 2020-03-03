using System.Collections.Generic;
using System.Linq;
using PageObject.Pages.GooglePage;
using PageObject.Pages.GooglePage.GoogleControls;
using PageObject.Utils;

namespace PageObject.Services
{
    public class GoogleSearchResultsPageService : PageProvider<GoogleResultsPage>
    {
        public void GoToNextSearchResultPage() => GetPage().NextPageButton.Click();
        public string GetDescriptionResultByIndex(int index)=> GetPage().SearchResults[index].Description;
        public List<string> GetSearchLinks() => GetPage().SearchResults.Select(el => el.Link.ToLower()).ToList();
        public string GetDescriptionByCategories(string category) => SearchCategories().FirstOrDefault(cat => cat.Title.Equals(category))?.Description;
        public List<string> GetNamesByDescription(string category) => SearchCategories().Where(cat => cat.Description.Equals(category)).Select(el=>el.Title).ToList();
        public List<string> GetSearchTitles() => GetPage().SearchResults.Select(el => el.Title.ToLower()).ToList();
        public List<string> RecommendedSearchList() => GetPage().RecommendedSearch.Select(el=>el.Text.ToLower()).ToList();

        public List<SearchCategory> SearchCategories() => GetPage().SearchCategory.ToList();

    }
}
