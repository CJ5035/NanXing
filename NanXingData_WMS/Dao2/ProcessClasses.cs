namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProcessClasses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProcessClasses()
        {
            WorkShopProcesses = new HashSet<WorkShopProcesses>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string ProcessClassName { get; set; }

        public int ProcessSort { get; set; }

        [StringLength(300)]
        public string ProcessReamrk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkShopProcesses> WorkShopProcesses { get; set; }
    }
}
