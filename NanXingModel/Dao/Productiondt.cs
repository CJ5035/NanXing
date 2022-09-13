namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("Productiondt")]
    public partial class Productiondt
    {
        [Key]
        public int SerialNo { get; set; }

        [Required]
        [StringLength(50)]
        public string ProSn { get; set; }

        public DateTime PRODate { get; set; }

        [StringLength(20)]
        public string WORKGRP { get; set; }

        [StringLength(30)]
        public string PrdMissionNo { get; set; }

        [StringLength(50)]
        public string ItemNo { get; set; }

        [StringLength(60)]
        public string ItemName { get; set; }

        [StringLength(60)]
        public string Spec { get; set; }

        [StringLength(100)]
        public string QCStandard { get; set; }

        [StringLength(50)]
        public string Client { get; set; }

        [StringLength(20)]
        public string ORDERNO { get; set; }

        [StringLength(20)]
        public string CHECKMAN { get; set; }

        [StringLength(20)]
        public string PackMan { get; set; }

        [StringLength(20)]
        public string COLOR { get; set; }

        [StringLength(30)]
        public string LOTNO { get; set; }

        [StringLength(20)]
        public string GRADE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WEIGHT { get; set; }

        [StringLength(40)]
        public string CASENO { get; set; }

        public short? WlStatus { get; set; }

        public short? IsReturn { get; set; }

        public short? IsPrint { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public short? IsCancel { get; set; }

        [StringLength(20)]
        public string OPERATOR { get; set; }

        [StringLength(40)]
        public string REMARK { get; set; }

        [StringLength(60)]
        public string RESERVE1 { get; set; }

        [StringLength(60)]
        public string RESERVE2 { get; set; }

        [StringLength(60)]
        public string RESERVE3 { get; set; }

        [StringLength(60)]
        public string RESERVE4 { get; set; }

        [StringLength(60)]
        public string RESERVE5 { get; set; }

        [StringLength(60)]
        public string RESERVE6 { get; set; }

        [StringLength(60)]
        public string RESERVE7 { get; set; }

        [StringLength(100)]
        public string RESERVE8 { get; set; }

        [StringLength(100)]
        public string RESERVE9 { get; set; }

        [StringLength(100)]
        public string RESERVE10 { get; set; }

        public DateTime? InputDate { get; set; }

        public int? PrdDtlSn { get; set; }
    }
}
