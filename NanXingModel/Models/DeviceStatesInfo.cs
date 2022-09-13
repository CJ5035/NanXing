using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class DeviceStatesInfo:Entity<int>
    {
        //public int Id { get; set; }
        public string? DeviceCode { get; set; }
        public string? PayLoad { get; set; }
        public string? DevicePostionRec { get; set; }
        public string? DevicePosition { get; set; }
        public string? Battery { get; set; }
        public string? DeviceName { get; set; }
        public int? DeviceStatusInt { get; set; }
        public string? DeviceStatus { get; set; }
        public DateTime RecTime { get; set; }
        public string? DevicePostionX { get; set; }
        public string? DevicePostionY { get; set; }
    }
}
