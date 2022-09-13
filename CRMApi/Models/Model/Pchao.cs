using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class Pchao
    {
        public int Id { get; set; }
        public string Lotno { get; set; }
        public string Oper { get; set; }
        public int? Flag { get; set; }
    }
}
