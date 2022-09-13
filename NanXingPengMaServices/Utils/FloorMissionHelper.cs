using NanXingWMS_old.Entity;
using NanXingWMS_old.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanXingWMS_old.Utils
{
    public class FloorMissionHelper
    {
        //RedisCacheHelper redisHelper = new RedisCacheHelper();
        AGVInfUtils au = null;
        /// <summary>
        /// 提升机操作类
        /// </summary>
        TiShengJiHelper tsjh =null;

        string tsj_1F = string.Empty;
        string tsj_2F = string.Empty;
        string tsj_3F = string.Empty;

        string tsj_MoveIn_1F = string.Empty;
        string tsj_MoveIn_2F = string.Empty;
        string tsj_MoveIn_3F = string.Empty;

        string tsj_MoveOut_1F = string.Empty;
        string tsj_MoveOut_2F = string.Empty;
        string tsj_MoveOut_3F = string.Empty;


        AGVMissionInfo ai = null;

        //
        //ConcurrentBag<AGVMissionInfo_Floor> cbag = new ConcurrentBag<AGVMissionInfo_Floor>();

        ConcurrentDictionary<int, DateTime> cDic = new ConcurrentDictionary<int, DateTime>();

        //string tragetFloor = string.Empty;
        //ConcurrentDictionary<int, AGVMissionInfo_Floor> cDic = new ConcurrentDictionary<int, AGVMissionInfo_Floor>();


        public FloorMissionHelper(TiShengJiHelper tsjh)
        {
            this.tsjh = tsjh;
            au = new AGVInfUtils(DB4);
            au.ip = "192.168.3.180";
            ai = DB4.AGVMissionInfo.FirstOrDefault();
            //Task.Run(()=>
            //{
            //    RunTask();
            //});
        }
        int second = 0;
        private void InitConfig(int index)
        {
            string before = "tsj-" + index;
            tsj_1F = ConfigurationManager.AppSettings[before + "-1L"].ToString();
            tsj_2F = ConfigurationManager.AppSettings[before + "-2L"].ToString();
            tsj_3F = ConfigurationManager.AppSettings[before + "-3L"].ToString();

            tsj_MoveIn_1F = ConfigurationManager.AppSettings[before + "-1L-MoBanMoveIn"].ToString();
            tsj_MoveIn_2F = ConfigurationManager.AppSettings[before + "-2L-MoBanMoveIn"].ToString();
            tsj_MoveOut_1F = ConfigurationManager.AppSettings[before + "-1L-MoBanMoveOut"].ToString();
            tsj_MoveOut_2F = ConfigurationManager.AppSettings[before + "-2L-MoBanMoveOut"].ToString();

        }

        public void Init()
        {
            second++;
            AGVMissionInfo_Floor a1 = DB4.AGVMissionInfo_Floor.FirstOrDefault();
            //MessageBox.Show("54");
            DateTime dtStart = DateTime.Now;
            List<AGVMissionInfo_Floor> arr = new List<AGVMissionInfo_Floor>(2);
            //Logger.Default.Process(new Log("Info", "56"));
            //1初始化第一步，确定这台是第几号提升机，确定每层楼的目标点 192.168.0.54
            if (tsjh.ClientTcp._endPointendPoint.ToString().Split(':')[0]== "192.168.0.54"
                || tsjh.ClientTcp._endPointendPoint.ToString().Split(':')[0] == "127.0.0.1")
            {
                InitConfig(1);
            }
            else if( tsjh.ClientTcp._endPointendPoint.ToString().Split(':')[0] == "192.168.0.55")
            {
                InitConfig(2);
            }
            //int waitSecond = 0;
            while (true)
            {
                try
                {
                    DateTime dt = DateTime.Now;
                    //1、等待确认的任务发送继续任务
                    DB4.Entry(ai).Reload();
                    DateTime fid = DateTime.Now.AddDays(-1);
                    List<AGVMissionInfo> runlist = DB4.AGVMissionInfo.AsNoTracking().Where(u => u.OrderTime > fid
                      && u.SendState == "成功" && u.RunState == "等待确认"
                      && (u.StartLocation == tsj_1F || u.EndLocation == tsj_1F
                       || u.StartLocation == tsj_2F || u.EndLocation == tsj_2F
                       || u.StartLocation == tsj_3F || u.EndLocation == tsj_3F)
                    ).ToList();

                    foreach (AGVMissionInfo temp in runlist)
                    {
                        au.ContinueTask(temp.MissionNo);
                    }


                    DB4.Entry(a1).Reload();
                    //2、对已发送的跨楼层任务进行跟踪
                    List<AGVMissionInfo_Floor> hasSendlist = DB4.AGVMissionInfo_Floor.Where(u => u.OrderTime > fid
                    && u.SendState == "成功").OrderBy(u => u.ID).ToList();
                    UpdateAMIF(hasSendlist);
                    Thread.Sleep(1000);
                    //判断提升机状态是否空闲
                    if (Form1.tsjs1 != null && Form1.tsjs1.carState == "空闲中")
                    {
                        //1、读取终点位为提升机的任务4
                        //如果是“任务中”、“已完成” 则判断提升机的起始位 的数量与状态
                        //如果数量相同，则发送提升机指令

                        //1、获取所有未完成的跨楼层任务
                        DB4.Entry(a1).Reload();
                        List<AGVMissionInfo_Floor> list1 = DB4.AGVMissionInfo_Floor.AsNoTracking().Where(u =>
                                   u.OrderTime > fid
                                && u.RunState != "执行失败" && u.RunState != "发送失败"
                                && u.RunState != "已完成" && u.RunState != "已取消"
                                 ).OrderBy(u => u.ID).ToList();

                        //2、判断第一阶段的任务个数
                        List<AGVMissionInfo_Floor> stepA_list = list1.Where(u => (u.SendState == "成功" || u.SendState == "发送中")
                                && (u.RunState == string.Empty || u.RunState == null)).ToList();

                        if (stepA_list.Count() >= 2)
                        {
                            string startFloor = stepA_list[0].StartLocation.Substring(0, 1);
                            int saId1 = stepA_list[0].ID;
                            int saId2 = stepA_list[1].ID;
                            DB4.Entry(ai).Reload();
                            List<AGVMissionInfo> sAList = DB4.AGVMissionInfo.AsNoTracking().Where(u =>
                            u.MissionFloor_ID == saId1 || u.MissionFloor_ID == saId2).OrderByDescending(u => u.ID).ToList();

                            //获取第一阶段已完成的数据做判断，数据库中
                            if ((startFloor == "1" && Form1.tsjs1.F1Count == 2 && Form1.tsjs1.F1State == "叉车放料箱到位")
                              || (startFloor == "2" && Form1.tsjs1.F2Count == 2 && Form1.tsjs1.F2State == "叉车放料箱到位")
                              || (startFloor == "3" && Form1.tsjs1.F3Count == 2 && Form1.tsjs1.F3State == "叉车放料箱到位")
                              || (sAList[0].RunState == "已完成" && sAList[1].RunState == "已完成"))
                            {
                                List<AGVMissionInfo_Floor> list = new List<AGVMissionInfo_Floor>(2);
                                list.Add(stepA_list[0]);
                                list.Add(stepA_list[1]);

                                tsjh.SendTSJOrder(stepA_list[0].StartLocation, stepA_list[0].EndLocation, list.Count);

                                Task.Run(() =>
                                {
                                    SendAGVWait(list, 2, 30, 10);
                                });

                                AGVMissionInfo_Floor aif0 = DB4.AGVMissionInfo_Floor.Where(u => u.ID == saId1).FirstOrDefault();
                                aif0.RunState = string.Empty;
                                aif0.RunState = "发送中";
                                AGVMissionInfo_Floor aif1 = DB4.AGVMissionInfo_Floor.Where(u => u.ID == saId2).FirstOrDefault();
                                aif1.RunState = string.Empty;
                                aif1.RunState = "发送中";
                                DB4.SaveChanges();
                            }
                        }
                        else if (stepA_list.Count() == 1)
                        {
                            //有新的 未开始的跨楼层任务
                            AGVMissionInfo_Floor temp = list1.Where(u => u.SendState == string.Empty || u.SendState == null).
                                OrderBy(u => u.ID).FirstOrDefault();
                            
                            string endFloor = stepA_list[0].EndLocation.Substring(0, 1);
                            string startFloor = stepA_list[0].StartLocation.Substring(0, 1);
                            double ts = double.Parse(Program.ReckonSeconds(dtStart, DateTime.Now));

                            //判断第一个子任务是否已完成
                            int saId1 = stepA_list[0].ID;
                            List<AGVMissionInfo> sAList = DB4.AGVMissionInfo.AsNoTracking().Where(u =>
                                     u.MissionFloor_ID == saId1).ToList();
                            //有新任务并新任务与旧任务的目标起始楼层一致,且新任务与旧任务大于10秒
                            if (temp != null && ts > 10
                                && temp.EndLocation.StartsWith(endFloor) && temp.StartLocation.StartsWith(startFloor))
                            {
                                SendOrder(temp, 1, DB4);
                            }
                            else if (
                                //没有新任务并等待时间大于20秒
                                //判断第一个子任务是否已完成
                                (temp == null && ts > 20 && sAList.Count > 0 && sAList[0].RunState == "已完成")
                                ||
                                //有新任务但目标楼层不一致
                                ((startFloor == "1" && Form1.tsjs1.F1Count == 1 && Form1.tsjs1.F1State == "叉车放料箱到位")
                              || (startFloor == "2" && Form1.tsjs1.F2Count == 1 && Form1.tsjs1.F2State == "叉车放料箱到位")
                              || (startFloor == "3" && Form1.tsjs1.F3Count == 1 && Form1.tsjs1.F3State == "叉车放料箱到位")))
                            {
                                tsjh.SendTSJOrder(stepA_list[0].StartLocation, stepA_list[0].EndLocation, stepA_list.Count);
                                arr.Clear();
                                arr.Add(stepA_list[0]);
                                //cDic.TryAdd(stepA_list[0].ID, DateTime.Now);
                                AGVMissionInfo_Floor aif0 = DB4.AGVMissionInfo_Floor.Where(u => u.ID == saId1).FirstOrDefault();
                                aif0.RunState = string.Empty;
                                aif0.RunState = "发送中";
                                DB4.SaveChanges();
                                Task.Run(() =>
                                {
                                    SendAGVWait(arr, 2, 30, 0);
                                });

                            }
                        }
                        else if (stepA_list.Count() == 0)
                        {
                            List<AGVMissionInfo_Floor> temp = list1.Where(u => u.SendState == string.Empty).
                               OrderBy(u => u.ID).ToList();
                            List<AGVMissionInfo_Floor> temp2 = list1.Where(u => u.SendState.Length > 0).
                               OrderBy(u => u.ID).ToList();
                            if (temp2.Count > 0 && temp.Count > 0 && temp[0].StartLocation.Substring(0, 1) != temp2[0].StartLocation.Substring(0, 1))
                            {
                                //等待上一批任务完成
                                continue;
                            }
                            else if (temp.Count > 1
                                && temp[0].StartLocation.Substring(0, 1) == temp[1].StartLocation.Substring(0, 1)
                                && temp[0].EndLocation.Substring(0, 1) == temp[1].EndLocation.Substring(0, 1))
                            {
                                //判断前两个是否相等
                                //SendOrder(temp[0], 1);
                                //SendOrder(temp[1], 1);
                                arr.Clear();
                                arr.Add(temp[0]);
                                arr.Add(temp[1]);
                                int saId1 = temp[0].ID;
                                int saId2 = temp[1].ID;

                                AGVMissionInfo_Floor aif0 = DB4.AGVMissionInfo_Floor.Where(u => u.ID == saId1).FirstOrDefault();
                                aif0.SendState = string.Empty;
                                aif0.SendState = "发送中";
                                AGVMissionInfo_Floor aif1 = DB4.AGVMissionInfo_Floor.Where(u => u.ID == saId2).FirstOrDefault();
                                aif1.SendState = string.Empty;
                                aif1.SendState = "发送中";
                                DB4.SaveChanges();

                                Task.Run(() =>
                                {
                                    SendAGVWait(arr, 1, 0, 10);
                                });

                            }
                            else if (temp.Count == 1)
                            {
                                SendOrder(temp[0], 1, DB4);
                                //cDic.TryAdd(temp[0].ID, DateTime.Now);
                                dtStart = DateTime.Now;
                            }
                        }
                    }
                    else
                    {
                        //tsjh.CloseTcp();
                        //tsjh.OpenTcp("192.168.0.54",9232);
                        if (second >= 3)
                        {
                            tsjh.WriteToTcp(TiShengOrder.Check);
                            second = 0;
                        }
                    }

                    //Logger.Default.Process(new Log("Info", $"总耗时{Program.ReckonSeconds(dt, DateTime.Now) }秒"));
                    Thread.Sleep(3000);
                }
                catch(Exception ex){
                    Logger.Default.Process(new Log("Error", ex.ToString()));
                }
            }
        }
        /// <summary>
        /// 延时发送AGV任务
        /// </summary>
        /// <param name="list">跨楼层任务</param>
        /// <param name="buzhou">步骤</param>
        /// <param name="beforeSecond">执行前等待时间</param>
        /// <param name="afterSecond">每条指令间隔时间</param>
        private void SendAGVWait(List<AGVMissionInfo_Floor> list,int buzhou,int beforeSecond,int afterSecond)
        {
            //Debug.WriteLine("开始延时任务："+DateTime.Now.ToString("G"));
            Logger.Default.Process(new Log("Info", "开始延时任务：" + DateTime.Now.ToString("G")));
            //List<AGVMissionInfo_Floor> list = (List<AGVMissionInfo_Floor>)obj;
            Thread.Sleep(beforeSecond*1000);
            
            foreach (AGVMissionInfo_Floor amif in list)
            {
                SendOrder(amif, buzhou, DB4);
                
                Logger.Default.Process(new Log("Info", "发送完成：" + DateTime.Now.ToString("G")));

                Thread.Sleep(afterSecond*1000);
            }
            //SendOrder(stepA_list[1], 2);
        }
        private string listName = "AGVMiss";
        private void SetTaskSet(AGVMissionInfo_Floor[] arr, int buzhou, int beforeSecond, int afterSecond)
        {
            //DateTime dtime1 = DateTime.Now.AddSeconds(beforeSecond);
            //AGVMissionTimeOut amto = null;
            //string jsonData = string.Empty;

            //amto = new AGVMissionTimeOut() { amif = arr[0], buzhou = buzhou, planRunTime = dtime1 };
            //jsonData = JsonConvert.SerializeObject(amto);
            //RedisCacheHelper.AddSortSet(listName, jsonData, double.Parse(dtime1.ToString("yyyyMMddHHmmss")));

            //if (arr.Length==2)
            //{
            //    DateTime dtime2 = DateTime.Now.AddSeconds(beforeSecond + afterSecond);

            //    amto = new AGVMissionTimeOut() { amif = arr[1] ,buzhou=buzhou,planRunTime=dtime2 };
            //    jsonData = JsonConvert.SerializeObject(amto);
            //    RedisCacheHelper.AddSortSet(listName, jsonData, double.Parse(dtime2.ToString("yyyyMMddHHmmss")));
            //}
            
        }

        private void RunTask()
        {
            //添加redis组件
            //RedisCacheHelper.Add(Text_WriteKey.Text.Trim(), Text_WriteValue.Text.Trim(), DateTime.Now.AddDays(1));

            //执行指令2时将跨楼层任务运行状态改为发送中

            //延时下发指令，然后呢还要延时第二条指令
            //1、根据跨楼层的数据进行时间判断
            //Dictionary<AGVMissionTimeOut, double> ret = RedisCacheHelper.GetValuesWithScoreInSortSet<AGVMissionTimeOut>(listName);

            AGVMissionInfo ami = null;
            AGVMissionInfo_Floor amif = null;
            List<int> list_ID = null;
            int amif_ID = 0;
            List<DateTime> list_Temp = null;
            DateTime dtime = DateTime.Now;
            while (true)
            {
                list_ID = cDic.Keys.ToList();
                list_Temp = cDic.Values.ToList();
                //开线程判断任务是否下发
                for (int i = 0; i < list_ID.Count; i++)
                {
                    //SendOrder(amif, buzhou);
                    //AGVMissionInfo_Floor outAmi = null;
                    //cDic.TryRemove(amif.ID,out outAmi);
                    //Thread.Sleep(afterSecond*1000);
                    int tempId = list_ID[i];
                    amif = DB5.AGVMissionInfo_Floor.AsNoTracking().Where(u => u.ID == tempId).FirstOrDefault();
                    ami = DB5.AGVMissionInfo.AsNoTracking().
                           Where(u => u.MissionFloor_ID == tempId).OrderByDescending(u => u.ID).FirstOrDefault();

                    //1、判断跨楼层任务在第几步
                    if (amif.SendState == string.Empty)
                    {
                        //发送步骤1，未发送，不用等待直接发送步骤1
                        SendOrder(amif, 1, DB5);
                        break;
                    }
                    else if (amif.SendState.Length > 0 
                        && string.IsNullOrEmpty(amif.RunState)
                        && ami != null && ami.RunState != "已完成")
                    {
                        //发送步骤1，已发送，判断是否已运行，
                        //已运行的时候判断时间间隔》10秒发送第二条任务，然后
                        if (ami.RunState == "运行中")
                        {
                            //计算时间差
                            int second = Convert.ToInt32(Math.Floor(ReckonSeconds(ami.OrderTime?? DateTime.Now, DateTime.Now)));
                            cDic.TryRemove(tempId, out dtime);
                            //如果有第二条任务就发送
                            if (list_ID.Count-1>i)
                            {
                                if (second < 10)
                                    Thread.Sleep((10 - second) * 1000);
                                int nextId = list_ID[i + 1];
                                amif = DB5.AGVMissionInfo_Floor.AsNoTracking().Where(u => u.ID == nextId).FirstOrDefault();
                                SendOrder(amif, 1, DB5);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (amif.SendState.Length > 0
                       && string.IsNullOrEmpty(amif.RunState) 
                       && ami!=null && ami.RunState=="已完成")
                    {
                        //发送步骤二指令
                        //判断时间间隔》30秒发送步骤二任务
                        int second = Convert.ToInt32(Math.Floor(ReckonSeconds(list_Temp[i], DateTime.Now)));

                        if (second<30)
                            Thread.Sleep((30 - second) * 1000);
                        SendOrder(amif, 2,DB5);
                        AGVMissionInfo_Floor aif0 = DB5.AGVMissionInfo_Floor.Where(u => u.ID == tempId).FirstOrDefault();
                        aif0.RunState = "任务中";
                        DB5.SaveChanges();
                        cDic.TryRemove(tempId, out dtime);
                        if (second < 40)
                            Thread.Sleep((40 - second) * 1000);
                    }
                }
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// 更新跨楼层任务的状态
        /// </summary>
        /// <param name="hasSendlist"></param>
        private void UpdateAMIF(List<AGVMissionInfo_Floor> hasSendlist)
        {
            foreach (AGVMissionInfo_Floor temp in hasSendlist)
            {
                DateTime dt1 = DateTime.Now.AddDays(-1);
                //根据进出仓来判断子任务的状态
                DB4.Entry(ai).Reload();
                AGVMissionInfo ami = DB4.AGVMissionInfo.AsNoTracking().Where(u => u.OrderTime > dt1 && u.MissionFloor_ID == temp.ID)
                    .OrderByDescending(u => u.ID).FirstOrDefault();
                //条件1：已取消，总任务=已取消
                //条件2：已完成，判断是第一阶段则任务中，第二阶段则已完成
                //条件3：执行失败、下发失败
                if (ami.RunState != temp.RunState)
                {
                    if (ami.RunState == "已取消" || ami.RunState == "执行失败" || ami.RunState == "发送失败") 
                    { 
                        temp.RunState = ami.RunState;
                        DB4.SaveChanges();
                    }
                    else if (ami.RunState == "已完成")
                    {
                        if ((temp.Mark == "05" && ami.Mark == "05")
                          || (temp.Mark == "02" && ami.Mark == temp.Mark)
                          || (temp.Mark == "04" && ami.Mark == temp.Mark))
                        {
                            temp.RunState = ami.RunState;
                            DB4.SaveChanges();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 发送调用AGV
        /// </summary>
        /// <param name="position">发送指令的楼层</param>
        /// <param name="prosn">条码</param>
        /// <param name="startPo">进仓点位</param>
        /// <param name="endPo">目标点位</param>
        /// <param name="nowPre">操作人</param>
        /// <param name="lie">目标点的列</param>
        /// <param name="spId">进仓计划ID</param>
        /// <param name="buzhou">步骤1 为 搬进start楼层的提升机位置</param>
        ///                      步骤2 为 从end楼层的提升机位置搬走

        ///modelCode = "713"; 713 是从提升机搬走东西 ，714是搬到提升机
        ///modelCode = "3"; 3 是从提升机搬走东西 ，4是搬到提升机
        ///
        private int SendOrder(AGVMissionInfo_Floor amif,int buzhou, NanXingGuoRen_WMSEntities1 temp )
        {
                string start = string.Empty;
                string end = string.Empty;
                string lineOrder = string.Empty;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                string modelCode = string.Empty;

                //当进仓第二步骤成功才算成功进仓
                //当出仓第1步骤成功算出仓成功
                //所以进仓第二步骤为02、出仓\调拨第一步骤为03，第二步骤为05
                string mark = string.Empty;
                if (buzhou == 1)
                {
                    start = amif.StartLocation;
                    //搬进
                    if (amif.StartLocation.StartsWith("1"))
                    {
                        end = tsj_1F;
                        modelCode = tsj_MoveIn_1F;
                    }
                    else if (amif.StartLocation.StartsWith("2"))
                    {
                        end = tsj_2F;
                        modelCode = tsj_MoveIn_2F;

                    }
                    else if (amif.StartLocation.StartsWith("3"))
                        end = tsj_3F;
                    lineOrder = end;
                    if (amif.Mark == "05"||amif.Mark == "04")
                        mark = "03";
                    else
                        mark = "06";
                }
                else if (buzhou == 2)
                {
                    //搬走
                
                    if (amif.EndLocation.StartsWith("1"))
                    {
                        start = tsj_1F; 
                        modelCode = tsj_MoveOut_1F;
                    }
                    else if (amif.EndLocation.StartsWith("2"))
                    {
                        start = tsj_2F;
                        modelCode = tsj_MoveOut_2F;
                    }
                    else if (amif.EndLocation.StartsWith("3"))
                        start = tsj_3F;
                    end = amif.EndLocation;
                    //mark = "06";
                    WareLocation ewl = DB4.WareLocation.Where(u => u.AGVPosition == end).FirstOrDefault();
                    string[] arr = ewl.WareLocaNo.Split('-');
                    lineOrder = $"{arr[0]}-{ arr[1]}";

                    if (amif.Mark == "02"|| amif.Mark == "04")
                        mark = amif.Mark;
                    else
                        mark = "05";
                }


                //插入数据
                AGVMissionInfo mission = new AGVMissionInfo();

                //执行存储过程，返回流水号
                Type t = typeof(string);
                SqlParameter[] sqlParms = new SqlParameter[1];
                sqlParms[0] = new SqlParameter("@MaintainCate", "MissionNo");

                var result = temp.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();
                mission.MissionNo = result;
                mission.AreaClass = result;
                mission.OrderTime = DateTime.Now;
                mission.SortIndex = 1;
                mission.StartLocation = start.Trim();
                mission.EndLocation = end.Trim();
                mission.Mark = mark;
                mission.TrayNo = amif.TrayNo.Trim();
                mission.StockPlan_ID = Convert.ToInt32(amif.StockPlan_ID);
                mission.StockPlan = temp.StockPlan.Where(u => u.ID == mission.StockPlan_ID).FirstOrDefault();
                mission.RunState = string.Empty;
                mission.userId = amif.userId;
                mission.MissionFloor_ID = amif.ID;
                mission.SendState = "成功";
                //if (amif.StockNo == "回转")
                    lineOrder = string.Empty;
                mission.OrderGroupId = lineOrder;

                temp.AGVMissionInfo.Add(mission);

            AGVMissionInfo_Floor aif0 = temp.AGVMissionInfo_Floor.Where(u => u.ID == amif.ID).FirstOrDefault();

            aif0.SendState = "成功";
            temp.SaveChanges();
            //string modelCode = "711";
           
            //发送AGV指令
            SendAGVOrder(result, $"{start},{end}", lineOrder, modelCode);
            return mission.ID;

        }

        /// <summary>
        /// 调用AGV
        /// </summary>
        /// <param name="orderId">3215443</param>
        /// <param name="path">"20000091,20000078"</param>
        private void SendAGVOrder(string orderId, string path, string orderGroupId, string modelCode)
        {
            //
            MissionOrder mo = new MissionOrder();
            mo.modelProcessCode = modelCode;
            mo.priority = "3";
            mo.fromSystem = "WMS";
            mo.orderId = orderId;
            mo.orderGroupId = orderGroupId;
            TaskOrderDetails taskOrderDetails = new TaskOrderDetails(path, "", "", "");
            List<TaskOrderDetails> list = new List<TaskOrderDetails>();
            list.Add(taskOrderDetails);
            mo.taskOrderDetail = list;


            au.SendMissionOrder(mo);
        }

        private void OldCode()
        {
            //if ( hasAMI.Count==2 && 
            //   ((Form1.tsjs1.F1Count==2 && Form1.tsjs1.F1State == "叉车放料箱到位" )
            //    || (Form1.tsjs1.F2Count == 2 && Form1.tsjs1.F2State == "叉车放料箱到位")
            //    || (Form1.tsjs1.F3Count == 2 && Form1.tsjs1.F3State == "叉车放料箱到位" )))
            //{
            //    tsjh.SendTSJOrder(hasAMI[0].StartLocation, hasAMI[0].EndLocation, hasAMI.Count);
            //    ids.Add(SendOrder(hasAMI[0], 2));
            //    ids.Add(SendOrder(hasAMI[1], 2));
            //    hasAMI.Clear();
            //}
            //else if(hasAMI.Count < 2)
            //{
            //    DB4.Entry(a1).Reload();
            //    List<AGVMissionInfo_Floor> list = DB4.AGVMissionInfo_Floor.Where(u => u.SendState.Length == 0)
            //        .OrderBy(u => u.OrderTime).ToList();

            //    if (list.Count > 0)
            //    {
            //        //1、判断提升机里面有货物，那就判断目的地是否同一个楼层
            //        if (hasAMI.Count == 1 && tragetFloor != list[0].EndLocation.Substring(0, 1) && Form1.tsjs1.CarState2 == "料箱到位")
            //        {
            //            //启动提升机，启动目标楼层AGV指令
            //            tsjh.SendTSJOrder(hasAMI[0].StartLocation, hasAMI[0].EndLocation, hasAMI.Count);
            //            ids.Add(SendOrder(hasAMI[0], 2));

            //            hasAMI.Clear();
            //        }
            //        else if (hasAMI.Count == 1 && tragetFloor == list[0].EndLocation.Substring(0, 1))
            //        {
            //            //启动起点AGV指令，读取提升机状态，启动提升机，启动目标楼层AGV指令
            //            ids.Add(SendOrder(list[0], 1));
            //            hasAMI.Add( list[0]);
            //        }
            //        //2、无货物
            //        else if (hasAMI.Count == 0)
            //        {
            //            //0、如果>1,判断是否同一个目标楼层
            //            if (list.Count > 1 && list[0].EndLocation.Substring(0, 1) == list[1].EndLocation.Substring(0, 1))
            //            {
            //                ids.Add(SendOrder(list[0], 1));
            //                ids.Add(SendOrder(list[1], 1));
            //                hasAMI.Add(list[0]);
            //                hasAMI.Add(list[1]);
            //            }
            //            //1、如果不是0的条件 ,启动起点AGV指令,并重置等待时间，
            //            else
            //            {
            //                ids.Add(SendOrder(list[0], 1));
            //                dtStart = DateTime.Now;
            //                hasAMI.Add( list[0]);
            //            }

            //            tragetFloor = list[0].EndLocation.Substring(0, 1);
            //        }
            //    }
            //    else
            //    {
            //        //1、判断提升机内是否有货物,20秒内无新任务，则判断状态启动提升机
            //        if (hasAMI.Count == 1 &&
            //            ((Form1.tsjs1.F1Count == 1 && Form1.tsjs1.F1State == "叉车放料箱到位")
            //    || (Form1.tsjs1.F2Count == 1 && Form1.tsjs1.F2State == "叉车放料箱到位")
            //    || (Form1.tsjs1.F3Count == 1 && Form1.tsjs1.F3State == "叉车放料箱到位")))
            //        {
            //            double ts = double.Parse(Program.ReckonSeconds(dtStart, DateTime.Now));
            //            if (ts > 20)
            //            {
            //                //启动提升机，启动目标楼层AGV指令
            //                tsjh.SendTSJOrder(hasAMI[0].StartLocation, hasAMI[0].EndLocation, hasAMI.Count);
            //                ids.Add(SendOrder(hasAMI[0], 2));
            //                hasAMI.Clear();

            //            }
            //        }
            //    }
            //    DB4.SaveChanges();
            //}

        }

        private NanXingGuoRen_WMSEntities1 nw12 = null;
        private NanXingGuoRen_WMSEntities1 DB4
        {
            get
            {
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (nw12 == null)
                {
                    nw12 = new NanXingGuoRen_WMSEntities1();
                    //nw12.Database.Log = s => {
                    //    Debug.WriteLine(s);
                    //};
                }
                return nw12;
            }
        }

        private NanXingGuoRen_WMSEntities1 nw13 = null;
        private NanXingGuoRen_WMSEntities1 DB5
        {
            get
            {
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (nw13 == null)
                {
                    nw13 = new NanXingGuoRen_WMSEntities1();
                }
                return nw13;
            }
        }

        /// <summary>
        /// 计算使用时间
        /// </summary>
        /// <param name="dt1">开始时间</param>
        /// <param name="dt2">结束时间</param>
        /// <returns>相隔的秒数</returns>
        private double ReckonSeconds(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = (dt2 - dt1).Duration();

            double second = 0;
            if (ts.Hours > 0)
            {
                second += ts.Hours * 3600;
            }
            if (ts.Minutes > 0)
            {
                second += ts.Minutes * 60;
            }
            second += ts.Seconds;
            second += (ts.Milliseconds * 0.001);

            return second;

        }
    }
}
