using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            //WithoutLinq();
            //WithLinq();
            List<Product> products = new List<Product>();
            products = AddProductData(products);
            var InStock = products.Where(product => product.UnitsInStock > 0).ToList();
            var OutOfStock = products.Where(product => product.UnitsInStock == 0).ToList();
            var Electronics = products.Where(product => product.Category == "Electronics").ToList();
            var CountOfElectronics = products.Where(product => product.Category == "Electronics").Count();
            var Furniture = products.Where(product => product.Category == "Furniture").ToList();
            var EmptyList = products.Where(product => product.Category == "SomethingDifferent").ToList();
            // check if your query has results
            if (EmptyList.Any())
            {
                Console.WriteLine("There is data");
            }
            else
            {
                Console.WriteLine("There is no data");
            }

                Console.WriteLine(string.Join(", ", CountOfElectronics));
        }

        public static void WithoutLinq()
        {
            List<int> allNumbers = new List<int>()
                { 4, 2, 3, 7, 15, 20, 6 };

            List<int> onlyOdds = new List<int>();
            foreach (int number in allNumbers)
            {
                if (number % 2 == 1)
                    onlyOdds.Add(number);
            }
            Console.WriteLine(string.Join(", ", onlyOdds));
        }

        public static void WithLinq()
        {
            List<int> allNumbers = new List<int>()
                { 4, 2, 3, 7, 15, 20, 6 };

            //var onlyOdds = from number in allNumbers
            //               where number % 2 == 1
            //               select number;


            // Shorthand version of writing Linq queries
            var onlyOdds = allNumbers.Where(number => number % 2 == 1);

            Console.WriteLine(string.Join(", ", onlyOdds));
        }
        
        public static List<Product> AddProductData(List<Product> products)
        {
            Product p1 = new Product();
            p1.ProductId = 1;
            p1.Name = "Laptop";
            p1.Price = 1200.00m;
            p1.UnitsInStock = 5;
            p1.Category = "Electronics";

            Product p2 = new Product();
            p2.ProductId = 2;
            p2.Name = "Mouse";
            p2.Price = 25.00m;
            p2.UnitsInStock = 0;
            p2.Category = "Electronics";

            Product p3 = new Product();
            p3.ProductId = 3;
            p3.Name = "Keyboard";
            p3.Price = 75.00m;
            p3.UnitsInStock = 12;
            p3.Category = "Electronics";

            Product p4 = new Product();
            p4.ProductId = 4;
            p4.Name = "Desk Chair";
            p4.Price = 300.00m;
            p4.UnitsInStock = 3;
            p4.Category = "Furniture";

            Product p5 = new Product();
            p5.ProductId = 5;
            p5.Name = "Monitor";
            p5.Price = 450.00m;
            p5.UnitsInStock = 0;
            p5.Category = "Electronics";

            Product p6 = new Product();
            p6.ProductId = 6;
            p6.Name = "Webcam";
            p6.Price = 60.00m;
            p6.UnitsInStock = 8;
            p6.Category = "Electronics";

            Product p7 = new Product();
            p7.ProductId = 7;
            p7.Name = "Bookshelf";
            p7.Price = 150.00m;
            p7.UnitsInStock = 1;
            p7.Category = "Furniture";

            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);
            products.Add(p6);
            products.Add(p7);

            return products;
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string Category { get; set; }

        public Product() { }

        public override string ToString()
        {
            return $"\n--- Product Details ---\n" +
               $"ID: {ProductId}\n" +
               $"Name: {Name}\n" +
               $"Price: {Price:C}\n" +
               $"Units in Stock: {UnitsInStock}\n" +
               $"Category: {Category}\n" +
               $"-----------------------";
        }
    }
}
