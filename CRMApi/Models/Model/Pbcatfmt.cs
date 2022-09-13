using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Pbcatfmt
    {
        public string PbfName { get; set; }
        public string PbfFrmt { get; set; }
        public short PbfType { get; set; }
        public int? PbfCntr { get; set; }
    }
}
