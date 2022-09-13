using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class TrayState : Entity<int>
    {
        public TrayState()
        {
            TrayPros = new HashSet<TrayPro>();
            WareLocations = new HashSet<WareLocation>();
        }

        //public int Id { get; set; }
        public string TrayNo { get; set; } = null!;
        public DateTime Optdate { get; set; }
        public int OnlineCount { get; set; }
        public int? WareLocationId { get; set; }
        public string? Proname { get; set; }
        public string? Itemno { get; set; }
        public string? Spec { get; set; }
        public string? BatchNo { get; set; }
        public string? BoxName { get; set; }
        public string? Color { get; set; }
        public string? Probiaozhun { get; set; }
        public string? Position { get; set; }
        public string? Remark { get; set; }

        public virtual WareLocation? WareLocation { get; set; }
        public virtual ICollection<TrayPro> TrayPros { get; set; }
        public virtual ICollection<WareLocation> WareLocations { get; set; }
    }
}
