using OpenQA.Selenium;
using Serilog;

namespace Core.Controls
{
    public class CTextInput : Control
    {
        public CTextInput(IWebElement element) : base(element)
        {
        }

        public void SendKeys(string text)
        {
            Log.Information("'{0}' input in {1}", text, Name);
            WrappedElement.SendKeys(text);
        }
    }
}
