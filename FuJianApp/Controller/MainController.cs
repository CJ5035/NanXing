using NanXingCangKu.Entity;
using NanXingCangKu.Threads;
using NanXingCangKu.Utils;
using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingService_WMS.Services;
using NanXingService_WMS.Services.APS;
using NanXingService_WMS.Services.WMS;
using NanXingService_WMS.Utils.ThreadUtils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZigBeePrint.Utils;
using NanXingService_WMS.Utils;
using NanXingService_WMS.Managers;
using NanXingService_WMS.Services.WMS.AGV;
using NanXingService_WMS.Entity.StockEntity;
using NanXingService_WMS.Utils.AGVUtils;
using NanXingService_WMS.Helper.WMS;
using UtilsSharp.Standard;

namespace NanXingCangKu.Controller
{
    /// <summary>
    /// 页面功能的分发
    /// </summary>
    public class MainController
    {
        #region 初始化工具方法类
        /// <summary>
        /// AGV执行工具类
        /// </summary>
        //AGVInfUtils agvUtils = new AGVInfUtils();

        /// <summary>
        /// 计算时间差
        /// </summary>
        TimeUtils timeUtils = new TimeUtils();

        /// <summary>
        /// 数据库执行工具类
        /// </summary>
        LiuShuiHaoService liuShuiHaoService = new LiuShuiHaoService();
        TrayStateService tss = new TrayStateService();
        ProductionService pds = new  ProductionService();
        ProPlanOrderlistsService pols = new ProPlanOrderlistsService();
        TrayProService tps = new TrayProService();
        TrayStateService trayStateService = new TrayStateService();
        
        AGVMissionService missionService = new AGVMissionService();
        WareLocationService wareLocationService = new WareLocationService();
        WareLocationLockHisService wareLocationLockHisService = new WareLocationLockHisService();

        StockPlanService stockPlanService = new StockPlanService();
        InstockManager instockManager;
        OutstockManager outstockManager;
        HuiZhuanHelper huiZhuanHelper;
        #endregion

        #region 初始化变量
        Form1 f1;
        MyTask huiZhuanTask1 = null;
        MyTask huiZhuanTask2 = null;

        public MainController(Form1 f1)
        {
            this.f1 = f1;
            //instockManager = new InstockManager(
            //trayStateService, wareLocationService, liuShuiHaoService, missionService,
            //wareLocationLockHisService);
            //outstockManager = new OutstockManager(
            //    wareLocationService, stockPlanService, liuShuiHaoService, missionService,
            //    wareLocationLockHisService);
            //Debug.WriteLine(lshs.GetTrayLSH());
        }

        public void Init()
        {
            //初始化数据连接
            liuShuiHaoService.Init();
            
            //初始化后台打印功能
            PrintThread.StartPrint();
            //初始化后台更新功能
            
            //MyTask itemTask = new MyTask(itemService.StartUpdate,3600000, true).StartTask();

            //Stopwatch stopwatch = Stopwatch.StartNew();
            //instockService.GetInstockWL("A771-181121");
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
           
        }

        public void Close()
        {
            PrintThread.ClosePrint();
        }
        #endregion

        #region AGV功能入口
        public DataTable ShowMission(DateTime startTime,DateTime endTime)
        {

           var q= missionService.SelectToList
                (u => u.OrderTime >= startTime && u.OrderTime <= endTime,
                a=> new ShowMission
                {
                    任务单号 = a.MissionNo,
                    任务时间 = a.OrderTime ?? startTime,
                    任务起点 = a.StartLocation,
                    任务终点 = a.EndLocation,
                    发送结果 = a.SendState ?? string.Empty,
                    执行结果 = a.RunState ?? string.Empty,
                    执行设备 = a.AGVCarId ?? string.Empty,
                })
                .OrderByDescending(u=>u.任务时间);

            return missionService.ConvertToDataTable(q);
        }
        
