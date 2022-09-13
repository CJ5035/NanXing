using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class BatchNoPro
    {
        public int Id { get; set; }
        public string Prosn { get; set; }
        public DateTime? Prodate { get; set; }
        public string Proname { get; set; }
        public string Itemno { get; set; }
        public string Class { get; set; }
        public string Unit { get; set; }
        public string Spec { get; set; }
        public string BatchNo { get; set; }
        public string BoxNo { get; set; }
        public string BoxName { get; set; }
        public string Ingredients { get; set; }
        public string Remark1 { get; set; }
        public string Protype { get; set; }
        public string Color { get; set; }
        public string Probiaozhun { get; set; }
        public string YuanliaobatchNo { get; set; }
        public string Position { get; set; }
        public decimal? Proweight { get; set; }
        public string UserId { get; set; }
    }
}
