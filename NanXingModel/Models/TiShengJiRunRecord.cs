using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class TiShengJiRunRecord : Entity<int>
    {
        public TiShengJiRunRecord()
        {
            AgvmissionInfoFloors = new HashSet<AgvmissionInfoFloor>();
        }

        //public int Id { get; set; }
        public string? TsjName { get; set; }
        public string? TsjIp { get; set; }
        public int TsjPort { get; set; }
        public DateTime OrderTime { get; set; }
        public string? StartFloor { get; set; }
        public string? EndFloor { get; set; }
        public string? InsideTrayNo { get; set; }
        public string? OutsideTrayNo { get; set; }
        public int TrayCount { get; set; }

        public virtual ICollection<AgvmissionInfoFloor> AgvmissionInfoFloors { get; set; }
    }
}
