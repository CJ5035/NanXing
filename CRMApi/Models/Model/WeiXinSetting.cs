using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class WeiXinSetting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime? ExpiraitonTime { get; set; }
    }
}
