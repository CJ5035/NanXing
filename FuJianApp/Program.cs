using NanXingCangKu.Controller;
using NanXingService_WMS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NanXingCangKu
{
    static class Program
    {   
        /// <summary>
        /// 本程序名
        /// </summary>
        public static string programName = Path.GetFileName(Application.ExecutablePath);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            


            Application.Run(new Form1());

           
        }
       

        #region EF模型
        //private static NanXingGuoRen_CangKu_NewEntities nwms = null;
        //public static NanXingGuoRen_CangKu_NewEntities DB_WMS
        //{
        //    get
        //    {
        //        //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
        //        if (nwms == null)
        //        {
        //            nwms = new NanXingGuoRen_CangKu_NewEntities();
        //        }
        //        return nwms;
        //    }
        //}


        #endregion

        #region 全局异常捕获
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str;
            var strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now + "\r\n";
            var error = e.Exception;
            if (error != null)
            {
                str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                     error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("应用程序线程错误:{0}", e);
            }
            Logger.Default.Process(new Log(LevelType.Error, $" {str}", programName));
            //WriteLog("Error90::" + str);
            MessageBox.Show("出现异常：" + error.Message + "\r\n" + error.ToString());
            Application.ExitThread();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var error = e.ExceptionObject as Exception;
            var strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now + "\r\n";
            var str = error != null ? string.Format(strDateInfo + "Application UnhandledException:{0};\n\r堆栈信息:{1}", error.Message, error.StackTrace) : string.Format("Application UnhandledError:{0}", e);
            Logger.Default.Process(new Log(LevelType.Error, $" {str}", programName));
            //WriteLog("Error102::" + str);
            MessageBox.Show("出现异常：" + error.Message + "\r\n" + error.ToString());
            Application.ExitThread();
        }

        #endregion
    }
}
