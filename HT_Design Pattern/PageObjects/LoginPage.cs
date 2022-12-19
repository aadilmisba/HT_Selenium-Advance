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

        //public IWebElement UsernameField => driver.FindElement(By.Id("identifierId"));
        public TextBox UsernameField => new TextBox(driver.FindElement(By.Id("identifierId")));

        public Button UsernameButton => new Button(driver.FindElement(By.Id("identifierNext")));
        public Button PasswordButton => new Button(driver.FindElement(By.Id("passwordNext")));

        //public IWebElement PasswordField => driver.FindElement(By.XPath("//*[@id='password']//input"));
        public TextBox PasswordField => new TextBox(driver.FindElement(By.XPath("//*[@id='password']//input")));

        public WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(50));

        public IWebElement MainPage => driver.FindElement(By.CssSelector("body"));

        //TODO string senderMail, string subject, string textbox parameter values are not used in function
        public void Login(string username, string password)
        {
            //passing the value from test
            UsernameField.SendKeys(username);

            //var UsernameButton = new Button(NextButton);
            UsernameButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("//*[@id='password']//input"))));
            //pass this value from test
            PasswordField.SendKeys(password);

            //var PasswordButton = new Button(LoginButton);
            PasswordButton.Click();

        }
    }
}