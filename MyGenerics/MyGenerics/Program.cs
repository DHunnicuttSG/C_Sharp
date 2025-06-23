using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenerics
{
    public class Program
    {
        static void Main(string[] args)
        {
            //WordList();
            List<int> nums = new List<int>();
            AddToList(nums);
            AddToListWithRange(nums);
            //InsertAtIndex(nums);
            //RemoveFromList(nums);

            //Dictionary<string, Product> products = new Dictionary<string, Product>();
            //AddDataToDictionary(products);

            //// get data from Dictionary
            //Product value = products["0001"];
            //Console.WriteLine($"{value.Name} : {value.Price:C}");

            //CountLetters();

            //GetListOfNumbers();
        }

        public static void RemoveFromList(List<int> nums)
        {
            // Remove an item by value
            nums.Remove(20);

            // Remove an item by index
            nums.RemoveAt(nums.Count - 1);

            // Remove all elements that are equal to 2
            nums.RemoveAll(x => x == 2);

            PrintLists(nums);
        }

        public static void InsertAtIndex(List<int> nums)
        {
            // insert 20 at index 2
            nums.Insert(2, 20);

            PrintLists(nums);
        }

        public static void AddToListWithRange(List<int> nums)
        {
            // Add array elements to list
            int[] toAdd = { 2, 7, 8, 9 };
            nums.AddRange(toAdd);

            PrintLists(nums);
        }

        public static void AddToList(List<int> nums)
        {
            nums.Add(1);
            nums.Add(2);
            nums.Add(3);
            nums.Add(2);
            nums.Add(5);

            PrintLists(nums);
        }

        public static void WordList()
        {
            List<string> words = new List<string>()
            {
                "apple", "pear", "banana", "pineapple", "peach", "plum"
            };

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }

        public static void PrintLists(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            // print out a different way (without a loop!)
            Console.WriteLine("");
            Console.Write(string.Join(", ", list));
            Console.WriteLine("\n");
        }

        public static void AddDataToDictionary(Dictionary<string, Product> products)
        {
            products.Add("0001",
                new Product() { UPCCode = "0001", Name = "Bananas", Price = 1.99M });

            products.Add("1313",
                new Product() { UPCCode = "1313", Name = "Apples", Price = 3.49M });

            products.Add("4249",
                new Product() { UPCCode = "4249", Name = "Lettuce", Price = 0.78M });
        }

        public static void CountLetters()
        {
            string sentence = "This is a test. This is only a test.";
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();
            foreach (char letter in sentence)
            {
                if (letterCounts.ContainsKey(letter))
                {
                    letterCounts[letter]++;
                }
                else
                {
                    letterCounts.Add(letter, 1);
                }
            }

            foreach (KeyValuePair<char, int> entry in letterCounts)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        public static void GetListOfNumbers()
        {
            string input;
            int output;

            List<int> numbers = new List<int>();

            do
            {
                Console.Write("Enter a number (Q to quit): ");
                input = Console.ReadLine();

                if(int.TryParse(input, out output))
                {
                    numbers.Add(output);
                }
            } while (input != "Q");
            
            Console.WriteLine("The numbers entered were: {0}", string.Join(",", numbers));
        }
    }

    public class Product
    {
        public string UPCCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
