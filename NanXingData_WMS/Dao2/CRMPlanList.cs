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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRMPlanList()
        {
            ProductOrderlists = new HashSet<ProductOrderlists>();
        }

        public long ID { get; set; }

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

        [StringLength(1000)]
        public string BoxNo { get; set; }

        [StringLength(1000)]
        public string BoxName { get; set; }

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

        public DateTime? deliveryDate { get; set; }

        [StringLength(3000)]
        public string BoxRemark { get; set; }

        [StringLength(20)]
        public string crmListStatus { get; set; }

        [StringLength(1000)]
        public string crmListType { get; set; }

        [StringLength(1000)]
        public string CRMApplyList_InCode { get; set; }

        [StringLength(1000)]
        public string ConvertRate { get; set; }

        public virtual CRMPlanHead CRMPlanHead { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrderlists> ProductOrderlists { get; set; }
    }
}
