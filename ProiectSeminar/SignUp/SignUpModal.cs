using OpenQA.Selenium;
using ProiectSeminar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProiectSeminar.SignUp
{
    public class SignUpModal
    {
        private readonly Random _random = new Random();
        private IWebDriver driver;

        public SignUpModal(IWebDriver browser)
        {
            driver = browser;
        }

        //form inputs + submit button

        private By username = By.Id("sign-username");
        private IWebElement TxtUsername => driver.FindElement(username);

        private By password = By.Id("sign-password");
        private IWebElement TxtPassword => driver.FindElement(password);

        private By signUp = By.CssSelector("button[onclick=\"register()\"]");
        private IWebElement BtnSignUp => driver.FindElement(signUp);

        public void Register()
        {
            WaitHelpers.WaitElementToBeVisible(driver, username);           
            TxtUsername.SendKeys(RandomString(12, true));
            TxtPassword.SendKeys(RandomString(12));
            BtnSignUp.Click();
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
 
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }


    }
}
