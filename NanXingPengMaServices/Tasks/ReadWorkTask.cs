using NanXingWMS_old.Model;
using NanXingWMS_old.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NanXingWMS_old.Tasks
{
    class ReadWorkTask
    {
        /// <summary>
        /// dic,key为ip,value为循坏线程
        /// </summary>
        Dictionary<string, Task> dic = new Dictionary<string, Task>();
        
        public void StartRead()
        {
            while (true)
            {
                //一直读表，一直判断dic中的线程是否结束
                //1、读取运输任务单号
                //2、发送给AGV
                //List<PacketPosition> packetPosition = Program.DB2.PacketPosition.ToList();
                //Task task = null;
                //foreach(PacketPosition item in packetPosition)
                //{
                //    if (dic.TryGetValue(item.PlcIp,out task))
                //    {
                //        if (task == null || task.IsCompleted)
                //        {
                //            ReadWorkNo rwn = new ReadWorkNo(item);
                //            task = Task.Factory.StartNew(delegate { rwn.StartRead(); }) ;
                //        }
                //    }
                //    else
                //    {
                //        ReadWorkNo rwn = new ReadWorkNo(item);
                //        task = Task.Factory.StartNew(delegate { rwn.StartRead(); });
                //        dic.Add(item.PlcIp, task);
                //    }
                //}
                Thread.Sleep(5000);
            }
        }


    }
}
