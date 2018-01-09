using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            CenterWindowOnScreen();
        }

        static string Encriptar(string value)
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

        static string Desencriptar(string value)
        {

            string hash = "MeC@go3nTO";
            byte[] keyArray;
            byte[] toEncrypt = Convert.FromBase64String(value);

            MD5CryptoServiceProvider hasmd5 = new MD5CryptoServiceProvider();
            keyArray = hasmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

            hasmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransform = tdes.CreateDecryptor();
           
            byte[] resultArray = cryptoTransform.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);

            tdes.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection sqlCon = new MySqlConnection(@"server=localhost;user=root;database=colegio;port=3306;password=root");

            string usuario = txbUsername.Text;
            string clave = txbPassword.Password;

            try
            {

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                String query = "SELECT COUNT(1) FROM loginalumno WHERE Usuario=@Username AND Clave=@Password";
                
                //Encriptamos la contraseña introducida para compararla con la clave encriptada de la BBDD
                string claveEncriptada = Encriptar(clave);

                //string claveDesencriptada = Desencriptar(claveEncriptada);

                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", usuario);
                sqlCmd.Parameters.AddWithValue("@Password", claveEncriptada);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            
                if (count == 1)
                {

                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();

                }
                else
                {

                    MessageBox.Show("Usuario o contraseña incorrecto");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            RegistroWindow registro = new RegistroWindow();
            registro.Show();

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
