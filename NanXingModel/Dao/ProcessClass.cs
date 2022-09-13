using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Dao
{
    public class ProcessClass
     : Entity<int>
    {
        //public int ID { get; set; }
        [StringLength(50)]
        /// <summary>
        /// 工序组名
        /// </summary>
        public string ProcessClassName { get; set; }
        /// <summary>
        /// 工序分组排序
        /// </summary>
        public int ProcessSort { get; set; }

        [StringLength(300)]
        /// <summary>
        /// 工序组名备注
        /// </summary>
        public string ProcessReamrk { get; set; }


        public virtual List<WorkShopProcess> workShopProcessList { get; set; }

        public string ProcessClassSortName
        {
            get
            {
                return ParseSortName();
            }
        }

        public string ParseSortName()
        {
            return ProcessSort.ToString("D2") + "." + ProcessClassName;
        }
    }
}
