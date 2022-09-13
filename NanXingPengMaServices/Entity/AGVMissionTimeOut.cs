using NanXingWMS_old.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingWMS_old.Entity
{
    public class AGVMissionTimeOut
    {
        public AGVMissionInfo_Floor amif { get; set; }

        public int buzhou { get; set; }

        public DateTime planRunTime { get; set; }


    }
}
