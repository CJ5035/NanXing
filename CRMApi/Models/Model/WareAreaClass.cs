using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class WareAreaClass
    {
        public WareAreaClass()
        {
            WareAreas = new HashSet<WareArea>();
        }

        public int Id { get; set; }
        public string AreaClass { get; set; }
        public int? SortIndex { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<WareArea> WareAreas { get; set; }
    }
}
