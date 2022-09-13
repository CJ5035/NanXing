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
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Onlines = new HashSet<Onlines>();
            this.WareLocation = new HashSet<WareLocation>();
            this.Roles = new HashSet<Roles>();
            this.Titles = new HashSet<Titles>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public string Gender { get; set; }
        public string ChineseName { get; set; }
        public string EnglishName { get; set; }
        public string Photo { get; set; }
        public string QQ { get; set; }
        public string CompanyEmail { get; set; }
        public string OfficePhone { get; set; }
        public string OfficePhoneExt { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string IdentityCard { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<System.DateTime> TakeOfficeTime { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> DeptID { get; set; }
    
        public virtual Depts Depts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Onlines> Onlines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WareLocation> WareLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Roles> Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Titles> Titles { get; set; }
    }
}
