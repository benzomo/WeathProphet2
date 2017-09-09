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
          

            this.m_dbC.Close();




        }



    }

    



}
