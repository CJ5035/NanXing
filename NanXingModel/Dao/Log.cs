namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("Log")]
    public partial class Log
     : Entity<int>
  {
        //public int ID { get; set; }

        public DateTime Logdate { get; set; }

        [Required]
        [StringLength(50)]
        public string MarkLogLevel { get; set; }

        public string LogMessage { get; set; }

        [StringLength(255)]
        public string LogAction { get; set; }

        [StringLength(255)]
        public string LogAmount { get; set; }

        [StringLength(255)]
        public string StackTrace { get; set; }
    }
}
