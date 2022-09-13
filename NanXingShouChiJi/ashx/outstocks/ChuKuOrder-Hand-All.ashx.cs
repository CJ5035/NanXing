using NanXingService_WMS.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx.outstocks
{
    /// <summary>
    /// ChuKuOrder_HC2 的摘要说明
    /// </summary>
    public class ChuKuOrder_Hand_All : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);
            string batchNo = dic["batchNo"];
            string userId = dic["nowPer"];

            var result= WareLocationTrayManager.UnBindTrayWarelocationByBatchNo(batchNo, userId);
            RunResult<string> runResult = null;
            if (result)
                runResult = RunResult<string>.True();
            else
                runResult = RunResult<string>.False();
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(runResult));
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