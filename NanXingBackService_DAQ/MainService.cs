using NanXingData_WMS.Dao;
using NanXingService_WMS.Entity.SensorEntity;
using NanXingService_WMS.Services;
using NanXingService_WMS.Threads;
using NanXingService_WMS.Threads.DAQ;
using NanXingService_WMS.Utils.ThreadUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace NanXingBackService_DAQ
{
    public partial class MainService : ServiceBase
    {
        DaqThread daqThread = new DaqThread();
        MyTask myTask = null;

        ProductionThread productionThread2 = new ProductionThread();
        ProductionThread productionThread3 = new ProductionThread();
        MyTask productTask3L = null;

        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            int waitSecond = 5;
            try
            {
                waitSecond = Convert.ToInt32(ConfigurationManager.AppSettings["WaitSecond"]);
            }
            catch
            {

            }
            //myTask = new MyTask(new Action(daqThread.Control), waitSecond, true)
            //     .StartTask();
            daqThread.Start(waitSecond);

            productTask3L = new MyTask(new Action(productionThread3.Control3L), 1, true,null,
                new Action(productionThread3.CloseConnect)).StartTask();

            productionThread2.Control2L();
        }

        protected override void OnStop()
        {
            if (myTask != null)
                myTask.CloseTask();
            if(productTask3L!=null)
                productTask3L.CloseTask();
            if (productionThread2!=null)
            {
                productionThread2.CloseTcp();
            }
            
        }
    }
}
