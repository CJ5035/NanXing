using NanXingService_WMS.Utils.SensorUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingService_WMS.Entity.SensorEntity
{
    /// <summary>
    /// 有毒气体传感器
    /// </summary>
    public class ToxicGas : IEquipment, ISensor<float>
    {
        public string EquipmentName { get => "有毒气体传感器"; }
        public string ReceiveMessage { get; set; }
        public byte[] CommandCode { get => SensorTools.GetDatagramBytes("01 03 00 00 00 01 84 0A"); }

        public float GetResult(string msg)
        {
            try
            {
                return SensorTools.CalculateHexToInt(msg.Substring(6, 4));
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
