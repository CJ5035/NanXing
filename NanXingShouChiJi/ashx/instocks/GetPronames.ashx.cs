using NanXingShouChiJi.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// GetPronames 的摘要说明
    /// </summary>
    public class GetPronames : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //Debug.WriteLine(System.Threading.Thread.GetDomain().BaseDirectory+ "/res/files/排产工艺名.xls");
            DataTable dt = ExcelUtils.ReadExcel(System.Threading.Thread.GetDomain().BaseDirectory + "/res/files/排产工艺名.xls");
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(dt, new DataTableConverter()));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}