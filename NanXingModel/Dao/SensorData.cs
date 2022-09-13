using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Dao
{
    /// <summary>
    /// 生产设备参数
    /// </summary>
    [Table("SensorData")]
    public class SensorData : Entity<int>
    {
        /// <summary>
        /// 主键
        ///</summary>
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ID { get; set; }

        /// <summary>
        /// 楼层
        /// </summary>
        [MaxLength(10)]
        public string Floor { get; set; }

        /// <summary>
        /// 更新时间
        ///</summary>
        public DateTime? RefleshTime { get; set; }
        /// <summary>
        /// 电表数据1
        ///</summary>
        public float Ammeter1 { get; set; }
        /// <summary>
        /// 电表数据2
        ///</summary>
        public float Ammeter2 { get; set; }
        /// <summary>
        /// 电表数据3
        ///</summary>
        public float Ammeter3 { get; set; }
        /// <summary>
        /// 湿度
        ///</summary>
        public float Humidity { get; set; }
        /// <summary>
        /// 温度
        ///</summary>
        public float Temperature { get; set; }
        /// <summary>
        /// 噪音
        ///</summary>
        public float Noise { get; set; }
        /// <summary>
        /// 有毒气体
        ///</summary>
        public float ToxicGas { get; set; }
        /// <summary>
        /// 烟囱温度1——炉前温度
        ///</summary>
        public float StackTemp1 { get; set; }
        /// <summary>
        /// 燃烧室温度——炉前温度
        ///</summary>
        public float ChamberTemp1 { get; set; }
        /// <summary>
        /// 烟囱温度2——炉中温度
        ///</summary>
        public float StackTemp2 { get; set; }
        /// <summary>
        /// 燃烧室温度——炉中温度
        ///</summary>
        public float ChamberTemp2 { get; set; }
        /// <summary>
        /// 烟囱温度3——炉后温度
        ///</summary>
        public float StackTemp3 { get; set; }
        /// <summary>
        /// 燃烧室温度——炉后温度
        ///</summary>
        public float ChamberTemp3 { get; set; }
        /// <summary>
        /// 柴油流量
        ///</summary>
        public float? DieselOilFlow { get; set; }

    }
}
