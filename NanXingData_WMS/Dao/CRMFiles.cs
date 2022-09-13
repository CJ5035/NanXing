using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingData_WMS.Dao
{
    [Table("CRMFiles")]
    public class CRMFiles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        /// <summary>
        /// CRM内码
        /// </summary>
        [Index]
        [StringLength(1000)]
        public string CRMID { get; set; }

        /// <summary>
        /// 文件位置
        /// </summary>
        [StringLength(1000)]
        public string CRMFilePath { get; set; }

        /// <summary>
        /// 传送时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
