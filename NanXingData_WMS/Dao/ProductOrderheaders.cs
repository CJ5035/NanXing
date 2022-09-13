namespace NanXingData_WMS.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductOrderheaders")]
    public partial class ProductOrderheaders
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string ProductOrderNo { get; set; }

        public DateTime? Newdate { get; set; }

        public DateTime? Moddate { get; set; }
        /// <summary>
        /// 合并时间
        /// </summary>
        public DateTime? Optdate { get; set; }

        /// <summary>
        /// 排产单类型：大包装生产单/小包装生产单
        /// </summary>
        [StringLength(50)]
        public string OrderClass { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }


        [StringLength(255)]
        public string mergeCellsValue { get; set; }
        [StringLength(255)]
        public string mergeCells { get; set; }

        [StringLength(2550)]
        public string ItemNameStr { get; set; }
        [StringLength(255)]
        public string Workshops { get; set; }

        [StringLength(50)]
        public string OrderNo { get; set; }

        /// <summary>
        /// 打印状态：未打印、已打印
        /// </summary>
        [StringLength(10)]
        public string PrintState { get; set; }
        /// <summary>
        /// 排产单的状态：未生产、生产中、已完成、已删除
        /// </summary>
        [StringLength(10)]
        public string ProductOrder_State { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<ProductOrderlists> ProductOrderlists { get; set; }
    }
}
