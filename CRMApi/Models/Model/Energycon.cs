using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Energycon
    {
        public int Sn { get; set; }
        public string EquName { get; set; }
        public DateTime? ReadDate { get; set; }
        public decimal? CurKwh { get; set; }
        public decimal? PhaseKwh { get; set; }
        public string Remark { get; set; }
    }
}
