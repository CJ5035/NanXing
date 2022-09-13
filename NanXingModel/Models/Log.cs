using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class Log
    :Entity<int>
{
        //public int Id { get; set; }
        public DateTime Logdate { get; set; }
        public string MarkLogLevel { get; set; } = null!;
        public string? LogMessage { get; set; }
        public string? LogAction { get; set; }
        public string? LogAmount { get; set; }
        public string? StackTrace { get; set; }
    }
}
