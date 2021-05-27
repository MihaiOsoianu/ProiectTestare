using OpenQA.Selenium;
using ProiectSeminar.Cart;
using ProiectSeminar.Contact;
using ProiectSeminar.Home;
using ProiectSeminar.Login;
using ProiectSeminar.SignUp;
using ProiectSeminar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSeminar.Controls
{
    public class MenuItemControl
    {
        public IWebDriver driver;

        public MenuItemControl(IWebDriver browser)
        {
            driver = browser;
        }

        private By home = By.CssSelector("a[class=\"nav-link\"][href=\"index.html\"]");
        public IWebElement BtnHome => driver.FindElement(home);

        private By contact = By.CssSelector("a[data-target=\"#exampleModal\"]");
        public IWebElement BtnContact => driver.FindElement(contact);
                
        private By cart = By.Id("cartur");
        public IWebElement BtnCart => driver.FindElement(cart);

        public ContactModal OpenContactModal()
        {
            WaitHelpers.WaitElementToBeVisible(driver, contact);
            BtnContact.Click();
            return new ContactModal(driver);
        }

        public HomePage NavigateToHomePage()
        {
            WaitHelpers.WaitElementToBeVisible(driver, home);
            BtnHome.Click();
            return new HomePage(driver);
        }

        public CartPage NavigateToCartPage()
        {
            WaitHelpers.WaitElementToBeVisible(driver, cart);
            BtnCart.Click();
            return new CartPage(driver);
        }
    }

    public class LoggedOutMenuItemControl : MenuItemControl
    {
        public LoggedOutMenuItemControl(IWebDriver browser) : base(browser)
        {

        }

        private By login = By.Id("login2");
        public IWebElement BtnLogin => driver.FindElement(login);

        private By signUp = By.Id("signin2");
        public IWebElement BtnSignUp => driver.FindElement(signUp);

        public SignUpModal OpenSignUpModal()
        {
            WaitHelpers.WaitElementToBeVisible(driver, signUp);
            BtnSignUp.Click();
            return new SignUpModal(driver);
        }

        public LoginModal OpenLoginModal()
        {
            WaitHelpers.WaitElementToBeVisible(driver, login);
            BtnLogin.Click();
            return new LoginModal(driver);
        }       
               
    }

    public class LoggedInMenuItemControl : MenuItemControl
    {
        public LoggedInMenuItemControl(IWebDriver browser) : base(browser)
        {

        }

        public By username = By.Id("nameofuser");
        public IWebElement LblUsername => driver.FindElement(username);

        private By logout = By.Id("logout2");
        public IWebElement BtnLogout => driver.FindElement(logout);

    }
}