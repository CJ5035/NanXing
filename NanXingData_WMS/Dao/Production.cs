namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production")]
    public partial class Production
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string prosn { get; set; }

        public DateTime prodate { get; set; }

        [Required]
        [StringLength(50)]
        public string proname { get; set; }

        [Required]
        [StringLength(50)]
        public string itemno { get; set; }

        public int? ProductOrderlistsID { get; set; }

        [Column("class")]
        [StringLength(50)]
        public string _class { get; set; }

        [StringLength(50)]
        public string unit { get; set; }

        [StringLength(50)]
        public string spec { get; set; }

        [StringLength(100)]
        public string batchNo { get; set; }

        [StringLength(50)]
        public string boxNo { get; set; }

        [StringLength(50)]
        public string boxName { get; set; }

        [StringLength(50)]
        public string ingredients { get; set; }
        [StringLength(400)]
        public string remark { get; set; }

        [StringLength(50)]
        public string protype { get; set; }

        [StringLength(50)]
        public string color { get; set; }

        [StringLength(50)]
        public string probiaozhun { get; set; }

        [StringLength(100)]
        public string yuanliaobatchNo { get; set; }

        [StringLength(20)]
        public string position { get; set; }

        [StringLength(100)]
        public string danjuhao { get; set; }

        //public virtual ProductOrderlists ProductOrderlists { get; set; }

    }
}
