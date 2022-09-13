using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Menu : Entity<int>
    {
        public Menu()
        {
            InverseParent = new HashSet<Menu>();
        }

        //public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? NavigateUrl { get; set; }
        public string? Remark { get; set; }
        public int SortIndex { get; set; }
        public int? ParentId { get; set; }
        public int? ViewPowerId { get; set; }

        public virtual Menu? Parent { get; set; }
        public virtual Power? ViewPower { get; set; }
        public virtual ICollection<Menu> InverseParent { get; set; }
    }
}
