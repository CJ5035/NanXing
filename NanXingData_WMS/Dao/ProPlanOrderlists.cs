namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProPlanOrderlists")]
    public partial class ProPlanOrderlists
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(200)]
        public string PlanOrder_XuHao { get; set; }

        [StringLength(50)]
        public string Itemno { get; set; }

        [NotMapped]
        public string Itemno2 { get { return Itemno; }}


        [StringLength(200)]
        public string ItemName { get; set; }

        [StringLength(200)]
        public string InName { get; set; }

        [StringLength(200)]
        public string MaterialItem { get; set; }

        [StringLength(20)]
        public string Spec { get; set; }
        [StringLength(20)]
        public string Biaozhun { get; set; }
        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [StringLength(20)]
        public string Class { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        public decimal? PcCount { get; set; }

        public DateTime? Newdate { get; set; }
        public DateTime? Moddate { get; set; }
        public DateTime? PlanDate { get; set; }
        [StringLength(20)]
        public string PlanTime { get; set; }

        [StringLength(20)]
        public string Jingbanren { get; set; }
        [StringLength(400)]
        public string Remark { get; set; }

        [StringLength(200)]
        public string Clientname { get; set; }

        public int? ProPlanOrderheaders_ID { get; set; }

        [StringLength(100)]
        public string BatchNo { get; set; }

        [StringLength(50)]
        public string BoxNo { get; set; }

        [StringLength(300)]
        public string BoxName { get; set; }
        [StringLength(500)]
        public string BoxRemark { get; set; }

        [StringLength(100)]
        public string Ingredients { get; set; }

        [StringLength(50)]
        public string GiveDept { get; set; }

        [StringLength(1000)]
        public string ProductRecipe { get; set; }

        [StringLength(50)]
        public string Chejianclass { get; set; }

        [StringLength(20)]
        public string ERPOrderNo { get; set; }
        /// <summary>
        /// 排产单的状态：未生产、生产中、已完成、已删除
        /// </summary>
        [StringLength(10)]
        public string PlanOrder_State { get; set; }

        /// <summary>
        /// 打印状态：未打印、已打印
        /// </summary>
        [StringLength(10)]
        public string PrintState { get; set; }
        /// <summary>
        /// 优先级：正常、紧急、加急
        /// </summary>
        [StringLength(10)]
        public string Priority { get; set; }
        public decimal? PcCount_03_Tank { get; set; }
        public decimal? PcCount_03_Bag { get; set; }
        public decimal? PcCount_03_Box { get; set; }
        public decimal? PcCount_07_Tank { get; set; }
        public decimal? PcCount_07_Bag { get; set; }
        public decimal? PcCount_07_Box { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual List<Production> Production { get; set; }
        [ForeignKey("ProPlanOrderheaders_ID")]
        public virtual ProPlanOrderheaders ProPlanOrderheaders { get; set; }

        public virtual List<ProductOrderlists> ProductOrderlists { get; set; }

        public long? CRMPlanList_ID { get; set; }

        [ForeignKey("CRMPlanList_ID")]
        public virtual CRMPlanList crmPlanList { get; set; }
    }
}
