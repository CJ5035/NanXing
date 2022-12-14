using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingKanBan_Product.ashx.html2
{
    /// <summary>
    /// GetProOrderTable 的摘要说明
    /// </summary>
    public class GetProOrderTable : BaseAshx
    {
        public override void ProcessRequest(HttpContext context)
        {
            
            Dictionary<string, string> dic = GetDicInJson(context);
            string beforeDays = dic["beforeDays"];
            string afterDays = dic["afterDays"];
            int beforeDay =  Convert.ToInt32(beforeDays);
            int afterDay = Convert.ToInt32(afterDays);


            var runResult= ProductOrderManager.GetOrderReport("生产日期",
                DateTime.Now.AddDays(beforeDay).Date, DateTime.Now.Date.AddDays(afterDay+1).AddMinutes(-1), null,
                null, null, null, null, null, null, null);
            context.Response.ContentType = "application/json";
            //runResult.SetError(msg, StockResult.GetBaseStateCode(msg));
            context.Response.Write(JsonConvert.SerializeObject(runResult));
        }
    }
}