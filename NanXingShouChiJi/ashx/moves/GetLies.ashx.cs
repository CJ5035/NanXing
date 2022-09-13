using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx.moves
{
    /// <summary>
    /// GetLies 的摘要说明
    /// </summary>
    public class GetLies : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);

            string warearea = dic["warearea"];
            List<string> q=wareLocationService.GetIQueryable(u => u.WareArea.WareNo == warearea)
                .GroupBy(u => u.WareLoca_Lie).Select(u => u.Key).ToList<string>();
          
            for(int i = 0; i < q.Count; i++)
            {
                q[i]= q[i].Split('-')[1];
            }
            q=q.OrderBy(u => u.Length).ThenBy(u=>u).ToList();
            //var q = from a in DB2.WareLocation
            //        where a.WareArea.WareNo == warearea
            //        && a.WareLocaNo.Contains("-")
            //        group a by new
            //        {
            //            id =a.WareLocaNo.Substring(a.WareLocaNo.IndexOf("-") + 1, a.WareLocaNo.Length - a.WareLocaNo.IndexOf("-") - 1)
            //            .Substring(0, 
            //             a.WareLocaNo.Substring(a.WareLocaNo.IndexOf("-") + 1, a.WareLocaNo.Length - a.WareLocaNo.IndexOf("-") - 1).IndexOf("-"))
            //        } into g
            //        orderby 
            //            g.Key.id.Length ascending, g.Key.id ascending
            //        select new {
            //            lie = g.Key.id
            //        }; 

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