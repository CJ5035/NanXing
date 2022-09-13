using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingCangKu.Utils
{
    public class TimeUtils
    {
        
        /// <summary>
        /// 计算时间差
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public double ReckonSeconds( DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = (dt2 - dt1).Duration();
            double second = 0;
            if (ts.Hours > 0)
            {
                second += ts.Hours * 3600;
            }
            if (ts.Minutes > 0)
            {
                second += ts.Minutes * 60;
            }
            second += ts.Seconds;
            second += (ts.Milliseconds * 0.001);
          
            return second;
        }

    }

}
