//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NanXingShouChiJi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockPlan
    {
        public int ID { get; set; }
        public string PlanNo { get; set; }
        public string proname { get; set; }
        public string batchNo { get; set; }
        public string probiaozhun { get; set; }
        public string spec { get; set; }
        public Nullable<decimal> count { get; set; }
        public System.DateTime plantime { get; set; }
        public string planUser { get; set; }
        public string states { get; set; }
        public string color { get; set; }
        public string mark { get; set; }
        public string position { get; set; }
    }
}
