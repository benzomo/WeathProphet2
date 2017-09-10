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

            MyTable.ItemsSource = ds.Tables["Variables"].DefaultView;

            this.builder = new SQLiteCommandBuilder(dataadapter);
            this.builder.ConflictOption = ConflictOption.OverwriteChanges;
    

            this.dataadapter.AcceptChangesDuringUpdate = true;
            this.dataadapter.AcceptChangesDuringFill = true;
            this.dataadapter.InsertCommand = this.builder.GetInsertCommand();
            this.dataadapter.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
            this.dataadapter.UpdateCommand = this.builder.GetUpdateCommand();

           
            this.dataadapter.DeleteCommand = this.builder.GetDeleteCommand();

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


            Chart1.DataContext = new KeyValuePair<string, int>[] {

                new KeyValuePair<string, int>("Dog", 30),

                new KeyValuePair<string, int>("Cat", 25),

                new KeyValuePair<string, int>("Rat", 5),

                new KeyValuePair<string, int>("Hampster", 8),

                new KeyValuePair<string, int>("Rabbit", 12) };


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.RunR();

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ///App.ToExcel();
            ///App.FromExcel();
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
