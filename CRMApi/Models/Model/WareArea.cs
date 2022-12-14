using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class WareArea
    {
        public WareArea()
        {
            WareLocations = new HashSet<WareLocation>();
        }

        public int Id { get; set; }
        public string WareNo { get; set; }
        public int? WarId { get; set; }
        public int? WareHouseId { get; set; }
        public bool? WareAreaState { get; set; }
        public string InstockRule { get; set; }
        public string Protype { get; set; }
        public string InstockWay { get; set; }

        public virtual WareAreaClass War { get; set; }
        public virtual WareHouse WareHouse { get; set; }
        public virtual ICollection<WareLocation> WareLocations { get; set; }
    }
}
