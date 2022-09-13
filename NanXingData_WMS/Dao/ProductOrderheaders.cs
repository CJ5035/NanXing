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
        /// �ϲ�ʱ��
        /// </summary>
        public DateTime? Optdate { get; set; }

        /// <summary>
        /// �Ų������ͣ����װ������/С��װ������
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
        /// ��ӡ״̬��δ��ӡ���Ѵ�ӡ
        /// </summary>
        [StringLength(10)]
        public string PrintState { get; set; }
        /// <summary>
        /// �Ų�����״̬��δ�����������С�����ɡ���ɾ��
        /// </summary>
        [StringLength(10)]
        public string ProductOrder_State { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<ProductOrderlists> ProductOrderlists { get; set; }
    }
}
