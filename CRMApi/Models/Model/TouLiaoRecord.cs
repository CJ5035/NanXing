using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class TouLiaoRecord
    {
        public int Id { get; set; }
        public DateTime? RecTime { get; set; }
        public string Prosn { get; set; }
        public string UserId { get; set; }
    }
}
