using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class ProductFather
    {

        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        //private double _count;
        //public double Count
        //{
        //    get { return _count; }
        //    set { _count = value; }
        //}

        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ProductFather(string id, double price, string name)
        {
            this.Id = id;
            // this.Count = count;
            this.Price = price;
            this.Name = name;
        }
    }
}
