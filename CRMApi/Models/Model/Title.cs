using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Title
    {
        public Title()
        {
            TitleUsers = new HashSet<TitleUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<TitleUser> TitleUsers { get; set; }
    }
}
