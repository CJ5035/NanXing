using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.Entity
{
    //public string success = "success";
    //public string success = "success";

    /// <summary>
    /// WebApi 通用返回值
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 接口返回结果
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 接口返回结果代码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 接口返回结果数据
        /// </summary>
        public string data {get;set;}
        
       

    }

} 
