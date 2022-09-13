using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class ProductOrderlist
    {
        public ProductOrderlist()
        {
            Productions = new HashSet<Production>();
        }

        public int Id { get; set; }
        public string Itemno { get; set; }
        public string Name { get; set; }
        public string Spec { get; set; }
        public string Model { get; set; }
        public string InName { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Class { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceOut { get; set; }
        public decimal? Count { get; set; }
        public string Mark { get; set; }
        public DateTime? Optdate { get; set; }
        public string Jingbanren { get; set; }
        public string Remark1 { get; set; }
        public string Providername { get; set; }
        public string Clientname { get; set; }
        public int? ProductOrderheaderId { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? High { get; set; }
        public string BatchNo { get; set; }
        public string BoxNo { get; set; }
        public string BoxName { get; set; }
        public string Ingredients { get; set; }
        public string Chejianclass { get; set; }
        public string ErporderNo { get; set; }
        public DateTime? PlanDate { get; set; }

        public virtual ProductOrderheader ProductOrderheader { get; set; }
        public virtual ICollection<Production> Productions { get; set; }
    }
}
