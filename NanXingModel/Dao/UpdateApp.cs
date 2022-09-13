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
    /// 应用列表，方便上传的时间选择应用进行更新
    /// </summary>
    [Table("UpdateApp")]
    public class UpdateApp : Entity<long>
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long ID { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        [StringLength(20)]
        public string App_Name { get; set; }

        /// <summary>
        /// 应用路径
        /// </summary>
        [StringLength(20)]
        public string App_Path { get; set; }

        /// <summary>
        /// 应用类型：winform、ASP
        /// </summary>
        [StringLength(10)]
        public string App_Type { get; set; }

        /// <summary>
        /// 应用版本号：日期+流水号
        /// </summary>
        [StringLength(10)]
        public string App_Version { get; set; }
        /// <summary>
        /// 应用最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 最新版本号
        /// </summary>
        [StringLength(10)]
        public string App_NewVersion { get; set; }

        /// <summary>
        /// 最新版本上传时间
        /// </summary>
        public DateTime LastNewTime { get; set; }
        
    }
}
