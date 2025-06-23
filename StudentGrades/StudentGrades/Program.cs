using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GradeCalculator gc = new GradeCalculator();

            Console.Write("Enter the percentage: ");
            int.TryParse(Console.ReadLine(), out int total);
            string grade = gc.GetGradeByPercentage(total);
            Console.WriteLine($"Student Grade: {grade}");
        }
    }
}
