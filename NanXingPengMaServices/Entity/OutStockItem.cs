using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingWMS_old.Entity
{
    public class OutStockItem
    {
        //批号,型号,标准,日期,箱数,品名
        public string batchNo { get; set; }
        public string spec { get; set; }
        public string probiaozhun { get; set; }
        public DateTime prodate { get; set; }
        public string proName { get; set; }
        public int count { get; set; }
        public string color { get; set; }
        public int usableCount { get; set; }
    }
}
