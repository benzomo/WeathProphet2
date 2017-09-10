using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using RDotNet;
using System.Runtime.InteropServices;
using System.Data.SQLite;
using System.Data;
using System.Windows.Controls.DataVisualization.Charting;

namespace WealthProphet2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sql;
        DataSet ds;
        SQLiteConnection m_dbC;
        SQLiteDataAdapter dataadapter;
        SQLiteCommandBuilder builder;

        public MainWindow()
        {


            InitializeComponent();

            this.sql = "SELECT * FROM Variables";

            this.ds = new DataSet();
           
           
            
            this.m_dbC = new SQLiteConnection("Data Source= C:\\Users\\benmo\\Source\\Repos\\WealthProphet2\\WealthProphet2\\DB.db;");
            this.m_dbC.Open();

            this.dataadapter = new SQLiteDataAdapter(sql, m_dbC);
 
            this.dataadapter.Fill(ds, "Variables");

            this.m_dbC.Close();


            this.builder = new SQLiteCommandBuilder(dataadapter);
            this.builder.ConflictOption = ConflictOption.OverwriteChanges;
    

            this.dataadapter.AcceptChangesDuringUpdate = true;
            this.dataadapter.AcceptChangesDuringFill = true;
            this.dataadapter.InsertCommand = this.builder.GetInsertCommand();
            this.dataadapter.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
            this.dataadapter.UpdateCommand = this.builder.GetUpdateCommand();

           
            this.dataadapter.DeleteCommand = this.builder.GetDeleteCommand();

            MyTable.ItemsSource = ds.Tables["Variables"].DefaultView;

            List<string> luxS = new List<string>();
            List<double> luxV = new List<double>();
            List<string> basS = new List<string>();
            List<double> basV = new List<double>();
            List<string> survS = new List<string>();
            List<double> survV = new List<double>();

            List<double> spending = new List<double>();
            List<double> income = new List<double>();


            for (int loop = 0; loop < ds.Tables["Variables"].Select(" Category <> '' ").Length; loop++)
            {
                if ((double.Parse(ds.Tables["Variables"].Select(" Category <> ''")[loop].ItemArray[4].ToString()) > 5) & (ds.Tables["Variables"].Select(" Category <> ''")[loop].ItemArray[5].ToString().Equals("CFout") == true) )
                {

                    spending.Add(double.Parse(ds.Tables["Variables"].Select(" Category <> ''")[loop].ItemArray[4].ToString()));

                }
            }

            for (int loop = 0; loop < ds.Tables["Variables"].Select(" Type = 'CFin' ").Length; loop++)
            {   
                    income.Add(double.Parse(ds.Tables["Variables"].Select("Type = 'CFin'")[loop].ItemArray[4].ToString()));

            }


            for (int loop = 0; loop < ds.Tables["Variables"].Select(" Category = 'LUXURY'").Length; loop++)
            {
                if (double.Parse(ds.Tables["Variables"].Select(" Category = 'LUXURY'")[loop].ItemArray[4].ToString()) > 0)
                {
                    luxS.Add(ds.Tables["Variables"].Select(" Category = 'LUXURY'")[loop].ItemArray[7].ToString());
                    luxV.Add(double.Parse(ds.Tables["Variables"].Select(" Category = 'LUXURY'")[loop].ItemArray[4].ToString()));


                }
            }
            for (int loop = 0; loop < ds.Tables["Variables"].Select(" Category = 'SURV'").Length; loop++)
            {

                if (double.Parse(ds.Tables["Variables"].Select(" Category = 'SURV'")[loop].ItemArray[4].ToString()) > 0)
                {
                    survS.Add(ds.Tables["Variables"].Select(" Category = 'SURV'")[loop].ItemArray[7].ToString());
                    survV.Add(double.Parse(ds.Tables["Variables"].Select(" Category = 'SURV'")[loop].ItemArray[4].ToString()));

                }


            }
            for (int loop = 0; loop < ds.Tables["Variables"].Select(" Category = 'BASIC'").Length; loop++)
            {
                if (double.Parse(ds.Tables["Variables"].Select(" Category = 'BASIC'")[loop].ItemArray[4].ToString()) > 0)
                {
                    basS.Add(ds.Tables["Variables"].Select(" Category = 'BASIC'")[loop].ItemArray[7].ToString());
                    basV.Add(double.Parse(ds.Tables["Variables"].Select(" Category = 'BASIC'")[loop].ItemArray[4].ToString()));

                }
            }

            Console.WriteLine(luxS[0]);
            Console.WriteLine(luxV[0]);


            List<int> arr1 = new List<int>();
            int i = 0;
            foreach (DataRow row in ds.Tables["Variables"].Rows)
            {
        
                arr1.Add(row.Field<int>("VarID"));
                i++;
            }
            Console.WriteLine(arr1[0]);

            Console.WriteLine(arr1[5]);

            int[] array1 = App.GetVector(arr1);

            Console.WriteLine(array1[5]);

            double[][] bobby = App.ToRMatrix(array1);

            Console.WriteLine(bobby[0][20]);


            Chart1.DataContext = new KeyValuePair<string, double>[] {

                new KeyValuePair<string, double>("Luxury", luxV.Sum()),

                new KeyValuePair<string, double>("Survival", survV.Sum()),

                new KeyValuePair<string, double>("Basic", basV.Sum()),

                new KeyValuePair<string, double>("Savings", income.Sum() - spending.Sum()),

            };


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.ToExcel();
            //App.FromExcel();

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
            ///

            this.m_dbC.Open();

            this.dataadapter.Update(this.ds.Tables["Variables"]);

            DataTable dt = new DataTable();

            dt = this.ds.Tables["Variables"];

            Chart1.DataContext = new KeyValuePair<string, int>[] {

                new KeyValuePair<string, int>("Dog", 10),

                new KeyValuePair<string, int>("Cat", 25),

                new KeyValuePair<string, int>("Rat", 45),

                new KeyValuePair<string, int>("Hampster", 8),

                new KeyValuePair<string, int>("Rabbit", 2) };





            this.m_dbC.Close();




        }

        private void GetArray(DataTable xin, string strin)
        {
            Dictionary<int, int> id = new Dictionary<int, int>();
            int i = 0;
            foreach (DataRow row in xin.Rows)
            {

                id.Add(i, row.Field<int>(strin));
                i++;
            }

            int[] array1 = (new List<int>(id.Values)).ToArray();

        }



    }

    



}
