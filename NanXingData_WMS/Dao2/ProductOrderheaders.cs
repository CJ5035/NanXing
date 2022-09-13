namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductOrderheaders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOrderheaders()
        {
            ProductOrderlists = new HashSet<ProductOrderlists>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string ProductOrderNo { get; set; }

        public DateTime? Optdate { get; set; }

        [StringLength(50)]
        public string PositionClass { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [StringLength(20)]
        public string orderNo { get; set; }

        [StringLength(255)]
        public string mergeCells { get; set; }

        [StringLength(255)]
        public string mergeCellsValue { get; set; }

        public DateTime? Newdate { get; set; }

        public DateTime? Moddate { get; set; }

        [StringLength(255)]
        public string Workshops { get; set; }

        [StringLength(300)]
        public string WorkshopsValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrderlists> ProductOrderlists { get; set; }
    }
}
