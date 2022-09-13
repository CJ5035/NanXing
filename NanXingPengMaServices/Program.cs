using NanXingWMS_old.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanXingWMS_old
{
    static class Program
    {
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
            Logger.Default.Process(new Log("Warn", $" {str}"));
            //WriteLog("Error90::" + str);
            //MessageBox.Show("出现异常：" + error.Message + "\r\n" + error.ToString());
            //Application.ExitThread();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var error = e.ExceptionObject as Exception;
            var strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now + "\r\n";
            var str = error != null ? string.Format(strDateInfo + "Application UnhandledException:{0};\n\r堆栈信息:{1}", error.Message, error.StackTrace) : string.Format("Application UnhandledError:{0}", e);
            Logger.Default.Process(new Log("Warn", $" {str}"));
            //WriteLog("Error102::" + str);
            //MessageBox.Show("出现异常：" + error.Message + "\r\n" + error.ToString());
            //Application.ExitThread();
        }

        private static NanXingGuoRen_WMSEntities1 nw = null;
        public static NanXingGuoRen_WMSEntities1 DB2
        {
            get
            {
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (nw==null)
                {
                    nw = new NanXingGuoRen_WMSEntities1();
                }
                return nw;
            }
        }

        private static NanXingGuoRen_WMSEntities1 nw1 = null;
        public static NanXingGuoRen_WMSEntities1 DB3
        {
            get
            {
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (nw1 == null)
                {
                    nw1 = new NanXingGuoRen_WMSEntities1();
                }
                return nw1;
            }
        }

        private static NanXingGuoRen_WMSEntities1 nw12 = null;
        public static NanXingGuoRen_WMSEntities1 DB4
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
        /// <summary>
        /// 计算使用时间
        /// </summary>
        /// <param name="dt1">开始时间</param>
        /// <param name="dt2">结束时间</param>
        /// <returns>相隔的秒数</returns>
        public static string ReckonSeconds(DateTime dt1, DateTime dt2)
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
    }
}
