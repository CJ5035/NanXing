using NanXingData_WMS.Dao;
using NanXingService_WMS.Entity.StockEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingShouChiJi.ashx.moves
{
    /// <summary>
    /// GetWareArea 的摘要说明
    /// </summary>
    public class GetWareArea : BaseAshx
    {
        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> dic = GetDicInJson(context);

            string warehouse = dic["warehouse"];
            List<WareArea> list=wareAreaService.GetList(
                u => u.WareAreaState == true && u.WareHouse.WHName == warehouse
                && (u.WareAreaClass.AreaClass== AreaClassType.ChengPinArea
                || u.WareAreaClass.AreaClass == AreaClassType.HuanCunArea));
            list= wareAreaService.ConvertList(list);
            //int warehouseId = int.Parse(warehouse);
            //List<WareArea> list = DB2.WareArea.Where(u=>u.WareAreaState==true&& u.WareHouse_ID== warehouseId).ToList();
            //List<WareArea> list2 = new List<WareArea>();
            //foreach (var temp in list) {
            //    WareArea wa = new WareArea();
            //    wa.ID = temp.ID;
            //    wa.WareNo = temp.WareNo;
            //    list2.Add(wa);
            //}
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(list));
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