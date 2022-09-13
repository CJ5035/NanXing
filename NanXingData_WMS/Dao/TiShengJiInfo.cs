namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// 提升机基本参数
    /// </summary>
    [Table("TiShengJiInfo")]
    public partial class TiShengJiInfo
    {
        public int ID { get; set; }
        [StringLength(20)]
        public string TsjName { get; set; }
        [StringLength(25)]
        public string TsjIp{ get; set; }

        public int TsjPort { get; set; }

        public DateTime InputTime { get; set; }

        /// <summary>
        /// WHName ,用逗号分割
        /// </summary>
        [StringLength(200)]
        public string Floors { get; set; }

        [StringLength(20)]
        public string TsjPosition_1F { get; set; }
        [StringLength(20)]
        public string TsjPosition_2F { get; set; }
        [StringLength(20)]
        public string TsjPosition_3F { get; set; }

        /// <summary>
        /// 将托盘搬进提升机的任务模板
        /// </summary>
        [StringLength(20)]
        public string TsjInModel_1F { get; set; }
        [StringLength(20)]
        public string TsjInModel_2F { get; set; }
        [StringLength(20)]
        public string TsjInModel_3F { get; set; }

        [StringLength(20)]
        public string TsjOutModel_1F { get; set; }
        [StringLength(20)]
        public string TsjOutModel_2F { get; set; }
        [StringLength(20)]
        public string TsjOutModel_3F { get; set; }

        /// <summary>
        /// 提升机跨楼层AGV的服务器
        /// </summary>
        [StringLength(20)]
        public string AGVServerIP { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsOpen { get; set; }
    }
}
