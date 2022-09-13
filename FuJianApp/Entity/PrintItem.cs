using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingCangKu.Entity
{
    public class PrintItem
    {
        public string Department { get; set; }
        public string ProName { get; set; }
        public string QRCode { get; set; }
        public string ProDate { get; set; }
        public string Num { get; set; }
        public string BatchNo { get; set; }
        public string YuanLiaoBatchNo { get; set; }
        public string color { get; set; }
        public string biaoZhun { get; set; }
        public string boxName { get; set; }
        public string remark { get; set; }
        public string spec { get; set; }

        public PrintItem(string Department,
            string proName, string qRCode, string proDate, string num, string batchNo, string yuanLiaoBatchNo, string color, string biaoZhun, string boxName, string remark, string spec)
        {
            this.Department = Department;
            ProName = proName;
            QRCode = qRCode;
            ProDate = proDate;
            Num = num;
            BatchNo = batchNo;
            YuanLiaoBatchNo = yuanLiaoBatchNo;
            this.color = color;
            this.biaoZhun = biaoZhun;
            this.boxName = boxName;
            this.remark = remark;
            this.spec = spec;
        }
    }
}
