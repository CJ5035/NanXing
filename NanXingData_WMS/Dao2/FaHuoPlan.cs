namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaHuoPlan")]
    public partial class FaHuoPlan
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string danjutype { get; set; }

        [StringLength(100)]
        public string danjuno { get; set; }

        [StringLength(100)]
        public string itemno { get; set; }

        [StringLength(100)]
        public string itemname { get; set; }

        [StringLength(100)]
        public string spec { get; set; }

        [StringLength(100)]
        public string saleunit { get; set; }

        public decimal? salequt { get; set; }

        public decimal? outqut { get; set; }

        public decimal? boxnum { get; set; }

        public DateTime? fhdate { get; set; }
    }
}
