using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingService_WMS.Managers;
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
using System.Web.Compilation;

namespace NanXingKanBan.ashx.html2
{
    /// <summary>
    /// GetPCDData 的摘要说明
    /// </summary>
    public class GetPCDData : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);
            string beforeDays = dic["beforeDays"];
            string afterDays = dic["afterDays"];
            int beforeDay = Convert.ToInt32(beforeDays);
            int afterDay = Convert.ToInt32(afterDays);
            DateTime sDateTime = DateTime.Now.AddDays(beforeDay);
            DateTime eDateTime = DateTime.Now.AddDays(afterDay);

            
            var q=CRMPlanManager.GetMissionControlIndex(sDateTime, eDateTime);
            context.Response.ContentType = "application/json";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            context.Response.Write(JsonConvert.SerializeObject(q, Formatting.Indented, timeFormat));
        }

        
    }
}