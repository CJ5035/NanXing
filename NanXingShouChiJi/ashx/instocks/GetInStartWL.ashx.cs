
using NanXingData_WMS.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NanXingService_WMS.Utils;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// GetInStartWL 的摘要说明
    /// </summary>
    public class GetInStartWL : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);
            string position = dic["position"];
            //int positionID = Convert.ToInt32(position);
            List<WareLocation> list = instockManager.GetInStartWls(string.Empty, position);
           
            List<WareLocation> list2 = wareLocationService.ConvertList(list);
           

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(list2));
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