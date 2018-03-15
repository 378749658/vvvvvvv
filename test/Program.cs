using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Program
    {
        //字段 、属性、方法、构造函数、析构函数

        #region 析构函数
        /* 析构函数
         * 程序结束时执行 
         * 作用：帮助我们释放资源
         * GC
         */
        ~Program()
        {
            Console.WriteLine("我是析构函数");
        }
        #endregion

        #region 字段 + 属性
        private string _name;  //字段，格式前面加‘_’

        public string Name     //属性
        {
            get { return _name; } //取值
            set { _name = value; } //赋值
        }
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        private char _gender;

        public char Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        #endregion

        #region 字符串
        /*字符串
         * 1.字符串不可变性（指的是字符串在堆中的地址存在栈中，操作字符串时，复制的是栈中的地址）
         *   给一个字符串重新赋值时，在堆中开辟新空间存入新值，老值还在。（在进行大量字符串操作时，引入Stringbuilder）
         * 2.可以将字符串看做 char 类型的一个 只读 数组。(方法：ToCharArray(),将字符串转换为char数组)
         *   string str = "abcdefg";
         *   consolo.writeline(str[0]); 输出 a ；（只读，不能赋值。错误示范：str[0]='b'）
         * 
         * 字符串方法
         * 1> int .Length: 获得当前字符串中字符个数
         * 2> string .ToUpper(): 将字符串转换大写
         * 3> string .ToLower()： 将字符串转换为小写
         * 4> bool  .Equals(str,stringCoparison.OrdinalIgnorCase): 比较两个字符串，可以忽略大小写
         * 5> string[] .Split(): 分割字符串，返回字符串数组 
         * 6> string .Replace(string oldValue,string newValue):将字符串中的出现oldvalue的地方替换为newvalue。例子：名字替换
         * 7> string .Substring(int startIndex),从位置startIndex开始一直到最后的字符串,用于截取
         *    string .Substring(int startIndex,int length),取从位置startIndex开始长度为length的子字符串，若长度不足length，报错
         * 8> bool Contains(string value):判断字符串中是否含有子字符串value
         * 9> bool StartWith(string value)：判断字符串是否以子字符串value开始
         * 10> bool EndWith(string value):判断字符串是否以子字符串value结束
         * 11> int IndexOf(string value):取子字符串value 第一次出现的位置
         * 12> int IndexOf(string value,int startIndex):
         * 13> int LastIndexof(string value):最后一次出现的位置
         * 14> string Trim():去掉前后的空格 TrimEnd() TrimStart()
         * 15> bool IsNullOrEmpty():判断一个字符串是否为空或者为null
         * 16> string .Join():将数组按照指定的字符串连接，返回一个字符串 
         * 
         */

        public void JoinTest()
        {
            string[] names = { "张三", "李四", "王五" };
            //张三|李四|王五
            string strNew = string.Join("|", names);
            Console.WriteLine(strNew);
            Console.ReadKey();
        }

        public void SplitTest()
        {
            string s = "a b  df _ +   = ,,, fdr ";
            char[] chs = { ' ', '_', ',' };
            string[] str = s.Split(chs, StringSplitOptions.RemoveEmptyEntries);

        }

        //stringbuilder与string 对比(计时器 Stopwatch)
        public void StringbuilderTest()
        {
            StringBuilder sb = new StringBuilder();
            //string str = null; 
            //创建一个计时器，记录程序运行时间
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                //str += i;
                sb.Append(i);
            }
            sw.Stop();//结束计时
            Console.WriteLine(sb.ToString()); //转换为string输出
            Console.WriteLine(sw.Elapsed);
            Console.ReadKey();
        }

        #endregion //字符串

        #region 结构体 + 枚举 +结构和类的区别
        /*结构和类的区别
         * 结构：值类型
         * 类：引用类型 
         * 
         * 声明语法：class  struct
         * 
         * 结构中也可以有字段、属性、构造函数、方法
         * 
         * 在类中，构造函数里，既可以给字段赋值，也可以给属性赋值，构造函数可以重载
         * 但是在结构的构造函数中，必须只能给 字段 赋值
         * 结构构造函数中，需要给 全部 的字段赋值
         * 
         * 调用：
         * 结构也可以new出来，但是结构的new只干了一件事，在栈中开辟空间，调用结构的构造函数
         * 
         * 结构和类的构造函数
         * 相同点：都有一个默认的无参构造函数
         * 不同点：在类中写新的构造函数后，无参会被覆盖；结构中无参的依然在
         * 
         * 
         * 如果我们只是单纯的存储数据（不接触面向对象），如果需要面向对象的思想开发程序，使用类
         */
        public struct Mine
        {
            public Name1 _name;
            public int _age;
            public int _height;
            public Gender1 g_ender;
        }
        public enum Gender1
        {
            男,
            女
        }
        public enum Name1
        {
            张三,
            王五,
            李四,
            谢广坤
        }
        #endregion

        #region 值类型和引用类型 + 值传递和引用传递
        /*值类型和引用类型
         * 区别：
         * 1.内存空间不同，值类型在栈，引用类型在堆
         * 2.传递时，传递方式不同（分为值传递、引用传递）
         * 
         * 我们学的值类型和引用类型
         * 值类型：int double bool char decimal struct enum
         * 引用类型： string 自定义类 数组 集合 接口 object
         * 
         * 值类型在复制的时候，传递的是这个值得本身。
         * 引用类型在复制的时候，传递的是对这个对象的引用。
         */

        public void TranslateTest()
        {
            int n1 = 10;
            int n2 = n1;
            n2 = 20;
            Console.WriteLine(n1);//输出10
            Console.WriteLine(n2);//输出20
            Console.ReadKey();

            SuperClass s1 = new SuperClass();
            s1.Name = "张三";
            SuperClass s2 = s1;
            s2.Name = "李四";
            Console.WriteLine(s2.Name); //输出都是李四
            Console.ReadKey();

            string str1 = "张三";
            string str2 = str1;
            str2 = "李四";
            Console.WriteLine(str1);//输出为张三
            Console.WriteLine(str2);//输出为李四
            //string类型虽然是引用类型，但是具有不可变性，老值不变，新值存在新开辟的空间中。
        }
        #endregion

        #region 序列化和反序列化
        /* 序列化：将对象转换为二进制。
         * [Serializable]
         * 反序列化：将二进制对象转换为对象
         * 作用：传输数据
         * BinaryFormatter
         */
        public void SerializableTest()
        {

        }
        #endregion

        #region 集合 ArrayList + HashTable + foreach循环
        public void Collections()
        {
            //我们将一个对象输出到控制台，默认情况下，打印的就是这个对象所在类的命名空间

            #region ArrayList集合
            //ArrayList集合  命名空间（Alt+Shift+F10）：using System.Collections 
            //创建一个集合对象
            ArrayList list = new ArrayList();
            //集合：很多数据的一个集合，长度可变，类型随意
            //数组：长度不可变，类型单一
            /* ArrayList提供的方法：
             * list.Clear();   清空所有元素
             * list.Addrange();  添加集合
             * list.Add();     添加单个元素
             * list.Remove();  删除单个元素
             * list.RemoveAt(); 根据下标删除元素
             * list.RemoveRange(0,3); 根据下标移除一定范围（删除三个）元素
             * list.Sort();    升序排序
             * list.Reverse();  反转
             * list.Insert();  将单个元素插入指定索引处（前面）
             * list.InsertRange(); 将集合插入指定所引处（前面）
             * list.Contains();  Contains方法，判断是否包含某个指定元素，返回bool类型
             *      if(!list,Contains())  如果不包含，则（可以加入）
             */
            list.Add(1);
            list.Add(3.14);
            list.Add(true);
            list.Add("张三");
            list.Add('男');
            list.Add(new int[] { 1, 2, 3, 4, 9, 7, 8, 4, 5 });
            list.AddRange(new int[] { 9, 7, 8, 7, 6, 5, 1 });//添加集合，输出时不用强转
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is int[])
                {
                    for (int j = 0; j < ((int[])list[i]).Length; j++)
                    {
                        Console.WriteLine(((int[])list[i])[j]);
                    }
                } // 因为arraylist是object类型，强转后才能输出，如上，强转为int[]后，输出
                else
                {
                    Console.WriteLine(list[i]);
                }

            }
            Console.ReadKey();
            #endregion

            #region ArrayList集合集合长度问题 + 练习
            /* 集合长度问题
             * 理解两个意思
             * 1.count 表示这个集合中实际包含的元素的个数
             * 2.capcity 表示这个集合中可以包含的元素的个数（每次超过可包含元素个数，再开辟一倍空间）
             */
            //练习一
            ArrayList list1 = new ArrayList();
            list1.AddRange(new int[] { 1, 2, 3, 4, 5 });
            int sum = 0;
            int max = (int)list1[0];
            for (int i = 0; i < list1.Count; i++)
            {
                if ((int)list1[i] > max)
                {
                    max
                        = (int)list1[i];
                }
                sum += (int)list1[i]; //添加集合会换成object类型，需要强转才能相加
            }

            //练习二
            ArrayList list2 = new ArrayList();
            Random r = new Random();
            for (int j = 0; j < 10; j++)//输出十个随机数
            {
                int rNumber = r.Next(0, 10);
                //集合中没有这个随机数
                if (!list2.Contains(rNumber))
                {
                    list2.Add(rNumber);
                }
                else//集合中有这个随机数
                {
                    //一旦产生重复随机数，这次循环不算数
                    j--;
                }
            }
            for (int i = 0; i < list2.Count; i++)
            {
                Console.WriteLine(list2[i]);
            }
            Console.ReadKey();
            #endregion

            #region Hashtable集合（键值对集合）
            /* Hashtable集合
             * 键值对对象[键]=值；
             * 键值对集合中，键是唯一的，值可以重复；
             * Hashtable 提供的方法：
             * 1.if(!ht.ContainsKey())  如果不包含键值，则（可以添加）或者覆盖
             * 2.ht.Clear(); 移除所有元素
             * 3.ht.Remove(); 移除索引元素
             */
            //创建一个键值对集合
            Hashtable ht = new Hashtable();
            ht.Add(1, "张三");
            ht.Add(2, true);
            ht.Add(3, '男');
            ht.Add(false, "错误的");
            ht[5] = "新来的";          //这也是一种添加数据的方式
            ht[1] = "我可以把张三替换掉"; //如果有ht[1],就替换
            //for (int i = 0; i < ht.Count; i++)
            //{
            //    Console.WriteLine(ht[i]);
            //}
            //for循环不能用来遍历集合，用foreach

            //var:根据值能够推断出类型。（限制：声明变量时必须赋值->有些变量需要用户去赋值）
            //c#是一门强类型语言：在代码中，必须对每一个变量的类型有明确的定义
            //JS是一门弱类型语言：var可以是1，可以是true，自动判断类型
            foreach (var item in ht.Keys) //ht.Values
            {
                Console.WriteLine("键是{0}        值是{1}", item, ht[item]);
            }
            //在键值对集合中，根据键找值
            Console.WriteLine(ht[1]);
            Console.WriteLine(ht[2]);
            Console.WriteLine(ht[3]);
            Console.WriteLine(ht[false]);
            Console.ReadKey();
            #endregion //Hashtable

            #region foreach循环
            /*当数据量特别大，for的效率比foreach高 
             */
            int[] nums = { 1, 2, 3, 4, 5, 8, 9, 7 };
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
        #endregion

        #region List泛型集合 + 装箱和拆箱 + 字典集合（Dictionary）->键值对集合
        /* 装箱：就是将值类型转换为引用类型。
         * 拆箱：引用类型转换为值类型。
         * 看两种类型是否发生拆装箱，要看，这两种类型是否存在继承关系。
         *     如果有继承关系，有可能发生了拆装箱；如果没有继承关系，一定没发生拆装箱。
         * 代码中尽量避免拆装箱，会耗费系统时间
         */
        public void ListTest()
        {
            //创建泛型集合对象
            List<int> listInt = new List<int>();
            listInt.Add(1);
            listInt.Add(2);
            listInt.Add(3);
            listInt.AddRange(new int[] { 9, 8, 7, 4, 5, 6, 1 });
            listInt.AddRange(listInt);

            //List泛型集合可以转换为数组
            int[] nums = listInt.ToArray();


            for (int i = 0; i < listInt.Count; i++)
            {
                Console.WriteLine(listInt[i]);
            }
            Console.ReadKey();
        }

        public void DictionaryTest()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "张三");
            dic.Add(1, "李四");
            dic.Add(1, "王五");
            dic[1] = "新来的";
            //foreach更洋气的写法
            foreach (KeyValuePair<int, string> kv in dic)//kv既代表键，又代表值
            {
                Console.WriteLine("{0}      {1}", kv.Key, kv.Value);
            }

            foreach (var item in dic.Keys)
            {
                Console.WriteLine("{0}     {1}", item, dic[item]);
            }
            Console.ReadKey();
        }
        #endregion

        #region 静态非静态区别 关键字static
        /*
         静态与非静态区别：
        1.非静态类中，既可以有实例成员，也可以有静态成员。
        2.调用实例成员时，需要使用对象名.实例成员名，如p.MP().
           调用静态成员时，使用类名.静态成员名,如：Program.MP().
        总结：静态成员使用类名调用，实例成员使用对象名调用。
             静态函数中，只能访问静态成员，不允许访问实例成员。
             实例函数中，既可以使用静态成员，也可以使用实例成员。
             静态类中只允许有静态成员，不允许出现实例成员。 
         */
        #endregion

        #region 访问修饰符
        /*五种访问修饰符
         * public：公开的公共的
         * private：私有的，只能在当前类的内部访问
         * protect：受保护的，可以在当前类的内部以及该类的子类中访问
         * internal:修饰类，只能在当前项目中访问。在同一个项目中，internal和public权限一样。
         * protected internal:protect + internal
         * 
         * 可访问性不一致：
         * 子类的权限不能高于父类访问权限，子类会暴露父类成员
         * 
         * 
         * 修饰类的修饰符只有两个：
         * public： 
         * internal：当前程序集（暂时理解为项目）可以访问（如果类不加访问修饰符，默认为internal）
         */

        #endregion

        #region File类（操作文件）  using System.IO
        /* File只能读小文件（一次性读），读大文件需要用文件流（FileStream）
         * 基本操作：判存、复制、移动、删除
         * 基本方法：
         * File.Exist();
         * File.Copy();
         * File.Move();
         * File.Delete();
         * 
         */

        public void FileTest()
        {
            //创建文件 new.txt
            File.Create(@"C:\Users\qiang.wang\Desktop\new.txt");
            //删除一个文件:删除后不在回收站里
            File.Delete(@"C:\Users\qiang.wang\Desktop\new.txt");
            //复制一个文件
            File.Copy(@"C:\Users\qiang.wang\Desktop\new.txt", @"C:\Users\qiang.wang\Desktop\newtwo.txt");

            string str = "今天天气好晴朗处处好风光";
            //需要将字符串转换为字节数组
            byte[] buffer = Encoding.Default.GetBytes(str);
            //File方法写入文件WriteAllBytes()
            File.WriteAllBytes(@"C:\Users\qiang.wang\Desktop\new.txt", buffer);

            //返回字符串数组，以行的方式读取文件
            string[] contents = File.ReadAllLines(@"C:\Users\qiang.wang\Desktop\new.txt", Encoding.Default);
            foreach (string item in contents)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

            //返回一个字符串，直接读取整个文件
            string stri = File.ReadAllText(@"C:\Users\qiang.wang\Desktop\new.txt", Encoding.Default);
            Console.WriteLine(stri);
            Console.ReadKey();

        }
        #endregion

        #region  FileStream文件流 + StreamReader和StreamWriter
        /* 文件流
         * 减少内存压力
         * FileStream  操作字节（可以操作任何文件）
         * StreamReader和StreamWriter 操作字符（操作文本文件）
         * File类 只适合操作小文件
         * 
         * 将创建文件流对象的过程写在using中，会自动帮助我们释放流所占用的资源
         * 
         * 
         */

        public void FileStreamTest()
        {
            //使用FileStream读取数据
            //创建FileStream对象
            FileStream fsRead = new FileStream(@"C:\Users\qiang.wang\Desktop\new.txt", FileMode.OpenOrCreate, FileAccess.Read);
            byte[] buffer = new byte[1024 * 1024 * 5];
            //如果只有3.8M，每次读5M
            //返回本次实际读取到的有效字节数(实际文件大小)
            int r = fsRead.Read(buffer, 0, buffer.Length);//每次读5M
            //将字节数组中每一个元素按照指定的编码格式解码成字符串
            string s = Encoding.Default.GetString(buffer, 0, r);
            //关闭流
            fsRead.Close();
            //释放流所占用的资源
            fsRead.Dispose();
            Console.WriteLine(s);
            Console.ReadKey();

            //使用FileStream写入数据（using）
            using (FileStream fsWrite = new FileStream(@"C:\Users\qiang.wang\Desktop\new.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                string str = "看我有没有覆盖";
                byte[] buffre = Encoding.Default.GetBytes(str);//如果有乱码，Default改为别的UTF8、GBK2312
                fsWrite.Write(buffer, 0, buffer.Length);
            }
            Console.WriteLine("ok");
            Console.ReadKey();

            //实现多媒体文件复制
            //思路：先将复制的多媒体文件读取出来，然后写入指定位置
            string source = @"C:\Users\qiang.wang\Desktop\1.rar";
            string target = @"C:\Users\qiang.wang\Desktop\11.rar";
            //1.创建负责读取的流
            using (FileStream fsread = new FileStream(source, FileMode.OpenOrCreate, FileAccess.Read))
            {
                //2.创建一个负责写入的流
                using (FileStream fswrite = new FileStream(target, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffre = new byte[1024 * 1024 * 5];
                    while (true)
                    {
                        //返回本次实际读取到的字数
                        int R = fsRead.Read(buffre, 0, buffre.Length);//每次读5M
                        //如果返回一个0，就意味着什么都没有读取到，读取完了
                        if (R == 0)
                        {
                            break;
                        }
                        fswrite.Write(buffre, 0, R);
                    }
                }

            }
            Console.WriteLine("复制成功");
            Console.ReadKey();

        }

        public void StreamWriterAndStreamReader()
        {
            //操作文本
            //使用StreamReader读取一个文本文件
            using (StreamReader sr = new StreamReader(@"C:\Users\qiang.wang\Desktop\a.txt", Encoding.Default))
            {
                while (!sr.EndOfStream) //如果读取到了
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
            Console.ReadKey();
            //使用StreamReader写入一个文本文件
            using (StreamWriter sw = new StreamWriter(@"C:\Users\qiang.wang\Desktop\ab.txt", true))
            {
                sw.Write("今天天气好晴朗");
            }
            Console.WriteLine("写入ok");
            Console.ReadKey();
        }
        #endregion

        #region Directory类 文件夹 目录
        /* 
         * 
         * 
         */
        public void DirectoryTest()
        {

        }
        #endregion

        #region Path类 （操作路径）System.IO + 绝对路径和相对路径
        /* 绝对路径：通过给定路径可以直接能找到文件。
         * 相对路径：文件相对于应用程序的路径
         */
        public void PathTest()
        {
            string str = @"C:\Users\qiang.wang\Desktop\a.txt";
            //Path类方法

            //获得文件名
            Console.WriteLine(Path.GetFileName(str));
            //获得文件名不包括扩展名
            Console.WriteLine(Path.GetFileNameWithoutExtension(str));
            //获得扩展名
            Console.WriteLine(Path.GetExtension(str));
            //获得文件所在的文件夹名称
            Console.WriteLine(Path.GetDirectoryName(str));
            //获得全路径
            Console.WriteLine(Path.GetFullPath(str));
            //将两个路径连接到一起
            Console.WriteLine(Path.Combine(@"c\a\", "b.txt"));
            //更改扩展名
            Console.WriteLine(Path.ChangeExtension(str, ".wav"));

            //int index = str.LastIndexOf("\\");
            //str = str.Substring(index + 1); //截取索引index+1后的
            //Console.WriteLine(str);
            Console.ReadKey();

        }

        #endregion

        #region 部分类 + 密封类 + 重写tostring（）方法
        /* 部分类
         * 关键字 partial
         * 
         * 密封类
         * 关键字 sealed
         * 特征：不能被继承，但是可以继承其他类
         * 
         * 重写tostring()方法（ToString()是Object类的方法）
         * 默认tostring()打印命名空间
         */

        #endregion

        #region 继承
        /*继承
         * 我们可能会在一些类中写一些重复的成员，可以将重复的成员单独的封装到一个类中，作为这些类的父类。
         * 子类  派生类
         * 父类  基类
         * 子类继承父类
         * 继承了：父类的属性、方法。
         * 没有继承：父类的私有字段、构造函数。
         * 子类虽然没有继承父类的构造函数，但是子类默认调用父类的无参的构造函数。->用来创建父类对象 ->让子类可以使用父类成员
         * 父类重新写一个有参构造函数后，无参被覆盖，子类调用会出错。
         * 解决办法
         * 1.父类重新写一个无参数的构造函数（不推荐）
         * 2.子类中显示的调用父类的构造函数，使用关键字：base()。
         * (新建类要在项目中添加类，)
         * Object是所有类的基类（父类）。
         * 
         * 关键字new 可以隐藏从父类继承过来的同名成员（后果：子类调用不到父类成员）
         * 
         */

        #endregion

        #region  多态:虚方法、抽象类、接口
        /* 多态三种方法：
         * 1.虚方法(Virtual)
         * 步骤：
         * 将父类方法标记虚方法，关键字virtual，在子类方法中标记override，子类重写父类方法
         * （父类有方法有实现）
         * [public] virtual I...
         * {
         * 
         * }
         * 
         * 2.抽象类(abstract)
         * （父类不知道怎么实现）
         * [public] abstract I...
         * {
         * 
         * }
         * 
         * 3.接口(Interface)
         * 接口就是一个规范、能力。（扣篮，笔记本usb）
         * [public] interface I...able
         * {
         * 
         * }
         * 接口可以有 自动属性，方法，索引器，事件 （本质都是方法），没有构造函数和“字段”（自动属性自动生成了字段）
         * 接口中成员不允许添加访问修饰符，默认public
         * 接口成员不能有定义，即不能有任何实现
         * 可以有自动属性（区别与普通属性，本质相同）
         *     自动属性：自动生成字段，方法体
         *     普通属性：需要字段，还有方法体（get return 字段；    set 字段=value）
         * 一个类继承了一个接口，这个类必须实现这个接口中所有的成员
         * 接口不能继承一个类
         * 接口不能被实例化
         * 接口与接口之间可以继承，并且可以多继承
         * 一个类可以同时继承一个类并实现多个接口，如果一个子类同时继承了父类A，并实现了接口IA，那么语法上A必须写在IA前面
         * （class MyClass :A ,IA）因为类继承具有单根性
         * 
         * 什么时候用接口？
         * 面向对象 大部分都是 面向接口编程
         * 
         * 
         * 显示实现接口的目的：解决方法重名的问题(一个类继承接口时方法名可能会相同)
         * 当继承的接口中的方法和参数一模一样的时候，就要用到显示的实现接口（方法名前加接口命名）
         * 
         * 当一个抽象类实现接口的时候，需要子类去实现接口。
         */

        /* 什么时候用虚方法：
         * 可以抽象出来一个父类，父类可以有方法实现，需要创建父类对象
         * 
         * 什么时候用抽象类：
         * 可以抽象出来一个父类，但是不知道怎么去实现
         * 
         * 什么时候用接口：
         * 抽象不出来父类，但是都有一种 能力 或者 规范，用接口
         */
        public void VirtualTest()
        {

        }

        public void AbstractTest()
        {

        }

        public void PortTest()
        {

        }
        #endregion

        #region 简单工厂设计模式
        /* 设计模式：
         * 设计项目的方式。
         * 
         * 
         */
        #endregion

        static void Main(string[] args)
        {
            Random r = new Random();
            int random = r.Next(1, 10);
            Mine wq;
            wq._age = 18;
            wq._name = Name1.王五;
            wq._height = 140;
            wq.g_ender = Gender1.男;

            Program p = new Program();  // 非静态方法需要先实例化
            p = new InheritPractic();   //里氏转换：1.子类可以赋值给父类：如果有一个地方需要父类作为参数，可以给一个子类代替


            #region 关键字new
            /* 关键字new
             * 1.在内存中开辟空间
             * 2.在开辟空间中创建对象
             * 3.调用对象的构造函数进行初始化对象
             * 4.隐藏从父类继承的成员
             */
            #endregion

            //p.MP();   //冒泡排序

            #region 三个高级参数：out ref params
            //int[] n = { 3, 9, 7, 1, 5, 7, 6, 7, 4, 1 };
            //int a = 1;  //ref 参数
            //int max1;
            //int min1;
            //string sum1;
            //p.OutTest(n, out max1, out min1, out sum1, ref a);
            #endregion

            #region 方法的重载
            //p.CZ();  //第一个
            //p.CZ(1, 2);//第二个
            //p.CZ(1, 2, 3);//第三个
            #endregion

            #region string方法示例  (计时器 Stopwatch)
            //p.StringbuilderTest(); //计时器 Stopwatch
            //p.SplitTest();
            //p.JoinTest();
            #endregion

            #region 面向对象——继承
            InheritPractic Inherit = new InheritPractic("王五", 18, '男', 202);
            /* 重点：创建子类对象，先执行子类的构造函数，
             * 然后转到执行父类构造函数，
             * 最后回到子类的构造函数。
             */
            #endregion

        }

        public void MP() //冒泡排序
        {
            int[] n = { 3, 9, 7, 1, 5, 7, 6, 7, 4, 1 };
            for (int i = 0; i < n.Length - 1; i++)
            {
                for (int j = 0; j < n.Length - 1 - i; j++)
                {
                    if (n[j] < n[j + 1])
                    {
                        int temp;
                        temp = n[j];
                        n[j] = n[j + 1];
                        n[j + 1] = temp;
                    }
                }
            }
            for (int w = 0; w < n.Length; w++)
            {
                Console.WriteLine(n[w]);
            }
            Console.ReadKey();
        }

        //ref的本质是将值传递变为引用传递
        //高级参数 out(out参数必须在方法内赋值) ref 参数值传递，方法外赋值，方法内可以不赋值；params 只能有一个，必须在形参的最后一个
        public void OutTest(int[] x, out int max, out int min, out string sum, ref int a)
        {
            max = x[0];
            min = x[0];
            int Sum = 0;
            sum = null;
            for (int i = 0; i < x.Length - 1; i++)
            {
                if (x[i] > max)
                {
                    max = x[i];
                }
                if (x[i] < min)
                {
                    min = x[0];
                }
                Sum += x[i];
            }
            sum = Sum.ToString();
            a += 1;
            Console.WriteLine("数组中最大的数为{0}，最小的数为{1}，总和为{2}，原值为a=1,ref参数传递后值为{3}", max, min, sum, a);
            Console.ReadKey();
        }

        #region 方法的重载
        //方法的重载：方法的名称相同但参数不同
        //1.参数个数相同，类型必须不同  2.类型相同，参数个数必须不同
        public void CZ()
        {
            Console.WriteLine("这个方法没有参数");
        }
        public int CZ(int x, int y)
        {
            return x + y;
        }
        public int CZ(int x, int y, int z)
        {
            return x + y + z;
        }
        #endregion

        #region 构造函数 + this关键字
        /*构造函数 
        作用：帮助初始化对象（给对象的每个属性依次赋值）
        构造函数是一个特殊方法
        1.无返回值，甚至没有void
        2.构造函数名称和类名一样
         * 创建对象的时候会执行构造函数
         * 构造函数访问修饰符必须是public
         */

        /*this关键字
         * 1.当前类的对象
         * 2.在类中显示的调用本类的调用函数
         */
        public Program() //每个类默认的构造函数，与下面的构造函数构成重载 
        {

        }
        public Program(string name, char gender)
            : this(name, 0, gender)
        {

        }
        public Program(string name, int age, char gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        #endregion

        #region 进程 + 线程
        /* 进程 Process
         * 由多个线程组成
         * 
         * 通过进程打开一个指定文件
         * processstartinfo psi = new processstartinfo(@)
         * 通过进程打开应用程序
         * Process.start("calc") 打开计算器
         * 
         */

        /*
         * 线程 Thread 
        * 产生线程的四个步骤
        * 1.编写产生线程所要的执行方法
        * 2.引用System.Threading命名空间
        * 3.实例化Thread类，并传入一个指向线程所要运行方法的委托。（这时线程已经产生了，但是还没有运行）
        * 4.调用Thread实例Start方法，标记该线程可以被CPU执行，但具体时间由CPU决定。
        * 
        * 线程分为前台 后台线程
         * 前台线程：只有所有前台线程关闭，才能完成程序关闭
         * 后台线程：只要所有的前台线程关闭，后台程序自动结束
        * 转为后台线程方法  .IsBackGround（）
         * 
         * start（）启动线程，Thread.Sleep（）静态方法，当前线程停止运行一段时间
         * Thread.CurrentThread 获得当前线程引用
        * 
        * .net下不能跨线程访问
        * 解决办法：
        * （取消跨线程访问）
        * Control.CheckForIlegalCrossThreadCalls = false
        * 
        * 关闭主线程时判断线程是否为null，如果不为null就释放资源
        *   .Abort() (线程终止，不能被重新开始)
        *   
        * 如果线程执行的方法需要参数，那么要求这个参数必须是object类型（在线程提供的start方法的（）括号中加参数）
        *
         * 
        */

        #endregion

        #region Socket编程
        /* Socket:进程通信机制，通常也叫做套接字，用于描述IP地址和端口，是一个通信链的句柄。（类似于一个电话插座）
         * 
         * 
         * 
         */




        #endregion

        #region 单例模式  +  委托
        /*单例模式
         * 1.将构造函数私有化
         * 2.提供一个静态方法，返回一个对象
         * 3.创建一个单例
         * punlic static Form2 FrmSingle = null;
         * 
         * private Form2()
         * {
         *          InitializeComponent();
         * }
         * 
         * public static Form2 GetSingle()
         * {
         *          if(FrmSingle == null)
         *          {
         *            FrmSingle = new Form2();
         *          }
         *            return FrmSingle;
         * }
         */

        /*委托
         * 1.为什么使用委托
         * 将一个方法做为一个参数传递到一个方法中。
         * 
         * 2.委托概念
         * 委托指向的函数必须跟委托有一样的签名（返回值和参数）。
         * public delegate void 方法名（参数）；
         * 
         * 3.匿名函数
         * 当方法就调用一次时，使用匿名函数。
         * 匿名函数的签名和委托一样。
         * DelSayHi del = delegate(string name){
         * 执行一次的方法体。（如果有返回值，要有return）
         * }
         * del(参数)；（调用）
         * 
         * 4.练习：使用委托求数组最大值
         * 
         * 5.练习：使用委托求任意数组的最大值
         * 
         * 6.泛型委托
         * 所有类型换成 T
         * 
         * 7.多播委托
         * 委托可以指向多个函数
         * del += 函数
         * del -= 函数
         * 
         * 8.lamda表达式
         * 区别与匿名委托
         * =>  goes to 
         * DelSayHi del = (string name) => { 方法体。如匿名函数方法体 }；
         * del（参数）；
         * 
         * 9.使用委托实现窗体传值
         * 
         * 
         * 
         * 
         */

        #endregion

    }

    public class SuperClass   //里氏转换
    {
        private string _name;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public void Test()
        {   //里氏转换
            //1.子类可以赋值给父类：如果有一个地方需要父类作为参数，我们可以给一个子类代替
            //2.如果父类中装的是子类对象，那么可以将这个父类强转为子类对象
            Program p = new InheritPractic();
            //InheritPractic IP = (InheritPractic)p;
            #region 关键字is as
            /* is 表示类型转换，如果转换成功，返回一个true，否则false
             * as 表示类型转换，如果能够转换返回对应对象，否则返回一个null
             */
            InheritPractic y = p as InheritPractic;

            if (p is InheritPractic)
            {
                InheritPractic x = (InheritPractic)p;
            }
            else
            {
                Console.WriteLine("转换失败");
            }
            Console.ReadKey();
        }
        #endregion
    }

    public class InheritPractic : Program //Inherit继承
    {
        //关键字base,作用
        public InheritPractic(string name, int age, char gender, int id)
            : base(name, age, gender)
        {
            this.Id = id;
        }
        public InheritPractic()
        {

        }
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public void HelloTest()
        {
            Console.WriteLine("我是继承类的Hello");
        }

        InheritPractic IP = new InheritPractic();

    }

}

