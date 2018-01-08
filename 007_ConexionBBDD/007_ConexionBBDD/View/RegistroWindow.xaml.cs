using _007_ConexionBBDD.Model;
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
    /// Lógica de interacción para RegistroWindow.xaml
    /// </summary>
    public partial class RegistroWindow : Window
    {

        clsConexion conn;

        public RegistroWindow()
        {

            InitializeComponent();

            CenterWindowOnScreen();

            conn = new clsConexion();

        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            string clave = txbClave.Text;
            string claveConfirm = txbClaveConfirm.Text;

            if (clave.Equals(claveConfirm))
            {

                try
                {

                    conn.Registro(txbUsuario.Text, clave);

                    Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

            }
            else
            {

                MessageBox.Show("Las contraseñas no coinciden");

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
