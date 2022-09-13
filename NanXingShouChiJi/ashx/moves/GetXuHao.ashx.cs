using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NanXingShouChiJi.ashx.moves
{
    /// <summary>
    /// GetXuHao 的摘要说明
    /// </summary>
    public class GetXuHao :BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);

            string warearea = dic["warearea"];
            string lie = dic["lie"];

            string line = $"{warearea}-{lie}-";
            var q=wareLocationService.GetIQueryable(u => u.WareLoca_Lie == line
            && u.WareArea.WareAreaClass.AreaClass!="等待区")
                .Select(u => u.WareLoca_Index);
            

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(q));
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