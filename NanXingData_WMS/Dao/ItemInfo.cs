using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingData_WMS.Dao
{
    [Table("ItemInfo")]
    public class ItemInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /// <summary>
        /// 物料编码
        /// name
        /// </summary>
        [Index]
        [StringLength(100)]
        public string ItemNo { get; set; }
        /// <summary>
        /// CRM数据库唯一ID
        /// _id
        /// </summary>
        [StringLength(200)]
        public string CRMID { get; set; }
        /// <summary>
        /// CRM产品名称
        /// product_code
        /// </summary>
        [StringLength(200)]
        public string ItemName { get; set; }

        /// <summary>
        /// 规格属性
        /// product_spec
        /// </summary>
        [StringLength(400)]
        public string Spec { get; set; }

        /// <summary>
        /// 主单位
        /// field_1n4aG__c
        /// </summary>
        [StringLength(100)]
        public string MainUtil { get; set; }
        /// <summary>
        /// 辅助单位
        /// field_owUk6__c
        /// </summary>
        [StringLength(100)]
        public string SlaveUtil { get; set; }
        /// <summary>
        /// 换算率
        /// field_p5rBp__c
        /// </summary>
        public decimal ConvertRate { get; set; }
        /// <summary>
        /// CRM中该物料的创建时间
        /// create_time
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// CRM中该物料的修改时间
        /// last_modified_time
        /// </summary>
        [Index]
        public DateTime ModTime_CRM { get; set; }

        /// <summary>
        /// APS中该物料的记录时间
        /// </summary>
        //[DefaultValue(typeof(DateTime), DateTime.Now.ToString("yyyy-MM-dd")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 产品类别
        /// field_bE9px__c
        /// 字段类型为select one，引用字段
        /// </summary>
        //public string ProType { get; set; }


        /// <summary>
        /// 产品别名
        /// 
        /// </summary>
        [StringLength(200)]
        public string InName { get; set; }


        /// <summary>
        /// 产品原料名称
        /// 
        /// </summary>
        [StringLength(200)]
        public string MaterialItem { get; set; }


        /// <summary>
        /// 工序车间
        /// 
        /// </summary>
        [StringLength(255)]
        public string Workshops { get; set; }

        /// <summary>
        /// APS中最后修改物料资料的人员
        /// </summary>
        [StringLength(50)]
        public string ModUser_APS { get; set; }
        /// <summary>
        /// APS中该物料的修改时间
        /// </summary>
        public DateTime? ModTime_APS { get; set; }
    }
}
