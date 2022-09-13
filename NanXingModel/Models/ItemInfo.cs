using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class ItemInfo
    :Entity<int>
{
        //public int Id { get; set; }
        public string? ItemNo { get; set; }
        public string? Crmid { get; set; }
        public string? ItemName { get; set; }
        public string? Spec { get; set; }
        public string? MainUtil { get; set; }
        public string? SlaveUtil { get; set; }
        public decimal ConvertRate { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModTimeCrm { get; set; }
        public DateTime UpdateTime { get; set; }
        public string? InName { get; set; }
        public string? MaterialItem { get; set; }
        public string? Workshops { get; set; }
        public string? ModUserAps { get; set; }
        public DateTime? ModTimeAps { get; set; }
    }
}
