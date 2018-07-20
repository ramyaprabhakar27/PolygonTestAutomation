using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PolygonPageObjects.Utilities
{
    public static class Helper
    {
        public static void WaitForElementVisibleByCssSelector(string elementCSS, int timeOutInSeconds)
        {
            new WebDriverWait(Driver.UIDriver, TimeSpan.FromSeconds(timeOutInSeconds)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(elementCSS)));           
        }
        public static void WaitForElementByCssSelector(string elementCSS, int timeOutInSeconds)
        {            
            new WebDriverWait(Driver.UIDriver, TimeSpan.FromSeconds(timeOutInSeconds)).Until<IWebElement>((d) =>
            {
                return d.FindElement(By.CssSelector(elementCSS));
            });
        }
        public static void FluentWaitById(string elementID, int timeoutInSeconds)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(Driver.UIDriver);
            wait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id(elementID));
            });
        }
        public static void FluentWaitById(string elementID)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(Driver.UIDriver)
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(500),   
                Message = "Element Not Found",
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(elementID)));
        }
    }
}
