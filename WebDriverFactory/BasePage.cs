using Core.Selenium;
using OpenQA.Selenium;

namespace Core
{
    public class BasePage
    {
       protected IWebDriver Driver => ThreadDriverManager.GetWebDriver();
    }
}
