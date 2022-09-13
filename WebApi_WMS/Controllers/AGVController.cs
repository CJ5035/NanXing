using NanXingService_WMS.Entity.StockEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Services;
//using WebApi_WMS.Models;
using NanXingData_WMS.DaoUtils;
using NanXingData_WMS.Dao;
using NanXingService_WMS.Entity.AGVApiEntity;
using NanXingService_WMS.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using NanXingService_WMS.Threads.DiffFloorThreads;

namespace WebApi_WMS.Controllers
{
    public class AGVController : BaseController
    {
        public AGVController()
        {

        }

        /// <summary>
        /// 接收任务状态接口
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        [WebMethod]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public RunResult<string> MissionStates([FromBody] MissionState ms)
        {
            return AGVApiManager.UpdateMissionStates(ms);
        }

        /// <summary>
        /// 设备状态上传，然后保存到数据库
        /// </summary>
        /// <param name = "ds" ></ param >
        /// < returns ></ returns >
        [WebMethod]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public RunResult<string> CarStates([FromBody] DeviceStates ds)
        {
            return AGVApiManager.UpdateCarStates(ds);

        }

        /// <summary>
        /// 任务中请求客户系统获取任务点位 
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        [WebMethod]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public object GetMissionTarget([FromBody] MissionTarget mt)
        {
            if (mt == null)
            {
                return new
                {
                    code = 1001,
                    desc = ResultMsg.fail,
                    data = "数据不能为空"
                };
            }
            RunResult<string> result = AGVApiManager.GetMissionTarget(mt);
            if (result.code == 1000)
                return new
                {
                    code = 1000,
                    desc = ResultMsg.success,
                    data = new { pointName = result.desc }
                };
            else
                return new
                {
                    code = 1001,
                    desc = ResultMsg.fail,
                    data = result.desc
                }; ;
        }

        /// <summary>
        /// 记录AGV警报 
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        [WebMethod]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public RunResult<string> AGVAlarmlog([FromBody] Alarmlog al)
        {
            if (al != null)
            {
                AGVApiManager.AddAGVAlarmlog(al);
            }
            return RunResult<string>.True();

        }

        //[WebMethod]
        //[AcceptVerbs("GET", "POST")]
        //[HttpPost]
        //public object RecHuoJiaPosition([FromBody] HuoJiaState hjs)
        //{
        //    return new { code = 100, data = new { }, desc = "请求成功" };
        //}

    }
}
