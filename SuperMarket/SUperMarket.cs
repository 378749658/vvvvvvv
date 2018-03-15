using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class SUperMarket
    {
        Storage storage = new Storage();
        public SUperMarket()
        {
            storage.JinPros("Acer", 1000);
            storage.JinPros("SamSung", 1000);
            storage.JinPros("JiangYou", 1000);
            storage.JinPros("Banana", 1000);
        }
        //创建超市对象时，给仓库货架上导入货物

        public void AskBuying()
        {
            Console.WriteLine("欢迎光临，请问您需要什么");
            Console.WriteLine("我们有Acer,SamSung,JiangYou,Bananan");
            string strType = Console.ReadLine();
            Console.WriteLine("您需要多少");
            int count = Convert.ToInt32(Console.ReadLine());
            //取货
            ProductFather[] pros = storage.QuPro(strType, count);
            //结账
            double realMoney = GetMoney(pros);
            Console.WriteLine("您总共应支付{0}", realMoney);
            Console.WriteLine("请选择打折方式 1--不打折  2--打九折  3--打85折  4--买300送50  5--买500送10");
            string intput = Console.ReadLine();
            //通过简单工厂设计模式根据用户输入获得打折对象
            CalFather cal = GetCal(intput);
            double totalMoney= cal.GetTotalMoney(realMoney);
            Console.WriteLine("打完折后，您应付{0}元",totalMoney);
            Console.WriteLine("以下是您的购物信息");
            foreach (var item in pros)
            {
                Console.WriteLine("货物名称 ："+item.Name+","+"\t"+"货物单价："+item.Price+","+"\t"+"货物编号："+item.Id);

            }
        }

        public double GetMoney(ProductFather[] pros)
        {
            double realMoney = 0;
            for (int i = 0; i < pros.Length; i++)
            {
                realMoney += pros[i].Price;
            }
            return realMoney;
        }

        public CalFather GetCal(string input)//简单工厂核心，利用抽象类实现多态
        {
            CalFather cal = null;
            switch (input)
            {
                case "1": cal = new CalNormal();
                    break;
                case "2": cal = new CalRate(0.9);
                    break;
                case "3": cal = new CalRate(0.85);
                    break;
                case "4": cal = new CalMN(300, 50);
                    break;
                case "5": cal = new CalMN(500, 100);
                    break;
                default:
                    break;
            }
            return cal;
        }

        public void ShowPros()
        {
            storage.ShowPros();
        }
    }
}
