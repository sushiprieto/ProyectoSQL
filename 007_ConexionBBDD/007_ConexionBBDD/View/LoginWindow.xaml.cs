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

        //static void Desencriptar(string value)
        //{
        //    string hash = "f0xle@rn";
        //    byte[] datos = UTF8Encoding.UTF8.GetBytes(value);
        //    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        //    {

        //        //UTF8Encoding utf8 = new UTF8Encoding();
        //        byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
        //        using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider(){Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
        //        {
        //            ICryptoTransform transform = tripDes.CreateDecryptor();
        //            byte[] results = transform.TransformFinalBlock(datos, 0, datos.Length);
        //            value = UTF8Encoding.UTF8.GetString(results);
        //        }
                

        //    }

        //}

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

                //string hash = "f0xle@rn";
                //byte[] datos = UTF8Encoding.UTF8.GetBytes(clave);
                //using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                //{

                //    //UTF8Encoding utf8 = new UTF8Encoding();
                //    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                //    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                //    {
                //        ICryptoTransform transform = tripDes.CreateDecryptor();
                //        byte[] results = transform.TransformFinalBlock(datos, 0, datos.Length);
                //        clave = UTF8Encoding.UTF8.GetString(results);
                //    }


                //}

                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", usuario);
                sqlCmd.Parameters.AddWithValue("@Password", clave);

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
