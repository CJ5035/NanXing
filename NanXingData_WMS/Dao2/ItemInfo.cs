namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemInfo")]
    public partial class ItemInfo
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string ItemNo { get; set; }

        [StringLength(200)]
        public string CRMID { get; set; }

        [StringLength(200)]
        public string ItemName { get; set; }

        [StringLength(400)]
        public string Spec { get; set; }

        [StringLength(100)]
        public string MainUtil { get; set; }

        [StringLength(100)]
        public string SlaveUtil { get; set; }

        public decimal ConvertRate { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModTime_CRM { get; set; }

        public DateTime UpdateTime { get; set; }

        [StringLength(200)]
        public string InName { get; set; }

        [StringLength(200)]
        public string MaterialItem { get; set; }

        [StringLength(255)]
        public string Workshops { get; set; }

        [StringLength(50)]
        public string ModUser_APS { get; set; }

        public DateTime? ModTime_APS { get; set; }
    }
}
