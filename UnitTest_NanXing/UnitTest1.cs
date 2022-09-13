using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using NanXingData_WMS.DaoUtils;
using NanXingData_WMS.Dao;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NanXingService_WMS.Utils;
using NanXingService_WMS.Helper.WMS;
using NanXingService_WMS.Services;
using NanXingService_WMS.Services.WMS;
using NanXingService_WMS.Services.WMS.AGV;
using NanXingService_WMS.Managers;
using NanXingService_WMS.Entity;
using NanXingService_WMS.Threads;
using NanXingService_WMS.Utils.RedisUtils;
using RedLockNet;
using System.Threading;
using System.ComponentModel;
using System.Reflection;
using NanXingService_WMS.Utils.AGVUtils;
using System.Text;
using NanXingService_WMS.Utils.RabbitMQ;
using NanXingService_WMS.Threads.CRMThreads;
using System.Threading.Tasks;
using NanXingService_WMS.Utils.ThreadUtils;
using NanXingService_WMS.Entity.StockEntity;
using UtilsSharp;
using NanXingService_WMS.Entity.AGVApiEntity;
using NanXingService_WMS.Entity.CRMEntity.CRMAppleNoEntity;
using NanXingService_WMS.Helper.APS;
using NanXingService_WMS.Entity.CRMEntity;
using NanXingService_WMS.Services.APS;
using NanXingService_WMS.Utils.AutoMapper;
using NanXingService_WMS.Entity.CRMItemEntity;
using NanXingService_WMS.Entity.CRMEntity.CRMQueueEntitys.QueueOutputEntitys;
using NanXingService_WMS.Entity.CRMEntity.CRMQueueEntitys;
using NanXingService_WMS.Threads.DAQ;
using NanXingService_WMS.Utils.SensorUtils;
using System.Windows.Interop;

