using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Department
    {
        public Department()
        {
            staff = new HashSet<staff>();
        }

        public string Syscode { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Principal { get; set; }
        public string? Abstract { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
