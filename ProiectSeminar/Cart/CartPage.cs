using OpenQA.Selenium;
using ProiectSeminar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSeminar.Cart
{
    public class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver browser)
        {
            driver = browser;
        }

        //total of the cart
        private By totalPrice = By.Id("totalp");
        public IWebElement LblTotalPrice => driver.FindElement(totalPrice);

        //list of the products in the cart
        public By products = By.CssSelector("tbody[id=tbodyid] tr");
        public IList<IWebElement> LstProducts => driver.FindElements(products);

        //a delete button for an item from the cart
        private By delete = By.CssSelector("a[onclick^=deleteItem]");
        private IWebElement BtnDelete(string Title) =>
            LstProducts.FirstOrDefault(e => e.Text.Contains(Title)).FindElement(delete);

        //price for an item from the cart
        private By price = By.CssSelector(":nth-child(3)");
        public IWebElement LblPrice(string Title) =>
            LstProducts.FirstOrDefault(e => e.Text.Contains(Title)).FindElement(price);

        //a button for opening the order modal
        private By placeOrder = By.CssSelector("button[data-target=\"#orderModal\"]");
        private IWebElement BtnPlaceOrder => driver.FindElement(placeOrder);

        //below are the order form inputs
        private By name = By.Id("name");
        private IWebElement TxtName => driver.FindElement(name);

        private By country = By.Id("country");
        private IWebElement TxtCountry => driver.FindElement(country);

        private By city = By.Id("city");
        private IWebElement TxtCity => driver.FindElement(city);

        private By creditCard = By.Id("card");
        private IWebElement TxtCreditCard => driver.FindElement(creditCard);

        private By month = By.Id("month");
        private IWebElement TxtMonth => driver.FindElement(month);

        private By year = By.Id("year");
        private IWebElement TxtYear => driver.FindElement(year);

        //button for submiting order form
        private By purchase = By.CssSelector("button[onclick=\"purchaseOrder()\"]");
        private IWebElement BtnPurchase => driver.FindElement(purchase);

        //message that appears when order is successful
        private By successfulPurchase = By.CssSelector("div[class^=sweet-alert] h2");
        public IWebElement LblSuccessfulPurchase => driver.FindElement(successfulPurchase);

        public void DeleteProductFromCart(string title)
        {
            BtnDelete(title).Click();
        }

        public void PlaceOrder(OrderInputData inputData)
        {
            WaitHelpers.WaitElementToBeVisible(driver, placeOrder);
            BtnPlaceOrder.Click();
            WaitHelpers.WaitElementToBeVisible(driver, name);
            TxtName.SendKeys(inputData.name);
            TxtCountry.SendKeys(inputData.country);
            TxtCity.SendKeys(inputData.city);
            TxtCreditCard.SendKeys(inputData.creditCard);
            TxtMonth.SendKeys(inputData.month);
            TxtYear.SendKeys(inputData.year);
            BtnPurchase.Click();
        }
    }
}
