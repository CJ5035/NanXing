using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Dept : Entity<int>
    {
        public Dept()
        {
            InverseParent = new HashSet<Dept>();
            Users = new HashSet<User>();
        }

        //public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SortIndex { get; set; }
        public string? Remark { get; set; }
        public int? ParentId { get; set; }

        public virtual Dept? Parent { get; set; }
        public virtual ICollection<Dept> InverseParent { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
