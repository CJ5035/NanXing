namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("TrayPro")]
    public partial class TrayPro
     : Entity<int>
  {
        //public int ID { get; set; }

        public DateTime optdate { get; set; }

        public int TrayStateID { get; set; }

        [StringLength(60)]
        public string prosn { get; set; }

        public virtual TrayState TrayState { get; set; }
    }
}
