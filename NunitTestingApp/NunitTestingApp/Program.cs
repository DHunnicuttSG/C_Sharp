using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NunitTestingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program p1 = new Program();
            Console.WriteLine(p1.AddTwoNums(10, 12));
        }

        public int AddTwoNums(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
