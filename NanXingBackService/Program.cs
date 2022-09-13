using NanXingService_WMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace NanXingBackService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            try
            {
                //ExceptionlessClient.Default.Startup("oGj7yt9sqAAkFitI2Y4BvMWPHsE1OOc23j0jVL0u");
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new MainService()
                };
                ServiceBase.Run(ServicesToRun);
            }
            catch(Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error, ex.ToString()));
            }
            
        }
    }
}
