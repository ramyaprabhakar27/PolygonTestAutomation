using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using worksheet = Microsoft.Office.Interop.Excel.Worksheet;
using workbook = Microsoft.Office.Interop.Excel.Workbook;
using System.Runtime.InteropServices;
using System.Drawing;
using NUnit.Framework;
using System.Diagnostics;

namespace PolygonTests.Utilities
{
    public static class ReadDataFromExcel
    {
        public static List<string> ReadValuesFromExcelAndWrite()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string suburbText;
            List<string> suburbList = new List<string>();

            //string str;
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            
            xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\ramya.prabhakara\Downloads\CSharpPrograms\PolygonTestAutomation\PolygonTests\Utilities\PolygonTestData.xlsx");
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("PolygonTestDataSheet");
            //Gives the used cells in the sheet
            range = xlWorkSheet.UsedRange;
            for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                for (cCnt = 1; cCnt <= (range.Columns.Count); cCnt ++)
                {
                    //Get the string from the sheet
                    suburbText = (range.Cells[rCnt, cCnt] as Excel.Range).get_Value();
                    suburbList.Add(suburbText);
                }
            }
            xlWorkBook.Save();
            xlWorkBook.Close();
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return suburbList;
        }
    }
}
