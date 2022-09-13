using NanXingData_WMS.Dao;
using NanXingService_WMS.Entity.StockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// ChuKuOrder 的摘要说明
    /// 手动出库：直接修改库位状态，不通过AGV出库
    /// </summary>
    public class ChuKuOrder_Hand : BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);

            string trayNO = dic["prosn"];
            string userID = dic["userID"];

            WareLocation wl = wareLocationService.GetIQueryable(u => u.TrayState.TrayNO == trayNO,
                true,NanXingData_WMS.DaoUtils.DbMainSlave.Master).FirstOrDefault();
            TrayState ts = trayStateService.GetIQueryable(u => u.TrayNO == trayNO,false, 
                NanXingData_WMS.DaoUtils.DbMainSlave.Master).FirstOrDefault();
            if (wl!=null)
            {
                wareLocationService.UpdateByPlus(u => u.ID == wl.ID,
                    u => new WareLocation { TrayState_ID = null,WareLocaState= WareLocaState.NoTray });
            }
            if (ts != null) {
                trayStateService.UpdateByPlus(u => u.TrayNO == trayNO,
                          u => new TrayState { WareLocation_ID = null });
            }
            StockRecordService.AddHandStockRecord(ts, wl != null ? wl.WareLocaNo : string.Empty
                , userID, DateTime.Now, false);
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