using Core.Controls;
using OpenQA.Selenium;

namespace PageObject.Pages.GooglePage.GoogleControls
{
    public class SearchResult : Control
    {
        public SearchResult(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.XPath("//h2[@class='bNg8Rb']/..//*[@class = 'rc']");
        public string Title => Find<Control>(By.XPath(".//h3[@class='LC20lb DKV0Md']")).Text;
        public string Link => Find<Control>(By.ClassName("TbwUpd")).Text;
        public string Description => Find<Control>(By.ClassName("st")).Text;
    }
}
