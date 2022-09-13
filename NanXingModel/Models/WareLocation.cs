using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class WareLocation : Entity<int>
    {
        public WareLocation()
        {
            TrayStates = new HashSet<TrayState>();
        }

        //public int Id { get; set; }
        public string? WareLocaNo { get; set; }
        public string? WareLocaLie { get; set; }
        public string? WareLocaIndex { get; set; }
        public int? WareAreaId { get; set; }
        public int? HeaderId { get; set; }
        public string? Agvposition { get; set; }
        /// <summary>
        /// 仓位状态：预进、预出、占用、空
        /// </summary>
        public string? WareLocaState { get; set; }
        public string? TrayNo { get; set; }
        /// <summary>
        /// 是否启用，0为禁用，1为启用
        /// </summary>
        public int? IsOpen { get; set; }
        public int? TrayStateId { get; set; }

        public virtual User? Header { get; set; }
        public virtual TrayState? TrayState { get; set; }
        public virtual WareArea? WareArea { get; set; }
        public virtual ICollection<TrayState> TrayStates { get; set; }
    }
}
