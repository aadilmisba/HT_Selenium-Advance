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
    public class DraftPage : BasePage
    {
        //protected readonly IWebDriver driver;

        public DraftPage(IWebDriver browser) : base("", browser)
        {
            //this.driver = browser;
        }

        public Button Draftbutton => new Button(driver.FindElement(By.XPath("//a[contains(text(),'Drafts')]")));

        //public IWebElement DraftMail => driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Testing Subject')]"));
        public Button DraftMailbutton => new Button(driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Testing Subject')]")));

        public WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //public IWebElement SendMail => driver.FindElement(By.XPath("//div[text()='Send']"));
        public Button SendMailbutton =>new Button(driver.FindElement(By.XPath("//div[text()='Send']")));
        public IWebElement checkSubject => driver.FindElement(By.CssSelector("input[name=subjectbox]"));
        public IWebElement checkTextbox => driver.FindElement(By.XPath("//div[@role='textbox']"));

        public void DraftMails()
        {
            
            Draftbutton.Click();

            DraftMailbutton.Click();

            SendMailbutton.Click();
        }

        

    }

}
