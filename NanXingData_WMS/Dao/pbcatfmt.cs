namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pbcatfmt")]
    public partial class pbcatfmt
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string pbf_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(254)]
        public string pbf_frmt { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short pbf_type { get; set; }

        public int? pbf_cntr { get; set; }
    }
}
