using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx.TouLiao
{
    /// <summary>
    /// AddRecord 的摘要说明
    /// </summary>
    public class AddRecord : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);
            string prosn = dic["prosn"];
            string userID = dic["nowPer"];
            
            //TouLiaoRecord tlr = new TouLiaoRecord();
            //tlr.prosn = prosn;
            //tlr.RecTime = DateTime.Now;
            //tlr.userID = userID;
            //DB2.TouLiaoRecord.Add(tlr);
            context.Response.ContentType = "text/plain";
            context.Response.Write("success");
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