namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("AGVMissionInfo")]
    public partial class AGVMissionInfo: Entity<int>
    {
        //public int ID { get; set; }

        [StringLength(20)]
        public string MissionNo { get; set; }

        public DateTime? OrderTime { get; set; }

        [StringLength(50)]
        public string TrayNo { get; set; }

        [StringLength(50)]
        public string Mark { get; set; }

        [StringLength(50)]
        public string StartLocation { get; set; }

        [StringLength(50)]
        public string StartPosition { get; set; }

        [StringLength(50)]
        public string MiddleLocation { get; set; }

        [StringLength(50)]
        public string MiddlePosition { get; set; }

        [StringLength(50)]
        public string EndLocation { get; set; }

        [StringLength(50)]
        public string EndPosition { get; set; }

        [StringLength(50)]
        public string SendState { get; set; }
        [StringLength(100)]
        public string SendMsg { get; set; }

        [StringLength(100)]
        public string StateMsg { get; set; }

        [StringLength(50)]
        public string RunState { get; set; }

        public DateTime? StateTime { get; set; }

        public int? StockPlan_ID { get; set; }

        [StringLength(255)]
        public string OrderGroupId { get; set; }

        [StringLength(20)]
        public string ModelProcessCode { get; set; }

        [StringLength(20)]
        public string AGVCarId { get; set; }

        [StringLength(10)]
        public string userId { get; set; }

        public int? MissionFloor_ID { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public int? IsFloor { get; set; }
        /// <summary>
        /// 提升机名称，分类用
        /// </summary>
        [StringLength(20)]
        public string WHName { get; set; }
        //[ForeignKey("MissionFloor_ID")]
        public virtual List<AGVMissionInfo_Floor> AGVMissionInfo_Floor { get; set; }
    }
}
