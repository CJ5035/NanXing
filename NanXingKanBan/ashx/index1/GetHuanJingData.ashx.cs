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
    /// GetHuanJingData 的摘要说明
    /// </summary>
    public class GetHuanJingData : BaseAshx
    {

        public override  void ProcessRequest(HttpContext context)
        {
            //string sql = @"SELECT Ammeter1,Humidity,Temperature,Noise,ToxicGas FROM dbo.[SensorStorey3] WHERE ID=(SELECT MAX(ID) FROM dbo.[SensorStorey3]) ";

            var q = SensorDataService.GetLastSensorData();
            
            context.Response.ContentType = "application/json";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            context.Response.Write(JsonConvert.SerializeObject(q, Formatting.Indented, timeFormat));
        }

    }
}