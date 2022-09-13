namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pchao")]
    public partial class pchao
    {
        public int id { get; set; }

        [StringLength(50)]
        public string lotno { get; set; }

        [StringLength(50)]
        public string oper { get; set; }

        public int? flag { get; set; }
    }
}
