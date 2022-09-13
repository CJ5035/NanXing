using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class StockPlan:Entity<int>
    {
        //public int Id { get; set; }
        public string? PlanNo { get; set; }
        public string? Proname { get; set; }
        public string? BatchNo { get; set; }
        public string? Probiaozhun { get; set; }
        public string? Spec { get; set; }
        public decimal? Count { get; set; }
        public DateTime Plantime { get; set; }
        public string? PlanUser { get; set; }
        public string? States { get; set; }
        public string? Color { get; set; }
        public string? Mark { get; set; }
        public string? Position { get; set; }
    }
}
