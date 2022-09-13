using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Title : Entity<int>
    {
        public Title()
        {
            Users = new HashSet<User>();
        }

        //public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Remark { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
