using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class CrmplanHead : Entity<long>
    {
        public CrmplanHead()
        {
            CrmplanLists = new HashSet<CrmplanList>();
        }

        //public long Id { get; set; }
        public string? CrmapplyNo { get; set; }
        public string? ClientNo { get; set; }
        public string? ClientName { get; set; }
        public string? ApplicantId { get; set; }
        public string? ApplicantName { get; set; }
        public string? ApplicantPhone { get; set; }
        public string? ApplicantDept { get; set; }
        public string? ApplicantJob { get; set; }
        public DateTime? ApplyTime { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? SaleGroup { get; set; }
        public string? OrderSource { get; set; }
        public byte[]? Photo { get; set; }
        public string? Remark { get; set; }
        public string? Reserve1 { get; set; }
        public string? Reserve2 { get; set; }
        public string? Reserve3 { get; set; }
        public string? MakeClass { get; set; }

        public virtual ICollection<CrmplanList> CrmplanLists { get; set; }
    }
}
