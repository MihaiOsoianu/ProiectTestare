using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSeminar.Utils
{
    public static class WaitHelpers
    {
        public static void WaitElementToBeVisible(IWebDriver driver, By by, int timeSpan = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }


        public static void WaitForAlert(IWebDriver driver, int timeSpan = 15)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }
    }
}
