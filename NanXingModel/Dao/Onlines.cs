namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    public partial class Onlines
     : Entity<int>
  {
        //public int ID { get; set; }

        [StringLength(50)]
        public string IPAdddress { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int UserID { get; set; }

        public virtual Users Users { get; set; }
    }
}
