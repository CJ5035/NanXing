namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrayPro")]
    public partial class TrayPro
    {
        public int ID { get; set; }

        public DateTime optdate { get; set; }

        public int TrayStateID { get; set; }

        [StringLength(60)]
        public string prosn { get; set; }

        public virtual TrayState TrayState { get; set; }
    }
}
