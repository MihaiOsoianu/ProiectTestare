using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProiectSeminar.Controls;
using ProiectSeminar.Login;
using ProiectSeminar.SignUp;
using ProiectSeminar.Utils;
using System;

namespace ProiectSeminar.Tests
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;       
        private LoginModal loginModal;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();                        
            driver.Navigate().GoToUrl("https://demoblaze.com/");
            
            var menu = new LoggedOutMenuItemControl(driver);

            loginModal = menu.OpenLoginModal();      
        }

        [TestMethod]
        public void should_register_successfully_with_credentials()
        {
            loginModal.Login("ProiectTestare", "p@ssw0rd!");
            var menu = new LoggedInMenuItemControl(driver);
            WaitHelpers.WaitElementToBeVisible(driver, menu.username);
            Assert.AreEqual("Welcome ProiectTestare", menu.LblUsername.Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
