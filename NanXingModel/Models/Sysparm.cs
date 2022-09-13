using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Sysparm
    {
        public string Paraitem { get; set; } = null!;
        public string? Paravalue { get; set; }
        public string? ItemCls { get; set; }
        public string? Reserve1 { get; set; }
        public string? Reserve2 { get; set; }
        public string? Reserve3 { get; set; }
        public string? Reserve4 { get; set; }
    }
}
