using NanXingWMS_old.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanXingWMS_old.Utils
{
    class HuanZhuanUtils
    {
        public Form1 form1;
        private NanXingGuoRen_WMSEntities1 nw12 = null;
        private NanXingGuoRen_WMSEntities1 DB4
        {
            get
            {
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (nw12 == null)
                {
                    nw12 = new NanXingGuoRen_WMSEntities1();
                }
                return nw12;
            }
        }
        AGVInfUtils au = new AGVInfUtils();
        private bool isClose = false;
       
        public void GetHuiZhuan()
        {
            au.ip = "192.168.3.180";
            while (true)
            {
                DateTime fid = DateTime.Now.AddDays(-1);
                List<AGVMissionInfo_Floor> list = DB4.AGVMissionInfo_Floor.AsNoTracking().
                    Where(u => u.OrderTime > fid &&
                    u.StockNo == "回转" && (u.SendState.Length == 0
                    || (u.SendState.Length > 0 && u.RunState != "执行失败" && u.RunState != "发送失败"
                                 && u.RunState != "已完成" && u.RunState != "已取消"))).ToList();
                if (isClose)
                {
                    string[] arr = new string[1];
                    foreach (AGVMissionInfo_Floor temp in list)
                    {
                        List<AGVMissionInfo> list1= DB4.AGVMissionInfo.Where(u => u.OrderTime > fid &&
                        u.MissionFloor_ID == temp.ID && u.RunState != "执行失败" && u.RunState != "发送失败"
                                 && u.RunState != "已完成" && u.RunState != "已取消").ToList();
                        foreach (AGVMissionInfo temp1 in list1)
                        {
                            arr[0] = temp1.MissionNo;
                            Task.Run(() => au.CancelMission(arr));
                            Thread.Sleep(500);
                        }
                        //AGVMissionInfo_Floor aiff=DB4.AGVMissionInfo_Floor.Where(u => u.ID == temp.ID).FirstOrDefault();
                        //aiff.SendState = "成功";
                        //aiff.RunState = "已取消";


                    }
                    isClose = false;
                    break;
                }
                else
                {
                    if (list != null && list.Count == 0)
                    {
                        string[] arr ={ "2202112070000032", "2202112070000011" };
                        WriteFloorTable(arr, "admin");
                        //WriteFloorTable("2202112070000011", "admin");
                    }
                }
                Thread.Sleep(6000);
            }
            
           
        }
        private void WriteFloorTable( string[] prosn,   string nowPre)
        {
            //1、获取所有条码的起始位置，然后排序
            string prosn1 = prosn[0];
            string prosn2 = prosn[1];

            List<TrayState> list = DB4.TrayState.AsNoTracking()
                .Where(u => u.TrayNO == prosn1 || u.TrayNO == prosn2)
                .ToList();
            if (list[0].WareLocation==null || list[1].WareLocation == null)
            {
                form1.ChangeStatus(4, string.Empty);
                string msg = string.Empty;
                if (list[0].WareLocation == null && list[1].WareLocation == null)
                    msg = $"{prosn2}、{prosn1}";
                else 
                    msg = list[0].TrayNO == prosn1 ? prosn2 : prosn1;
                MessageBox.Show($"发送指令失败，找不到{msg}的仓位信息，请重新进仓再回转");
                return;
            }
            if (list[0].WareLocation.AGVPosition.StartsWith("1"))
            {
                list = list.OrderBy(u => u.WareLocation.AGVPosition).ToList();
            }else
            {
                list = list.OrderByDescending(u => u.WareLocation.AGVPosition).ToList();
            }
            //"22000390", "11000100"
            foreach (TrayState temp in list)
            {
                //插入数据
                AGVMissionInfo_Floor mission = new AGVMissionInfo_Floor();

                //执行存储过程，返回流水号
                Type t = typeof(string);
                SqlParameter[] sqlParms = new SqlParameter[1];
                sqlParms[0] = new SqlParameter("@MaintainCate", "MissionNo");

                var result = DB4.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();

                //WareLocation ewl = DB4.TrayState.Where(u => u.TrayNO == "2202112070000032").FirstOrDefault().WareLocation;

                //WareLocation ewl=
                string ePo = string.Empty;
                if (temp.WareLocation.AGVPosition.StartsWith("2"))
                {
                    if (temp.WareLocation.AGVPosition == "22000551")
                        ePo = "11000832";
                    else if (temp.WareLocation.AGVPosition == "22000556"|| temp.WareLocation.AGVPosition == "22000391")
                        ePo = "11000386";
                }
                else if (temp.WareLocation.AGVPosition.StartsWith("1"))
                {
                    if (temp.WareLocation.AGVPosition == "11000386" || temp.WareLocation.AGVPosition == "22000100")
                        ePo = "22000556";
                    else if (temp.WareLocation.AGVPosition == "11000832")
                        ePo = "22000551";
                }
                mission.StockNo = "回转";
                mission.MissionNo = result;
                mission.AreaClass = result;
                mission.OrderTime = DateTime.Now;
                mission.SortIndex = 1;
                mission.StartLocation = temp.WareLocation.AGVPosition.Trim();
                mission.EndLocation = ePo;
                mission.Mark = "05";
                mission.TrayNo = temp.TrayNO.Trim();
                mission.StockPlan_ID = 0;
                //mission.StockPlan = DB2.StockPlan.Where(u => u.ID == mission.StockPlan_ID).FirstOrDefault();
                mission.RunState = string.Empty;
                mission.SendState = string.Empty;
                mission.userId = nowPre;
                string lineOrder = string.Empty;
                mission.OrderGroupId = lineOrder;
                DB4.AGVMissionInfo_Floor.Add(mission);
                DB4.SaveChanges();
            }
           
            
            
        }

        public void Close()
        {
            isClose = true;

        }
    }
}
