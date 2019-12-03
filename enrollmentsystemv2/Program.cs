using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security;

namespace enrollmentsystemv2
{
    class Program
    {
        public static void showspecific() 
        {
            Console.Write("Keyword: ");
            var keyword = Console.ReadLine() ?? "";
            Console.WriteLine("Showing all fetched results:");
            Console.WriteLine("");

            using (var sr = new StreamReader("db.txt"))

            {

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (String.IsNullOrEmpty(line)) continue;
                    if (line.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Search complete. Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void showall() 
        {
            Console.WriteLine("Showing all data: ");
            Console.WriteLine("");
            string path = Directory.GetCurrentDirectory() + @"db.txt";

            StreamReader sr1 = File.OpenText("db.txt");


            string s = "";
            int counter = 1;
            StringBuilder sb = new StringBuilder();

            while ((s = sr1.ReadLine()) != null)
            {
                var lineOutput = counter++ + " " + s;
                Console.WriteLine(lineOutput);

                sb.Append(lineOutput);
            }


            sr1.Close();
            Console.WriteLine();
            StreamWriter sw1 = File.AppendText(path);
            sw1.Write(sb);

            sw1.Close();
            Console.WriteLine("");
            Console.WriteLine("Search complete. Press any key to continue...");
            Console.ReadLine();
            Console.Clear();

        }
        public static void Find()
        {
            Console.Clear();
            string choice;
            do
            {
                Console.WriteLine("++++++'Find'++++++");
                Console.WriteLine("1. Show all data ");
                Console.WriteLine("2. Find specific data ");
                Console.WriteLine("3. Return to main menu ");
                Console.Write("Please enter desired action: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    showall();
                }
                else if (choice == "2")
                {
                    showspecific();
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("Please enter a valid choice...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (choice != "1"|| choice != "2");




        }
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("Please enter the id of the student data to be updated: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the following data: ");
            Console.Write("First Name: ");
            string fname = Console.ReadLine();
            Console.Write("Middle Name: ");
            string mname = Console.ReadLine();
            Console.Write("Last Name: ");
            string lname = Console.ReadLine();
            Console.Write("Age: ");
            string age = Console.ReadLine();
            Console.Write("Grade: ");
            string grade = Console.ReadLine();
            Console.Write("Section: ");
            string section = Console.ReadLine();
            Console.Write(@"Payment Status ('1. full  2. partial'): ");
            string paystatchoice = Console.ReadLine();

            string paystat;

            if (paystatchoice == "1")
            {
                paystat = "full";
            }
            else
            {
                paystat = "partial";
            }

            string Str = lname + ";" + fname + ";" + mname + ";" + age + ";" + grade + ";" + section + ":" + paystat;
            

            lineChanger(Str, "db.txt", id);
            Console.WriteLine("Update Success!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Please enter the id to delete: ");
            int line_to_delete = Convert.ToInt32(Console.ReadLine());
            string line = null;
            int line_number = 0;
            
            using (StreamReader reader = new StreamReader("db.txt"))
            {
                using (StreamWriter writer = new StreamWriter("temp.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        line_number++;

                        if (line_number == line_to_delete)
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }
            var result = File.ReadAllLines(@"temp.txt");
            File.WriteAllLines(@"db.txt", result);
        }
        public static void Insert()
        {
            Console.Clear();
            var lineCount = File.ReadLines("db.txt").Count();

            Console.WriteLine("Please enter the following data: ");
            Console.Write("First Name: ");
            string fname = Console.ReadLine();
            Console.Write("Middle Name: ");
            string mname = Console.ReadLine();
            Console.Write("Last Name: ");
            string lname = Console.ReadLine();
            Console.Write("Age: ");
            string age = Console.ReadLine();
            Console.Write("Grade: ");
            string grade = Console.ReadLine();
            Console.Write("Section: ");
            string section = Console.ReadLine();
            Console.Write(@"Payment Status ('1. full  2. partial'): ");
            string paystatchoice = Console.ReadLine();

            string paystat;

            if (paystatchoice == "1")
            {
                paystat = "full";
            }
            else
            {
                paystat = "partial";
            }
            
            string Str = lname + ";" + fname + ";" + mname + ";" + age + ";" + grade + ";" + section + ":" + paystat;
            File.AppendAllText("db.txt", Str + Environment.NewLine);

            Console.WriteLine("Input Success!");
            Console.ReadLine();
            Console.Clear();

        }
        public static void Menu()
        {

            string choice;
            do
            {
                Console.WriteLine("******ENROLLMENT SYSTEM******");
                var lineCount = File.ReadLines("db.txt").Count();
                Console.WriteLine("Number of Students: " + lineCount);
                Console.WriteLine("+===========================+");
                Console.WriteLine("||1. Insert new student    ||");
                Console.WriteLine("||2. Remove student        ||");
                Console.WriteLine("||3. Update student        ||");
                Console.WriteLine("||4. Find student          ||");
                Console.WriteLine("||5. Logout                ||");
                Console.WriteLine("||6. Exit program          ||");
                Console.WriteLine("+===========================+");
                Console.Write("Please enter desired action (1-5): ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Insert();
                }
                if (choice == "2")
                {
                    Delete();
                }
                else if (choice == "3")
                {
                    Update();

                }
                else if (choice == "4")
                {
                    Find();
                }
                else if (choice == "5") 
                {

                    form();

                }
                else if (choice == "6")
                {
                    Console.WriteLine("Terminating program. Please any key to exit...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter a valid choice.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                }

            } while (choice != "1" || choice != "2" || choice != "3" || choice != "4" || choice != "5");

        }
        private static SecureString pass()
        {
            
            SecureString password = new SecureString();
            ConsoleKeyInfo input;

            do
            {
                input = Console.ReadKey(true);
                if (!char.IsControl(input.KeyChar))
                {

                    password.AppendChar(input.KeyChar);
                    Console.Write("*");

                }
                else
                {
                    if (input.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        // Remove last charcter if Backspace is Pressed
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            } 
            while (input.Key != ConsoleKey.Enter);
            {

                return password;

            }
        }

        public static void form()
        {
            string username;
            string Password;
            do
            {
                Console.Clear();
                Console.WriteLine("******ENROLLMENT SYSTEM******");
                Console.Write("username: ");
                username = Console.ReadLine();
                Console.Write("password: ");
                SecureString password = pass();
                Password = new System.Net.NetworkCredential(string.Empty, password).Password;


                if (username == "user" && Password == "root")
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("invalid username or password...");
                    Console.ReadLine();
                }
            }
            while (username != "user" && Password != "root");
        }
        public static void Main(string[] args)
        {
            form();
        }
    }
}