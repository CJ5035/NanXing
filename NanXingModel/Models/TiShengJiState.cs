using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class TiShengJiState:Entity<int>
    {
        //public int Id { get; set; }
        public DateTime? InputTime { get; set; }
        public string? DeviceState { get; set; }
        public string? CarState { get; set; }
        public string? CarTarget { get; set; }
        public int? CarCount { get; set; }
        public int? F1count { get; set; }
        public int? F2count { get; set; }
        public int? F3count { get; set; }
        public string? CarState2 { get; set; }
        public string? F1state { get; set; }
        public string? F2state { get; set; }
        public string? F3state { get; set; }
        public string? TsjIp { get; set; }
        public string? F1duiJieWei { get; set; }
        public string? F2duiJieWei { get; set; }
        public string? F3duiJieWei { get; set; }
        public string? OrderReceive { get; set; }
    }
}
