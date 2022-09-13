using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class TitleUser
    {
        public int TitleId { get; set; }
        public int UserId { get; set; }

        public virtual Title Title { get; set; }
        public virtual User User { get; set; }
    }
}
