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
    public class InboxPage : BasePage
    {
        public InboxPage(IWebDriver browser) : base("", browser)
        {
        }

        public IWebElement CommposeBoxField => webDriver.FindElement(By.XPath("//div[@jscontroller='eIu7Db']"));
            
        public IWebElement SenderMailField => webDriver.FindElement(By.CssSelector("input[role=combobox]"));
        public IWebElement SubjectField => webDriver.FindElement(By.Name("subjectbox"));
        public IWebElement TextBoxField => webDriver.FindElement(By.XPath("//div[@aria-label='Message Body']"));
        public IWebElement SaveCloseField => webDriver.FindElement(By.XPath("//img[@alt='Close']"));


        public void Compose(string senderMail, string subject, string textbox)
        {
            Actions ac = new Actions(webDriver);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(50));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(CommposeBoxField));
            ac.MoveToElement(CommposeBoxField).Click().Build().Perform();
           
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SenderMailField));
            ac.MoveToElement(SenderMailField).Build().Perform();
            SenderMailField.SendKeys(senderMail); 
            SubjectField.SendKeys(subject); 
            TextBoxField.SendKeys(textbox); 
            //SaveCloseField.Click();
            var SaveCloseButton = new Button(SaveCloseField);
            SaveCloseButton.Click();
        }



    }
}
