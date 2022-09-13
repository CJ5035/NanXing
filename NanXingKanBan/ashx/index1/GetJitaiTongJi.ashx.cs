using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NanXingKanBan.ashx.index1
{
    /// <summary>
    /// GetJitaiTongJi 的摘要说明
    /// </summary>
    public class GetJitaiTongJi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string sql = string.Format(@"  select case when States=0 then '待机' when States=1 then '运行'
  when States=2 then '检修' when States=3 then '故障' end name
  ,COUNT(States) value  from [KeLe].[dbo].[PositionInfo] group by States
  order by name");
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            context.Response.ContentType = "application/json";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            context.Response.Write(JsonConvert.SerializeObject(dt, Formatting.Indented, timeFormat));
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