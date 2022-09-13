namespace NanXingData_WMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductOrderlists
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOrderlists()
        {
            Production = new HashSet<Production>();
        }

        public int ID { get; set; }

        [StringLength(20)]
        public string ProductOrder_XuHao { get; set; }

        [StringLength(30)]
        public string Itemno { get; set; }

        [StringLength(50)]
        public string ItemName { get; set; }

        [StringLength(50)]
        public string InName { get; set; }

        [StringLength(50)]
        public string MaterialItem { get; set; }

        [StringLength(20)]
        public string Spec { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [StringLength(20)]
        public string Class { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        public decimal? PcCount { get; set; }

        public DateTime? Optdate { get; set; }

        public DateTime? PlanDate { get; set; }

        [StringLength(10)]
        public string Jingbanren { get; set; }

        public string Remark { get; set; }

        [StringLength(50)]
        public string Clientname { get; set; }

        public int? ProductOrderheader_ID { get; set; }

        [StringLength(50)]
        public string BatchNo { get; set; }

        [StringLength(20)]
        public string BoxNo { get; set; }

        [StringLength(20)]
        public string BoxName { get; set; }

        [StringLength(50)]
        public string Ingredients { get; set; }

        [StringLength(20)]
        public string Chejianclass { get; set; }

        [StringLength(20)]
        public string ERPOrderNo { get; set; }

        [StringLength(10)]
        public string ProductOrder_State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Production> Production { get; set; }

        public virtual ProductOrderheaders ProductOrderheaders { get; set; }
    }
}
