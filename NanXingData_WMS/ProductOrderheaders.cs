namespace NanXingData_WMS
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

        public DateTime? optdate { get; set; }

        [StringLength(50)]
        public string positionClass { get; set; }

        [StringLength(200)]
        public string remark { get; set; }

        [StringLength(20)]
        public string orderNo { get; set; }

        [StringLength(255)]
        public string mergeCells { get; set; }

        [StringLength(255)]
        public string mergeCellsValue { get; set; }

        [StringLength(20)]
        public string ProductOrderNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrderlists> ProductOrderlists { get; set; }
    }
}
