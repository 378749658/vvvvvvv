using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUID
{
    class Program
    {
        static void Main(string[] args)
        {
            //产生独一无二（不会重复）的编号
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.ReadKey();
        }
    }
}
