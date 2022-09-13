using NanXingShouChiJi.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingShouChiJi.Utils
{
    class AGVInfUtils
    {
        public string ip = string.Empty;
        HttpUtils httpUtils = new HttpUtils();
        NanXingGuoRen_WMSEntities4 DB2 = null;

        public AGVInfUtils(NanXingGuoRen_WMSEntities4 dB2)
        {
            DB2 = dB2;
            this.ip = ConfigurationManager.AppSettings["agvip"].ToString();
        }

        //1、主动下发任务
        public void SendMissionOrder( MissionOrder mission)
        {
            string api = string.Format("http://{0}:8001/ics/taskOrder/addTask", ip);
            string json = JsonConvert.SerializeObject(mission);
            Debug.WriteLine(json);
            string result = httpUtils.HttpApi(api, json, "post");
            //result = "{ \"code\": 1000, \"data\": \"3215435\",  \"desc\": \"请求成功\" }";
            Debug.WriteLine(result);
            Dictionary<string, object> dd = result.Trim(new char[] { '{', '}', ']', '[' }).Replace("[", "").Replace("{", "").Replace("\"", "").Split(',').ToDictionary(s => s.Split(':')[0].Trim(), s => (object)s.Split(':')[1].Trim());
            //不成功要重复执行吗？
            //不成功则回写结果
            //int code = Convert.ToDouble(mission.OrderId);
            //成功
            //Program.DB2.
            if (dd.Count>0)
            {
                Model.AGVMissionInfo agvMission = DB2.AGVMissionInfo.Where(u => u.MissionNo == mission.orderId).FirstOrDefault();
                
                if (agvMission!=null)
                {
                    agvMission.SendMsg = dd["desc"].ToString();
                    //RunState 1为成功 2为失败
                    if (dd["code"].ToString() == "1000")
                    {
                        agvMission.SendState = "成功";
                    }
                    else
                    {
                        agvMission.SendState = "失败";
                    }
                    agvMission.StateMsg = result;
                }
               
                DB2.SaveChanges();
            }
        }

        //2、主动获取任务状态接口
        public void GetMissionState(int orderId)
        {
            string api = string.Format("http://{0}:180/ics/out/task/getTaskOrderStatus", ip);
            Test obj = new Test();
            obj.orderId = orderId;
            string json = JsonConvert.SerializeObject(obj);
            string result = httpUtils.HttpApi(api, json, "post");
            Debug.WriteLine(result);
            //result: {"code":1000,"data":{"areaId":1,"createTime":1629786327,"taskOrderDetail":[{"shelfNumber":"","time":1629787743,"status":9}],"fromSystem":"WMS","status":9},"desc":"success"}

            Dictionary<string, object> dd = result.Trim(new char[] { '{', '}', ']', '[' }).Replace("[", "").Replace("{", "").Replace("\"", "").Split(',').ToDictionary(s => s.Split(':')[0].Trim(), s => (object)s.Split(':')[1].Trim());

        }

        //3、主动取消任务接口
        public void CancelMission(int orderId)
        {
            string api = string.Format("http://{0}:8001/ics/out/task/cancelTask", ip);
           
            string json = JsonConvert.SerializeObject(new { orderId= orderId, destPosition ="", destStorage =""});
            string result = httpUtils.HttpApi(api, json, "post");
            Debug.WriteLine(result);
            Dictionary<string, object> dd = result.Trim(new char[] { '{', '}', ']', '[' }).Replace("[", "").Replace("{", "").Replace("\"", "").Split(',').ToDictionary(s => s.Split(':')[0].Trim(), s => (object)s.Split(':')[1].Trim());

        }

        //4、主动获取AGV设备状态接口
        public void GetAGVState( string areaId,string deviceType,string deviceCode)
        {
            string api = string.Format("http://{0}:8001/ics/out/device/list/deviceInfo", ip); 
            string result = httpUtils.HttpApi(api, JsonConvert.SerializeObject(new { areaId = 1, deviceType = 0, deviceCode = deviceCode }), "post");
            Debug.WriteLine(result);

            //result :{"code":1000,"data":[{"taskPath":"20000091,20000085","payLoad":"0.0","orderId":"3215439","shelfNum":"","devicePosition":"20000905","devicePostionRec":[-18415,-7765],"state":"InTask","deviceCode":"7E04B8DPA400003","battery":"84","deviceName":"0003","deviceStatus":4}],"desc":"success"}

            Dictionary<string, object> dd = result.Trim(new char[] { '{', '}', ']', '[' }).Replace("[", "").Replace("{", "").Replace("\"", "").Split(',').ToDictionary(s => s.Split(':')[0].Trim(), s => (object)s.Split(':')[1].Trim());

        }

        //5、报警消息接口
        /// <summary>
        /// ICS系统主动发送过来
        /// </summary>
        public void GetMsg(string result)
        {
            JObject jo = JObject.Parse(result);
            string[] values = jo.Properties().Select(item => item.Value.ToString()).ToArray();
            JArray jlist = JArray.Parse(values[1].ToString());
            //List<DocItem> list = jlist.ToObject<List<DocItem>>();
            Debug.WriteLine(result);
            Dictionary<string, object> dd = result.Trim(new char[] { '{', '}', ']', '[' }).Replace("[", "").Replace("{", "").Replace("\"", "").Split(',').ToDictionary(s => s.Split(':')[0].Trim(), s => (object)s.Split(':')[1].Trim());

        }
    }
}
