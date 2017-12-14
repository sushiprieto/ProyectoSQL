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
        public MySqlConnection connection;
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

        public bool OpenConnection()
        {
            connection = new MySqlConnection();
            try
            {

                //connection.ConnectionString = string.Format("server={0};database={1};uid={2};pwd={3};", host, dataBase, user, pass);
                string connStr = "server=localhost;user=root;database=colegio;port=3306;password=root";
                connection = new MySqlConnection(connStr);
                connection.Open();

                return true;
            }
            catch (MySqlException e)
            {
                throw e;
            }

        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public List<string>[] Select()
        {
            string query = "SELECT * FROM alumno";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["AlumnoID"] + "");
                    list[1].Add(dataReader["Nombre"] + "");
                    list[2].Add(dataReader["Apellidos"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public bool InsertarAlumno(string id, string nombre, string apellidos, string curso, string sexo, string nota)
        {

            try
            {

                string connStr = "server=localhost;user=root;database=colegio;port=3306;password=root";
                connection = new MySqlConnection(connStr);

                //This is my insert query in which i am taking input from the user through windows forms
                string query = "INSERT INTO alumno(AlumnoID, Nombre, Apellidos, Curso, Sexo, NotaExamen) VALUES('" + id + "','" + nombre + "','" + apellidos + "','" + curso + "','" + sexo + "','" + nota + "');";

                //This is  MySqlConnection here i have created the object and pass my connection string.
                connection = new MySqlConnection(connStr);

                //This is command class which will handle the query and connection object.
                MySqlCommand MyCommand2 = new MySqlCommand(query, connection);
                MySqlDataReader MyReader2;

                connection.Open();

                // Here our query will be executed and data saved into the database.
                MyReader2 = MyCommand2.ExecuteReader();              

                connection.Close();

                return true;

            }
            catch (Exception ex)
            {

                return false;

            }

        }

        public bool BorrarAlumno(string id)
        {

            try
            {
               
                string connStr = "server=localhost;user=root;database=colegio;port=3306;password=root";
                connection = new MySqlConnection(connStr);

                string query = "DELETE FROM alumno WHERE AlumnoID='" + id + "';";
                     
                connection = new MySqlConnection(connStr);
                MySqlCommand mCommand = new MySqlCommand(query, connection);
                MySqlDataReader mReader;

                connection.Open();

                mReader = mCommand.ExecuteReader();
            
                connection.Close();

                return true;

            }
            catch (Exception ex)
            {

                return false;

            }

        }

    }
}
