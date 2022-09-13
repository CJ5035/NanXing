using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Online
    :Entity<int>
    {
        //public int Id { get; set; }
        public string? Ipadddress { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
