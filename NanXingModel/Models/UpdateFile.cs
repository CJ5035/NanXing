using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class UpdateFile : Entity<long>
    {
        //public long Id { get; set; }
        public string? AppName { get; set; }
        public string? AppVersion { get; set; }
        public DateTime UpdateTime { get; set; }
        public string? FileName { get; set; }
        public int FileLength { get; set; }
        public string? FilePath { get; set; }
    }
}
