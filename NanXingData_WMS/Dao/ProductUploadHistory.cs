using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NanXingData_WMS.Dao
{
    [Table("ProductUploadHistory")]
    public class ProductUploadHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //排产单号、产品名称、上报数量、上报时间、上报人员、上报车间
        public DateTime? Newdate { get; set; }
        public DateTime? Moddate { get; set; }

        [Index]
        [StringLength(30)]
        public string ProductOrder_XuHao { get; set; }
        [StringLength(200)]
        public string ItemName { get; set; }

        [StringLength(20)]
        public string Spec { get; set; }

        [StringLength(20)]
        public string Biaozhun { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        public decimal ProCount { get; set; }

        [StringLength(50)]
        public string Chejianclass { get; set; }

        [StringLength(20)]
        public string UploadUser { get; set; }
        [StringLength(20)]
        public string UploadBatch { get; set; }
        [StringLength(20)]
        public string LiuShuiHao { get; set; }
        [StringLength(20)]
        public string ModUser { get; set; }
    }
}
