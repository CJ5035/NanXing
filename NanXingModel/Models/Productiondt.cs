using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    /// <summary>
    /// fdsfds fdsfsfd  fsd fds f
    /// </summary>
    public partial class Productiondt
    {
        public int SerialNo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProSn { get; set; } = null!;
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime Prodate { get; set; }
        public string? Workgrp { get; set; }
        public string? PrdMissionNo { get; set; }
        public string? ItemNo { get; set; }
        public string? ItemName { get; set; }
        public string? Spec { get; set; }
        public string? Qcstandard { get; set; }
        public string? Client { get; set; }
        public string? Orderno { get; set; }
        public string? Checkman { get; set; }
        public string? PackMan { get; set; }
        public string? Color { get; set; }
        /// <summary>
        /// fds fds  fds fdsfds fs
        /// </summary>
        public string? Lotno { get; set; }
        public string? Grade { get; set; }
        public decimal? Weight { get; set; }
        public string? Caseno { get; set; }
        public short? WlStatus { get; set; }
        public short? IsReturn { get; set; }
        public short? IsPrint { get; set; }
        public string? Password { get; set; }
        public short? IsCancel { get; set; }
        public string? Operator { get; set; }
        public string? Remark { get; set; }
        public string? Reserve1 { get; set; }
        public string? Reserve2 { get; set; }
        public string? Reserve3 { get; set; }
        public string? Reserve4 { get; set; }
        public string? Reserve5 { get; set; }
        public string? Reserve6 { get; set; }
        public string? Reserve7 { get; set; }
        public string? Reserve8 { get; set; }
        public string? Reserve9 { get; set; }
        public string? Reserve10 { get; set; }
        public DateTime? InputDate { get; set; }
        public int? PrdDtlSn { get; set; }
    }
}
