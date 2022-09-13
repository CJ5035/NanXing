namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Text;

    [Table("AGVAlarmLog")]
    public partial class AGVAlarmLog
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string deviceNum { get; set; }

        [StringLength(1000)]
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}:[\r\n");
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(this.GetType()))
            {
                //Type proType = pd.PropertyType.Name == "Nullable`1" ? pd.PropertyType.GenericTypeArguments[0] : pd.PropertyType;
                sb.Append($"{pd.Name}:{pd.GetValue(this)}\r\n");
            }
            sb.Append($"]\r\n");
            return sb.ToString();
        }
    }
}
