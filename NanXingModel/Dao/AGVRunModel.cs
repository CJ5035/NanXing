using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
namespace NanXingModel.Dao
{

    [Table("AGVRunModel")]
    public class AGVRunModel : Entity<int>
    {
        //[Key]
        //public int ID { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WareHouse_ID { get; set; }
        /// <summary>
        /// 任务模板代码
        /// </summary>
        public string AGVModelCode { get; set; }
        /// <summary>
        /// 任务模板描述
        /// </summary>
        public string ModelDesc { get; set; }
        /// <summary>
        /// 发送仓位的字符串格式 
        /// {strat}{middle}{end}
        /// </summary>
        public string OrderPath { get; set; }

        /// <summary>
        /// API返回的仓位  
        /// {strat}{middle}{end}
        /// </summary>
        public string ApiRuturnPath { get; set; }

        [ForeignKey("WareHouse_ID")]
        public virtual WareHouse wareHouse { get; set; }
    }
}
