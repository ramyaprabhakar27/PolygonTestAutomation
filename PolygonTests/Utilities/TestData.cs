using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonTests.Utilities
{
    public static class TestData
    {
        private static string testData = "Westmead,Wentworthville,Harris park";

        public static List<string> GetTestData()
        {
            return (testData.Split(',').ToList());
        }
    }
}
