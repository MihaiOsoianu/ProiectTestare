using OpenQA.Selenium;
using ProiectSeminar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSeminar.Product
{
    public class ProductPage
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver browser)
        {
            driver = browser;
        }

        //button used to add item to cart

        public By addToCart = By.CssSelector("a[onclick^=\"addToCart(\"]");
        private IWebElement BtnAddToCart => driver.FindElement(addToCart);

        public void AddItemToCart()
        {
            WaitHelpers.WaitElementToBeVisible(driver, addToCart);
            BtnAddToCart.Click();
        }
    }
}
