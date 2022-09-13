using NanXingService_WMS;
using NanXingService_WMS.Services;
using NanXingService_WMS.Threads.CRMThreads;
using NanXingService_WMS.Utils.RabbitMQ;
using NanXingService_WMS.Utils.ThreadUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace NanXingBackService_APS
{
    public partial class MainService : ServiceBase
    {
        ItemInfoManager itemService = new ItemInfoManager();
        CRMReturnWriteThread returnWriteThread = new CRMReturnWriteThread();
        RabbitMQUtils rabbitMQUtils = new RabbitMQUtils();

        MyTask itemTask;
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logger.Default.Process(new Log(LevelType.Info,
                    $"服务开启。。。"));

            #region APS
            itemTask = new MyTask(new Action(itemService.StartUpdate), 600, true)
                .StartTask();

            returnWriteThread.Control();

            #endregion

        }

        protected override void OnStop()
        {
            try
            {
                itemTask.CloseTask();
            }
            catch (Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error,
                    "关闭物料线程出现错误\r\n" + ex.ToString()));
            }
            try { returnWriteThread.CloseCRMThread(); }
            catch (Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error,
                    "关闭回写CRM执行线程出现错误\r\n" + ex.ToString()));
            };
        }
    }
}
