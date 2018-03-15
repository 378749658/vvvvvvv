using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    /// <summary>
    /// 按折扣打折
    /// </summary>
    class CalRate:CalFather
    {
        private double _rate;

        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public CalRate(double rate)
        {
            this.Rate = rate;
        }

        public override double GetTotalMoney(double realMoney)
        {
            return realMoney * this.Rate;
        }
    }
}
