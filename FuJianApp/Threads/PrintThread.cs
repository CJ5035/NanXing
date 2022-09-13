using NanXingCangKu.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ZigBeePrint.Utils;

namespace NanXingCangKu.Threads
{
    /// <summary>
    /// 打印线程，从打印队列中打印标签
    /// </summary>
    public class PrintThread
    {
        /// <summary>
        /// 打印工具类
        /// </summary>
        static BarTenderUtils btUtils = null;
        /// <summary>
        /// 打印队列
        /// </summary>
        public static ConcurrentQueue<PrintItem> printQueue = new ConcurrentQueue<PrintItem>();

        /// <summary>
        /// 取消指令
        /// </summary>
        static CancellationTokenSource cts = null;
        public static Task printTask = null;
        static PrintItem printItem = null;
        public static void StartPrint() 
        {
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            btUtils = new BarTenderUtils();

            printTask = Task.Factory.StartNew(() => {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    PrintControl();
                }
            }, token);
            //MessageBox.Show("打印线程打开成功");
        }

        public static void PrintControl()
        {
            try
            {
                if (printQueue.Any())
                {
                    //1.定时从队列中查询数据
                    printQueue.TryDequeue(out printItem);
                    //2.打印
                    btUtils.PrintLabel(printItem);
                    Logger.Default.Process(new Log(LevelType.Info, "打印成功"));
                }
                else
                    Thread.Sleep(1000);

            }
            catch(Exception ex)
            {
                Logger.Default.Process(new Log(LevelType.Error, ex.ToString()));
            }
        }

        public static void ClosePrint()
        {
            cts.Cancel();
            if (btUtils!=null)
                btUtils.ClosePrint();
        }
    }
}
