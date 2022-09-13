namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeviceStatesInfo")]
    public partial class DeviceStatesInfo
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string deviceCode { get; set; }

        [StringLength(50)]
        public string payLoad { get; set; }

        [StringLength(50)]
        public string devicePostionRec { get; set; }

        [StringLength(50)]
        public string devicePosition { get; set; }

        [StringLength(50)]
        public string battery { get; set; }

        [StringLength(50)]
        public string deviceName { get; set; }

        public int? deviceStatusInt { get; set; }

        [StringLength(50)]
        public string deviceStatus { get; set; }

        public DateTime recTime { get; set; }

        [StringLength(10)]
        public string devicePostionX { get; set; }

        [StringLength(10)]
        public string devicePostionY { get; set; }
    }
}
