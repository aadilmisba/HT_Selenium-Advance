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

        public IWebElement SentMail => driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement newTextbox => driver.FindElement(By.XPath("//div[@aria-label='Message Body']"));

        public IWebElement newSendField => driver.FindElement(By.XPath("//div[text()='Send']"));

        public IWebElement updatedSentMail => driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement moreField => driver.FindElement(By.XPath("//span[contains(text(),'More')]"));

        public IWebElement trashField => driver.FindElement(By.XPath("//a[contains(text(),'Trash')]"));

        public IWebElement newSentMail => driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement AccountField => driver.FindElement(By.CssSelector("img.gb_Ca.gbii"));

        //public IWebElement SignOut => driver.FindElement(By.XPath("//div[text()='Sign out']"));

        public Button SentButton => new Button(driver.FindElement(By.XPath("//a[contains(text(),'Sent')]")));
        public Button updatedSentButton => new Button(driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]")));
        public Button AccountButton => new Button(driver.FindElement(By.CssSelector("img.gb_Ca.gbii")));
        public Button SignOutButton => new Button(driver.FindElement(By.XPath("//div[text()='Sign out']")));


        public void SendMails(string newMessage)
        {
            Actions ac = new Actions(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"))));
            
            SentButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentMail));
            ac.ContextClick(SentMail).Build().Perform();
            ac.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
            newTextbox.SendKeys(newMessage);
            ac.MoveToElement(newSendField).Click().Build().Perform();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(updatedSentMail));
            
            updatedSentButton.Click();
            driver.Navigate().Back();
        }

        public void DeleteMail()
        {
            Actions ac = new Actions(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
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
            
            AccountButton.Click();
            driver.SwitchTo().Frame("account");
            //SignOut.Click();
           
            SignOutButton.Click();
            driver.SwitchTo().ParentFrame();
        }


    }

}
