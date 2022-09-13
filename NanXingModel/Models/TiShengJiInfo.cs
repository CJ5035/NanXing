using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class TiShengJiInfo:Entity<int>
    {
        //public int Id { get; set; }
        public string? TsjName { get; set; }
        public string? TsjIp { get; set; }
        public int TsjPort { get; set; }
        public DateTime InputTime { get; set; }
        public string? Floors { get; set; }
        public string? TsjPosition1f { get; set; }
        public string? TsjPosition2f { get; set; }
        public string? TsjPosition3f { get; set; }
        public string? TsjInModel1f { get; set; }
        public string? TsjInModel2f { get; set; }
        public string? TsjInModel3f { get; set; }
        public string? TsjOutModel1f { get; set; }
        public string? TsjOutModel2f { get; set; }
        public string? TsjOutModel3f { get; set; }
        public int IsOpen { get; set; }
        public string? AgvserverIp { get; set; }
    }
}
