using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class RoleUser
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
