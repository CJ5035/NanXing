using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Log
    {
        public int Id { get; set; }
        public DateTime Logdate { get; set; }
        public string MarkLogLevel { get; set; }
        public string LogMessage { get; set; }
        public string LogAction { get; set; }
        public string LogAmount { get; set; }
        public string StackTrace { get; set; }
    }
}
