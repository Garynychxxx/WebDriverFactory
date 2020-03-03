using System.Collections.Generic;
using Core.Extensions;
using Core.Selenium;
using OpenQA.Selenium;
using Serilog;

namespace Core.Controls
{
    public class Control
    {
        public string Name { get; set; }
        protected IWebDriver Driver;
        public IWebElement WrappedElement;

        public Control(IWebElement element)
        {
            WrappedElement = element;
            Driver = ThreadDriverManager.GetWebDriver();
        }

        public T Find<T>(By by) where T : Control
        {
            return WrappedElement.Find<T>(by);
        }

        public List<T> FindAll<T>(By by) where T : Control
        {
            return WrappedElement.FindAll<T>(by);
        }

        public void Click()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                Log.Information($"Click on <{Name}>");
            }

            WrappedElement.Click();
        }

        public bool Displayed()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                Log.Information($"<{Name}> is Displayed ");
            }

            return WrappedElement.Displayed;
        }

        public string Text => WrappedElement.Text;
    }
}
