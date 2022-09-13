using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class TrayWeightRecord:Entity<int>
    {
        //public int Id { get; set; }
        public string? Prosn { get; set; }
        public string? BatchNo { get; set; }
        public string? Position { get; set; }
        public string? Proname { get; set; }
        public string? Spec { get; set; }
        public string? Biaozhun { get; set; }
        public string? Result { get; set; }
        public decimal TrayCount { get; set; }
        public decimal TrayWeight { get; set; }
        public string? BoxName { get; set; }
        public string? Color { get; set; }
        public string? Itemno { get; set; }
        public DateTime RecTime { get; set; }
        public int? RecUserId { get; set; }
    }
}
