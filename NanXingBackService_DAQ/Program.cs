using NanXingCangKu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace NanXingBackService_DAQ
{
    internal static class Program
    {
        public static bool IsActive { get; private set; }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            // 授权示例
            if (!HslCommunication.Authorization.SetAuthorizationCode("f562cc4c-4772-4b32-bdcd-f3e122c534e3"))
            {
                // MessageBox.Show( "授权失败！当前程序只能使用8小时！" );
                // return;
            }
            else
            {
                IsActive = true;
            }
            System.Threading.ThreadPool.SetMaxThreads(2000, 800);

            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new MainService()
                };
                ServiceBase.Run(ServicesToRun);

            }
            catch (Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error,$"{ex}"));
            }
        }
    }
}
