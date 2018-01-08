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

            CenterWindowOnScreen();

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

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
