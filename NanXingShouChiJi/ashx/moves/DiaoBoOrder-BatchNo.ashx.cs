using NanXingShouChiJi.Entity;
using NanXingShouChiJi.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// DiaoBoOrder 的摘要说明
    /// </summary>
    public class DiaoBoOrder_BatchNo : BaseAshx
    {
        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);

            string proname = dic["proname"];
            string batchNo = dic["batchNo"];
            string countStr = dic["count"];
            string position = dic["position"];
            string endPosition = dic["endPosition"];
            string userId = dic["nowPer"];
            string huanCun = dic["huancun"];

            context.Response.ContentType = "application/json";
            int count = Convert.ToInt32(countStr);
            var result = movestockManager.MoveBatchNo(batchNo, proname, endPosition,
                userId, position, count, string.Empty,huanCun);
            context.Response.Write(JsonConvert.SerializeObject(result));
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