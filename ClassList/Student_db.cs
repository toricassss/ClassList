using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassList
{
    abstract public class Student_db
    {
        private const string db = "gmis";
        private const string user = "gmis";
        private const string pass = "gmis";
        private const string server = "alacritas.cis.utas.edu.au";

        static MySqlConnection? conn;

        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2}; Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public static ObservableCollection<Student> LoadAll()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            // Declare a data reader
            MySqlDataReader? rdr = null;

            try
            {
                // Instantiate a connection
                conn = GetConnection();
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select student_id, given_name, family_name, title, campus, phone, email, category from student", conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    Student s = new Student { student_id = rdr.GetInt32(0), given_name = rdr.GetString(1), family_name = rdr.GetString(2), title = rdr.GetString(3), campus = rdr.GetString(4), phone = rdr.GetString(5), email = rdr.GetString(6), category = rdr.GetString(7) };
                    students.Add(s);
                }
            }
            catch (MySqlException s)
            {
                Console.WriteLine("Error connecting to database: " + s);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return students;
        }
    }
}