using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class AgvmissionInfo
    {
        public int Id { get; set; }
        public string AreaClass { get; set; }
        public int? SortIndex { get; set; }
        public DateTime? OrderTime { get; set; }
        public string StockNo { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string RunState { get; set; }
        public string StateMsg { get; set; }
        public string SendState { get; set; }
        public string SendMsg { get; set; }
        public string MissionNo { get; set; }
        public string TrayNo { get; set; }
        public string Mark { get; set; }
        public int? StockPlanId { get; set; }
        public string OrderGroupId { get; set; }
        public string AgvcarId { get; set; }
        public string UserId { get; set; }
        public int? MissionFloorId { get; set; }
    }
}
