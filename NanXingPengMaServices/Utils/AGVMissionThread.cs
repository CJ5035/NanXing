using NanXingWMS_old.Entity;
using NanXingWMS_old.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NanXingWMS_old.Utils
{
    /// <summary>
    /// 获取AGV任务的执行车辆 线程
    /// </summary>
    class AGVMissionThread
    {
        AGVInfUtils au = new AGVInfUtils();

        AGVMissionInfo asi = Program.DB4.AGVMissionInfo.FirstOrDefault();
        List<string> nolist = new List<string>();
        public void Init()
        {
            //读取所有没有的mission
            au.ip = "192.168.3.180";
            while (true)
            { //1、读取未完成出入仓任务计划单号
                Program.DB4.Entry(asi).Reload();
                DateTime dt = DateTime.Now.AddDays(-1);
                List<AGVMissionInfo> list = Program.DB4.AGVMissionInfo.Where(
                u => u.OrderTime>dt && (u.AGVCarId == null||u.MissionFloor_ID!=null) 
                && u.SendState=="成功"  && u.RunState != "执行失败" && u.RunState != "发送失败"
                && (u.RunState == "已完成" || u.RunState == "运行中" )  )
                    .OrderBy(u => u.ID).ToList();
                foreach (AGVMissionInfo temp in list)
                {
                    string result= au.GetMissionState(temp.MissionNo);
                    //Logger.Default.Process(new Log("Info", result));
                    MissionStates rb = JsonConvert.DeserializeObject<MissionStates>(result);
                    if (rb.data != null && rb.data.taskOrderDetail != null
                        && rb.data.taskOrderDetail.Length>0
                        && !string.IsNullOrEmpty(rb.data.taskOrderDetail[0].deviceNum)
                        )
                    {
                        if(temp.AGVCarId != rb.data.taskOrderDetail[0].deviceNum)
                        {
                            temp.AGVCarId = rb.data.taskOrderDetail[0].deviceNum;
                            Program.DB4.SaveChanges();
                        }
                        string sta = ReturnState(rb.data.taskOrderDetail[0].status);
                        if (temp.RunState != sta)
                        {
                            temp.RunState = sta;

                            if (temp.RunState == "已完成")
                            {
                                IfOK(temp);
                                Program.DB4.SaveChanges();
                            }
                        }
                            
                       
                    }
                    else
                    {
                        if (nolist.Contains(temp.MissionNo))
                        {
                            temp.AGVCarId = string.Empty;
                            Program.DB4.SaveChanges();
                        }
                        else
                        {
                            nolist.Add(temp.MissionNo);
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
        private void IfOK(  AGVMissionInfo temp)
        {
            TrayState ts = Program.DB4.TrayState.Where(u => u.TrayNO == temp.TrayNo).FirstOrDefault();
            if (temp.Mark == "02" || temp.Mark == "04" || temp.Mark == "05")
            {
                WareLocation ewl = Program.DB4.WareLocation.Where(u => u.AGVPosition == temp.EndLocation).FirstOrDefault();
                if (ewl != null)
                {
                    ts.WareLocation_ID = ewl.ID;
                    ts.WareLocation = ewl;
                }
            }
            else if (temp.Mark == "03")
            {
                if (ts.WareLocation != null)
                {
                    ts.WareLocation.WareLocaState = true;
                }
                ts.WareLocation_ID = null;
                ts.WareLocation = null;
            }
        }

        private string ReturnState(string status)
        {
            string msg = string.Empty;
            if (status == "9")
            {
                msg = "已下发";
            }
            else if (status == "6")
            {
                msg = "运行中";
            }
            else if (status == "7")
            {
                msg = "执行失败";
            }
            else if (status == "5")
            {
                msg = "发送失败";
            }
            else if (status == "3")
            {
                msg = "已取消";
                //agvMission.StockPlan.states = "2";
            }
            else if (status == "8")
            {
                msg = "已完成";
            }
            else if (status == "10")
            {
                msg = "等待确认";
            }
            return msg;
        }
    }
}
