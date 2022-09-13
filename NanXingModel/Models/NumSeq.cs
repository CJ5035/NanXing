using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class NumSeq
    {
        public string? Cate { get; set; }
        public string? DateNo { get; set; }
        public int? Seq { get; set; }
        public DateTime? CrTime { get; set; }
    }
}
