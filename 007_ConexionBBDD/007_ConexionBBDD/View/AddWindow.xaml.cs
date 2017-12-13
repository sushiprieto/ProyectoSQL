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
        public AddWindow()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //This is my connection string i have assigned the database file address path
                string MyConnection2 = "server=localhost;user=root;database=colegio;port=3306;password=root";
                //This is my insert query in which i am taking input from the user through windows forms
                string Query = "insert into alumno(AlumnoID,Nombre,Apellidos,Curso,Sexo,NotaExamen) values('" + this.txbID.Text + "','" + this.txbNombre.Text + "','" + this.txbApellidos.Text + "','" + this.txbCurso.Text + "','" + this.txbSexo.Text + "','" + this.txbNotaExamen.Text + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                MessageBox.Show("Save Data");
                
                MyConn2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
