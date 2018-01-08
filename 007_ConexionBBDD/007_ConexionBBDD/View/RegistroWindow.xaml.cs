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
using System.Security.Cryptography;

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

        //static string Encriptar (string value)
        //{

        //    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        //    {

        //        UTF8Encoding utf8 = new UTF8Encoding();
        //        byte[] datos = md5.ComputeHash(utf8.GetBytes(value));

        //        return Convert.ToBase64String(datos);

        //    }

        //}

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            string usuario = txbUsuario.Text;
            string clave = txbClave.Text;
            string claveConfirm = txbClaveConfirm.Text;

            if (usuario.Equals("") || clave.Equals("") || claveConfirm.Equals(""))
            {

                MessageBox.Show("No puede haber campos vacios", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {

                if (clave.Equals(claveConfirm))
                {

                    try
                    {

                        //string claveEncriptada = Encriptar(clave);

                        //string hash = "f0xle@rn";
                        //byte[] datos = UTF8Encoding.UTF8.GetBytes(clave);
                        //using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                        //{

                        //    //UTF8Encoding utf8 = new UTF8Encoding();
                        //    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                        //    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                        //    {
                        //        ICryptoTransform transform = tripDes.CreateEncryptor();
                        //        byte[] results = transform.TransformFinalBlock(datos, 0, datos.Length);
                        //        clave = Convert.ToBase64String(results, 0, results.Length);
                        //    }


                        //}

                        conn.Registro(usuario, clave);

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
