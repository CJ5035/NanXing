using NanXingService_WMS.Utils.SensorUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingService_WMS.Entity.SensorEntity
{
    /// <summary>
    /// 温湿度传感器
    /// </summary>
    public class Humiture : IEquipment, ISensor<float[]>
    {
        public string position = "12";
        public string EquipmentName { get => "温湿度传感器"; }
        public string ReceiveMessage { get; set; }
        public byte[] CommandCode { get => SensorTools.GetDatagramBytes("12 03 00 00 00 02 C6 A8"); }

        public float[] GetResult(string msg)
        {
            float[] resultArr;
            try
            {
                resultArr = new float[2];

                for (int i = 0; i < resultArr.Length; i++)
                {
                    string str = msg.Substring(6 + i * 4, 4);
                    resultArr[i] = SensorTools.CalculateHexToInt(str);
                }
            }
            catch (Exception)
            {

                resultArr = new float[] { 0f, 0f };
            }

            return resultArr;
        }
    }
}
