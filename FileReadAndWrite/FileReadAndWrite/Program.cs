using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadAndWrite
{
    public class Program
    {
        static string AddressBookPath = @".\AddressBook.txt";
        static void Main(string[] args)
        {
            CreateFile();
            //WriteWithAllLines();
            //WriteWithStreamWriter();
            //AppendWithStreamWriter();
            //ReadAllLines();
            //ReadWithStreamReader();
            CheckIfAddressBookExists();
            ReadAllAddressBookContacts();
        }

        public static void CreateFile()
        {
            string path = @".\List.txt";

            if (!File.Exists(path))
            {
                File.Create(path);
                Console.WriteLine("File created.");
            }
        }

        static void WriteWithAllLines()
        {
            string path = @".\List.txt";
            string[] lines = new string[]
            {
                "Blue",
                "Green",
                "Yellow",
                "Red",
                "Orange"
            };
            File.WriteAllLines(path, lines);
            Console.WriteLine("Wrote to File using All Lines.");
        }

        static void WriteWithStreamWriter()
        {
            string path = @".\List1.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Red");
                writer.WriteLine("Green");
                writer.WriteLine("Yellow");
                writer.WriteLine("Blue");
            }

            Console.WriteLine("Wrote to File using Stream Writer.");
        }

        static void AppendWithStreamWriter()
        {
            string path = @".\List1.txt";
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine("Orange");
                writer.WriteLine("Purple");
                writer.WriteLine("Pink");
                writer.WriteLine("Teal");
            }

            Console.WriteLine("Appended to File using Stream Writer.");
        }

        static void ReadAllLines()
        {
            string path = @".\List.txt";

            String[] allLines = File.ReadAllLines(path);
            Console.WriteLine(string.Join(", ", allLines));
        }


        public static void ReadWithStreamReader()
        {
            string path = @".\List1.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static void CheckIfAddressBookExists()
        {
            if (!File.Exists(AddressBookPath))
            {
                Console.WriteLine("Could not find file at {0}", AddressBookPath);
            }
        }

        public static void ReadAllAddressBookContacts()
        {
            string[] rows = File.ReadAllLines(AddressBookPath);

            List<Contact> contacts = new List<Contact>();

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                Contact c = new Contact();
                c.FirstName = columns[0];
                c.LastName = columns[1];
                c.Street1 = columns[2];
                c.Street2 = columns[3];
                c.City = columns[4];
                c.State = columns[5];
                c.ZipCode = columns[6];

                contacts.Add(c);
            }

            foreach (var contact in contacts.OrderBy(c => c.LastName))
            {
                Console.WriteLine("{0}, {1}",
                    contact.LastName, contact.FirstName);
                Console.WriteLine(contact.Street1);

                if (!string.IsNullOrEmpty(contact.Street2))
                    Console.WriteLine(contact.Street2);

                Console.WriteLine("{0}, {1} {2}",
                    contact.City, contact.State, contact.ZipCode);

                //blank line between records
                Console.WriteLine("");
            }
        }
    }
}
