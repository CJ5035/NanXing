namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    public partial class TelenClients
     : Entity<int>
  {
        //public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string levelCode { get; set; }

        public DateTime? serverTime { get; set; }

        [StringLength(50)]
        public string condiction { get; set; }

        [StringLength(50)]
        public string remark { get; set; }

        [StringLength(50)]
        public string fax { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string bank { get; set; }

        [StringLength(50)]
        public string Eamil { get; set; }

        [StringLength(20)]
        public string Number { get; set; }

        public string clientManager { get; set; }

        public string implementer { get; set; }

        public string gendan { get; set; }

        public string nickname { get; set; }

        public string openid { get; set; }
    }
}
