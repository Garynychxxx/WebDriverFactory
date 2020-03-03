using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Controls;
using Core.Extensions;
using OpenQA.Selenium;
using PageObject.Pages.GooglePage.GoogleControls;

namespace PageObject.Pages.GooglePage
{
    public class GoogleResultsPage : BasePage
    {
        public CButton NextPageButton => Driver.Find<CButton>(By.XPath("//a[@class = 'pn']"));
        public List<SearchResult> SearchResults => Driver.FindAll<SearchResult>(SearchResult.DefaultLocator);
        public List<SearchCategory> SearchCategory => Driver.FindAll<SearchCategory>(GoogleControls.SearchCategory.DefaultLocator);
        public List<Control> RecommendedSearch => Driver.FindAll<Control>(By.XPath("//p[@class = 'nVcaUb']/a")).ToList();

    }
}
