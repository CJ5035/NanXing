using NanXingService_WMS.Entity.InstockEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx.outstocks
{
    /// <summary>
    /// GetOutPros_HC 的摘要说明
    /// 获取缓存位中的产品批号信息
    /// </summary>
    public class GetOutPros_HC : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);
            string position = dic["position"];
            
            List<StockProItem> q = outstockManager.GetPros(position, true);

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(q));
        }

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}