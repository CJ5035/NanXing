using NanXingData_WMS.Dao;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;

namespace NanXingShouChiJi.ashx.login
{
    /// <summary>
    /// GetWareHouses 的摘要说明
    /// </summary>
    /// //BaseAshx
    public class GetWareHouses : BaseAshx
    {
        //HuanCunUtils hcu = new HuanCunUtils();
        public override void ProcessRequest(HttpContext context)
        {
            List<WareHouse> list = wareHouseService.GetAll();
            List<WareHouse> list2 = wareHouseService.ConvertList(list);
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(list2));
        }
        //public override void ProcessRequestAsync(HttpContext context)
        //{
        //    //context.Response.ContentType = "text/plain";
        //    //context.Response.Write("Hello World");
        //}


        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}