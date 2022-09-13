namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("TiShengJiState")]
   
    public partial class TiShengJiState
     : Entity<int>
  {
        //public int ID { get; set; }
        [StringLength(25)]
        public string TsjIp{ get; set; }

       public DateTime? InputTime { get; set; }

        [StringLength(20)]
        public string deviceState { get; set; }

        [StringLength(20)]
        public string carState { get; set; }

        [StringLength(20)]
        public string carTarget { get; set; }

        public int? CarCount { get; set; }

        public int? F1Count { get; set; }

        public int? F2Count { get; set; }

        public int? F3Count { get; set; }

        [StringLength(20)]
        public string CarState2 { get; set; }

        [StringLength(20)]
        public string F1State { get; set; }

        [StringLength(20)]
        public string F2State { get; set; }

        [StringLength(20)]
        public string F3State { get; set; }


        [StringLength(20)]
        public string F1DuiJieWei { get; set; }

        [StringLength(20)]
        public string F2DuiJieWei { get; set; }

        [StringLength(20)]
        public string F3DuiJieWei { get; set; }

        [StringLength(20)]
        public string OrderReceive { get; set; }
    }
}
