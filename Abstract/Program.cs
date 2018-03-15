using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{

    class Program
    {
        static void Main(string[] args)
        {
            //抽象类不允许创建对象
            Animal a = new DOG();//new Duck();
            a.Bark();
            Console.ReadKey();

            //使用多态求矩形面积和周长以及圆形的面积和周长
            Shape shape = new Circle(5);
            double area = shape.GetArea();
            double perimeter = shape.GetPerimeter();
            Console.WriteLine("面积{0}          周长{1}", area, perimeter);
            Console.ReadKey();

            //用多态实现将 移动硬盘或者U盘或者MP3插到电脑上进行读写数据
            //第一种写法
            MobileDisk md = new MobileDisk();
            UDisk u = new UDisk();
            MP3 mp3 = new MP3();
            Computer cpu = new Computer();
            cpu.CpuRead(u);
            cpu.CpuWrite(u);
            Console.ReadKey();
            //第二种写法
            MobileStorage ms = new UDisk();//new MboileDisk();//new UDisk();
            Computer cpu1 = new Computer();
            cpu1.CpuRead(ms);
            cpu1.CpuWrite(ms);
            Console.ReadKey();
            //第三种写法：创建父类对象字段
            MobileStorage ms1 = new UDisk();//new MboileDisk();//new UDisk();
            Computer cpu2 = new Computer();
            cpu2.Ms = ms1;
            Console.ReadKey();
        }
    }
    public abstract class Animal
    {
        public abstract void Bark();
        //空实现 ，无方法体
    }
    /* 抽象类和抽象方法必须用abstract标记
     * 抽象方法必须在抽象类中
     * 抽象类不能被实例化
     * 子类继承抽象类，必须把父类的所有抽象成员重写（除非子类也是一个抽象类）
     * 抽象成员访问修饰符不可以是private
     * 抽象类中可以包含实例成员
     * 抽象类中有构造函数，虽然不能被实例化
     * 如果父类的抽象方法中有参数，那么继承这个抽象父类的子类在重写父类方法时必须传入相应参数
     * （如果抽象父类方法有返回值，那么子类在重写这个抽象方法时，也必须传入返回值。）
     * ====
     * 如果父类中的方法有默认的实现，并且父类需要被实例化。可以考虑将父类定义成一个普通类，用虚方法实现多态。
     * 如果父类中的方法没有默认实现，父类也不需要被实例化，则可以将该类定义为抽象类。
     */

    public class DOG : Animal
    {
        public override void Bark()
        {
            Console.WriteLine("狗狗汪汪叫");
        }
    }

    public class Duck : Animal
    {
        public override void Bark()
        {
            Console.WriteLine("鸭子嘎嘎叫");
        }
    }



    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    public class Circle : Shape
    {
        private double _r;

        public double R
        {
            get { return _r; }
            set { _r = value; }
        }
        public Circle(double r)
        {
            this.R = r;
        }
        public override double GetArea()
        {
            return Math.PI * this.R * this.R;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * this.R;
        }
    }

    public class Square : Shape
    {
        private double _height;

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        private double _width;

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public Square(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
        public override double GetArea()
        {
            return this.Height * this.Width;
        }
        public override double GetPerimeter()
        {
            return (this.Height + this.Width) * 2;
        }
    }




    public abstract class MobileStorage
    {
        public abstract void Read();
        public abstract void Write();
    }

    public class MobileDisk : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("移动硬盘读取数据");
        }
        public override void Write()
        {
            Console.WriteLine("移动硬盘写入数据");
        }
    }

    public class UDisk : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("U盘读取数据");
        }
        public override void Write()
        {
            Console.WriteLine("U盘写入数据");
        }
    }

    public class MP3 : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("MP3盘读取数据");
        }
        public override void Write()
        {
            Console.WriteLine("MP3写入数据");
        }
        public void PlayMusic()
        {
            Console.WriteLine("MP3可以自己播放音乐");
        }
    }

    public class Computer
    {
        //拿到父类对象 一、传参
        public void CpuRead(MobileStorage ms)//将抽象父类传参数进来，由里氏转换，子类可以赋值给子类，
        {
            ms.Read();//函数方法实现了多态，表面上看调用父类方法，其实已经被子类方法重写了，调用的是子类方法
        }
        public void CpuWrite(MobileStorage ms)
        {
            ms.Write();
        }

        //拿到父类对象 二、创建父类对象字段和属性
        private MobileStorage _ms;

        public MobileStorage Ms
        {
            get { return _ms; }
            set { _ms = value; }
        }
        public void CpuRead()
        {
            Ms.Read();
        }
        public void CpuWrite()
        {
            Ms.Write();
        }
    }
}
