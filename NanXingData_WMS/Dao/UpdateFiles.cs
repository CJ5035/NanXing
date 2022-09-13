using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingData_WMS.Dao
{
    /// <summary>
    /// 文件列表，方便上传的时间选择应用进行更新
    /// </summary>
    [Table("UpdateFiles")]
    public class UpdateFiles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        /// <summary>
        /// 文件关联的应用名称
        /// </summary>
        [StringLength(20)]
        public string App_Name { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [StringLength(20)]
        public string App_Version { get; set; }
        /// <summary>
        /// 应用最后更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        [StringLength(50)]
        public string FileName { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        //[StringLength(50)]
        public int FileLength { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [StringLength(120)]
        public string FilePath { get; set; }
    }
}
