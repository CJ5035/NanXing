using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Fahuotongzhi
    {
        public string Danjutype { get; set; }
        public string Fhdate { get; set; }
        public string Danjuno { get; set; }
        public string Itemno { get; set; }
        public string Itemname { get; set; }
        public string Spec { get; set; }
        public string Saleunit { get; set; }
        public double? Salequt { get; set; }
        public double? Outqut { get; set; }
        public double? Boxnum { get; set; }
        public DateTime? Fhdatenew { get; set; }
    }
}
