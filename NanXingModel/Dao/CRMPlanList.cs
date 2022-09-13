namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("CRMPlanList")]
    public partial class CRMPlanList : Entity<long>
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long ID { get; set; }

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
        public DateTime? deliveryDate { get; set; }
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

        public List<ProductOrderlists> ProductOrderlists { get; set; }

        /// <summary>
        /// CRM子订单任务状态：未排产、已排产、生产中、已完成、已终止、冻结、已取消
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
