namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    public partial class ProductOrderheaders
    {
       
        public int ID { get; set; }

        [StringLength(50)]
        public string ProductOrderNo { get; set; }
        public DateTime? Newdate { get; set; }

        public DateTime? Moddate { get; set; }

        public DateTime? Optdate { get; set; }

        /// <summary>
        /// 排产单类型：大包装排产单/小包装排产单
        /// </summary>
        [StringLength(50)]
        public string PositionClass { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [StringLength(20)]
        public string orderNo { get; set; }

        [StringLength(255)]
        public string mergeCells { get; set; }

        [StringLength(255)]
        public string mergeCellsValue { get; set; }
        [StringLength(255)]
        public string Workshops { get; set; }

        [StringLength(300)]
        public string WorkshopsValue { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<ProductOrderlists> ProductOrderlists { get; set; }
    }
}
