using NanXingService_WMS;
using NanXingService_WMS.Helper.APS;
using NanXingService_WMS.Services;
using NanXingService_WMS.Threads;
using NanXingService_WMS.Threads.CRMThreads;
using NanXingService_WMS.Threads.DiffFloorThreads;
using NanXingService_WMS.Threads.SameFloorThreads;
using NanXingService_WMS.Utils.RabbitMQ;
using NanXingService_WMS.Utils.ThreadUtils;
using System;
using System.ServiceProcess;
using System.Threading;

namespace NanXingBackService
{
    public partial class MainService : ServiceBase
    {
       
        GroupMissionThread groupMissionThread = new GroupMissionThread();
        SameFloorFactory sameFloorThread = new SameFloorFactory();
        DiffFloorFactory diffFloorThread = new DiffFloorFactory();
        
        WareLieStateThread wareLieStateThread1 ;
        WareLieStateThread wareLieStateThread2 ;
        WareLieStateThread wareLieStateThread3 ;
        WareLieStateThread wareLieStateThread4 ;

        RabbitMQUtils rabbitMQUtils = new RabbitMQUtils();

      
        MyTask groupTask;

        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logger.Default.Process(new Log(LevelType.Info,
                    $"服务开启。。。"));
         

            #region WMS
            //任务分类线程
            groupTask = new MyTask(new Action(groupMissionThread.Control), 1, true)
                .StartTask();
            //同楼层执行线程
            sameFloorThread.Start();
            //跨楼层执行线程
            diffFloorThread.StartNew();

            wareLieStateThread1 = new WareLieStateThread(rabbitMQUtils);
            wareLieStateThread2 = new WareLieStateThread(rabbitMQUtils);
            wareLieStateThread3 = new WareLieStateThread(rabbitMQUtils);
            wareLieStateThread4 = new WareLieStateThread(rabbitMQUtils);

            wareLieStateThread1.Run();
            Thread.Sleep(1000);
            wareLieStateThread2.Run();
            Thread.Sleep(1000);
            wareLieStateThread3.Run();
            Thread.Sleep(1000); 
            wareLieStateThread4.Run();
            Thread.Sleep(1000);


            #endregion
        }

        protected override void OnStop()
        {
            Logger.Default.Process(new Log(LevelType.Error,
                    "关闭服务"));
            try
            {
                groupTask.CloseTask();

            }
            catch (Exception ex){
                Logger.Default.Process(new Log(LevelType.Error,
                    "关闭分类线程出现错误\r\n"+ex.ToString()));
            }

            
            try
            {
               sameFloorThread.Close();
            }
            catch (Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error,
                    "关闭同楼层执行线程出现错误\r\n" + ex.ToString()));
            }
            try
            {
                 diffFloorThread.Close();
            }
            catch (Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error,
                    "关闭跨楼层执行线程出现错误\r\n" + ex.ToString()));
            }
            
           

            try { wareLieStateThread1.CloseTask(); }
            catch (Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error,
                    "关闭回写CRM执行线程出现错误\r\n" + ex.ToString()));
            };
            try { wareLieStateThread2.CloseTask(); }
            catch (Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error,
                    "关闭回写CRM执行线程出现错误\r\n" + ex.ToString()));
            };
            try { wareLieStateThread3.CloseTask(); }
            catch (Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error,
                    "关闭回写CRM执行线程出现错误\r\n" + ex.ToString()));
            };
            try { wareLieStateThread4.CloseTask(); }
            catch (Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error,
                    "关闭回写CRM执行线程出现错误\r\n" + ex.ToString()));
            };

        }

    }
}
