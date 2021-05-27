using OpenQA.Selenium;
using ProiectSeminar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSeminar.Contact
{
    public class ContactModal
    {
        private IWebDriver driver;

        public ContactModal(IWebDriver browser)
        {
            driver = browser;
        }
        
        //below are the form inputs + submit button

        private By contactEmail = By.Id("recipient-email");
        private IWebElement TxtContactEmail => driver.FindElement(contactEmail);

        private By contactName = By.Id("recipient-name");
        private IWebElement TxtContactName => driver.FindElement(contactName);

        private By message = By.Id("message-text");
        private IWebElement TxtMessage => driver.FindElement(message);

        private By sendMessage = By.CssSelector("button[onclick=\"send()\"]");
        private IWebElement BtnSendMessage => driver.FindElement(sendMessage);

        public void SendContactMessage(ContactInputData inputData)
        {
            WaitHelpers.WaitElementToBeVisible(driver, contactName);
            TxtContactEmail.SendKeys(inputData.contactEmail);
            TxtContactName.SendKeys(inputData.contactName);
            TxtMessage.SendKeys(inputData.message);
            BtnSendMessage.Click();
        }
    }
}
