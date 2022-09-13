namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("pchao")]
    public partial class pchao
     : Entity<int>
  {
        //public int ID { get; set; }

        [StringLength(50)]
        public string lotno { get; set; }

        [StringLength(50)]
        public string oper { get; set; }

        public int? flag { get; set; }
    }
}
