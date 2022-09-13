using NanXingData_WMS.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace NanXingShouChiJi.ashx.outstocks
{
    /// <summary>
    /// ChuKuOrder_HC 的摘要说明
    /// 缓存区到出库车位
    /// </summary>
    public class ChuKuOrder_HC : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            DateTime dtime1 = DateTime.Now;
            Dictionary<string, string> dic = GetDicInJson(context);

            StockPlan sp = new StockPlan();

            //执行存储过程，返回流水号
            var result = liuShuiHaoService.GetOutStockNoLSH();

            sp.PlanNo = result;
            sp.batchNo = dic["batchNo"];
            sp.color = dic["color"];
            sp.count = decimal.Parse(dic["count"]);
            sp.proname = dic["proname"];
            sp.spec = dic["spec"];
            sp.probiaozhun = dic["biaozhun"];
            sp.planUser = dic["nowPer"];
            sp.position = dic["position"];

            sp.mark = "03";
            sp.plantime = DateTime.Now;
            sp.states = "0";

            //stockPlanService.AddStockPlan(sp);

            //1、先获取所有出仓库位
            var runResult = outstockManager.Outstock(sp);
            Debug.WriteLine("出仓所用时间：" + ReckonSeconds(dtime1, DateTime.Now));
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(runResult));
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