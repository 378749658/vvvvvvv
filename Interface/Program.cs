using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Person
    {
        public void CHLSS()
        {
            Console.WriteLine("我是人类，可以吃喝拉撒睡");
        }
    }

    public class NBAPlayer  
    {
        public void KouLan()
        {
            Console.WriteLine("我可以扣篮");
        }
    }

    public class Student : Person,IKouLanable //多继承，就需要接口（继承：单根性）
    {
        //public void koulan()
        //{
        //    Console.WriteLine("我也可以扣篮");
        //}
        public void KouLan()
        {
            Console.WriteLine("我也可以扣篮");
        }
    }

    public interface IKouLanable
    {
         void KouLan();
    }
}
