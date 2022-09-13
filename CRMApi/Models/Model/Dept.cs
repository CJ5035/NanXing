using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Dept
    {
        public Dept()
        {
            InverseParent = new HashSet<Dept>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SortIndex { get; set; }
        public string Remark { get; set; }
        public int? ParentId { get; set; }

        public virtual Dept Parent { get; set; }
        public virtual ICollection<Dept> InverseParent { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