namespace UnitTest_NanXing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        //[Stopwatch]
        public void TestMethod1()
        {
           var result= SensorTools.CalculateHexToInt("080304019900017320".Substring(6, 4));


            ProductionThread s7SmartThread = new ProductionThread();
            DaqThread daqThread = new DaqThread();  

             //new MyTask(new Action(daqThread.), 5, true)
             //   .StartTask();

            //s7SmartThread.Control();
            //var z= AutoMapperUtils.mapper.ConfigurationProvider;
            //CRMApiHelper apiHelper = new CRMApiHelper();
            //ItemInfoDatalist[] dataList = apiHelper.GetItemFromApi(1632931200000);
            string msgBody = "{\"WriteType\":\"CRMPushPro\",\"WriteObject\":{\"planOrderNo_XuHao\":\"P20220830009-02-03XD\",\"proOrderNo\":\"S20220830007-02\",\"taskName\":\"03小包装-小袋\",\"proState\":\"未生产\",\"planTime\":1656604800000,\"crmState\":\"已下推\",\"updateUser\":\"超级管理员\",\"crm_ID\":\"62f4e17e1f52230001f6acfa\"}}";
            CRMWriteEntity obj = JsonConvert.DeserializeObject<CRMWriteEntity>(msgBody);
            CRMProEntity cRMPro = JsonConvert.DeserializeObject<CRMProEntity>(obj.WriteObject.ToString());
           
            CRMReturnWriteThread cRMReturnWriteThread = new CRMReturnWriteThread();
            //cRMReturnWriteThread.DeleteCRMPlan(cRMPro);
            cRMReturnWriteThread.WriteCRMPushPro(cRMPro);
            CRMPlanEntity cRMPutItem = new CRMPlanEntity();
            cRMPutItem.planOrderNo = "111";
            cRMPutItem.crm_ID = "62a7ea5859400d000135cc2a";
            cRMPutItem.fzCount = 996.ToString();
            cRMPutItem.fzUnit = "箱ssss1";
            cRMPutItem.pcUnit = "11122222kg";
            //decimal convertRate = string.IsNullOrEmpty(planList.ConvertRate) ? (decimal)0 : decimal.Parse(planList.ConvertRate);
            cRMPutItem.pcCount = "9996";
            cRMPutItem.crmState = "已下推";
            cRMPutItem.pcTime = UnixDateTImeUtils.ConvertDateTimeInt(DateTime.Now);
            cRMPutItem.batchNo = "eeee";

            //var mapper = AutoMapperUtils.Register().CreateMapper();
            var dest = AutoMapperUtils.mapper.Map<CRMEntityPushPlan>(cRMPutItem);
            //var dest2 = AutoMapperUtils.mapper.Map<Object_PushPro>(
            //    new CRMProEntity { crmState = "已下推", proOrderNo = "1111" }
            //    ); ;

            Debug.WriteLine("!");
            //  crmputLists.Add(cRMPutItem);
            //  RabbitMQUtils rabbitMQUtils = new RabbitMQUtils();
            //  CRMReturnWriteThread wareLieStateThread1 = new CRMReturnWriteThread();

            //  wareLieStateThread1.Control();

            //  Console.ReadLine();
            //  CRMProTask proTask = new CRMProTask()
            //  {
            //      crm_ID= "6295d5df42b30b0001f263ca",
            //      taskName = "2222",
            //      startTime = UnixDateTImeUtils.ConvertDateTimeInt(DateTime.Now).ToString(),
            //      endTime = UnixDateTImeUtils.ConvertDateTimeInt(DateTime.Now).ToString(),
            //      unit = "UNIT",
            //      count = 123456789,
            //      updateUserID = "123456",
            //      updateUserName = "123456",
            //  };

            //  Object_Task1 object_Task1 = new Object_Task1();
            //  apiHelper.WriteCRMApply("Object_Task1", proTask);



            //  List<CRMPlanEntity> crmputLists = new List<CRMPlanEntity>();
            //  CRMPlanEntity cRMPutItem = new CRMPlanEntity();
            //  cRMPutItem.crmID = "62a7ea5859400d000135cc2a";
            //  cRMPutItem.fzCount = 996.ToString();
            //  cRMPutItem.fzUnit = "箱ssss1";
            //  cRMPutItem.pcUnit = "11122222kg";
            ////decimal convertRate = string.IsNullOrEmpty(planList.ConvertRate) ? (decimal)0 : decimal.Parse(planList.ConvertRate);
            //  cRMPutItem.pcCount = "9996";
            //  cRMPutItem.pcState = "已下推";
            //  cRMPutItem.pcTime = UnixDateTImeUtils.ConvertDateTimeInt(DateTime.Now);
            //  cRMPutItem.batchNo = "eeee";
            //  crmputLists.Add(cRMPutItem);
            //  RabbitMQUtils.Send(CRMReturnWriteThread.queueName_CRMPushPlan, crmputLists);


            //  CRMApplyState cRMApplyState = new CRMApplyState();
            //  cRMApplyState.crmID = cRMPutItem.crmID;
            //  cRMApplyState.pcState = "待排产";
            //  RabbitMQUtils.Send(CRMReturnWriteThread.queueName_CRMChangeState, cRMApplyState);

            //  Console.WriteLine();
            //  Console.ReadLine();






            //ItemInfoManager itemService = new ItemInfoManager();
            //MyTask itemTask = new MyTask(new Action(itemService.StartUpdate), 3600, true)
            //    .StartTask(); ;
            //Console.ReadLine();
            //GroupMissionThread groupMissionThread = new GroupMissionThread();
            //WareLieLockHepler lieLockHelper = new WareLieLockHepler();

            ////ItemInfoManager itemInfoManager = new ItemInfoManager();

            //lieLockHelper.LockLie("1A-1-","123", true);
            //lieLockHelper.LockLie("2A-1-", "123", true);
            //var value5 = lieLockHelper.GetLockLies(true);
            //var value6 = lieLockHelper.GetLockLieBatchNo("1A-1-",true);
            //var value7 = lieLockHelper.GetLockLieValue("1A-1-","123", true);
            TiShengJiInfoService tiShengJiInfoService = new TiShengJiInfoService();
            
            TrayStateService trayStateService = new TrayStateService();
            WareLocationService _wareLocationService = new WareLocationService();
            StockPlanService stockPlanService = new StockPlanService();
            LiuShuiHaoService liuShuiHaoService = new LiuShuiHaoService();
            AGVMissionService missionService = new AGVMissionService();
            AGVMissionFloorService floorService = new AGVMissionFloorService();
            WareLocationLockHisService _wareLocationLockHisService = new WareLocationLockHisService();
            DeviceStatesService deviceStatesService = new DeviceStatesService();
            AGVAlarmLogService alarmLogService = new AGVAlarmLogService();
            AGVRunModelService runModelService = new AGVRunModelService();
            WareLocationLockHisService wareLoactionLockHisService = new WareLocationLockHisService();
            InstockHelper instockHelper = new InstockHelper(_wareLocationService, _wareLocationLockHisService);
            StockRecordService stockRecordService = new StockRecordService();
            OutstockManager outstockManager = new OutstockManager(_wareLocationService,
                stockPlanService, liuShuiHaoService, missionService, _wareLocationLockHisService, stockRecordService);
            AGVOrderUtils orderUtils = new AGVOrderUtils("192.168.3.180");
            WareLocationTrayManager wareLocationTrayNoManager = new WareLocationTrayManager(trayStateService,
                _wareLocationService, wareLoactionLockHisService);
            AGVApiManager manager = new AGVApiManager(missionService, floorService, trayStateService,
                _wareLocationService, deviceStatesService, alarmLogService
            , runModelService, wareLoactionLockHisService, tiShengJiInfoService, stockRecordService
             , wareLocationTrayNoManager);
            ProductOrderheadersService productOrderheaderService = new ProductOrderheadersService();
            ProductOrderlistsService productOrderService = new ProductOrderlistsService();
            ProPlanOrderlistsService planListService = new ProPlanOrderlistsService();
            ProductUploadHistoryService productUploadHistoryService=new ProductUploadHistoryService();
            ProductOrderManager orderManager = new ProductOrderManager(productOrderheaderService,
           productOrderService, planListService, productUploadHistoryService
            );

            //orderManager.GetOrderReport(DateTime.Parse("2022-01-01"), DateTime.Now);








            missionService.UpdateByPlus(u => u.ID == 2096,
                u => new AGVMissionInfo { Remark = "222222" });

            var ware= manager.GetMissionTarget(new MissionTarget()
            {
                orderId = "2022061000038",
                modelProcessCode = "b06"
            });



            var all = missionService.GetList(null, false, DbMainSlave.Master);
           
            Stopwatch watch = Stopwatch.StartNew();
            foreach(var temp in all)
            {
                temp.Remark = String.Empty;
            }
            DataTable editDt = missionService.ConvertToDataTable(all);
            //missionService.BatchInsertOrUpdate(null, editDt, "AGVMissionInfo");

            watch.Stop();
            Debug.WriteLine($"修改{all.Count}条数据，耗时：{watch.ElapsedMilliseconds}");
            var mission=missionService.FirstOrDefault(null,false,DbMainSlave.Master);
            watch.Restart();

            mission.Remark = "bbb";
            missionService.InsertOrUpdate(mission);
            missionService.SaveChanges();
            watch.Stop();
            Debug.WriteLine($"耗时：{watch.ElapsedMilliseconds}");
            watch.Restart();
            var mission2 =new AGVMissionInfo();
            MapperHelper<AGVMissionInfo, AGVMissionInfo>.Map(mission, mission2);
            mission2.ID = 0;
            mission2.Remark = "aaa";
            mission2.AGVMissionInfo_Floor = null;
            missionService.InsertOrUpdate(mission2);
            missionService.SaveChanges();
             watch.Stop();
            Debug.WriteLine($"耗时：{watch.ElapsedMilliseconds}");
            Debug.WriteLine($"耗时：{watch.ElapsedMilliseconds}");

            RabbitMQUtils rabbitMQUtils = new RabbitMQUtils();
            GroupMissionThread groupMissionThread = new GroupMissionThread();
            MyTask task = rabbitMQUtils.Recevice<List<CRMPlanList>>("ChangeCRM", 
                new Action<List<CRMPlanList>>((item) =>
            {
                Debug.WriteLine(item[0].CRMApplyNo_Xuhao);
                Debug.WriteLine(item[0].CRMApplyList_InCode);


                Thread.Sleep(5000);
                Debug.WriteLine(DateTime.Now.ToString("G"));
            }));
            Console.ReadLine();
            RedisHelper redisHelper = new RedisHelper();
            ChooseTiShengJiHelper chooseTiShengJiHelper = new ChooseTiShengJiHelper(tiShengJiInfoService);
          
            //try
            {
                //redisHelper.SortedSetAdd("1#提升机", "1A-1-", 1);
                //redisHelper.SortedSetAdd("2#提升机", "1G-1-", 2);

                var ccc = chooseTiShengJiHelper.ChooseTSJByCount("11111");


                var aa = redisHelper.HashKeys("1#提升机");
                foreach (var temp in aa)
                {
                    Debug.WriteLine(temp.ToString());
                }
                bool RET = false;
                RET=chooseTiShengJiHelper.RemoveLieInTSJ("1#提升机", "1F-1-5", "1F-1-");
                RET = chooseTiShengJiHelper.RemoveLieInTSJ("1#提升机", "1F-1-4", "1F-1-");
                RET = chooseTiShengJiHelper.RemoveLieInTSJ("1#提升机", "1F-1-4", "1F-2-");
                //var q= redisHelper.SortedSetRangeByRank("1#提升机");
                //WareLocation wareLocation= manager.GetWareLocationInLie("2G-1-", "{end}");

                //GroupMissionThread groupMissionThread1 = new GroupMissionThread();
                //RabbitMQUtils.Send("Test", 1);
                ////groupMissionThread.Control();
                List<AGVMissionInfo> list = new List<AGVMissionInfo>();
              
                list.Add(missionService.FindById(2060));
                RET = chooseTiShengJiHelper.RemoveLieInTSJ("2#提升机", "1C-12-2", "1C-12-");
                list.Add(missionService.FindById(2059));
                list.Add(missionService.FindById(2058));
                list.Add(missionService.FindById(2057));

                groupMissionThread.ParseFloor(list, new DataTable());

                Debug.WriteLine(71);


                //rabbitMQUtils.Send("Test", 1);
            }
            //RabbitMQUtils.Send("Test", 1);
            //RabbitMQUtils.Send("Test", 1); 
            //RabbitMQUtils.Send("Test", 1);

            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //RedisCacheHelper.AddList("Test1", "5");
            //RedisCacheHelper.AddList("Test1", "1");
            //RedisCacheHelper.AddListLeft("Test1", "2");
            //Debug.WriteLine(RedisCacheHelper.GetValueInList("Test1"));//2
            //Debug.WriteLine(RedisCacheHelper.GetValueInList("Test1"));//5
            //Debug.WriteLine(RedisCacheHelper.GetValueInList("Test1"));//1

            //List<WareLocation> list2 = outstockWLsHelper.OutStock(sp);
            //Debug.WriteLine(ret);
            //rabbitMQUtils.Send("Test", 2);
            watch.Stop();
            Debug.WriteLine($"耗时：{watch.ElapsedMilliseconds}");
            //watch.Restart();
            //string[] temp1 = str.Split(',');
            //watch.Stop();
            //Debug.WriteLine($"耗时：{watch.ElapsedTicks}");

            CRMReturnWriteThread thread = new CRMReturnWriteThread();

            using (redisHelper.CreateLock("lock", TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1),
                    TimeSpan.FromMilliseconds(500)))
            {
                Thread.Sleep(30000);
            }

            thread.Control();
            // task.CloseTask();
            //Debug.WriteLine($"{list.Count}条修改数据耗时：{watch.ElapsedMilliseconds}");
            Console.ReadLine(); 
        }

        private void GetTianFuSign()
        {
            //string[] vv = { "method", "appKey", "timestamp", "version", "page", "pageSize" };
            //string[] value = { "methodiot.listIots", "appKeyApp-165095734283-26683"
            //        , "timestamp"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 
            //        "version1.0", "page1", "pageSize10" };
            //string secret = "Sec-d91e300e-3c54-4742-8511-b4797831d60d";
            //Array.Sort(vv, string.CompareOrdinal);
            //StringBuilder sbuilder = new StringBuilder();
            //foreach(var temp in vv)
            //{

            //    foreach(var v in value) {
            //        if (v.Contains(temp))
            //        {
            //            sbuilder.Append(v);
            //            break;
            //        }
            //    }
            //}
            //Debug.WriteLine(secret+sbuilder.ToString()+secret);
        }

        string[] timeName = { "ID", "InputTime" };
        private bool IsEqual(TiShengJiState ts1, TiShengJiState ts2)
        {
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(TiShengJiState)))
            {
                if (!(pd.GetValue(ts1)??string.Empty).Equals(pd.GetValue(ts2) ?? string.Empty)
                    && !timeName.Contains(pd.Name))
                {
                    return false;
                }  
            }
            return true;
        }

        /// <summary>
        /// 判断两个相同引用类型的对象的属性值是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1">对象1</param>
        /// <param name="obj2">对象2</param>
        /// <param name="type">按type类型中的属性进行比较</param>
        /// <returns></returns>
        public bool CompareProperties<T>(T obj1, T obj2, Type type)
        {
            //为空判断
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null || obj2 == null)
                return false;

            Type t = type;
            PropertyInfo[] props = t.GetProperties();
            foreach (var po in props)
            {
                if (IsCanCompare(po.PropertyType))
                {
                    if (!po.GetValue(obj1).Equals(po.GetValue(obj2))
                        && !timeName.Contains(po.Name))
                    {
                        return false;
                    }
                }
                else
                {
                    var b = CompareProperties(po.GetValue(obj1), po.GetValue(obj2), po.PropertyType);
                    if (!b && !timeName.Contains(po.Name)) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 该类型是否可直接进行值的比较
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool IsCanCompare(Type t)
        {
            if (t.IsValueType)
            {
                return true;
            }
            else
            {
                //String是特殊的引用类型，它可以直接进行值的比较
                if (t.FullName == typeof(String).FullName)
                {
                    return true;
                }
                return false;
            }
        }


        public void Test()
        {
            Debug.WriteLine("Test");
            Thread.Sleep(10000);
        }

        public bool Update(DataTable dataTable)
        {

            SqlTransaction tran = null;//声明一个事务对象  
            try
            {
                using (SqlConnection conn = new SqlConnection("Password=tzhuser;Persist Security Info=True;User ID=tzhuser;Initial catalog=NanXingGuoRen_CangKu_New;Data Source=127.0.0.1"))
                {
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = "select * from FaHuoPlan";
                    comm.CommandTimeout = 600;
                    comm.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter(comm);
                    //adapter.SelectCommand = new SqlCommand(, conn);
                    SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(adapter);
                    sqlCmdBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                    adapter.AcceptChangesDuringUpdate = false;
                    adapter.UpdateCommand = sqlCmdBuilder.GetUpdateCommand();
                    string columnsUpdateSql = string.Empty;

                    conn.Open();//打开链接  
                    adapter.UpdateBatchSize = 2000;
                    Debug.WriteLine(adapter.Update(dataTable));
                    //dataTable.AcceptChanges();
                    //Debug.WriteLine(dataTable.ExtendedProperties["SQL"].ToString());
                    //using (tran = conn.BeginTransaction())
                    //{
                    //    //if (dataTable.ExtendedProperties!=null)
                    //    //{
                    //    //    adapter.SelectCommand.CommandText 
                    //    //        = dataTable.ExtendedProperties["SQL"].ToString();
                    //    //}

                    //    tran.Commit();
                    //    return true;
                    //}
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                if (null != tran)
                    tran.Rollback();

                return false;//返回False 执行失败！  
            }
        }
    }
}
