//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NanXingWMS_old.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrayState
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrayState()
        {
            this.TrayPro = new HashSet<TrayPro>();
        }
    
        public int ID { get; set; }
        public string TrayNO { get; set; }
        public System.DateTime optdate { get; set; }
        public int OnlineCount { get; set; }
        public Nullable<int> WareLocation_ID { get; set; }
        public Nullable<decimal> trayHeight { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrayPro> TrayPro { get; set; }
        public virtual WareLocation WareLocation { get; set; }
    }
}
