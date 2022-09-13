using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class WareLocation
    {
        public WareLocation()
        {
            TrayStates = new HashSet<TrayState>();
        }

        public int Id { get; set; }
        public string WareLocaNo { get; set; }
        public int? WareAreaId { get; set; }
        public int? HeaderId { get; set; }
        public bool? WareLocaState { get; set; }
        public string Agvposition { get; set; }
        public string WareLocaNoLong { get; set; }

        public virtual User Header { get; set; }
        public virtual WareArea WareArea { get; set; }
        public virtual ICollection<TrayState> TrayStates { get; set; }
    }
}
