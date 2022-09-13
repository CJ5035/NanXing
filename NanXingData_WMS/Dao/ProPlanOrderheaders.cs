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
        /// �ϲ�ʱ��
        /// </summary>
        public DateTime? Optdate { get; set; }

        /// <summary>
        /// �Ų������ͣ����װ�Ų���/С��װ�Ų���
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

        //��¼��Ʒ��Ϣ

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
        /// ��������
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
