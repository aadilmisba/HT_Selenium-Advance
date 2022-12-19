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

namespace HT_Design_Pattern
{
    public class Driver
    {
        public IWebDriver? driver;

        string hubUrl = "http://localhost:4444/wd/hub";

        public Driver(string browserName)
        {
            if (browserName == "chrome")
            {
                ChromeOptions options = new ChromeOptions();

                driver = new RemoteWebDriver(new Uri(hubUrl), options);
                //driver = new RemoteWebDriver(new Uri(hubUrl), options1);

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                //open the browser  
                //navigate to URL  
                //driver.Navigate().GoToUrl("https://mail.google.com/");

                //Maximize the browser window  
                driver.Manage().Window.Maximize();
            }
            else if (browserName == "firefox")
            {
                FirefoxOptions options = new FirefoxOptions();

                driver = new RemoteWebDriver(new Uri(hubUrl), options);

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                //open the browser  
                //navigate to URL  
                //driver.Navigate().GoToUrl("https://mail.google.com/");

                //Maximize the browser window  
                driver.Manage().Window.Maximize();

            }

        }

       

     

        public void Close()
        {
            driver.Quit();
            driver = null;
        }
    }
}
