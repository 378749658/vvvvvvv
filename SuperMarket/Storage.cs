using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Storage
    {
        //存储货物
         List<List<ProductFather>> List = new List<List<ProductFather>>();

         /// <summary>
         /// 向用户展示货物
         /// </summary>
         public void ShowPros()
         {
             foreach (var item in List)
             {
                 Console.WriteLine("超市有：" + item[0].Name + "," + "\t" + "有" + item.Count + "个，" + "\t" + "每个" + item[0].Price + "元");
             }
         }

        /* list[0]  Acer
         * list[1]  SamSung
         * list[2]  Jiangyou (soy)
         * list[3]  banana
         */

        /// <summary>
        /// 在创建仓库对象时，向仓库中添加货架
        /// </summary>
        public Storage()
        {
            List.Add(new List<ProductFather>());
            List.Add(new List<ProductFather>());
            List.Add(new List<ProductFather>());
            List.Add(new List<ProductFather>());
        }
      /// <summary>
      /// 进货
      /// </summary>
      /// <param name="strType">货物类型</param>
      /// <param name="count">货物数量</param>
        public  void JinPros(string strType,int count)
        {
            for (int i = 0; i < count; i++)
            {
                switch (strType)
                {
                    case "Acer": List[0].Add(new Acer(Guid.NewGuid().ToString(),1000,"宏基笔记本"));
                        break;
                    case "SamSung": List[1].Add(new SamSung(Guid.NewGuid().ToString(), 2000, "棒子手机"));
                        break;
                    case "JiangYou": List[2].Add(new JiangYou(Guid.NewGuid().ToString(), 10, "老抽"));
                        break;
                    case"Banana":List[3].Add(new Banana(Guid.NewGuid().ToString(),50,"大香蕉"));
                        break;
                    default:
                        break;
                }
            }
 
        }

        /// <summary>
        /// 从仓库中提取货物
        /// </summary>
        /// <param name="strType">货物类型</param>
        /// <param name="count">货物数量</param>
        /// <returns></returns>
        public  ProductFather[] QuPro(string strType, int count)//也可以返回一个集合
        {
            ProductFather[] pros = new ProductFather[count];
            for (int i = 0; i < count; i++)
            {
                switch (strType)//取货时可能货架时空的，会报错，应该先判断是否是0
                {
                    case "Acer":
                        if (List[0].Count==0)
                        {
                            
                        }
                        pros[i] = List[0][0];
                        List[0].RemoveAt(0);
                        break;
                    case"SamSung":pros[i]=List[1][0];
                        List[1].RemoveAt(0);
                        break;
                    case "JiangYou": pros[i] = List[2][0];
                        List[2].RemoveAt(0);
                        break;
                    case "banana": pros[i] = List[3][0];
                        List[3].RemoveAt(0);
                        break;
                    default:
                        break;
                }
            }
            return pros;
        }

       
    }
}
