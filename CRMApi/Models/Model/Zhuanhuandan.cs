using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Zhuanhuandan
    {
        public int Sn { get; set; }
        public string Danjuhao { get; set; }
        public string Bumen { get; set; }
        public DateTime? Riqi { get; set; }
        public string Workshop { get; set; }
        public string Itemno { get; set; }
        public string Itemname { get; set; }
        public string Spec { get; set; }
        public double? Quantity { get; set; }
        public double? Rkquantity { get; set; }
        public string Lotno { get; set; }
        public DateTime? Makedate { get; set; }
        public double? Boxnun { get; set; }
        public string Paichandan { get; set; }
        public string Fahuodanhao { get; set; }
        public int? Fahuoqut { get; set; }
        public double? Danjianwt { get; set; }
    }
}
