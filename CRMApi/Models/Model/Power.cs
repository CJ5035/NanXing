using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Power
    {
        public Power()
        {
            Menus = new HashSet<Menu>();
            RolePowers = new HashSet<RolePower>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<RolePower> RolePowers { get; set; }
    }
}