        public BaseResult<string> StartHuiZhuan(string trayNo1,string trayNo2,int index)
        {
            var result = new BaseResult<string>();
            //TrayState trayState1 = trayStateService.GetByTrayNo(trayNo1, true, DbMainSlave.Master);
            //TrayState trayState2 = trayStateService.GetByTrayNo(trayNo2, true, DbMainSlave.Master);
            WareLocation trayWL1=wareLocationService.GetIQueryable(u => u.TrayState.TrayNO == trayNo1,
                true, DbMainSlave.Master).FirstOrDefault();
            WareLocation trayWL2 = wareLocationService.GetIQueryable(u => u.TrayState.TrayNO == trayNo2,
            true, DbMainSlave.Master).FirstOrDefault();
            if (trayWL1 == null || trayWL2 == null)
            {
                result.SetError($"没有找到{(trayWL1 == null ? trayNo1 : trayNo2)}该条码",
                    BaseStateCode.数据找不到);
                return result;
            }

            if (trayWL1.AGVPosition.Substring(0,1) 
                != trayWL2.AGVPosition.Substring(0, 1))
            {
                result.SetError($"货物{trayNo1}与{trayNo2}不在同一个楼层",
                    BaseStateCode.数据验证不通过);
                return result;
            }

            if (huiZhuanHelper == null)
                huiZhuanHelper = new HuiZhuanHelper(liuShuiHaoService
                    , missionService, instockManager, outstockManager,wareLocationService);
            if (index == 1)
                huiZhuanTask1 =huiZhuanHelper.StartHuiZhuan(trayNo1, trayNo2,index);
            else if (index == 2)
                huiZhuanTask2 = huiZhuanHelper.StartHuiZhuan(trayNo1, trayNo2, index);
            result.SetOk();
            return result;
        }
        public void StopHuiZhuan(int index)
        {
            if (huiZhuanHelper == null)
                return;

            if (index == 1)
            {
                if(huiZhuanTask1!=null)
                    huiZhuanTask1.CloseTask();
                huiZhuanTask1 = null;
            }
            else if (index == 2)
            {
                if (huiZhuanTask2 != null)
                    huiZhuanTask2.CloseTask();
                huiZhuanTask2 = null;
            }
        }

        /// <summary>
        /// 取消AGV任务
        /// </summary>
        /// <param name="missions"></param>
        public void CancelMission(string[] missions)
        {
            //Task.Run(() => agvUtils.CancelMission(missions)); 
        }
        #endregion

        #region 打印功能入口

        public void Print(PrintItem noCodeItem,int printCount)
        {
            if (PrintThread.printTask.Status != TaskStatus.Running)
            {
                MessageBox.Show("打印线程未初始化，请重启本软件");
                return;
            }
            int trayCount = int.Parse(noCodeItem.Num);
           
            DateTime dt = DateTime.Now;
            //DateTime dt0 = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            DateTime dt3 = DateTime.Now;
           
            DataTable pdTable = pds.ClassToDataTable(typeof(Production));
            DataTable tpTable = tps.ClassToDataTable(typeof(TrayPro));
          
            DataRow tpDr = null;

            //List<TrayState> tslist = new List<TrayState>();

            for (int j = 0;j< printCount; j++)
            {
                //获取流水号
                string trayNo = liuShuiHaoService.GetTrayLSH();

                Debug.WriteLine("206::"+trayNo);
                //生成新托盘
                //tsDr=tsTable.NewRow();
                TrayState ts = new TrayState();
                ts.TrayNO= trayNo;
                ts.OnlineCount= trayCount;
                ts.optdate= dt;
                ts.itemno= string.Empty;
                ts.boxName= noCodeItem.boxName;
                ts.batchNo= noCodeItem.BatchNo;
                ts.boxName= noCodeItem.boxName;
                ts.proname= noCodeItem.ProName;
                ts.spec= noCodeItem.spec;
                ts.color= noCodeItem.color;
                ts.probiaozhun= noCodeItem.biaoZhun;
                ts.remark= noCodeItem.remark;
                //tsList.Add(ts);
                tss.Insert(ts);
                tss.SaveChanges();
                //插入production表
                for (int i = 1; i <= trayCount; i++)
                {
                    string prosn = trayNo + i.ToString("D5");

                    pdTable = ParsePrintItem(pdTable, prosn, noCodeItem);

                    tpDr = tpTable.NewRow();
                    int tsId = ts.ID;
                    tpDr["prosn"] = prosn;
                    tpDr["TrayStateID"] = tsId;
                    tpDr["optdate"] = dt;
                    tpTable.Rows.Add(tpDr);
                }
                noCodeItem.QRCode = trayNo;
                PrintItem printItem = null;
                printItem=noCodeItem.MapTo(printItem);
                //将打印数据放进打印线程的任务队列中等待打印
                PrintThread.printQueue.Enqueue(printItem);
              
                //Debug.WriteLine("打印标签用时" + Form1.mainController.RecTime(dt2, DateTime.Now));
            }
            tss.SaveChanges();
            pds.SetDataTableToTable(pdTable, "Production");
            //dt2 = DateTime.Now;
            tps.SetDataTableToTable(tpTable, "TrayPro");
            //Debug.WriteLine("数据库中插入产品托盘关联" + Form1.mainController.RecTime(dt2, DateTime.Now));

            Debug.WriteLine("总用时" + Form1.mainController.RecTime(dt3, DateTime.Now));
        }
        #endregion

