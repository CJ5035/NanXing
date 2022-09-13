using NanXingData_WMS.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// GetProInfo2 的摘要说明
    /// </summary>
    public class GetProInfo2 :BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            string prosn = context.Request.QueryString["prosn"].ToString().Trim();

            //查询条码信息

            TrayState ts= trayStateService.GetByTrayNo(prosn);
            ts = (TrayState)trayStateService.ParseValue(ts, typeof(TrayState), false);
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(ts));
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