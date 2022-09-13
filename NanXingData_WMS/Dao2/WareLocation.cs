namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WareLocation")]
    public partial class WareLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WareLocation()
        {
            TrayState = new HashSet<TrayState>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string WareLocaNo { get; set; }

        [StringLength(50)]
        public string WareLoca_Lie { get; set; }

        [StringLength(50)]
        public string WareLoca_Index { get; set; }

        public int? WareArea_ID { get; set; }

        public int? header_ID { get; set; }

        [StringLength(50)]
        public string AGVPosition { get; set; }

        [StringLength(10)]
        public string WareLocaState { get; set; }

        [StringLength(50)]
        public string TrayNo { get; set; }

        public int? IsOpen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrayState> TrayState { get; set; }

        public virtual Users Users { get; set; }

        public virtual WareArea WareArea { get; set; }
    }
}
