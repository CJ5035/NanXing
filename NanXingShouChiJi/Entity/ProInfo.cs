using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.Entity
{
    public class ProInfo
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string proname { get; set; }
        /// <summary>
        /// 产品批号
        /// </summary>
        public string batchNo { get; set; }
        /// <summary>
        /// 产品标准
        /// </summary>
        public string probiaozhun { get; set; }
        /// <summary>
        /// 产品规格
        /// </summary>
        public string spec { get; set; }
        /// <summary>
        /// 产品颜色
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 出货数量
        /// </summary>
        public decimal count { get; set; }

    }
}