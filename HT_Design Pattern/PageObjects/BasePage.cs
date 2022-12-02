using System;
using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V104.Browser;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace HT_Design_Pattern.PageObjects
{
    public abstract class BasePage
    {
        private readonly string host = "https://mail.google.com/";
        private readonly string url;

        protected readonly IWebDriver webDriver;

        public BasePage(string url, IWebDriver browser)
        {
            this.url = url;
            this.webDriver = browser;
        }

        public void Open()
        {
            webDriver.Navigate().GoToUrl(host + url);
        }
    }
}
