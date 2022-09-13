using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class FaHuoPlan
    :Entity<int>
{
        //public int Id { get; set; }
        public string? Danjutype { get; set; }
        public string? Danjuno { get; set; }
        public string? Itemno { get; set; }
        public string? Itemname { get; set; }
        public string? Spec { get; set; }
        public string? Saleunit { get; set; }
        public decimal? Salequt { get; set; }
        public decimal? Outqut { get; set; }
        public decimal? Boxnum { get; set; }
        public DateTime? Fhdate { get; set; }
    }
}
