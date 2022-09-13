namespace NanXingModel.Dao
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    public partial class AGVMissionInfo_Floor
     : Entity<int>
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
        public string EndLocation { get; set; }

        [StringLength(50)]
        public string EndPosition { get; set; }

        [StringLength(50)]
        public string SendState { get; set; }
        [StringLength(50)]
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
        /// <summary>
        /// �жϸ������Ƿ������Ѿ��ȴ�״̬
        /// </summary>
        public int? IsContinued { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
        /// <summary>
        /// ���������ƣ�������
        /// </summary>
        [StringLength(20)]
        public string TSJ_Name { get; set; }
        [ForeignKey("MissionFloor_ID")]
        public virtual AGVMissionInfo AGVMissionInfo { get; set; }

        public int? TiShengJiRecord_ID { get; set; }
        [ForeignKey("TiShengJiRecord_ID")]
        public virtual TiShengJiRunRecord TiShengJiRunRecord { get; set; }
    }
}
