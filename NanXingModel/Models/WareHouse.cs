using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    /// <summary>
    /// 仓库主表
    /// </summary>
    public partial class WareHouse : Entity<int>
    {
        public WareHouse()
        {
            WareAreas = new HashSet<WareArea>();
        }

        //public int Id { get; set; }
        public string? Whname { get; set; }
        public string? Whposition { get; set; }
        public bool? Whstate { get; set; }
        public string? Remark { get; set; }
        public string? AgvmodelCode { get; set; }
        public string? AgvserverIp { get; set; }

        public virtual ICollection<WareArea> WareAreas { get; set; }
    }
}
