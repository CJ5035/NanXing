using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class UpdateApp : Entity<long>
    {
        //public long Id { get; set; }
        public string? AppName { get; set; }
        public string? AppPath { get; set; }
        public string? AppType { get; set; }
        public string? AppVersion { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string? AppNewVersion { get; set; }
        public DateTime LastNewTime { get; set; }
    }
}