        #region 工具方法
        string boxStr = "B-001";
        string classStr = "大包装车间";
        string itemStr = "1";

        /// <summary>
        /// 将流水号与打印数据插入DataTable中
        /// </summary>
        /// <param name="dt">原DataTable</param>
        /// <param name="prosn">prosn流水号</param>
        /// <param name="noCodeItem">产品信息</param>
        /// <returns>产品DataTable</returns>
        private Production ParsePrintItem( string prosn, PrintItem noCodeItem)
        {
            /*
             
                    pd = ParsePrintItem(prosn, noCodeItem);
                    pdlist.Add(pd);

                    tp = new TrayPro();
                    tp.prosn = prosn;
                    tp.TrayStateID = ts.ID;
                    tp.optdate = dt;
                    tplist.Add(tp);
                   
            dt2 = DateTime.Now;
            pds.InsertBulk(pdlist.AsQueryable());
            Debug.WriteLine($"数据库中插入{num}个产品托盘关联" + Form1.mainController.RecTime(dt2, DateTime.Now));
            dt2 = DateTime.Now;
            tps.InsertBulk(tplist.AsQueryable());
            Debug.WriteLine($"数据库中插入{num}个产品托盘关联" + Form1.mainController.RecTime(dt2, DateTime.Now));

            pds.SaveChangesAsync();
            */
            Production pd = new Production();
            pd.proname= noCodeItem.ProName;
            pd.prodate = DateTime.Parse(noCodeItem.ProDate);
            pd.prosn = prosn;
            pd.batchNo = noCodeItem.BatchNo;
            pd.ProductOrderlistsID = 1;
            pd.boxNo = boxStr;
            pd.boxName = noCodeItem.boxName;
            pd._class = classStr;
            pd.itemno = itemStr;
            pd.color = noCodeItem.color;
            pd.probiaozhun = noCodeItem.biaoZhun;
            pd.spec = noCodeItem.spec;
            pd.yuanliaobatchNo = noCodeItem.YuanLiaoBatchNo;
            pd.remark = noCodeItem.remark;
            return pd;
        }

        /// <summary>
        /// 将流水号与打印数据插入DataTable中
        /// </summary>
        /// <param name="dt">原DataTable</param>
        /// <param name="prosn">prosn流水号</param>
        /// <param name="noCodeItem">产品信息</param>
        /// <returns>产品DataTable</returns>
        private DataTable ParsePrintItem(DataTable dt , string prosn,PrintItem noCodeItem)
        {
            DataRow dr = dt.NewRow();
            dr["proname"] = noCodeItem.ProName;
            dr["prodate"] = DateTime.Parse(noCodeItem.ProDate);
            dr["prosn"] = prosn;
            dr["batchNo"]= noCodeItem.BatchNo;
            dr["ProductOrderlistsID"]= 3;
            dr["boxNo"]= boxStr;
            dr["boxName"]= noCodeItem.boxName;
            dr["class"]= classStr;
            dr["itemno"]= itemStr;
            dr["color"]= noCodeItem.color;
            dr["probiaozhun"]= noCodeItem.biaoZhun;
            dr["spec"]= noCodeItem.spec;
            dr["yuanliaobatchNo"]= noCodeItem.YuanLiaoBatchNo;
            dr["remark"]= noCodeItem.remark;
            dt.Rows.Add(dr);
            return dt;
        }
        /// <summary>
        /// 计时
        /// </summary>
        /// <param name="dt1">起始时间</param>
        /// <param name="dt2">结束时间</param>
        /// <returns>秒数</returns>
        public string RecTime(DateTime dt1,DateTime dt2)
        {
            return timeUtils.ReckonSeconds(dt1, dt2).ToString();
        }
        #endregion
    }
}
