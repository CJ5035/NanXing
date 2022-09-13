using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Online
    {
        public int Id { get; set; }
        public string Ipadddress { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
