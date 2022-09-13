using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class WareAreaClass : Entity<int>
    {
        public WareAreaClass()
        {
            WareAreas = new HashSet<WareArea>();
        }

        //public int Id { get; set; }
        public string? AreaClass { get; set; }
        public int? SortIndex { get; set; }
        public string? Remark { get; set; }

        public virtual ICollection<WareArea> WareAreas { get; set; }
    }
}
