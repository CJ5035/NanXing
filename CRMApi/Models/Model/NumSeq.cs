using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class NumSeq
    {
        public string Cate { get; set; }
        public string DateNo { get; set; }
        public int? Seq { get; set; }
        public DateTime? CrTime { get; set; }
    }
}
