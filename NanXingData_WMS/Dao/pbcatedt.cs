namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pbcatedt")]
    public partial class pbcatedt
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string pbe_name { get; set; }

        [StringLength(254)]
        public string pbe_edit { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short pbe_type { get; set; }

        public int? pbe_cntr { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short pbe_seqn { get; set; }

        public int? pbe_flag { get; set; }

        [StringLength(32)]
        public string pbe_work { get; set; }
    }
}
