using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Role
    {
        public Role()
        {
            RolePowers = new HashSet<RolePower>();
            RoleUsers = new HashSet<RoleUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<RolePower> RolePowers { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
