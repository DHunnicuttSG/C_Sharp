using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ScopeVars();
            //MyVector();
            //Concat();

            //Person p1 = new Person
            //{
            //    name = "Dave",
            //    age = 25
            //};

            //Person2 p2 = new Person2();

            //GetDateTime();
            //DateParse();

            DateTime d = new DateTime(2015, 7, 29);

            Console.WriteLine(d.DayOfWeek);
        }


        public static void ScopeVars()
        {
            // *** Scope ***

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            } // i goes out of scope here
              // We can declare a variable named i again, because
              // there's no other variable with that name in scope
            for (int i = 9; i >= 0; i--)
            {
                Console.WriteLine(i);
            } // i goes out of scope here.
        }

        public static void MyVector()
        {
            Vector x, y;
            x = new Vector();
            x.Value = 30; // Value is a field defined in Vector class
            y = x;
            Console.WriteLine(y.Value);
            y.Value = 50;
            Console.WriteLine(x.Value);
        }

        public class Vector
        {
            public int Value;
        }

        public static void Concat()
        {
            var a = 5;
            var b = 7;
            var c = "C_Sharp";
            Console.WriteLine(a + b + c);
            Console.WriteLine(c + b + a);
        }

        public class Person
        {
            public string name;
            public int age;
        }

        public class Person2
        {
            private string name { get; set; }
            private int age { get; set; }
        }

        public static void GetDateTime()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Today);
            Console.WriteLine(DateTime.UtcNow);
        }

        public static void DateParse()
        {
            DateTime d1 = DateTime.Parse("07/04/2025 1:30:00 PM");

            Console.WriteLine(d1.Year);    // 2015
            Console.WriteLine(d1.Month);   // 10
            Console.WriteLine(d1.Day);     // 4
            Console.WriteLine(d1.Hour);    // 1
            Console.WriteLine(d1.Minute);  // 30
            Console.WriteLine(d1.Second);  // 0
        }
    }
}
