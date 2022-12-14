namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeiXinSetting")]
    public partial class WeiXinSetting
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string key { get; set; }

        [StringLength(200)]
        public string value { get; set; }

        public DateTime? expiraiton_time { get; set; }
    }
}
