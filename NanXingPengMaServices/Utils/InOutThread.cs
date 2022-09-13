using NanXingWMS_old.Entity;
using NanXingWMS_old.Model;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NanXingWMS_old.Utils
{
   /// <summary>
   /// 出库任务循环读取，并下发到AGV
   /// </summary>
    class InOutThread
    {
        AGVInfUtils au = new AGVInfUtils();
        StockPlan sp = Program.DB3.StockPlan.FirstOrDefault();

        public void Init()
        {
            au.ip = "192.168.3.180";
            while (true)
            {
                //1、读取未完成出入仓任务计划单号
                Program.DB3.Entry(sp).Reload();
                List<StockPlan> list = Program.DB3.StockPlan.Where(u => u.states == "0"
                        && u.mark=="03").OrderBy(u => u.plantime).ToList();
                foreach (StockPlan spItem in list)
                {
                    try
                    {
                        OutStock(spItem);
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        Logger.Default.Process(new Log("Error",ex.ToString()));
                        Thread.Sleep(500);

                    }
                }
                Thread.Sleep(500);
            }
        }
        #region 出仓

        private void OutStock(StockPlan sp)
        {
            this.sp = sp;
            DateTime dt = DateTime.Now;
            //Debug.WriteLine("开始出仓时间：" + dt.ToString("yyyy-MM-dd HH:mm:ss"));
            //1、获取该品种生产日期最小的集合
            DataTable wldt = GetSortByProdate(sp);
            List<string> wlList = new List<string>();
            Dictionary<string, string> lieDic = new Dictionary<string, string>();
            //Dictionary<string, string> wlDic = new Dictionary<string, string>();
            #region 计算列数和散件数量
            GetLieCount(wldt, ref wlList, ref lieDic);
            #endregion

            SendLieOrder(lieDic, wlList, sp);
            //Thread.Sleep(500);
            //修改任务单状态为已发送
            sp.states = "1";
            Program.DB3.SaveChanges();
            //Debug.WriteLine("114：" + sp.states);

            DateTime dt2 = DateTime.Now;
            Debug.WriteLine("结束出仓时间：" + dt2.ToString("yyyy-MM-dd HH:mm:ss"));
            Debug.WriteLine("出仓所用时间：" + ReckonSeconds(dt, dt2));
        }

        /// <summary>
        /// 计算列数和散件数量
        /// </summary>
        /// <param name="wldt">该产品所有仓位</param>
        /// <param name="wlList">列名</param>
        /// <param name="lieDic">散件仓位名</param>
        private void GetLieCount(DataTable wldt, ref List<string> wlList, ref Dictionary<string, string> lieDic)
        {
            decimal? dcount1 = sp.count;
            //相减后的数
            decimal? dcount2 = 0;
            //2、获取所有库区的数据

            foreach (DataRow dr in wldt.Rows)
            {
                dcount2 = dcount1 - Convert.ToDecimal(dr["sumcount"]);
                //先逐列计算数量
                if (dcount2 > 0)
                {
                    lieDic.Add(dr["lie"].ToString(), dr["InstockRule"].ToString());
                    dcount1 = dcount2;
                }
                else
                {
                    //最后一列
                    DataTable lieDt = null;
                    //判断出仓顺序
                    if (dr["InstockRule"].ToString() == "优先使用小的仓位号")
                    {
                        //去除出仓的位置
                        //desc
                        lieDt = GetLiePro(dr["lie"].ToString(), "desc", sp);
                    }
                    else
                    {
                        //asc
                        lieDt = GetLiePro(dr["lie"].ToString(), "asc", sp);
                    }

                    foreach (DataRow liedr in lieDt.Rows)
                    {
                        dcount2 = dcount1 - Convert.ToDecimal(liedr["OnlineCount"]);
                        if (dcount2 > 0)
                        {
                            wlList.Add(liedr["lie"].ToString() + liedr["xuhao"].ToString());
                            dcount1 = dcount2;
                        }
                        else
                        {
                            wlList.Add(liedr["lie"].ToString() + liedr["xuhao"].ToString());
                            break;
                        }
                    }
                    break;
                }
            }
        }

        string[] outPositions = { "20000348", "20000352", "20000356", "20000360", "20000364" };
        /// <summary>
        /// 将整列和散件转换成出库命令
        /// </summary>
        /// <param name="lieDic">列</param>
        /// <param name="wlList">散件</param>
        /// <param name="sp">进出仓任务清单</param>
        private void SendLieOrder(Dictionary<string, string> lieDic,List<string> wlList, StockPlan sp)
        {
            Dictionary<string, DataRow[]> dic = new Dictionary<string, DataRow[]>();
            List<string> list = new List<string>();
            //执行存储过程，返回流水号
            Type t = typeof(string);
            SqlParameter[] sqlParms = new SqlParameter[1];
            sqlParms[0] = new SqlParameter("@MaintainCate", "Stock");
            var result = Program.DB3.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();
            //1、寻找到所有列的数据
            foreach (KeyValuePair<string, string> kv in lieDic)
            {
                //Console.WriteLine(kv.Key + kv.Value);
                list.Add("'"+kv.Key+"'" );
            }
            if (list.Count>0)
            {
                DataTable alldt = GetAllWl(sp, string.Join(",", list.ToArray()));
                int maxCount = 0;
                foreach (KeyValuePair<string, string> kv in lieDic)
                {
                    DataRow[] drs = alldt.Select(string.Format("lie='{0}'", kv.Key));
                    if (drs.Count() > maxCount)
                        maxCount = drs.Count();
                    if (kv.Value == "优先使用小的仓位号")
                    {
                        drs = drs.OrderByDescending(x => x["xuhao"]).ToArray();
                    }
                    else { drs = drs.OrderBy(x => x["xuhao"]).ToArray(); }
                    dic.Add(kv.Key, drs);
                }

                List<string> dicName = dic.Keys.ToList();
                
                for (int i=0;i< dicName.Count;i++)
                {
                    dicName[0] = dicName[0] + result;
                }

                List<DataRow[]> dicValue = dic.Values.ToList();
                for (int j = 0; j < maxCount; j++)
                {
                    for (int i = 0; i < dicValue.Count; i++)
                    {
                        if (dicValue[i].Length > 0)
                        {
                            //1、发送AGV并记录AGVMission表
                            //Debug.WriteLine(dicValue[i][0]["lie"].ToString() + dicValue[i][0]["xuhao"].ToString());
                            string wlNo = dicValue[i][0]["lie"].ToString() + dicValue[i][0]["xuhao"].ToString();
                            TrayState ts = Program.DB3.TrayState.Where(u => u.WareLocation.WareLocaNo == wlNo).FirstOrDefault();
                            SendAGVOrder(ts.TrayNO, wlNo, outPositions[(j* dicValue.Count+i) % 5], "03",sp, dicName[i]);
                            dicValue[i] = Remove(dicValue[i], 0);
                            //Thread.Sleep(100);
                        }
                    }
                }
            }

            if (wlList.Count > 0)
            {
                Debug.WriteLine(wlList.Count);
                string[] srr = wlList[0].Split('-');
                string lineOrder = srr[0] + "-" + srr[1]+"-"+ result;
                for (int i=0;i< wlList.Count;i++)
                {
                    string wlNo = wlList[i];
                    TrayState ts = Program.DB3.TrayState.Where(u => u.WareLocation.WareLocaNo == wlNo).FirstOrDefault();
                    SendAGVOrder(ts.TrayNO, wlNo, outPositions[i%5],"03",sp, lineOrder);
                    //Debug.WriteLine(outPositions[i % 5]);
                    //wlList.RemoveAt(0);
                    //Thread.Sleep(100);
                }
            }
        }

        /// <summary>
        /// 发送AGV的命令
        /// </summary>
        /// <param name="trayNo">托号</param>
        /// <param name="startPo">开始的仓位号</param>
        /// <param name="endPo">结束AGVPosition</param>
        /// <param name="mark">02表示进仓，03表示出仓</param>
        /// 
        private void SendAGVOrder(string trayNo,string startPo, string endPo,string mark,StockPlan sp,string lineOrder )
        {
            AGVMissionInfo mission = new AGVMissionInfo();

            //执行存储过程，返回流水号
            Type t = typeof(string);
            SqlParameter[] sqlParms = new SqlParameter[1];
            sqlParms[0] = new SqlParameter("@MaintainCate", "MissionNo");

            var result = Program.DB3.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();
            WareLocation wl = Program.DB3.WareLocation.Where(u => u.WareLocaNo == startPo).FirstOrDefault();
            if (wl != null)
            {
                mission.MissionNo = result;
                mission.AreaClass = result;
                mission.OrderTime = DateTime.Now;
                mission.SortIndex = 1;
                mission.StartLocation = wl.AGVPosition.Trim();
                mission.EndLocation = endPo;
                mission.Mark = mark;
                mission.TrayNo = trayNo.Trim();
                mission.StockPlan_ID = sp.ID;
                mission.StockPlan = sp;
                mission.RunState = string.Empty;
                Program.DB3.AGVMissionInfo.Add(mission);
                Program.DB3.SaveChanges();

                //开线程读
                SendOrderTest(result, wl.AGVPosition + "," + endPo, lineOrder);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId">3215443</param>
        /// <param name="path">"20000091,20000078"</param>
        /// <param name="lineOrder">列名+流水号</param>
        private void SendOrderTest(string orderId, string path,string lineOrder)
        {
            //
            MissionOrder mo = new MissionOrder();
            mo.modelProcessCode = "1";
            mo.priority = "6";
            mo.fromSystem = "WMS";
            mo.orderId = orderId;
            mo.orderGroupId = lineOrder;
            TaskOrderDetails taskOrderDetails = new TaskOrderDetails(path, "", "", "");
            List<TaskOrderDetails> list = new List<TaskOrderDetails>();
            list.Add(taskOrderDetails);
            mo.taskOrderDetail = list;

            au.SendMissionOrder(mo);
        }
        /// <summary>
        /// 删除数组某个元素
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="index">元素序号</param>
        /// <returns>新数组</returns>
        private DataRow[] Remove(DataRow[] array, int index)
        {
            int length = array.Length;
            DataRow[] result = new DataRow[length - 1];
            try
            {
                Array.Copy(array, result, index);
                Array.Copy(array, index + 1, result, index, length - index - 1);
                return result;
            }
            catch
            {
                return result;
            }
        }

        /// <summary>
        /// 获取该品种生产日期最小的集合，去除任务单中的出库位，与入库列
        /// </summary>
        /// <param name="sp">出入仓</param>
        /// <returns></returns>
        private DataTable GetSortByProdate(StockPlan sp)
        {
          
            string sql =string.Format(@"
               select a.lie,batchNo,proname,probiaozhun,spec,protype,color,min(prodate) minprodate,InstockRule
	             ,LEFT(lie,charindex('-',lie))
	            ,left(right(lie,len(lie)-charindex('-',lie)),charindex('-',right(lie,len(lie)-charindex('-',lie)))-1)
	            ,SUM(OnlineCount) sumcount
	            from(
	            select LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) lie,
	            Right(WareLocaNo,len(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) xuhao
	            ,batchNo,proname,probiaozhun,spec,a.protype,color,prodate,OnlineCount,warearea.InstockRule from
	             WareLocation d ,warearea ,  (
	             select TrayNO,a.id,WareLocation_ID,max(b.prosn) prosn,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,prodate,OnlineCount
	              from traystate a,(select TrayStateID,MIN(prosn)prosn from TrayPro group by TrayStateID) b
	             ,(select prosn,batchNo,proname,probiaozhun,spec,protype,color,convert(nvarchar,prodate,23)prodate
	              from  Production 
	              group by prosn,batchNo,proname,probiaozhun,spec,protype,color,convert(nvarchar,prodate,23)) c
	             where a.ID=b.TrayStateID and b.prosn=c.prosn 
	             group by a.id,TrayNO,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,WareLocation_ID,prodate,OnlineCount)a
	             where a.WareLocation_ID=d.ID and charindex('-',WareLocaNo)>0 and d.WareArea_ID=WareArea.ID and WareArea.WareHouse_ID=2
	             and not exists(select StartLocation from ( select distinct  StartLocation  
	             from AGVMissionInfo where Mark='03' AND SendState='成功' and 
                (len(RunState)=0 or (RunState!='已完成' and RunState!='已取消' and RunState!='执行失败'and RunState!='发送失败')))a where 
	             d.AGVPosition=StartLocation)
	             AND NOT exists( select lie from
	             (SELECT LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) lie,AGVPosition FROM WareLocation,
             (select  EndLocation  from AGVMissionInfo where SendState='成功' AND Mark='02' and 
             (len(RunState)=0 or (RunState!='已完成' and RunState!='已取消' and RunState!='执行失败'and RunState!='发送失败')))A
	         WHERE WareLocation.AGVPosition=A.EndLocation )f where 
	         LEFT(d.WareLocaNo,charindex('-',d.WareLocaNo,charindex('-',d.WareLocaNo)+1))=f.lie)) a
            where  batchNo ='{0}' and probiaozhun='{1}' and spec='{2}' and color='{3}' and proname='{4}'
	             group by a.lie,batchNo,proname,probiaozhun,spec,protype,color,InstockRule
	             order by min(prodate),LEFT(lie,charindex('-',lie))
	            ,convert(int,left(right(lie,len(lie)-charindex('-',lie)),charindex('-',right(lie,len(lie)-charindex('-',lie)))-1))
	            ",
                sp.batchNo,sp.probiaozhun,sp.spec,sp.color,sp.proname);
            Debug.WriteLine(sql);
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 获取某列的所有仓位的情况
        /// </summary>
        /// <param name="lie">列号</param>
        /// <returns></returns>
        private DataTable GetLiePro(string lie,string sortType, StockPlan sp)
        {
            string sql = string.Format(@"select LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) lie,
	            Right(WareLocaNo,len(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) xuhao
	            ,batchNo,proname,probiaozhun,spec,a.protype,color,prodate,OnlineCount,warearea.InstockRule from
	             WareLocation d ,warearea ,  (
	             select TrayNO,a.id,WareLocation_ID,max(b.prosn) prosn,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,prodate,OnlineCount
	              from traystate a,(select TrayStateID,MIN(prosn)prosn from TrayPro group by TrayStateID) b
	             ,(select prosn,batchNo,proname,probiaozhun,spec,protype,color,convert(nvarchar,prodate,23)prodate
	              from  Production 
	              group by prosn,batchNo,proname,probiaozhun,spec,protype,color,convert(nvarchar,prodate,23)) c
	             where a.ID=b.TrayStateID and b.prosn=c.prosn 
	             group by a.id,TrayNO,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,WareLocation_ID,prodate,OnlineCount)a
	             where a.WareLocation_ID=d.ID and charindex('-',WareLocaNo)>0 and d.WareArea_ID=WareArea.ID 
	              and not exists(select StartLocation from ( select distinct  StartLocation  
	             from AGVMissionInfo where Mark='03' AND SendState='成功' and
                (len(RunState)=0 or (RunState!='已完成' and RunState!='已取消' and RunState!='执行失败'and RunState!='发送失败')))a where 
	             d.AGVPosition=StartLocation)
	             and LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))='{0}'
           and batchNo ='{2}' and probiaozhun='{3}' and spec='{4}' and color='{5}' and proname='{6}'
            order by Right(WareLocaNo,len(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) {1}", lie, sortType
            , sp.batchNo, sp.probiaozhun, sp.spec, sp.color, sp.proname);
            Debug.WriteLine(sql);
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 获取所有的列的所有位置
        /// </summary>
        /// <param name="sp">计划任务单号</param>
        /// <param name="line">所有位置的字符串</param>
        /// <returns></returns>
        private DataTable GetAllWl(StockPlan sp,string line) 
        {
            string sql = string.Format(@" select LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) lie,
	            Right(WareLocaNo,len(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) xuhao
	            ,batchNo,proname,probiaozhun,spec,a.protype,color,prodate,OnlineCount,warearea.InstockRule from
	             WareLocation d ,warearea ,  (
	             select TrayNO,a.id,WareLocation_ID,max(b.prosn) prosn,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,prodate,OnlineCount
	              from traystate a,(select TrayStateID,MIN(prosn)prosn from TrayPro group by TrayStateID) b
	             ,(select prosn,batchNo,proname,probiaozhun,spec,protype,color,convert(nvarchar,prodate,23)prodate
	              from  Production 
	              group by prosn,batchNo,proname,probiaozhun,spec,protype,color,convert(nvarchar,prodate,23)) c
	             where a.ID=b.TrayStateID and b.prosn=c.prosn 
	             group by a.id,TrayNO,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,WareLocation_ID,prodate,OnlineCount)a
	             where a.WareLocation_ID=d.ID and charindex('-',WareLocaNo)>0 and d.WareArea_ID=WareArea.ID 
                and not exists(select loca from ( select distinct case when Mark='02' then EndLocation  when  Mark='03' then StartLocation end loca
	             from AGVMissionInfo where SendState='成功' and
                (len(RunState)=0 or (RunState!='已完成' and RunState!='已取消' and RunState!='执行失败'and RunState!='发送失败')))a where 
	             d.AGVPosition=loca)
	             and LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) in ({5})
	             and batchNo ='{0}' and probiaozhun='{1}' and spec='{2}' and color='{3}' and proname='{4}'
	             order by  LEFT(LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)),charindex('-',LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))))
	            ,CONVERT(INT,left(right(LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)),len(LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))-charindex('-',LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))),charindex('-',right(LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)),len(LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))-charindex('-',LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))))-1)),
	             Right(WareLocaNo,len(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) desc",
            sp.batchNo, sp.probiaozhun, sp.spec, sp.color, sp.proname, line
            );
            //Debug.WriteLine(sql);
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 计算使用时间
        /// </summary>
        /// <param name="dt1">开始时间</param>
        /// <param name="dt2">结束时间</param>
        /// <returns>相隔的秒数</returns>
        public string ReckonSeconds(DateTime dt1, DateTime dt2)
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

            return second.ToString();

        }

        #endregion 
    }
}
