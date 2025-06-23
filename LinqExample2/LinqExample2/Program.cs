using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintStudents(StudentRepo.SelectAll());
            AnonymousType();
            GetAverageGPA();
            HonorRoll();
        }

        public static void AnonymousType()
        {
            var students = from s in StudentRepo.SelectAll()
                           select new
                           { LastFirst = s.LastName + ", " + s.FirstName, s.Major, s.GPA };

            string headingFormat = "{0,-31} {1,-18} {2,4}";
            string lineFormat = "{0,-31} {1,-18} {2,4}";

            Console.WriteLine(headingFormat, "Name", "Major", "GPA");
            Console.WriteLine("--------------------------------------------------------");

            foreach (var student in students)
            {
                Console.WriteLine(lineFormat, student.LastFirst, student.Major, student.GPA);
            }
        }
        
        // IEnumerable means I can pass in List, Array or any type that can be 'looped'
        public static void PrintStudents(IEnumerable<Student> students)
        {
            string headingFormat = "{0,-15} {1,-15} {2,-18} {3,4}";
            string lineFormat = "{0,-15} {1,-15} {2,-18} {3,4}";

            Console.WriteLine(headingFormat, "Last Name", "First Name", "Major", "GPA");
            Console.WriteLine("--------------------------------------------------------");

            foreach (Student student in students)
            {
                Console.WriteLine(lineFormat, student.LastName, student.FirstName, student.Major, student.GPA);
            }
            Console.WriteLine();
        }

        public static void GetAverageGPA()
        {
            var students = StudentRepo.SelectAll();
            //decimal average = students.Average(s => s.GPA);
                           
            
            //Console.WriteLine($"\nAverage GPA: {average:F2}");
            Console.WriteLine($"\nMax GPA: {students.Average(s => s.GPA):F2}");
            Console.WriteLine($"\nMax GPA: {students.Max(s => s.GPA)}");
            Console.WriteLine($"\nMax GPA: {students.Min(s => s.GPA)}");
        }

        public static void HonorRoll()
        {
            var honorRoll = StudentRepo.SelectAll().Where(s => s.GPA > 3.5M);
            PrintStudents(honorRoll);
        }

        public static void GroupByMajor()
        {

        }
    }
}
