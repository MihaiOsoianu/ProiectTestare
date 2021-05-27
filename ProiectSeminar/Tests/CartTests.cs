using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProiectSeminar.Controls;
using ProiectSeminar.Home;
using ProiectSeminar.Product;
using ProiectSeminar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProiectSeminar.Tests
{
    [TestClass]
    public class CartTests
    {
        public IWebDriver driver;
        public HomePage homePage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoblaze.com/");

            homePage = new HomePage(driver);
        }

        [TestMethod]
        public void should_add_product_to_cart_successfully()
        {
            //waiting for products to load on the page
            WaitHelpers.WaitElementToBeVisible(driver, homePage.products);
            //accessing a product page using its title
            var productPage = homePage.NavigateToProductPage("Iphone");
            //waiting for the product page to load
            WaitHelpers.WaitElementToBeVisible(driver, productPage.addToCart);
            //adding the product to cart
            productPage.AddItemToCart();
            //waiting for the alert to show
            WaitHelpers.WaitForAlert(driver);
            //asserting that Product was added
            Assert.AreEqual("Product added", driver.SwitchTo().Alert().Text);
        }

        [TestMethod]
        public void should_add_multiple_products_to_cart()
        {
            //waiting for products to load on the page
            WaitHelpers.WaitElementToBeVisible(driver, homePage.products);
            //accessing a product page using its title
            var productPage = homePage.NavigateToProductPage("Iphone");
            //waiting for the product page to load
            WaitHelpers.WaitElementToBeVisible(driver, productPage.addToCart);
            //adding the product to cart
            productPage.AddItemToCart();
            //waiting for the alert to show
            WaitHelpers.WaitForAlert(driver);
            //closing the alert
            driver.SwitchTo().Alert().Accept();
            //declaring a LoggedOutMenu to use its elements
            var menu = new LoggedOutMenuItemControl(driver);
            //accesing the home page through menu
            menu.NavigateToHomePage();
            //waiting for products to load on the page
            WaitHelpers.WaitElementToBeVisible(driver, homePage.products);
            //accessing a product page using its title
            productPage = homePage.NavigateToProductPage("Nokia");
            //waiting for the product page to load
            WaitHelpers.WaitElementToBeVisible(driver, productPage.addToCart);
            //adding the product to cart
            productPage.AddItemToCart();
            //wating for the alert to show
            WaitHelpers.WaitForAlert(driver);
            //closing the alert
            driver.SwitchTo().Alert().Accept();
            //accesing the cart page through menu
            var cartPage = menu.NavigateToCartPage();            
            //waiting for the products in the cart to show
            WaitHelpers.WaitElementToBeVisible(driver, cartPage.products);
            //asserting that there are the correct number of items in the cart
            Assert.AreEqual(cartPage.LstProducts.Count, 2);
        }

        [TestMethod]
        public void should_delete_an_product_from_cart()
        {
            //waiting for products to load on the page
            WaitHelpers.WaitElementToBeVisible(driver, homePage.products);
            //accessing a product page using its title
            var productPage = homePage.NavigateToProductPage("Iphone");
            //waiting for the product page to load
            WaitHelpers.WaitElementToBeVisible(driver, productPage.addToCart);
            //adding the product to cart
            productPage.AddItemToCart();
            //waiting for the alert to show
            WaitHelpers.WaitForAlert(driver);
            //closing the alert
            driver.SwitchTo().Alert().Accept();
            //declaring a LoggedOutMenu to use its elements
            var menu = new LoggedOutMenuItemControl(driver);
            //accesing the home page through menu
            menu.NavigateToHomePage();
            //waiting for products to load on the page
            WaitHelpers.WaitElementToBeVisible(driver, homePage.products);
            //accessing a product page using its title
            productPage = homePage.NavigateToProductPage("Nokia");
            //waiting for the product page to load
            WaitHelpers.WaitElementToBeVisible(driver, productPage.addToCart);
            //adding the product to cart
            productPage.AddItemToCart();
            //wating for the alert to show
            WaitHelpers.WaitForAlert(driver);
            //closing the alert
            driver.SwitchTo().Alert().Accept();
            //accesing the cart page through menu
            var cartPage = menu.NavigateToCartPage();
            //waiting for the products in the cart to show
            WaitHelpers.WaitElementToBeVisible(driver, cartPage.products);
            //asserting that there are the correct number of items in the cart (2)
            Assert.AreEqual(cartPage.LstProducts.Count, 2);
            //removing an product from the cart
            cartPage.DeleteProductFromCart("Iphone");
            //*!*the method below (WaitElementToBeVisible) was picking up the products before the page refresh
            //WaitHelpers.WaitElementToBeVisible(driver, cartPage.products);
            Thread.Sleep(5000);
            //asserting that there are the correct number of items in the cart (1)
            Assert.AreEqual(cartPage.LstProducts.Count, 1);          
        }

        [TestMethod]
        public void should_recalculate_total_price_after_deleting_a_product()
        {
            //waiting for products to load on the page
            WaitHelpers.WaitElementToBeVisible(driver, homePage.products);
            //accessing a product page using its title
            var productPage = homePage.NavigateToProductPage("Iphone");
            //waiting for the product page to load
            WaitHelpers.WaitElementToBeVisible(driver, productPage.addToCart);
            //adding the product to cart
            productPage.AddItemToCart();
            //waiting for the alert to show
            WaitHelpers.WaitForAlert(driver);
            //closing the alert
            driver.SwitchTo().Alert().Accept();
            //declaring a LoggedOutMenu to use its elements
            var menu = new LoggedOutMenuItemControl(driver);
            //accesing the home page through menu
            menu.NavigateToHomePage();
            //waiting for products to load on the page
            WaitHelpers.WaitElementToBeVisible(driver, homePage.products);
            //accessing a product page using its title
            productPage = homePage.NavigateToProductPage("Nokia");
            //waiting for the product page to load
            WaitHelpers.WaitElementToBeVisible(driver, productPage.addToCart);
            //adding the product to cart
            productPage.AddItemToCart();
            //wating for the alert to show
            WaitHelpers.WaitForAlert(driver);
            //closing the alert
            driver.SwitchTo().Alert().Accept();
            //accesing the cart page through menu
            var cartPage = menu.NavigateToCartPage();
            //waiting for the products on cart page to show
            WaitHelpers.WaitElementToBeVisible(driver, cartPage.products);
            //saving the price of the element to be deleted and the total price
            var totalPrice = cartPage.LblTotalPrice.Text;
            var price = cartPage.LblPrice("Iphone").Text;
            //removing an element from the cart
            cartPage.DeleteProductFromCart("Iphone");
            //waiting 5s
            Thread.Sleep(5000);
            //asserting that the total of the cart changed to the correct amount after removing the item
            Assert.AreEqual(Int32.Parse(totalPrice) - Int32.Parse(price), Int32.Parse(cartPage.LblTotalPrice.Text));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
