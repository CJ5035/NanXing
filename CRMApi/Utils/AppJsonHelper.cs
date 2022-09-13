using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CRMApi.Models.Entity;

namespace CRMApi.Utils
{
    /// <summary>
    /// 读取配置文件到缓存中，或从缓存中取出配置信息
    /// </summary>
    public class AppJsonHelper
    {
        /// <summary>
        /// 将配置文件内容放进缓存中
        /// </summary>
        /// <returns></returns>
        public static SelfConfigEntity InitJsonModel()
        {
            string key = "key_myjsonfilekey";
            SelfConfigEntity cachemodel = SystemCacheHelper.Get<SelfConfigEntity>(key);
            if (cachemodel == null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                var broot = builder.AddJsonFile("./Config/SelfConfig.json").Build();
                cachemodel = broot.GetSection("jwtconfig").Get<SelfConfigEntity>();
                SystemCacheHelper.Set(key, cachemodel);
            }
            return cachemodel;
        }

        /// <summary>
        /// 获取到配置文件内容的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonName">jason 配置文件中内容节点</param>
        /// <param name="jsonFilePath">./configs/zrfjwt.json  json文件的路径需要始终赋值一下</param>
        /// <returns></returns>
        public static T GetJsonModelByFilePath<T>(string jsonName, string jsonFilePath)
        {
            if (!string.IsNullOrEmpty(jsonName))
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                var broot = builder.AddJsonFile(jsonFilePath).Build();
                T model = broot.GetSection(jsonName).Get<T>();
                return model;
            }
            return default;
        }
    }
}
