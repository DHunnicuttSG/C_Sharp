﻿using ContactList.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactController controller = new ContactController();
            controller.Run();
        }
    }
}
