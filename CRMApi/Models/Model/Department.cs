using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Department
    {
        public Department()
        {
            staff = new HashSet<staff>();
        }

        public string Syscode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Principal { get; set; }
        public string Abstract { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
