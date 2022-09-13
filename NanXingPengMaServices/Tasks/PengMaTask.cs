using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingWMS_old.Tasks
{
    class PengMaTask
    {
        ReadWorkTask rwt = new ReadWorkTask();

        public void Run()
        {
            
            //1-1 回写排产单信息
            Task task = Task.Factory.StartNew(delegate { rwt.StartRead(); });

            //2、控制喷码机开始

            //3、控制喷码机停止

            //4、读取RFID数据

            //5、写入数据库
        }
    }
}
