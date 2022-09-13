using NanXingService_WMS.Entity.ProductEntity;
using NanXingService_WMS.Services.APS;
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
    /// Get10DaysData 的摘要说明
    /// </summary>
    public class Get10DaysData :BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {


           var query= ProductionService.GetJiTaiBigBoxDateReport
                (DateTime.Now.Date.AddDays(-10), DateTime.Now);
            context.Response.ContentType = "application/json";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            context.Response.Write(JsonConvert.SerializeObject(query, Formatting.Indented, timeFormat));
        }

        
    }
}