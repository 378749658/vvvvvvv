using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    /// <summary>
    /// 不打折
    /// </summary>
    class CalNormal : CalFather
    {
        public override double GetTotalMoney(double realMoney)
        {
            return realMoney;
        }

    }
}
