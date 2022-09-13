namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STAFF")]
    public partial class STAFF
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(10)]
        public string name { get; set; }

        public int sex { get; set; }

        [StringLength(20)]
        public string idcard { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(10)]
        public string edured { get; set; }

        [StringLength(20)]
        public string telephone { get; set; }

        public DateTime? indate { get; set; }

        public DateTime? demdate { get; set; }

        public int? posstate { get; set; }

        [Required]
        [StringLength(20)]
        public string department { get; set; }

        [StringLength(6)]
        public string authorgrp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? workcls { get; set; }

        [StringLength(30)]
        public string bank { get; set; }

        [StringLength(30)]
        public string account { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? timepay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? basepay { get; set; }

        [Column("abstract")]
        [StringLength(50)]
        public string _abstract { get; set; }

        [StringLength(20)]
        public string password { get; set; }

        public virtual DEPARTMENT DEPARTMENT1 { get; set; }
    }
}
