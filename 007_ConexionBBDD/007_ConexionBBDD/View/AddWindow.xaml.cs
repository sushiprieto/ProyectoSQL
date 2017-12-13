using _007_ConexionBBDD.Model;
using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace _007_ConexionBBDD.View
{
    /// <summary>
    /// Lógica de interacción para AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {

        MySqlConnection connection;

        string user, password, database, port, server;
        string connStr;

        public AddWindow()
        {

            InitializeComponent();

            user = "root";
            password = "root";
            database = "colegio";
            port = "3306";
            server = "localhost";

            connStr = "server=" + server + ";user=" + user + ";database=" + database + ";port=" + port + ";password=" + password;

        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
               
                //This is my insert query in which i am taking input from the user through windows forms
                string query = "insert into alumno(AlumnoID, Nombre, Apellidos, Curso, Sexo, NotaExamen) values('" + this.txbID.Text + "','" + this.txbNombre.Text + "','" + this.txbApellidos.Text + "','" + this.txbCurso.Text + "','" + this.txbSexo.Text + "','" + this.txbNotaExamen.Text + "');";
                
                //This is  MySqlConnection here i have created the object and pass my connection string.
                connection = new MySqlConnection(connStr);
                
                //This is command class which will handle the query and connection object.
                MySqlCommand MyCommand2 = new MySqlCommand(query, connection);
                MySqlDataReader MyReader2;

                connection.Open();

                // Here our query will be executed and data saved into the database.
                MyReader2 = MyCommand2.ExecuteReader();

                Close();

                connection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }
    }
}
