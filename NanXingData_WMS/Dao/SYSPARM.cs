namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSPARM")]
    public partial class SYSPARM
    {
        [Key]
        [StringLength(60)]
        public string paraitem { get; set; }

        [StringLength(50)]
        public string paravalue { get; set; }

        [StringLength(50)]
        public string ItemCls { get; set; }

        [StringLength(50)]
        public string Reserve1 { get; set; }

        [StringLength(50)]
        public string Reserve2 { get; set; }

        [StringLength(100)]
        public string Reserve3 { get; set; }

        [StringLength(100)]
        public string Reserve4 { get; set; }
    }
}
