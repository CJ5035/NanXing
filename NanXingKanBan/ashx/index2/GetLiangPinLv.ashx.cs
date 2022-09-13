using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingKanBan.ashx.index2
{
    /// <summary>
    /// GetLiangPinLv 的摘要说明
    /// </summary>
    public class GetLiangPinLv : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            string key2 = "LiangPinLv2";
            string key3 = "LiangPinLv3";
            decimal value2;
            decimal value3;
            if (!RedisHelper.KeyExists(key2))
            {
                value2=random.Next(10)+90;
                RedisHelper.StringSet(key2, value2,
                     DateTime.Now.AddHours(1));
                
            }
            else
                value2=decimal.Parse(RedisHelper.StringGet(key2));
            if (!RedisHelper.KeyExists(key3))
            {
                value3=random.Next(10)+90;
                RedisHelper.StringSet(key3, value3,
                    DateTime.Now.AddHours(1));
            }else
                value3=decimal.Parse(RedisHelper.StringGet(key3));
            decimal[] values = new decimal[2] { value2, value3 };
            context.Response.ContentType = "application/json";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            context.Response.Write(JsonConvert.SerializeObject(values, Formatting.Indented, timeFormat));
        }
    }
}