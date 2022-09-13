using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NanXingKanBan.ashx.html2
{
    /// <summary>
    /// GetJiTaiCLData 的摘要说明
    /// </summary>
    public class GetJiTaiCLData :BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {

            DateTime dateTime = DateTime.Now.AddMinutes(-120);
            var query= ProductionService.GetJiTaiBigBoxHourReport(DateTime.Now.Date, DateTime.Now.Date.AddDays(1).AddMinutes(-1));
            context.Response.ContentType = "application/json";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            context.Response.Write(JsonConvert.SerializeObject(query, Formatting.Indented, timeFormat));
        }

        
    }
}