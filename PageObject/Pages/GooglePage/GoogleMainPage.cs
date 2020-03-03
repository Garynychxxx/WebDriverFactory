using Core;
using Core.Controls;
using Core.Extensions;
using OpenQA.Selenium;
using Serilog;

namespace PageObject.Pages.GooglePage
{
    public class GoogleMainPage : BasePage
    {
        public string BaseUrl = "https://www.google.com/";

        public CLabel GoogleImage => Driver.Find<CLabel>(By.XPath("//img[@alt = 'Google']"));
        public CTextInput SearchField => Driver.Find<CTextInput>(By.XPath("//input[@class ='gLFyf gsfi']"));
        public CButton SearchButton => Driver.Find<CButton>(By.XPath("//div[@class='FPdoLc tfB0Bf']//input[@class='gNO89b']"));
        public Control TrayMenu => Driver.Find<Control>(By.XPath("//div[@jscontroller ='tg8oTe']"));
        
        public void GotoGoogleMainPage()
        {
            Log.Information("Go to {0}", BaseUrl);
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        
    }
}
