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

        clsConexion cone;

        string user, password, database, port, server;
        string connStr;

        public MainWindow()
        {

            InitializeComponent();

            CenterWindowOnScreen();

            cone = new clsConexion();

            user = "root";
            password = "root";
            database = "colegio";
            port = "3306";
            server = "localhost";

            connStr = "server=" + server + ";user=" + user + ";database=" + database + ";port=" + port + ";password=" + password; 

            mostrarAlumnos();

        }

        private void btnEditarFila_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                object item = dataGridCustomers.SelectedItem;
                string ID = (dataGridCustomers.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string Nombre = (dataGridCustomers.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string Apellidos = (dataGridCustomers.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string Curso = (dataGridCustomers.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                string Sexo = (dataGridCustomers.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                string Nota = (dataGridCustomers.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;

                //MessageBox.Show(ID + Nombre + Apellidos + Curso + Sexo + Nota);

                cone.ActualizarAlumno(ID, Nombre, Apellidos, Curso, Sexo, Nota);

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void btnBorrarFila_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                object item = dataGridCustomers.SelectedItem;
                string ID = (dataGridCustomers.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;             

                cone.BorrarAlumno(ID);
                MessageBox.Show("Alumno Eliminado");

                //Actualizamos el datagrid
                mostrarAlumnos();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void btnLoadDataGrid_Click(object sender, RoutedEventArgs e)
        {

            mostrarAlumnos();

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

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

    }
}
