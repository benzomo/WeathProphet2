using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using RDotNet;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data.SQLite;





namespace WealthProphet2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {



        static public void ToExcel()
        {


            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 1] = "ID";
            xlWorkSheet.Cells[1, 2] = "Name";
            xlWorkSheet.Cells[2, 1] = "1";
            xlWorkSheet.Cells[2, 2] = "One";
            xlWorkSheet.Cells[3, 1] = "2";
            xlWorkSheet.Cells[3, 2] = "Two";

            

            xlWorkBook.SaveAs("C:\\Users\\benmo\\Source\\Repos\\WealthProphet2\\ExcelTest.xlsx", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

        }

         
            static public void RunR()
        {
            
            // Set the folder in which R.dll locates.
            var envPath = Environment.GetEnvironmentVariable("PATH");
            var rBinPath = @"C:\Program Files\R\R-3.4.1\bin";
            //var rBinPath = @"C:\Program Files\R\R-2.11.1-x64\bin"; // Doesn't work ("DLL was not found.")
            Environment.SetEnvironmentVariable("PATH", envPath + Path.PathSeparator + rBinPath);
            using (REngine engine = REngine.GetInstance())
            {
                // Initializes settings.
                engine.Initialize();

                // .NET Framework array to R vector.
                NumericVector group1 = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
                engine.SetSymbol("group1", group1);
                // Direct parsing from R script.
                NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();

                // Test difference of mean and get the P-value.
                GenericVector testResult = engine.Evaluate("t.test(group1, group2)").AsList();
                double p = testResult["p.value"].AsNumeric().First();

                Console.WriteLine("Group1: [{0}]", string.Join(", ", group1));
                Console.WriteLine("Group2: [{0}]", string.Join(", ", group2));
                Console.WriteLine("P-value = {0:0.000}", p);
                Console.ReadLine();
            }
        }



    }


}

