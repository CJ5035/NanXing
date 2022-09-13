namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("SERIALNO")]
    public partial class SERIALNO
    {
        [Key]
        [StringLength(20)]
        public string SERIALNAME { get; set; }

        [Column("SERIALNO")]
        public int SERIALNO1 { get; set; }
    }
}
