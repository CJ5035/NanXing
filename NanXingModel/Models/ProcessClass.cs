using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class ProcessClass : Entity<int>
    {
        public ProcessClass()
        {
            WorkShopProcesses = new HashSet<WorkShopProcess>();
        }

        //public int Id { get; set; }
        public string? ProcessClassName { get; set; }
        public int ProcessSort { get; set; }
        public string? ProcessReamrk { get; set; }

        public virtual ICollection<WorkShopProcess> WorkShopProcesses { get; set; }
    }
}
