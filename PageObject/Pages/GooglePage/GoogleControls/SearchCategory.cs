using Core.Controls;
using OpenQA.Selenium;

namespace PageObject.Pages.GooglePage.GoogleControls
{
    public class SearchCategory : Control
    {
        public SearchCategory(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.XPath("//div[@class='klitem']");

        public string Title => Find<Control>(By.XPath(".//div[@class='kltat']")).Text;
        public string Description => Find<Control>(By.XPath(".//div[@class='ellip klmeta']")).Text;

    }
}
