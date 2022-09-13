using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.Entity
{
    /// <summary>
    /// 状态代码
    /// </summary>
    public class StatusCodeS
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        public static int success = 1000;
        /// <summary>
        /// 请求失败
        /// </summary>
        public static int fail = 1001;
        /// <summary>
        /// 参数错误
        /// </summary>
        public static int paramError = 7000;
        /// <summary>
        /// 其他错误
        /// </summary>
        public static int other = 9999;
    }
}
