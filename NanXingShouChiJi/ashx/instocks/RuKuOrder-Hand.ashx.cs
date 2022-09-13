using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx.instocks
{
    /// <summary>
    /// RuKuOrder_Hand 的摘要说明
    /// </summary>
    public class RuKuOrder_Hand :BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);
            string prosn = dic["prosn"];
            string position = dic["position"];
            string endPo = dic["endPo"];
            string userId = dic["nowPre"];
            var warelocation =wareLocationService.GetByWLNo(endPo, false, NanXingData_WMS.DaoUtils.DbMainSlave.Master);
            var trayState= trayStateService.GetByTrayNo(prosn, false, NanXingData_WMS.DaoUtils.DbMainSlave.Master);
            var result = new UtilsSharp.Standard.BaseResult<string>();
            if (warelocation.TrayState != null)
                result.SetError("该仓位已有条码，请先对仓位条码进行出仓操作");
            var ret= WareLocationTrayManager.ChangeTrayWareLocation(0, warelocation, trayState);
            if (ret)
            {
                StockRecordService.AddHandStockRecord(trayState, warelocation.WareLocaNo, userId, DateTime.Now, true);
                result.SetOk() ;
            }
            else
                result.SetError(string.Empty);
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(result));
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