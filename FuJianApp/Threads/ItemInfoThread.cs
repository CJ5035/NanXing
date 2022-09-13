using NanXingService_WMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NanXingCangKu.Threads
{
    /// <summary>
    /// 定时刷新产品信息类
    /// </summary>
    public class ItemInfoThread
    {
        static ItemInfoManager itemService = new ItemInfoManager();
        static CancellationTokenSource tokenSource = null;
        static Task task = null;
        /// <summary>
        /// 线程入口
        /// </summary>
        public static void CreateTask()
        {
            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            task =Task.Factory.StartNew(()=> {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    MainControl();

                    Thread.Sleep(3600000);
                }
            }, token);
        }

        /// <summary>
        /// 线程出口，关闭任务
        /// </summary>
        public static void Close()
        {
            tokenSource.Cancel();
        }

        /* 包含功能
         * 1.定时获取产品信息
         *  1-1 判断是否存在数据库中
         *  1-2 如果为新增则插入新数据
         *  1-3 如果为修改则修改原数据
         * 2.保存产品信息获取记录
        */

        /// <summary>
        /// 主要功能
        /// </summary>
        private static void MainControl()
        {
            itemService.StartUpdate();
        }

    }
}
