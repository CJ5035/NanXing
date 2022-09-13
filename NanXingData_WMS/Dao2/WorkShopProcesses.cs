namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkShopProcesses
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string WorkShopName { get; set; }

        public int WorkShopSort { get; set; }

        public int ProcessClass_Id { get; set; }

        public virtual ProcessClasses ProcessClasses { get; set; }
    }
}
