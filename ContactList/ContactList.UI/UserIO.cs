﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.UI
{
    public class UserIO
    {
        public string ReadString(string prompt) 
        {
            string userInput = "";

            while(userInput == "")
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine().Trim();

                if(userInput == "")
                {
                    Console.WriteLine("That was not a valid input. Please try again.");
                }
            }
            return userInput;
        }

        public int ReadInt(string prompt)
        {
            int output;

            while (true) 
            { 
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine().Trim();
                if (int.TryParse(userInput, out output))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That was not valid input. Please try again");
                }
            }
            return output;
        }

        public int ReadInt(string prompt, int min, int max)
        {
            int output;

            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine().Trim();
                if (int.TryParse(userInput, out output))
                {
                    if (output >= min && output <= max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"That number was not between {min} and {max}. Please try again.");
                    }
                }
            }
            return output;
        }
    }
}
