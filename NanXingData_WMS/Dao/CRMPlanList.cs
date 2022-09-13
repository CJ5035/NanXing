namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CRMPlanList")]
    public partial class CRMPlanList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Index]
        [StringLength(1000)]
        public string CRMApplyList_InCode { get; set; }
        [StringLength(1000)]
        public string CRMApplyNo_Xuhao { get; set; }

        [StringLength(1000)]
        public string ItemNo { get; set; }

        [StringLength(1000)]
        public string ItemName { get; set; }

        [StringLength(1000)]
        public string Spec { get; set; }

        public int OrderCount { get; set; }

        [StringLength(1000)]
        public string Unit { get; set; }

        [StringLength(1000)]
        public string InventoryCount { get; set; }

        public decimal OrderCountONkg { get; set; }

        /// <summary>
        /// 交付日期
        /// </summary>
        public DateTime? DeliveryDate { get; set; }
        [StringLength(1000)]
        public string BoxNo { get; set; }

        [StringLength(1000)]
        public string BoxName { get; set; }

        /// <summary>
		/// 包装备注
		/// </summary>
        [StringLength(3000)]
        public string BoxRemark { get; set; }

        [StringLength(1000)]
        public string Biaozhun { get; set; }

        [StringLength(500)]
        public string ProductRecipe { get; set; }

        [StringLength(1000)]
        public string ApplyNoState { get; set; }

        [StringLength(1000)]
        public string EmergencyDegree { get; set; }

        [StringLength(3000)]
        public string Remark { get; set; }

        [StringLength(1000)]
        public string ConvertRate { get; set; }

        [StringLength(1000)]
        public string Reserve2 { get; set; }

        [StringLength(1000)]
        public string Reserve3 { get; set; }

        [StringLength(50)]
        public string Reserve4 { get; set; }

        [StringLength(1000)]
        public string Reserve5 { get; set; }

        [StringLength(1000)]
        public string Reserve6 { get; set; }

        [StringLength(1000)]
        public string Reserve7 { get; set; }
        public long CRMPlanHead_Id { get; set; }
        [ForeignKey("CRMPlanHead_Id")]
        public virtual CRMPlanHead CRMPlanHead { get; set; }

        public virtual List<ProPlanOrderheaders> ProPlanOrderheaders { get; set; }
        public virtual List<ProPlanOrderlists> ProPlanOrderlists { get; set; }

        /// <summary>
        /// CRM子订单任务状态：未排产、已下推、生产中、已完成、已终止、冻结、已取消
        /// </summary>
        [StringLength(20)]
        public string crmListStatus { get; set; }

        /// <summary>
        /// CRM子订单任务类型：出口、内销、其他
        /// </summary>
        [StringLength(1000)]
        public string crmListType { get; set; }

    }
}
