using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingService_WMS.Entity.InstockEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NanXingShouChiJi.ashx.outstocks
{
    /// <summary>
    /// GetInfoByBatchNo 的摘要说明
    /// 根据批号获取产品名称与数量
    /// </summary>
    public class GetInfoByBatchNo :BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);
            string position = dic["position"];
            string batchNo = dic["batchNo"];
            string huancun = dic["huancun"];
            bool isHuanCun = false;
            if (huancun == "1")
                isHuanCun = true;

            var dt = trayStateService.GetInfoByBatchNo(batchNo, position, isHuanCun);

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(dt, new DataTableConverter()));
            
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