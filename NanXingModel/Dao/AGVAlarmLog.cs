namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("AGVAlarmLog")]
    public partial class AGVAlarmLog  : Entity<int>
    {
        //public int ID { get; set; }

        [StringLength(50)]
        public string deviceNum { get; set; }

        [StringLength(50)]
        public string alarmDesc { get; set; }

        public int? alarmType { get; set; }

        public int? areaId { get; set; }

        public int? alarmReadFlag { get; set; }

        [StringLength(50)]
        public string channelDeviceId { get; set; }

        [StringLength(50)]
        public string alarmSource { get; set; }

        [StringLength(256)]
        public string channelName { get; set; }

        public DateTime? alarmDate { get; set; }

        public DateTime recTime { get; set; }

        [StringLength(50)]
        public string deviceName { get; set; }

        public int? alarmGrade { get; set; }
    }
}
