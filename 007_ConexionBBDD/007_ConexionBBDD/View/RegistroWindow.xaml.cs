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

        static string Encriptar (string value)
        {
            string hash = "MeC@go3nTO";
            byte[] keyArray;
            byte[] toEncrypt = UTF8Encoding.UTF8.GetBytes(value);

            MD5CryptoServiceProvider hasmd5 = new MD5CryptoServiceProvider();
            keyArray = hasmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

            hasmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransform = tdes.CreateEncryptor();

            byte[] resultArray = cryptoTransform.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);

            tdes.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

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

                        //Encriptamos la clave para introducirla en la BBDD
                        string claveEncriptada = Encriptar(clave);
                                                
                        conn.Registro(usuario, claveEncriptada);

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
