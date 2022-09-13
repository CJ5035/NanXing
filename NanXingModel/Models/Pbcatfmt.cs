using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Pbcatfmt
    {
        public string PbfName { get; set; } = null!;
        public string PbfFrmt { get; set; } = null!;
        public short PbfType { get; set; }
        public int? PbfCntr { get; set; }
    }
}
