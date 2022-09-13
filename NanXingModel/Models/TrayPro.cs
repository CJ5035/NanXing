using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class TrayPro:Entity<int>
    {
        //public int Id { get; set; }
        public DateTime Optdate { get; set; }
        public int TrayStateId { get; set; }
        public string? Prosn { get; set; }

        public virtual TrayState TrayState { get; set; } = null!;
    }
}
