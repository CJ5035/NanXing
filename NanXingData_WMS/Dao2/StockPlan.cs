namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockPlan")]
    public partial class StockPlan
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string PlanNo { get; set; }

        [StringLength(50)]
        public string proname { get; set; }

        [StringLength(50)]
        public string batchNo { get; set; }

        [StringLength(50)]
        public string probiaozhun { get; set; }

        [StringLength(50)]
        public string spec { get; set; }

        public decimal? count { get; set; }

        public DateTime plantime { get; set; }

        [StringLength(50)]
        public string planUser { get; set; }

        [StringLength(50)]
        public string states { get; set; }

        [StringLength(50)]
        public string color { get; set; }

        [StringLength(10)]
        public string mark { get; set; }

        [StringLength(20)]
        public string position { get; set; }
    }
}
