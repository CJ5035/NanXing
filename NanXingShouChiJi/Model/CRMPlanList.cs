//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NanXingShouChiJi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CRMPlanList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRMPlanList()
        {
            this.ProductOrderlists = new HashSet<ProductOrderlists>();
        }
    
        public long ID { get; set; }
        public string CRMApplyNo_Xuhao { get; set; }
        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public string Spec { get; set; }
        public int OrderCount { get; set; }
        public string Unit { get; set; }
        public string InventoryCount { get; set; }
        public decimal OrderCountONkg { get; set; }
        public string BoxNo { get; set; }
        public string BoxName { get; set; }
        public string Biaozhun { get; set; }
        public string ProductRecipe { get; set; }
        public string ApplyNoState { get; set; }
        public string EmergencyDegree { get; set; }
        public string Remark { get; set; }
        public string Reserve2 { get; set; }
        public string Reserve3 { get; set; }
        public string Reserve4 { get; set; }
        public string Reserve5 { get; set; }
        public string Reserve6 { get; set; }
        public string Reserve7 { get; set; }
        public long CRMPlanHead_Id { get; set; }
        public Nullable<System.DateTime> deliveryDate { get; set; }
        public string BoxRemark { get; set; }
        public string crmListStatus { get; set; }
        public string crmListType { get; set; }
        public string CRMApplyList_InCode { get; set; }
        public string ConvertRate { get; set; }
    
        public virtual CRMPlanHead CRMPlanHead { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrderlists> ProductOrderlists { get; set; }
    }
}
