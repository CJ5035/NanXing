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
    public class WorkShopProcess
     : Entity<int>
    {
        //public int ID { get; set; }

        [StringLength(50)]
        /// <summary>
        /// 工序车间名称
        /// </summary>
        public string WorkShopName { get; set; }
        /// <summary>
        /// 工序车间排序
        /// </summary>
        public int WorkShopSort { get; set; }

        /// <summary>
        /// 工序组名ID
        /// </summary>
        public int ProcessClass_Id{ get; set; }
        [ForeignKey("ProcessClass_Id")]
        public virtual ProcessClass processClass { get; set; }
    }
}
