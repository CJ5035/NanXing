namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProPlanOrderheaders")]
    public partial class ProPlanOrderheaders
    {
       
        public int ID { get; set; }

        [StringLength(50)]
        public string PlanOrderNo { get; set; }
        public DateTime? Newdate { get; set; }

        public DateTime? Moddate { get; set; }
        /// <summary>
        /// 合并时间
        /// </summary>
        public DateTime? Optdate { get; set; }

        /// <summary>
        /// 排产单类型：大包装排产单/小包装排产单
        /// </summary>
        [StringLength(50)]
        public string PositionClass { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }


        [StringLength(255)]
        public string mergeCellsValue { get; set; }
        [StringLength(255)]
        public string mergeCells { get; set; }

        
        [StringLength(255)]
        public string Workshops { get; set; }

        [StringLength(50)]
        public string OrderNo { get; set; }

        //记录成品信息

        [StringLength(50)]
        public string Itemno { get; set; }

        [StringLength(200)]
        public string ItemName { get; set; }

        [StringLength(20)]
        public string Spec { get; set; }
        

        [StringLength(20)]
        public string Color { get; set; }

        [StringLength(20)]
        public string ProductionClass { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        public decimal? PcCount { get; set; }

        [StringLength(50)]
        public string BoxNo { get; set; }

        [StringLength(300)]
        public string BoxName { get; set; }
        [StringLength(500)]
        public string BoxRemark { get; set; }

        /// <summary>
        /// 交付日期
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        public DateTime? PlanDate { get; set; }
        [StringLength(100)]
        public string BatchNo { get; set; }
        [StringLength(20)]
        public string Biaozhun { get; set; }

        [StringLength(20)]
        public string Jingbanren { get; set; }

        [StringLength(200)]
        public string Clientname { get; set; }

        public long? CRMPlanList_ID { get; set; }

        [ForeignKey("CRMPlanList_ID")]
        public virtual CRMPlanList crmPlanList { get; set; }


        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<ProPlanOrderlists> ProPlanOrderlists { get; set; }
    }
}
