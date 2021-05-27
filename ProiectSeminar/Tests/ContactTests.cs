using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProiectSeminar.Contact;
using ProiectSeminar.Controls;
using ProiectSeminar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSeminar.Tests
{
    [TestClass]
    public class ContactTests
    {
        private IWebDriver driver;
        private ContactModal contactModal;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoblaze.com/");

            var menu = new LoggedOutMenuItemControl(driver);

            contactModal = menu.OpenContactModal();
        }

        [TestMethod]
        public void should_register_successfully_with_credentials()
        {
            contactModal.SendContactMessage(new ContactInputData());
            WaitHelpers.WaitForAlert(driver);
            Assert.AreEqual("Thanks for the message!!", driver.SwitchTo().Alert().Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
