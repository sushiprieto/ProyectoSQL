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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection sqlCon = new MySqlConnection(@"server=localhost;user=root;database=colegio;port=3306;password=root");

            try
            {

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                String query = "SELECT COUNT(1) FROM loginalumno WHERE Usuario=@Username AND Clave=@Password";

                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txbUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txbPassword.Password);

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

    }
}
