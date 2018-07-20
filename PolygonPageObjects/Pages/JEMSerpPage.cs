using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PolygonPageObjects.Utilities;

namespace PolygonPageObjects.Pages
{
    public static class JEMSerpPage
    {
        private static IWebElement JEMRestaurantCountText { get => Driver.UIDriver.FindElement(By.CssSelector(".beta.u-alignBottom.u-spacingRight")); }

        public static string GetJEMRestaurantCount()
        {
            try
            {
                Helper.WaitForElementVisibleByCssSelector(".beta.u-alignBottom.u-spacingRight", 5);
                return JEMRestaurantCountText.Text.Split(' ')[0];
            }
            catch(Exception)
            {
                return "-1";
            }
        }
    }
}
