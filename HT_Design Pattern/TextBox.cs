using HT_Design_Pattern.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_Design_Pattern
{
    public class TextBox
    {
        private IWebElement element;
        private WebDriver driver;
        private IWebDriver browser;

        public TextBox(IWebElement el)
        {
            element = el;
            //this.browser = browser;
        }

        public void Click()
        {
            element.Click();
        }

        public string GetText()
        {
            return element.Text;
        }
        public void SendKeys(string text)
        {
            this.element.SendKeys(text);
        }
        public string GetAttribute(string attributeName)
        {
            return this.element.GetAttribute(attributeName);
        }

    }

}
