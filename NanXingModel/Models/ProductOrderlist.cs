using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class ProductOrderlist : Entity<int>
    {
        public ProductOrderlist()
        {
            Productions = new HashSet<Production>();
        }

        //public int Id { get; set; }
        public string? ProductOrderXuHao { get; set; }
        public string? Itemno { get; set; }
        public string? ItemName { get; set; }
        public string? InName { get; set; }
        public string? MaterialItem { get; set; }
        public string? Spec { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public string? Class { get; set; }
        public string? Unit { get; set; }
        public decimal? PcCount { get; set; }
        public DateTime? PlanDate { get; set; }
        public string? Jingbanren { get; set; }
        public string? Remark { get; set; }
        public string? Clientname { get; set; }
        public int? ProductOrderheaderId { get; set; }
        public string? BatchNo { get; set; }
        public string? BoxNo { get; set; }
        public string? BoxName { get; set; }
        public string? Ingredients { get; set; }
        public string? Chejianclass { get; set; }
        public string? ErporderNo { get; set; }
        public string? ProductOrderState { get; set; }
        public DateTime? Newdate { get; set; }
        public DateTime? Moddate { get; set; }
        public string? Biaozhun { get; set; }
        public string? BoxRemark { get; set; }
        public string? GiveDept { get; set; }
        public string? ProductRecipe { get; set; }
        public long? CrmplanListId { get; set; }
        public string? PlanTime { get; set; }
        public string? Priority { get; set; }
        public string? PrintState { get; set; }
        public decimal? PcCount03Tank { get; set; }
        public decimal? PcCount03Bag { get; set; }
        public decimal? PcCount03Box { get; set; }
        public decimal? PcCount07Tank { get; set; }
        public decimal? PcCount07Bag { get; set; }
        public decimal? PcCount07Box { get; set; }

        public virtual CrmplanList? CrmplanList { get; set; }
        public virtual ProductOrderheader? ProductOrderheader { get; set; }
        public virtual ICollection<Production> Productions { get; set; }
    }
}
