using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class RolePower
    {
        public int RoleId { get; set; }
        public int PowerId { get; set; }

        public virtual Power Power { get; set; }
        public virtual Role Role { get; set; }
    }
}
