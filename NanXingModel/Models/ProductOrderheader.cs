using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class ProductOrderheader : Entity<int>
    {
        public ProductOrderheader()
        {
            ProductOrderlists = new HashSet<ProductOrderlist>();
        }

        //public int Id { get; set; }
        public string? ProductOrderNo { get; set; }
        public DateTime? Optdate { get; set; }
        public string? PositionClass { get; set; }
        public string? Remark { get; set; }
        public string? OrderNo { get; set; }
        public string? MergeCells { get; set; }
        public string? MergeCellsValue { get; set; }
        public DateTime? Newdate { get; set; }
        public DateTime? Moddate { get; set; }
        public string? Workshops { get; set; }
        public string? WorkshopsValue { get; set; }

        public virtual ICollection<ProductOrderlist> ProductOrderlists { get; set; }
    }
}
