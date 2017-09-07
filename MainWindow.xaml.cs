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
        public MainWindow()
        {


            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.RunR();

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ///App.ToExcel();
            App.FromExcel();

            string sql = "SELECT * FROM Variables";

            DataSet ds = new DataSet();

            SQLiteConnection m_dbC;
            m_dbC = new SQLiteConnection("Data Source= C:\\Users\\benmo\\Source\\Repos\\WealthProphet2\\WealthProphet2\\DB.db;");
            m_dbC.Open();

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter(sql, m_dbC);

            dataadapter.Fill(ds, "Variables");

            m_dbC.Close();

            MyTable.ItemsSource = ds.Tables["Variables"].DefaultView;


        }
        

    }

    



}
