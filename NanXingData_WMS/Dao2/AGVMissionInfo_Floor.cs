namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AGVMissionInfo_Floor
    {
        public int ID { get; set; }

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
        public string EndLocation { get; set; }

        [StringLength(50)]
        public string EndPosition { get; set; }

        [StringLength(50)]
        public string SendState { get; set; }

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
        public string AGVCarId { get; set; }

        [StringLength(10)]
        public string userId { get; set; }

        public int? MissionFloor_ID { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
    }
}
