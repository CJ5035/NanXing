//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCSApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log
    {
        public int ID { get; set; }
        public System.DateTime Logdate { get; set; }
        public string MarkLogLevel { get; set; }
        public string LogMessage { get; set; }
        public string LogAction { get; set; }
        public string LogAmount { get; set; }
        public string StackTrace { get; set; }
    }
}
