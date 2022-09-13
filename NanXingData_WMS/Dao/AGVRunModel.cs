using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NanXingData_WMS.Dao
{

    [Table("AGVRunModel")]
    public class AGVRunModel
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WareHouse_ID { get; set; }
        /// <summary>
        /// 提升机ID
        /// </summary>
        public int? TiShengJi_ID { get; set; }
        /// <summary>
        /// 任务模板代码
        /// </summary>
        [StringLength(20)]
        public string AGVModelCode { get; set; }

        [StringLength(50)]
        public string AGVModelName { get; set; }
        /// <summary>
        /// 任务模板描述
        /// </summary>
        [StringLength(100)]
        public string ModelDesc { get; set; }
        /// <summary>
        /// 发送仓位的字符串格式 
        /// {strat}{middle}{end}
        /// </summary>
        [StringLength(50)]
        public string SendOrderPath { get; set; }

        /// <summary>
        /// API返回的仓位  
        /// {strat}{middle}{end}
        /// </summary>
        [StringLength(50)]
        public string ApiRuturnPath { get; set; }

        [ForeignKey("WareHouse_ID")]
        public virtual WareHouse wareHouse { get; set; }
        [ForeignKey("TiShengJi_ID")]
        public virtual TiShengJiInfo TiShengJiInfo { get; set; }
    }
}
