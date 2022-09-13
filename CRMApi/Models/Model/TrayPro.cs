using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class TrayPro
    {
        public int Id { get; set; }
        public DateTime Optdate { get; set; }
        public int TrayStateId { get; set; }
        public string Prosn { get; set; }

        public virtual TrayState TrayState { get; set; }
    }
}
