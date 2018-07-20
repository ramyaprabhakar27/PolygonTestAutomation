using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace PolygonPageObjects.Utilities
{
    public static class Driver
    {
        private static IWebDriver uiDriver = new ChromeDriver();

        public static IWebDriver UIDriver
        {
            get
            {
                return uiDriver;
            }
            set
            {
                uiDriver = value;
            }
        }

        public static void SetUp()
        {
            if (IsDriverNull())
            {
                UIDriver = new ChromeDriver();
            }
        }

        public static void GoToSite(string url)
        {
            UIDriver.Navigate().GoToUrl(url);
        }

        public static void TearDown()
        {
            try
            {
                UIDriver.Manage().Cookies.DeleteAllCookies();
                UIDriver.Close();
                UIDriver.Quit();
                UIDriver.Dispose();
                UIDriver = null;
            }
            catch(Exception)
            {
                //Ignore if not able to close the driver
            }
        }

        public static bool IsDriverNull()
        {
            return (UIDriver == null);
        }
    }
}
