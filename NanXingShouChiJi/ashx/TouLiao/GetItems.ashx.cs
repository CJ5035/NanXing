using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx.TouLiao
{
    /// <summary>
    /// GetItems 的摘要说明
    /// </summary>
    public class GetItems :BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
           
            string prosn = context.Request.QueryString["prosn"].ToString().Trim();

            //Productiondt pd = DB2.Productiondt.Where(u => u.ProSn == prosn).FirstOrDefault();
            //Productiondt newdt = new Productiondt();

            //newdt.ProSn = pd.ProSn;

            //newdt.GRADE = pd.GRADE;
            //newdt.LOTNO = pd.LOTNO;
            //newdt.WEIGHT = pd.WEIGHT;
            //newdt.PRODate = pd.PRODate;
            //context.Response.ContentType = "application/json";

            //context.Response.Write(JsonConvert.SerializeObject(newdt));
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