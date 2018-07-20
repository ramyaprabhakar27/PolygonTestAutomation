using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NUnit.Framework;
using PolygonPageObjects.Pages;
using PolygonPageObjects.Utilities;
using PolygonTests.Utilities;

namespace PolygonTests.Tests
{
    [TestFixture]
    public static class JEMPageTest
    {      
        private static Logger logger = LogManager.GetLogger("JEMPage");
        private static  IList<IList<Object>> testData;
        private static string sheetID = "Polygon!A2:A4";

       [SetUp]
        public static void SetUp()
        {           
                Driver.SetUp();           
        }

        [Test]
        public static void TestJEMPage()
        {           
            Driver.GoToSite(URL.JEMPageUrl);
            string actualHeaderText = JEMPage.GetJEMHeroHeader();
            string expectedHeaderText = "Less talk, more eat.";           
            Assert.AreEqual(expectedHeaderText, actualHeaderText);
            Console.WriteLine($"Actual Header Text : {actualHeaderText} \n Expected Header Text : {expectedHeaderText}");

            string actualSubHeaderText = JEMPage.GetJEMHeroSubHeader();
            string expectedSubHeaderText = "Your favourite local restaurants delivered";           
            Assert.IsTrue(actualSubHeaderText.ToString().Equals(expectedSubHeaderText));
            Console.WriteLine($"Actual SubHeader Text : {actualSubHeaderText}  Expected SubHeader Text : {expectedSubHeaderText}");
        }

        [Test]
        public static void TestRestaurantCountUsingGoogleSreadSheest()
        {
            logger.Info("Test Restaurant Count");
            testData = GoogleAuth.GetData(sheetID);
            try
            {
                foreach (var data in testData)
                {
                    string searchSuburb = data[0].ToString();
                    Driver.GoToSite(URL.JEMPageUrl);
                    JEMPage.EnterSuburbSearchText(searchSuburb);
                    string actualResturantCount = JEMSerpPage.GetJEMRestaurantCount();
                    logger.Info($"{searchSuburb} Restaurant Count : {actualResturantCount} ");                    
                }
            }
            catch(Exception e)
            {

            }                                          
        }
        [Test]
        public static void TestRestaurantCountUsingTestDataList()
        {
            logger.Info("Test Restaurant Count");          
            try
            {
                foreach (string suburb in TestData.GetTestData())
                {
                    string searchSuburb = suburb.TrimEnd().TrimStart();
                    Driver.GoToSite(URL.JEMPageUrl);
                    JEMPage.EnterSuburbSearchText(searchSuburb);
                    string actualResturantCount = JEMSerpPage.GetJEMRestaurantCount();
                    logger.Info($"{suburb} Restaurant Count : {actualResturantCount} ");
                }

            }
            catch (Exception e)
            {

            }
        }

        [Test]
        public static void TestRestaurantCountUsingExcelSheet()
        {
            logger.Info("Test Restaurant Count");
           
            try
            {
                foreach (string suburb in ReadDataFromExcel.ReadValuesFromExcelAndWrite())
                {
                    string searchSuburb = suburb.TrimEnd().TrimStart();
                    Driver.GoToSite(URL.JEMPageUrl);
                    JEMPage.EnterSuburbSearchText(searchSuburb);
                    string actualResturantCount = JEMSerpPage.GetJEMRestaurantCount();
                    logger.Info($"{suburb} Restaurant Count : {actualResturantCount} ");
                }

            }
            catch (Exception e)
            {

            }
        }

        [TearDown]
        public static void TearDown()
        {
            Driver.TearDown();
        }
    }
}
