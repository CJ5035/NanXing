namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("TouLiaoRecord")]
    public partial class TouLiaoRecord
     : Entity<int>
  {
        //public int ID { get; set; }

        public DateTime? RecTime { get; set; }

        [StringLength(20)]
        public string prosn { get; set; }

        [StringLength(10)]
        public string userID { get; set; }
    }
}
