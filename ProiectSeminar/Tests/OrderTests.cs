using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProiectSeminar.Cart;
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
    public class OrderTests
    {

        public IWebDriver driver;
        public CartPage cartPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoblaze.com/");

            var menu = new LoggedOutMenuItemControl(driver);
            cartPage = menu.NavigateToCartPage();
        }

        [TestMethod]
        public void should_place_order_successfully()
        {
            cartPage.PlaceOrder(new OrderInputData());
            Assert.AreEqual("Thank you for your purchase!", cartPage.LblSuccessfulPurchase.Text);
        }

        [TestMethod]
        public void should_fail_placing_order_missing_name()
        {
            var inputData = new OrderInputData()
            {
                name = ""
            };
            cartPage.PlaceOrder(inputData);
            WaitHelpers.WaitForAlert(driver);
            Assert.AreEqual("Please fill out Name and Creditcard.", driver.SwitchTo().Alert().Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
