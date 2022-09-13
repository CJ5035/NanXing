using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class TrayWeightRecord
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public DateTime? RecTime { get; set; }
        public decimal? TrayWeight { get; set; }
        public decimal? TrayCount { get; set; }
        public string Prosn { get; set; }
        public string UserId { get; set; }
        public string Result { get; set; }
        public string Itemno { get; set; }
        public string BatchNo { get; set; }
        public string Proname { get; set; }
        public string Spec { get; set; }
        public string Color { get; set; }
        public string Biaozhun { get; set; }
        public string BoxName { get; set; }
    }
}
