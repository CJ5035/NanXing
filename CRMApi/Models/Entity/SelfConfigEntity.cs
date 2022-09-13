using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.Entity
{
    /// <summary>
    /// 自定义的配置文件数据
    /// </summary>
    public class SelfConfigEntity
    {

        /// <summary>
        /// 上传功能的信息实例
        /// </summary>
        public UpfileInfo upfileInfo { get; set; }
    }
    /// <summary>
    /// 上传功能的信息类
    /// </summary>
    public class UpfileInfo
    {

        /// <summary>
        /// 上传文件的保存路径
        /// </summary>
        public string uploadFilePath { get; set; }
    }
}
