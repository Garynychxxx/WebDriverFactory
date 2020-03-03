using PageObject.Pages.GooglePage;
using PageObject.Utils;

namespace PageObject.Services
{
    public class GoogleMainPageService : PageProvider<GoogleMainPage>
    {
        public void GotoBasePage()
        {
            GetPage().GotoGoogleMainPage();
        }

        public void Search(string query)
        {
            GetPage().SearchField.SendKeys(query);
            GetPage().GoogleImage.Click();
            GetPage().SearchButton.Click();
        }
        
    }
}
