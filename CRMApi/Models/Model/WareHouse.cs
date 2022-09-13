using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class WareHouse
    {
        public WareHouse()
        {
            WareAreas = new HashSet<WareArea>();
        }

        public int Id { get; set; }
        public string Whname { get; set; }
        public string Whposition { get; set; }
        public bool? Whstate { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<WareArea> WareAreas { get; set; }
    }
}
