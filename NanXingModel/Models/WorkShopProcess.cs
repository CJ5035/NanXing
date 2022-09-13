using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class WorkShopProcess:Entity<int>
    {
        //public int Id { get; set; }
        public string? WorkShopName { get; set; }
        public int WorkShopSort { get; set; }
        public int ProcessClassId { get; set; }

        public virtual ProcessClass ProcessClass { get; set; } = null!;
    }
}
