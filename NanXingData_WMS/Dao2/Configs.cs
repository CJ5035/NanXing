namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Configs
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ConfigKey { get; set; }

        [Required]
        [StringLength(4000)]
        public string ConfigValue { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }
    }
}
