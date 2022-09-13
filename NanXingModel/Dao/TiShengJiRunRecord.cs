using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;
    /// <summary>
    /// 提升机基本参数
    /// </summary>
    [Table("TiShengJiRunRecord")]
    public class TiShengJiRunRecord
     : Entity<int>
  {
        //public int ID { get; set; }
        [StringLength(20)]
        public string TsjName { get; set; }
        [StringLength(25)]
        public string TsjIp { get; set; }
        public int TsjPort { get; set; }
        public DateTime OrderTime { get; set; }
        /// <summary>
        /// 提升机任务携带的托盘数量
        /// </summary>
        public int TrayCount { get; set; }
        /// <summary>
        /// 提升机任务起始楼层
        /// </summary>
        [StringLength(20)]
        public string StartFloor { get; set; }

        /// <summary>
        /// 提升机任务终点楼层
        /// </summary>
        [StringLength(20)]
        public string EndFloor { get; set; }

        /// <summary>
        /// 最里面的托盘号
        /// </summary>
        [StringLength(20)]
        public string InsideTrayNo { get; set; }

        /// <summary>
        /// 靠外面的托盘号
        /// </summary>
        [StringLength(20)]
        public string OutsideTrayNo { get; set; }

        public virtual List<AGVMissionInfo_Floor> AGVMissionInfo_Floor { get; set; }
    }
}
