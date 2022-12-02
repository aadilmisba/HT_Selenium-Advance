using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Actions = OpenQA.Selenium.Interactions.Actions;


namespace HT_Design_Pattern.PageObjects
{

    public class SentPage : BasePage
    {
        public SentPage(IWebDriver browser) : base("", browser)
        {
        }

        public IWebElement SentField => webDriver.FindElement(By.XPath("//a[contains(text(),'Sent')]"));

        public IWebElement SentMail => webDriver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement newTextbox => webDriver.FindElement(By.XPath("//div[@aria-label='Message Body']"));

        public IWebElement newSendField => webDriver.FindElement(By.XPath("//div[text()='Send']"));

        public IWebElement updatedSentMail => webDriver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement moreField => webDriver.FindElement(By.XPath("//span[contains(text(),'More')]"));

        public IWebElement trashField => webDriver.FindElement(By.XPath("//a[contains(text(),'Trash')]"));

        public IWebElement newSentMail => webDriver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement AccountField => webDriver.FindElement(By.CssSelector("img.gb_Ca.gbii"));

        public IWebElement SignOut => webDriver.FindElement(By.XPath("//div[text()='Sign out']"));
     

        public void SendMails(string newMessage)
        {
            Actions ac = new Actions(webDriver);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentField));
            var SentButton = new Button(SentField);
            SentButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentMail));
            ac.ContextClick(SentMail).Build().Perform();
            ac.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
            newTextbox.SendKeys(newMessage);
            ac.MoveToElement(newSendField).Click().Build().Perform();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(updatedSentMail));
            var updatedSentButton = new Button(updatedSentMail);
            updatedSentButton.Click();
            webDriver.Navigate().Back();
        }

        public void DeleteMail()
        {
            Actions ac = new Actions(webDriver);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(moreField));
            ac.MoveToElement(moreField).Build().Perform();
            ac.Click(moreField).Perform();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(trashField));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(newSentMail));

            ac.DragAndDrop(newSentMail, trashField).Build().Perform();
        }


        public void LogOut()
        {
            //AccountField.Click();
            var AccountButton = new Button(AccountField);
            AccountButton.Click();
            webDriver.SwitchTo().Frame("account");
            //SignOut.Click();
            var SignOutButton = new Button(SignOut);
            SignOutButton.Click();
            webDriver.SwitchTo().ParentFrame();
        }


    }

}
