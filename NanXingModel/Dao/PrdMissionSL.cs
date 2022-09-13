namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("PrdMissionSL")]
    public partial class PrdMissionSL
    {
        [Key]
        public int SN { get; set; }

        [StringLength(30)]
        public string PrdMissionNo { get; set; }

        public DateTime PRODate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(20)]
        public string WORKGRP { get; set; }

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

        [StringLength(40)]
        public string COLOR { get; set; }

        [StringLength(30)]
        public string LOTNO { get; set; }

        [StringLength(20)]
        public string GRADE { get; set; }

        public double? WEIGHT { get; set; }

        public double? Quantity { get; set; }

        public double? Price { get; set; }

        public double? Cost { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public double? Thickness { get; set; }

        [StringLength(40)]
        public string CASENO { get; set; }

        [StringLength(200)]
        public string LabelName { get; set; }

        [StringLength(200)]
        public string BoxLblName { get; set; }

        public short? WlStatus { get; set; }

        public short? IsReturn { get; set; }

        public short? IsPrint { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public short? IsCancel { get; set; }

        [StringLength(20)]
        public string OPERATOR { get; set; }

        public DateTime? InputDate { get; set; }

        [StringLength(20)]
        public string KaiDan { get; set; }

        public DateTime? KaiDanDate { get; set; }

        [StringLength(20)]
        public string Auditer { get; set; }

        public DateTime? AuditDate { get; set; }

        [StringLength(20)]
        public string PiZhun { get; set; }

        public DateTime? PiZhunDate { get; set; }

        [StringLength(255)]
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

        [StringLength(100)]
        public string RESERVE11 { get; set; }

        [StringLength(100)]
        public string RESERVE12 { get; set; }

        [StringLength(100)]
        public string RESERVE13 { get; set; }

        [StringLength(100)]
        public string RESERVE14 { get; set; }

        [StringLength(255)]
        public string RESERVE15 { get; set; }

        [StringLength(255)]
        public string RESERVE16 { get; set; }

        [StringLength(255)]
        public string RESERVE17 { get; set; }

        [StringLength(255)]
        public string RESERVE18 { get; set; }

        [StringLength(255)]
        public string RESERVE19 { get; set; }

        [StringLength(255)]
        public string RESERVE20 { get; set; }

        [StringLength(50)]
        public string RESERVE21 { get; set; }

        [StringLength(50)]
        public string RESERVE22 { get; set; }

        [StringLength(50)]
        public string RESERVE23 { get; set; }

        [StringLength(50)]
        public string RESERVE24 { get; set; }

        [StringLength(50)]
        public string RESERVE25 { get; set; }

        [StringLength(50)]
        public string RESERVE26 { get; set; }

        [StringLength(50)]
        public string RESERVE27 { get; set; }

        [StringLength(50)]
        public string RESERVE28 { get; set; }

        [StringLength(50)]
        public string RESERVE29 { get; set; }

        [StringLength(50)]
        public string RESERVE30 { get; set; }
    }
}
