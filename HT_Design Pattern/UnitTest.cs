using HT_Design_Pattern.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace HT_Design_Pattern
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class UnitTest 
    {
        protected Driver webDriver;
        protected string drivername;
        
        public UnitTest(string drivername)
        {
            this.drivername = drivername;
        }

        [SetUp]
        public void inititalize()
        {
            webDriver = new Driver(drivername);

        }

        [TestCase]
        public void TestMethod()
        {
            var loginPage = new LoginPage(webDriver.driver);
            loginPage.Open();
            loginPage.Login("aadilmuhammadu@gmail.com", "Test@123");
            Assert.AreEqual(loginPage.UsernameField.GetAttribute("value"), "aadilmuhammadu@gmail.com");
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("value"), "Test@123");

            //Assert for login is successful
            Assert.True(loginPage.MainPage.Displayed, "The login is successful");   
            var InboxPage = new InboxPage(webDriver.driver);
            InboxPage.Compose("aadilmisba3@gmail.com", "Sample Subject", "Test Mail");
            var DraftPage = new DraftPage(webDriver.driver);
            DraftPage.DraftMails();
           

            var SentPage = new SentPage(webDriver.driver);
            SentPage.SendMails("Updated");
            SentPage.DeleteMail();
            SentPage.LogOut();

        }

        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }



    }
}