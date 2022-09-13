using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class CrmplanList : Entity<long>
    {
        public CrmplanList()
        {
            ProductOrderlists = new HashSet<ProductOrderlist>();
        }

        //public long Id { get; set; }
        public string? CrmapplyNoXuhao { get; set; }
        public string? ItemNo { get; set; }
        public string? ItemName { get; set; }
        public string? Spec { get; set; }
        public int OrderCount { get; set; }
        public string? Unit { get; set; }
        public string? InventoryCount { get; set; }
        public decimal OrderCountOnkg { get; set; }
        public string? BoxNo { get; set; }
        public string? BoxName { get; set; }
        public string? Biaozhun { get; set; }
        public string? ProductRecipe { get; set; }
        public string? ApplyNoState { get; set; }
        public string? EmergencyDegree { get; set; }
        public string? Remark { get; set; }
        public string? Reserve2 { get; set; }
        public string? Reserve3 { get; set; }
        public string? Reserve4 { get; set; }
        public string? Reserve5 { get; set; }
        public string? Reserve6 { get; set; }
        public string? Reserve7 { get; set; }
        public long CrmplanHeadId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? BoxRemark { get; set; }
        public string? CrmListStatus { get; set; }
        public string? CrmListType { get; set; }
        public string? CrmapplyListInCode { get; set; }
        public string? ConvertRate { get; set; }

        public virtual CrmplanHead CrmplanHead { get; set; } = null!;
        public virtual ICollection<ProductOrderlist> ProductOrderlists { get; set; }
    }
}
