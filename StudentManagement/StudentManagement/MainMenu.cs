using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class MainMenu
    {
        private const string separatorBar = "=========================";

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Management System");
            Console.WriteLine(separatorBar);
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Edit Student GPA");
            Console.WriteLine("");
            Console.WriteLine("Q - Quit");
            Console.WriteLine(separatorBar);
            Console.WriteLine("");
            Console.Write("Enter choice: ");
        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("List Students");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Add Student");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Remove Student");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("Edit Student");
                    Console.ReadKey();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That is not a valid choice. Press anykey to continue...");
                    Console.ReadKey();
                    break;
            }
            return true;
        }

        public static void Show()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                DisplayMenu();
                keepGoing = ProcessChoice();
            }
        }
    }
}
