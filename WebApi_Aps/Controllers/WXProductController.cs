using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using WebApi_Aps.Filter;
using System.Diagnostics;
using NanXingService_WMS.Entity;
using NanXingService_WMS.Entity.ProductEntity;

namespace WebApi_Aps.Controllers
{
    [RoutePrefix("api/WX_Product")]
    public class WXProductController : BaseController
    {
        //获取排产单号
        [ApiAuthorize]
        [HttpPost]
        [WebMethod]
        [Route("GetProductOrder1")]
        public object GetProductOrder1([FromBody] ProOrderNo request)
        {
            RunResult<object> runResult = ProductOrderManager.GetOrderProCount1(request.OrderNo);

            //从数据库获取订单
            Debug.WriteLine(request);
            return runResult;
        }

        //获取排产单号
        [ApiAuthorize]
        [HttpPost]
        [WebMethod]
        [Route("GetProductOrder")]
        public object GetProductOrder([FromBody] ProOrderNo request)
        {
            RunResult<object> runResult = ProductOrderManager.GetOrderProCount(request.OrderNo);

            //从数据库获取订单
            Debug.WriteLine(request);
            return runResult;
        }

        [ApiAuthorize]
        [HttpPost]
        [WebMethod]
        [Route("ChangeOrderStatue")]
        public object ChangeOrderStatue(ProOrderStatue request)
        {
            Debug.WriteLine(request);

            RunResult<string> runResult = ProductOrderManager.UpdateProOrderStatue(request.OrderId, request.Statue);

            //从数据库获取订单
            return runResult;
        }


        //获取排产单号
        [ApiAuthorize]
        [HttpPost]
        [WebMethod]
        [Route("AddCount")]
        public object AddOrderCount([FromBody] ProOrderAddCount request)
        {
            //Debug.WriteLine(request);
            string liushuihao = LiuShuiHaoService.GetUploadBatchLSH();
            RunResult<string> runResult = ProductOrderManager.UpdateOrderAddProCount
                (request.OrderID, request.Count, request.ControlUser, request.UploadBatch, liushuihao);

            //从数据库获取订单
            Debug.WriteLine(request);
            return runResult;
        }

        //获取排产单号
        [ApiAuthorize]
        [HttpPost]
        [WebMethod]
        [Route("GetProductCountHis")]
        public object GetProductCountHistory([FromBody] ProOrderNo request)
        {
            RunResult<object> runResult = ProductOrderManager.GetOrderAddCountHis(request.OrderNo);

            //从数据库获取订单
            Debug.WriteLine(request);
            return runResult;
        }


        //获取排产单号
        [ApiAuthorize]
        [HttpPost]
        [WebMethod]
        [Route("UpdateCount")]
        public object UpdateOrderCount([FromBody] List<ProOrderAddCount> request)
        {
            RunResult<string> runResult = ProductOrderManager.UpdateOrderProDataList(request);

            //从数据库获取订单
            Debug.WriteLine(runResult.ToString());
            return runResult;
        }



        public class ProOrderNo
        {
            public string OrderNo { get; set; }
        }

        public class ProOrderStatue
        {
            public int OrderId { get; set; }
            public string Statue { get; set; }
        }

    }
}