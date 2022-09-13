using NanXingData_WMS.Dao;
using NanXingService_WMS.Services;
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
    /// GetPressValue 的摘要说明
    /// 获取120分钟之内的平均数据
    /// </summary>
    public class GetPressValue : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            DateTime dateTime = DateTime.Now.AddMinutes(-120);

            var q=SensorDataService.GetAgvThermostatList(dateTime);
            
            context.Response.ContentType = "application/json";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            context.Response.Write(JsonConvert.SerializeObject(q, Formatting.Indented, timeFormat));
        }

     
    }
}