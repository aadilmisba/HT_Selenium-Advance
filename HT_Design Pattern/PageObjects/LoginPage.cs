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
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver browser) : base("", browser)
        {
        }

        public IWebElement UsernameField => webDriver.FindElement(By.Id("identifierId"));

        public IWebElement NextButton => webDriver.FindElement(By.Id("identifierNext"));
        public IWebElement PasswordField => webDriver.FindElement(By.XPath("//*[@id='password']//input"));

        
        
        public IWebElement LoginButton => webDriver.FindElement(By.Id("passwordNext"));

        public IWebElement MainPage => webDriver.FindElement(By.CssSelector("body"));

        //TODO string senderMail, string subject, string textbox parameter values are not used in function
        public void Login(string username, string password)
        {

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)webDriver;

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(50));
            jsExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border:2px solid red; background:yellow')", UsernameField);
            UsernameField.SendKeys(username); //pass this value from test
            //NextButton.Click();
            jsExecutor.ExecuteScript("arguments[0].click();", NextButton);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PasswordField));
            PasswordField.SendKeys(password); //pass this value from test
            //LoginButton.Click();
            var PasswordButton = new Button(LoginButton);
            PasswordButton.Click();

        }
    }
}