namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPARTMENT")]
    public partial class DEPARTMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTMENT()
        {
            STAFF = new HashSet<STAFF>();
        }

        [Required]
        [StringLength(20)]
        public string syscode { get; set; }

        [Key]
        [StringLength(20)]
        public string code { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        [StringLength(8)]
        public string principal { get; set; }

        [Column("abstract")]
        [StringLength(50)]
        public string _abstract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAFF> STAFF { get; set; }
    }
}
