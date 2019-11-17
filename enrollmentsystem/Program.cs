using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace enrollmentsystem
{
    class Program
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;
        public static void GetStudent()
        {
            int counter = 0;
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM students";
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                counter++;
                Console.WriteLine(reader[0] + "-" + reader[1] + " " + reader[2]);
            }
            con.Close();
            Console.WriteLine("====================================");
            Console.WriteLine("Number of Students :" + counter);
            Console.WriteLine("====================================");
        }
        public static void InsertStudent()
        {
            Console.Write("First Name : ");
            string fname = Console.ReadLine();
            Console.Write("Last Name : ");
            string lname = Console.ReadLine();
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO students (FirstName,LastName) VALUES ('" + fname + "','" + lname + "')";
            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Inserted");
            }
            else
            {
                Console.WriteLine("Three are errors. The record was not inserted.");
            }
        }
        public static void UpdateStudent()
        {
            Console.Write("ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name : ");
            string fname = Console.ReadLine();
            Console.Write("Last Name : ");
            string lname = Console.ReadLine();
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE students SET FirstName='" + fname + "',LastName='" + lname + "' WHERE Id=" + id;

            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("Three are errors. The record was not updated");
            }

        }
        public static void DeleteStudent()
        {
            Console.Write("Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM students WHERE Id=" + id + "";
            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Deleted.");
            }
            else
            {
                Console.WriteLine("Three are errors. The record was not deleted.");
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.List of Students");
                Console.WriteLine("2.Insert");
                Console.WriteLine("3.Update");
                Console.WriteLine("4.Delete");
                Console.WriteLine("====================================");
                Console.Write("Select : ");
                string sec = Console.ReadLine();
                Console.WriteLine("====================================");
                if (sec == "1")
                {
                    GetStudent();
                }
                else if (sec == "2")
                {
                    InsertStudent();
                    Console.WriteLine("====================================");
                    GetStudent();
                }
                else if (sec == "3")
                {
                    UpdateStudent();
                    Console.WriteLine("====================================");
                    GetStudent();
                }
                else if (sec == "4")
                {
                    DeleteStudent();
                    Console.WriteLine("====================================");
                    GetStudent();
                }

                Console.Write("Continue? (y/n) : ");
            
                char loop = char.Parse(Console.ReadLine());
                
                if (loop == 'n' || loop == 'N')
                {
                    break;
                }
                else if (loop == 'y' || loop == 'Y')
                {

                }
                else
                {
                    Console.WriteLine("Please enter a valid choice.");
                    Console.ReadKey(true);
                }


            }
        }
    }
}
