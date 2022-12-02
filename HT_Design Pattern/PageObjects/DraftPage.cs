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
    public class DraftPage : BasePage
    {

        public DraftPage(IWebDriver browser) : base("", browser)
        {

        }

        public IWebElement DraftField => webDriver.FindElement(By.XPath("//a[contains(text(),'Drafts')]"));

        public IWebElement DraftMail => webDriver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        //WebElement checkSenderMail = (WebElement)Driver.GetInstance().FindElement(By.XPath("//div[@class='aoD hl']"));
        public IWebElement checkSubject => webDriver.FindElement(By.CssSelector("input[name=subjectbox]"));
        public IWebElement checkTextbox => webDriver.FindElement(By.XPath("//div[@role='textbox']"));

        public IWebElement SendMail => webDriver.FindElement(By.XPath("//div[text()='Send']"));

        public void DraftMails()
        {
            //DraftField.Click();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DraftField));
            var Draftbutton = new Button(DraftField);
            Draftbutton.Click();
            //DraftMail.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DraftMail));
            var DraftMailbutton = new Button(DraftMail);
            DraftMailbutton.Click();
            //SendMail.Click();
            var SendMailbutton = new Button(SendMail);
            SendMailbutton.Click();
        }

        

    }

}
