using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class WeiXinSetting:Entity<int>
    {
        //public int Id { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public DateTime? ExpiraitonTime { get; set; }
    }
}
