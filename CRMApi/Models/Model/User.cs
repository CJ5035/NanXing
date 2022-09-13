using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class User
    {
        public User()
        {
            Onlines = new HashSet<Online>();
            RoleUsers = new HashSet<RoleUser>();
            TitleUsers = new HashSet<TitleUser>();
            WareLocations = new HashSet<WareLocation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public string Gender { get; set; }
        public string ChineseName { get; set; }
        public string EnglishName { get; set; }
        public string Photo { get; set; }
        public string Qq { get; set; }
        public string CompanyEmail { get; set; }
        public string OfficePhone { get; set; }
        public string OfficePhoneExt { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string IdentityCard { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? TakeOfficeTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? DeptId { get; set; }

        public virtual Dept Dept { get; set; }
        public virtual ICollection<Online> Onlines { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }
        public virtual ICollection<TitleUser> TitleUsers { get; set; }
        public virtual ICollection<WareLocation> WareLocations { get; set; }
    }
}
