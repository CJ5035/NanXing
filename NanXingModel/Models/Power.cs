using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Power : Entity<int>
    {
        public Power()
        {
            Menus = new HashSet<Menu>();
            Roles = new HashSet<Role>();
        }

        //public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? GroupName { get; set; }
        public string? Title { get; set; }
        public string? Remark { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
