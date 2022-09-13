using NanXingData_WMS.Dao;
using NanXingService_WMS.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// GetInstockWLs 的摘要说明
    /// </summary>
    public class GetInstockWLs : BaseAshx
    {
        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);
            Debug.WriteLine(context.Request.QueryString.Count);
            string trayNoStr = context.Request.QueryString["trayNo"];
            string position = context.Request.QueryString["position"];
            string user=context.Request.QueryString["user"];
            WareLocation wl=instockManager.GetWL(trayNoStr, position, user);

            context.Response.ContentType = "application/json";
            if (wl==null)
            {
                context.Response.Write(JsonConvert.SerializeObject(RunResult<string>.False(
                    "获取仓位失败，是请联系管理员\r\n失败原因：\r\n1、网络问题\r\n2、仓位已满")));
                return;
            }
            context.Response.Write(JsonConvert.SerializeObject(RunResult<string>.True(wl.WareLocaNo)));
            //context.Response.Write(JsonConvert.SerializeObject(dt, new DataTableConverter()));
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