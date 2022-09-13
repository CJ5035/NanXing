using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class TrayState
    {
        public TrayState()
        {
            TrayPros = new HashSet<TrayPro>();
        }

        public int Id { get; set; }
        public string TrayNo { get; set; }
        public DateTime Optdate { get; set; }
        public int OnlineCount { get; set; }
        public int? WareLocationId { get; set; }
        public decimal? TrayHeight { get; set; }

        public virtual WareLocation WareLocation { get; set; }
        public virtual ICollection<TrayPro> TrayPros { get; set; }
    }
}
