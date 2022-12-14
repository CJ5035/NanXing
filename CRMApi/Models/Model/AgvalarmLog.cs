using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class AgvalarmLog
    {
        public int Id { get; set; }
        public string DeviceNum { get; set; }
        public string AlarmDesc { get; set; }
        public int? AlarmType { get; set; }
        public int? AreaId { get; set; }
        public int? AlarmReadFlag { get; set; }
        public string ChannelDeviceId { get; set; }
        public string AlarmSource { get; set; }
        public string ChannelName { get; set; }
        public DateTime? AlarmDate { get; set; }
        public DateTime RecTime { get; set; }
        public string DeviceName { get; set; }
        public int? AlarmGrade { get; set; }
    }
}
