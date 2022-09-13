using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// NewInstockPlan 的摘要说明
    /// </summary>
    public class NewInstockPlan : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string,string> dic= GetDicInJson(context);
            string name = dic["selectPro"];
            string batchNo = dic["newBatchNo"];
            string count = dic["newTuoCount"];
            string nowPer = dic["nowPerson"];

            //StockPlan sp = new StockPlan();
            //Type t = typeof(string);
            //SqlParameter[] sqlParms = new SqlParameter[1];
            //sqlParms[0] = new SqlParameter("@MaintainCate", "Out");

            //var result = DB2.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();
            //sp.PlanNo = result;
            //sp.proname = name;
            //sp.batchNo = batchNo;
            //sp.count = Convert.ToInt32(count);
            //sp.mark = "02";
            //sp.states = "0";
            //sp.plantime = DateTime.Now;
            //sp.planUser = nowPer;
            //DB2.StockPlan.Add(sp);
            //DB2.SaveChanges();

            //context.Response.ContentType = "text/plain";
            //context.Response.Write("success:"+ sp.ID);
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