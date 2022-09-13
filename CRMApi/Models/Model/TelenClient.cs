using System;
using System.Collections.Generic;

#nullable disable

namespace CRMApi.Entity
{
    public partial class TelenClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LevelCode { get; set; }
        public DateTime? ServerTime { get; set; }
        public string Condiction { get; set; }
        public string Remark { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Bank { get; set; }
        public string Eamil { get; set; }
        public string Number { get; set; }
        public string ClientManager { get; set; }
        public string Implementer { get; set; }
        public string Gendan { get; set; }
        public string Nickname { get; set; }
        public string Openid { get; set; }
    }
}
