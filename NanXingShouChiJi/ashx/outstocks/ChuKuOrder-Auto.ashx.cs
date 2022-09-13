using NanXingData_WMS.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace NanXingShouChiJi.ashx.outstocks
{
    /// <summary>
    /// ChuKuOrder_Auto 的摘要说明
    /// 自动出库：从成品区到缓存区的出库功能
    /// </summary>
    public class ChuKuOrder_Auto :BaseAshx
    {
        string msg = string.Empty;
        public override void ProcessRequest(HttpContext context)
        {
            DateTime dtime1 = DateTime.Now;
            Dictionary<string, string> dic = GetDicInJson(context);

            StockPlan sp = new StockPlan();

            //执行存储过程，返回流水号
            var result = liuShuiHaoService.GetOutStockNoLSH();

            sp.PlanNo = result;
            sp.batchNo= dic["batchNo"];
            sp.color= dic["color"];
            sp.count= decimal.Parse(dic["count"]);
            sp.proname = dic["proname"];
            sp.spec = dic["spec"];
            sp.probiaozhun = dic["biaozhun"];
            sp.planUser= dic["nowPer"];
            sp.position= dic["position"];
            //存在position 同层出仓，判断position==1与为空则为05，position 为2 则为03
            if(sp.position=="07二楼")
                sp.mark = "03";
            else
                sp.mark = "05";
            sp.plantime = DateTime.Now;
            sp.states = "0";

            var runResult=outstockManager.Outstock(sp);
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
        //AGVInfUtils au = new AGVInfUtils(DB2);

    }
}