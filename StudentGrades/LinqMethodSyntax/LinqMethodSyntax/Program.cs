using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMethodSyntax
{
    public class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            List<int> allNumbers = new List<int>()
            {
                4,2,3,7,15,20,23,6,7,9,15,18,55
            };
            var onlyOdds = allNumbers.Where(number => number % 2 == 1);

            Console.Write(string.Join(" ", onlyOdds)); //Add comma to " " and see what happens
            Console.WriteLine();
            
            foreach (var number in onlyOdds) 
            {
                Console.Write(number + " ");
            }

            AddStudent();
            RemoveStudent();
            GetAStudent();
        }


        public static void AddStudent()
        {
            Student s1 = new Student() { FirstName = "Joe", LastName = "Student", StudentId = 5 };
            students.Add(s1);
            Student s2 = new Student() { FirstName = "Joe", LastName = "Student", StudentId = 6 };
            students.Add(s2);
            Student s3 = new Student() { FirstName = "Joe", LastName = "Student", StudentId = 7 };
            students.Add(s3);
            Student s4 = new Student() { FirstName = "Jane", LastName = "Student", StudentId = 10 };
            students.Add(s4);

            Console.WriteLine("\nAfter Add...");
            Console.WriteLine(string.Join("", students));
        }

        public static void RemoveStudent()
        {
            students.RemoveAll(s => s.StudentId == 6);
            Console.WriteLine("\nAfter Remove");
            Console.WriteLine(string.Join("", students));
        }

        public static void GetAStudent()
        {
            var AllTheJoes = students.Where(s => s.FirstName == "Joe");
            Console.WriteLine("\nGet by Name");
            Console.WriteLine(string.Join("", AllTheJoes));

            var JustOneJoe = students.FirstOrDefault(s => s.FirstName == "Joe");
            Console.WriteLine("\nGet by Name");
            Console.WriteLine(string.Join("", JustOneJoe));

            var JoeById = students.Where(s => s.StudentId == 7);
            Console.WriteLine("\nGet by ID (7)");
            Console.WriteLine(string.Join("", JoeById));
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Id: {StudentId}, First Name: {FirstName}, Last Name: {LastName}\n";
        }
    }
}
