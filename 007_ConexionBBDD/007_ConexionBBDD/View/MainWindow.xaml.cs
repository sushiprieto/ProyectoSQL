using _007_ConexionBBDD.Model;
using _007_ConexionBBDD.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace _007_ConexionBBDD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        clsConexion mConexion;

        public MainWindow()
        {
            InitializeComponent();
            mConexion = new clsConexion();
        }

        private void btnLoadDataGrid_Click(object sender, RoutedEventArgs e)
        {
            string password = "root";
            string connStr = "server=localhost;user=root;database=colegio;port=3306;password=" + password;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT AlumnoID,Nombre,Apellidos,Curso,Sexo,NotaExamen FROM alumno", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adp.Fill(ds, "LoadDataBinding");
            dataGridCustomers.DataContext = ds;

            conn.Close();


            //List<string>[] list;
            //list = mConexion.Select();

            //dataGridCustomers.Row.Clear();
            //for (int i = 0; i < list[0].Count; i++)
            //{
            //    int number = dataGridCustomers.Row
            //    dataGridCustomers.Rows[number].Cells[0].Value = list[0][i];
            //    dataGridCustomers.Rows[number].Cells[1].Value = list[1][i];
            //    dataGridCustomers.Rows[number].Cells[2].Value = list[2][i];
            //}


        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string MyConnection2 = "server=localhost;user=root;database=colegio;port=3306;password=root";
                string Query = "delete from alumno where AlumnoID='" + this.txbId.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Deleted");
                
                MyConn2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            AddWindow win = new AddWindow();
            win.Show();

        }
    }
}
