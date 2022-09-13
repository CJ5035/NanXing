namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CRMPlanHead")]
    public partial class CRMPlanHead
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [StringLength(1000)]
        public string CRMApplyNo { get; set; }

        [StringLength(1000)]
        public string ClientNo { get; set; }

        [StringLength(1000)]
        public string ClientName { get; set; }

        [StringLength(1000)]
        public string ApplicantId { get; set; }

        [StringLength(1000)]
        public string ApplicantName { get; set; }

        [StringLength(1000)]
        public string ApplicantPhone { get; set; }

        [StringLength(1000)]
        public string ApplicantDept { get; set; }

        [StringLength(1000)]
        public string ApplicantJob { get; set; }

        public DateTime? ApplyTime { get; set; }

        public DateTime? OrderDate { get; set; }

        [StringLength(1000)]
        public string SaleGroup { get; set; }

        [StringLength(1000)]
        public string OrderSource { get; set; }

        [MaxLength(4000)]
        public byte[] Photo { get; set; }

        [StringLength(3000)]
        public string Remark { get; set; }

        [StringLength(1000)]
        public string Reserve1 { get; set; }

        [StringLength(1000)]
        public string Reserve2 { get; set; }

        [StringLength(1000)]
        public string Reserve3 { get; set; }
        /// <summary>
        /// 单据排产类型:区分这张单是大包装还是小包装的排产申请
        /// </summary>
        [StringLength(20)]
        public string MakeClass { get; set; }


        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<CRMPlanList> CRMPlanList { get; set; }
    }
}
