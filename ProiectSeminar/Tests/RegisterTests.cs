using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProiectSeminar.Controls;
using ProiectSeminar.SignUp;
using ProiectSeminar.Utils;
using System;

namespace ProiectSeminar.Tests
{
    [TestClass]
    public class RegisterTests
    {
        private IWebDriver driver;       
        private SignUpModal signUpModal;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();                        
            driver.Navigate().GoToUrl("https://demoblaze.com/");
            
            var menu = new LoggedOutMenuItemControl(driver);

            signUpModal = menu.OpenSignUpModal();
        }

        [TestMethod]
        public void should_register_successfully_with_credentials()
        {
            //sansele sa dea eroare sunt foarte mici. credentialele sunt generate random
            signUpModal.Register();
            WaitHelpers.WaitForAlert(driver);
            Assert.AreEqual("Sign up successful.", driver.SwitchTo().Alert().Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
