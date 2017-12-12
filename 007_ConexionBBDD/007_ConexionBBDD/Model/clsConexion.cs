using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_ConexionBBDD.Model
{
    public class clsConexion
    {

        //Atributos
        public String host { get; set; }
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }

        public clsConexion()
        {

            this.host = "localhost";
            this.dataBase = "colegio";
            this.user = "root";
            this.pass = "root";

        }

        public clsConexion(String host, String dataBase, String user, String pass)
        {
            this.dataBase = dataBase;
            this.user = user;
            this.pass = pass;
            this.host = host;
        }

        public MySqlConnection getConnection()
        {
            MySqlConnection connection = new MySqlConnection();
            try
            {

                connection.ConnectionString = string.Format("server={0};database={1};uid={2};pwd={3};", host, dataBase, user, pass);
                

                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            return connection;

        }

        public void closeConnection(ref MySqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
