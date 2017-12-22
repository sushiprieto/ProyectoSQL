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

        clsConexion conn;

        public AddWindow()
        {

            InitializeComponent();

            conn = new clsConexion();

        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {

            string sexo = "";

            if (rdbHombre.IsChecked == true)
                sexo = "H";
            else if (rdbMujer.IsChecked == true)
                sexo = "M";

            try
            {
                
                conn.InsertarAlumno(txbID.Text, txbNombre.Text, txbApellidos.Text, txbCurso.Text, sexo, txbNotaExamen.Text);

                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }
    }
}
