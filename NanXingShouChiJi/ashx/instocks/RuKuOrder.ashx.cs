using NanXingData_WMS.Dao;
using NanXingService_WMS.Entity.StockEntity;
using NanXingShouChiJi.Entity;
using NanXingShouChiJi.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UtilsSharp.Standard;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// RuKuOrder 的摘要说明
    /// </summary>
    public class RuKuOrder :BaseAshx
    {
        public override void ProcessRequest(System.Web.HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var result = new BaseResult<string>();
            Dictionary<string, string> dic = GetDicInJson(context);
           
            string msg = string.Empty;
            string prosn = dic["prosn"];
            string startPo = dic["startPo"];
            string endPo = dic["endPo"];
            string nowPre = dic["nowPre"];
            string position = dic["position"];

            
            //int positionId = !string.IsNullOrEmpty(position) ? Convert.ToInt32(position) : 0;
            if (!instockManager.Instock(startPo, prosn, nowPre, position, string.Empty,ref msg,endPo))
            {
                result.SetError(msg, StockResult.GetBaseStateCode(msg));
                context.Response.Write(JsonConvert.SerializeObject(result));
                return;
            }
            result.SetOk();
            context.Response.Write(JsonConvert.SerializeObject(result));
        }
        

        /// <summary>
        /// 发送调用AGV
        /// </summary>
        /// <param name="position">发送指令的楼层</param>
        /// <param name="prosn">条码</param>
        /// <param name="startPo">进仓点位</param>
        /// <param name="endPo">目标点位</param>
        /// <param name="nowPre">操作人</param>
        /// <param name="lie">目标点的列</param>
        /// <param name="spId">进仓计划ID</param>
        

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}