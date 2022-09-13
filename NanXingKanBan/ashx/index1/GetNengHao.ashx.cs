﻿using Newtonsoft.Json;
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
    /// GetNengHao 的摘要说明
    /// </summary>
    public class GetNengHao : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            DateTime dateTime = DateTime.Now.AddMinutes(-120);

            var q =SensorDataService.GetNengHaoList(dateTime);
            context.Response.ContentType = "application/json";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            context.Response.Write(JsonConvert.SerializeObject(q, Formatting.Indented, timeFormat));
        }

      
    }
}