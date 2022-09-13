using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Pbcatvld
    {
        public string PbvName { get; set; } = null!;
        public string PbvVald { get; set; } = null!;
        public short PbvType { get; set; }
        public int? PbvCntr { get; set; }
        public string? PbvMsg { get; set; }
    }
}
