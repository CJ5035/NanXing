using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class TouLiaoRecord:Entity<int>
    {
        //public int Id { get; set; }
        public DateTime? RecTime { get; set; }
        public string? Prosn { get; set; }
        public string? UserId { get; set; }
    }
}
