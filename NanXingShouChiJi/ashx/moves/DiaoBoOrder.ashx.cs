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
    public class DiaoBoOrder : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);

            string msg = string.Empty;
            string prosn = dic["prosn"];
            //string startPo = dic["startPo"];
            string endPo = dic["endPo"];
            string nowPre = dic["nowPre"];
            string position = dic["position"];
            context.Response.ContentType = "application/json";

            var result = movestockManager.Move(prosn, endPo, nowPre, position, string.Empty);
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