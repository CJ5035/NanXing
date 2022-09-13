using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Pchao
    :Entity<int>
{
        //public int Id { get; set; }
        public string? Lotno { get; set; }
        public string? Oper { get; set; }
        public int? Flag { get; set; }
    }
}
