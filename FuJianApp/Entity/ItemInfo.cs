using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingCangKu.Entity
{
    public class ItemInfo
    {
        /// <summary>
        /// 物料编码
        /// name
        /// </summary>
        //[StringLength(100)]
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
    }
}
