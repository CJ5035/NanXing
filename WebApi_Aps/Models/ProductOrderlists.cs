//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCSApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductOrderlists
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOrderlists()
        {
            this.Production = new HashSet<Production>();
        }
    
        public int ID { get; set; }
        public string itemno { get; set; }
        public string name { get; set; }
        public string spec { get; set; }
        public string model { get; set; }
        public string inName { get; set; }
        public string color { get; set; }
        public string material { get; set; }
        public string Class { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> priceOut { get; set; }
        public Nullable<decimal> count { get; set; }
        public string mark { get; set; }
        public Nullable<System.DateTime> optdate { get; set; }
        public string jingbanren { get; set; }
        public string remark1 { get; set; }
        public string providername { get; set; }
        public string clientname { get; set; }
        public Nullable<int> ProductOrderheader_ID { get; set; }
        public Nullable<decimal> length { get; set; }
        public Nullable<decimal> width { get; set; }
        public Nullable<decimal> high { get; set; }
        public string batchNo { get; set; }
        public string boxNo { get; set; }
        public string boxName { get; set; }
        public string ingredients { get; set; }
        public string chejianclass { get; set; }
        public string ERPOrderNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Production> Production { get; set; }
        public virtual ProductOrderheaders ProductOrderheaders { get; set; }
    }
}
