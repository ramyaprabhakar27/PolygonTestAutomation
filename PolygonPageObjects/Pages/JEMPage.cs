using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolygonPageObjects.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace PolygonPageObjects.Pages
{
    public static class JEMPage
    {
        private static IWebElement JEMHeroHeader { get => Driver.UIDriver.FindElement(By.CssSelector(".hero-header")); }
        private static IWebElement JEMHeroSubHeader { get => Driver.UIDriver.FindElement(By.CssSelector(".hero-text>span")); }
        private static IWebElement JEMSuburbSearchText { get => Driver.UIDriver.FindElement(By.Id("homepage-search-fullAddress")); }
        private static IWebElement JEMFindFoodButton { get => Driver.UIDriver.FindElement(By.CssSelector(".btn.btn--primary.addressLookup-confirmBtn.form-submit")); }

        public static string GetJEMHeroHeader()
        {
            return JEMHeroHeader.Text;
        }

        public static string GetJEMHeroSubHeader()
        {
            return JEMHeroSubHeader.Text;
        }

        public static void EnterSuburbSearchText(string searchText)
        {
            Thread.Sleep(2000);
            JEMSuburbSearchText.Click();
            JEMSuburbSearchText.SendKeys(Keys.Control + "a");
            JEMSuburbSearchText.SendKeys(Keys.Backspace);
            JEMSuburbSearchText.SendKeys(searchText);
            try
            {
                Helper.WaitForElementVisibleByCssSelector(".addressLookup-suggestions-item.is-selected", 5);
                Driver.UIDriver.FindElement(By.CssSelector(".addressLookup-suggestions-item.is-selected")).Click();               
            }
            catch(Exception)
            {

            }
        }
    }
}
