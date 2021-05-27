using OpenQA.Selenium;
using ProiectSeminar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSeminar.Login
{
    public class LoginModal
    {

        private IWebDriver driver;

        public LoginModal(IWebDriver browser)
        {
            driver = browser;
        }

        //form inputs + submit button

        private By username = By.Id("loginusername");
        private IWebElement TxtUsername => driver.FindElement(username);

        private By password = By.Id("loginpassword");
        private IWebElement TxtPassword => driver.FindElement(password);

        private By login = By.CssSelector("button[onclick=\"logIn()\"]");
        private IWebElement BtnLogin => driver.FindElement(login);

        public void Login(string usrname, string passwd)
        {
            WaitHelpers.WaitElementToBeVisible(driver, username);
            TxtUsername.SendKeys(usrname);
            TxtPassword.SendKeys(passwd);
            BtnLogin.Click();
        }
    }
}
