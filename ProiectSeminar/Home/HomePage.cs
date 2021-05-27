using OpenQA.Selenium;
using ProiectSeminar.Product;
using ProiectSeminar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSeminar.Home
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        //a list of products
        public By products = By.CssSelector("div[id=tbodyid] > div");
        public IList<IWebElement> LstProducts => driver.FindElements(products);

        //anchor with title that coresponds to one of the products
        private By btnTitle = By.CssSelector("a[class=hrefch]");
        public IWebElement BtnTitle(string Title) =>
            LstProducts.FirstOrDefault(e => e.Text.Contains(Title)).FindElement(btnTitle);


        public ProductPage NavigateToProductPage(string title)
        {            
            BtnTitle(title).Click();
            return new ProductPage(driver);
        }
    }
}
