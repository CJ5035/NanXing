namespace NanXingModel.Dao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Volo.Abp.Domain.Entities;

    [Table("WareHouse")]
    public partial class WareHouse
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public WareHouse()
        //{
        //    WareArea = new HashSet<WareArea>();
        //}

        public int ID { get; set; }

        [StringLength(50)]
        public string WHName { get; set; }

        [StringLength(50)]
        public string WHPosition { get; set; }

        public bool? WHState { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
        /// <summary>
        /// AGV同楼层搬运模板
        /// </summary>
        [StringLength(20)]
        public string AGVModelCode { get; set; }
        /// <summary>
        /// 楼层AGV的服务器
        /// </summary>
        [StringLength(20)]
        public string AGVServerIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<WareArea> WareArea { get; set; }
        public virtual List<AGVRunModel> AGVRunModel { get; set; }

    }
}
