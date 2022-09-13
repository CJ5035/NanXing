namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("WareArea")]
    public partial class WareArea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WareArea()
        {
            WareLocation = new HashSet<WareLocation>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string WareNo { get; set; }

        public int? War_ID { get; set; }

        public int? WareHouse_ID { get; set; }

        public bool? WareAreaState { get; set; }

        [StringLength(10)]
        public string InstockRule { get; set; }

        [StringLength(10)]
        public string protype { get; set; }

        [StringLength(10)]
        public string InstockWay { get; set; }

        public virtual WareAreaClass WareAreaClass { get; set; }

        public virtual WareHouse WareHouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WareLocation> WareLocation { get; set; }
    }
}
