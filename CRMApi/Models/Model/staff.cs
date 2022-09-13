using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class staff
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public string Idcard { get; set; }
        public string Address { get; set; }
        public string Edured { get; set; }
        public string Telephone { get; set; }
        public DateTime? Indate { get; set; }
        public DateTime? Demdate { get; set; }
        public int? Posstate { get; set; }
        public string Department { get; set; }
        public string Authorgrp { get; set; }
        public decimal? Workcls { get; set; }
        public string Bank { get; set; }
        public string Account { get; set; }
        public decimal? Timepay { get; set; }
        public decimal? Basepay { get; set; }
        public string Abstract { get; set; }
        public string Password { get; set; }

        public virtual Department DepartmentNavigation { get; set; }
    }
}
