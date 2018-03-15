using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Chinese cn1 = new Chinese("王五");
            Chinese cn2 = new Chinese("李四");
            Japanese J1 = new Japanese("井上");
            Japanese J2 = new Japanese("树下");
            Korea k1 = new Korea("金秀贤");
            Korea k2 = new Korea("思密达");
            American a1 = new American("詹姆斯");
            American a2 = new American("科比");
            Person[] pers = { cn1, cn2, k2, k1, J1, J2, a2, a1 };

            for (int i = 0; i < pers.Length; i++)
            {
                //if (pers[i] is Chinese)
                //{
                //    ((Chinese)pers[i]).SayHello();
                //}
                //else if (pers[i] is Japanese)
                //{
                //    ((Japanese)pers[i]).SayHello();
                //}
                //else if (pers[i] is Korea)
                //{
                //    ((Korea)pers[i]).SayHello();
                //}
                //else
                //{
                //    ((American)pers[i]).SayHello();
                //}

                pers[i].SayHello(); //装的什么对象就调用谁的方法
            }
            Console.ReadKey();
        }
    }

    public class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Person(string name)
        {
            this.Name = name;
        }
        public virtual void SayHello()
        {
            Console.WriteLine("我是人类");
        }
    }

    public class Chinese:Person 
    {
        public Chinese(string name)
            : base(name)
        { 
        
        }
        public override void SayHello()
        {
            Console.WriteLine("我是中国人，我叫{0}", this.Name);
        }
    }

    public class Japanese : Person
    { 
    public Japanese(string name)
            : base(name)
        { 
        
        }
        public override void SayHello()
        {
            Console.WriteLine("我是日本人，我叫{0}", this.Name);
        }
    }

    public class Korea : Person
    { 
    public Korea(string name)
            : base(name)
        { 
        
        }
        public override void SayHello()
        {
            Console.WriteLine("我是棒子人，我叫{0}",this.Name);
        }
    }

    public class American : Person
    {
        public American(string name)
            : base(name)
        {

        }
        public override void SayHello()
        {
            Console.WriteLine("我是米国人，我叫{0}", this.Name);
        }
    }
}
