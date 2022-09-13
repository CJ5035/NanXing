using NanXingData_WMS.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// GetOutPro 的摘要说明
    /// </summary>
    public class GetOutPro :BaseAshx
    {

        public override void ProcessRequest(HttpContext context)
        {
            string trayNO = context.Request.QueryString["prosn"].ToString().Trim();
            WareLocation wareLocation = wareLocationService.GetIQueryable(
                u => u.TrayState.TrayNO == trayNO,
                true, NanXingData_WMS.DaoUtils.DbMainSlave.Master).FirstOrDefault();
            //TrayState ts= DB2.TrayState.Where(u => u.TrayNO == trayNO).FirstOrDefault();
            string wlposition = string.Empty;
            if (wareLocation == null)
            {
                wlposition = string.Empty;
            }
            else
                wlposition = wareLocation.WareLocaNo;

            context.Response.ContentType = "text/plain";
            context.Response.Write("success:" + wlposition);
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