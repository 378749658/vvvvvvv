﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            SUperMarket sm = new SUperMarket();
            sm.ShowPros();
            sm.AskBuying();
            Console.ReadKey();
          
        }
    }
}
