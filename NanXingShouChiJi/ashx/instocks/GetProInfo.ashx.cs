using NanXingData_WMS.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// GetProInfo 的摘要说明
    /// </summary>
    public class GetProInfo : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            //Debug.WriteLine(context.Request.QueryString.Count);
            //Debug.WriteLine(context.Request.Form.Count);
            //Dictionary<string, string> dic = GetDicInJson(context);
            string prosn = context.Request.QueryString["prosn"].ToString().Trim();

            //查询条码信息
            TrayState ts = trayStateService.GetByTrayNo( prosn.Trim());
            ts=(TrayState)trayStateService.ParseValue(ts, typeof(TrayState), false);
            if (ts != null)
            {
                if (ts.WareLocation!=null)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("fail:该条码已进仓，仓位号为 "+ ts.WareLocation.WareLocaNo);
                    return;
                }
                context.Response.ContentType = "application/json";
                context.Response.Write(JsonConvert.SerializeObject(ts));
            }

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