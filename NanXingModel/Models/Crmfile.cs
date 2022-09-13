using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Crmfile : Entity<long>
    {
        //public long Id { get; set; }
        public string? Crmid { get; set; }
        public string? CrmfilePath { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
