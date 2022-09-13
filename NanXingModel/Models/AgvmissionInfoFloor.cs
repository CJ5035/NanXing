using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class AgvmissionInfoFloor:Entity<int>
    {
        public AgvmissionInfoFloor()
        {
            AgvmissionInfos = new HashSet<AgvmissionInfo>();
        }

        //public int Id { get; set; }
        public string? MissionNo { get; set; }
        public DateTime? OrderTime { get; set; }
        public string? TrayNo { get; set; }
        public string? Mark { get; set; }
        public string? StartLocation { get; set; }
        public string? StartPosition { get; set; }
        public string? EndLocation { get; set; }
        public string? EndPosition { get; set; }
        public string? SendState { get; set; }
        public string? SendMsg { get; set; }
        public string? StateMsg { get; set; }
        public string? RunState { get; set; }
        public DateTime? StateTime { get; set; }
        public int? StockPlanId { get; set; }
        public string? OrderGroupId { get; set; }
        public string? AgvcarId { get; set; }
        public string? UserId { get; set; }
        public int? MissionFloorId { get; set; }
        public string? Remark { get; set; }
        public string? ModelProcessCode { get; set; }
        public string? TsjName { get; set; }
        public int? IsContinued { get; set; }
        public int? TiShengJiRecordId { get; set; }

        public virtual TiShengJiRunRecord? TiShengJiRecord { get; set; }
        public virtual ICollection<AgvmissionInfo> AgvmissionInfos { get; set; }
    }
}
