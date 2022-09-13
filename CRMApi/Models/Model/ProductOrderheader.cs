using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class ProductOrderheader
    {
        public ProductOrderheader()
        {
            ProductOrderlists = new HashSet<ProductOrderlist>();
        }

        public int Id { get; set; }
        public string Prosn { get; set; }
        public DateTime? Optdate { get; set; }
        public string PositionClass { get; set; }
        public string Remark { get; set; }
        public string OrderNo { get; set; }
        public string MergeCells { get; set; }
        public string MergeCellsValue { get; set; }

        public virtual ICollection<ProductOrderlist> ProductOrderlists { get; set; }
    }
}
