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

        MySqlConnection connection;

        string user, password, database, port, server;
        string connStr;

        public MainWindow()
        {
            InitializeComponent();

            user = "root";
            password = "root";
            database = "colegio";
            port = "3306";
            server = "localhost";

            connStr = "server=" + server + ";user=" + user + ";database=" + database + ";port=" + port + ";password=" + password; 

            mostrarAlumnos();

        }

        private void btnLoadDataGrid_Click(object sender, RoutedEventArgs e)
        {

            mostrarAlumnos();

        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                
                string query = "DELETE FROM alumno WHERE AlumnoID='" + this.txbId.Text + "';";

                connection = new MySqlConnection(connStr);
                MySqlCommand mCommand = new MySqlCommand(query, connection);
                MySqlDataReader mReader;

                connection.Open();

                mReader = mCommand.ExecuteReader();

                MessageBox.Show("Alumno borrado con éxito!");

                connection.Close();

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

        private void mostrarAlumnos()
        {

            connection = new MySqlConnection(connStr);
            connection.Open();

            string query = "SELECT * FROM alumno";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adp.Fill(ds, "CargarAlumno");
            dataGridCustomers.DataContext = ds;

            connection.Close();

        }

    }
}
