using NanXingData_WMS.Extensions;
using NLog.Targets;
using NX_WorkshopData.TCPClient;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NanXingService_WMS.Entity.SensorEntity
{
    /// <summary>
    /// 楼层设备类
    /// </summary>
    public class FloorBase
    {
        public string ip { get; set; }
        public int port { get; set; }

        /// <summary>
        /// 传感器客户端
        /// </summary>
        public AsyncClient sensorClient;
        /// <summary>
        /// 接收消息缓存字段
        /// </summary>
        public string sensorMsgFloor = string.Empty;
        public StringBuilder sbuilder = new StringBuilder();
        public DataTable dataTable { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        public string Floor { get; set; }
        /// <summary>
        /// 电表
        /// </summary>
        public Ammeter Ammeter { get; set; }

        /// <summary>
        /// 温湿度表
        /// </summary>
        public Humiture Humiture { get; set; }

        /// <summary>
        /// 噪声表
        /// </summary>
        public Noise Noise { get; set; }

        /// <summary>
        /// 有毒气体表
        /// </summary>
        public ToxicGas ToxicGas { get; set; }

        /// <summary>
        /// 温控1
        /// </summary>
        public Thermostat Thermostat1 { get; set; }

        /// <summary>
        /// 温控2
        /// </summary>
        public Thermostat Thermostat2 { get; set; }

        /// <summary>
        /// 温控3
        /// </summary>
        public Thermostat Thermostat3 { get; set; }

        /// <summary>
        /// 温控4
        /// </summary>
        public Thermostat Thermostat4 { get; set; }

        /// <summary>
        /// 温控5
        /// </summary>
        public Thermostat Thermostat5 { get; set; }

        /// <summary>
        /// 温控6
        /// </summary>
        public Thermostat Thermostat6 { get; set; }
        /// <summary>
        /// 柴油流量
        /// </summary>
        public float DieselOilFlow { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FloorBase(string ip,int port,string floor)
        {
            this.ip = ip;
            this.port = port;
            //this.dataTable = dt.Clone();
            this.Floor = floor;
            this.Ammeter = new Ammeter();
            this.Humiture = new Humiture();
            this.Noise = new Noise();
            this.Thermostat1 = new Thermostat();
            this.Thermostat2 = new Thermostat();
            this.Thermostat3 = new Thermostat();
            this.Thermostat4 = new Thermostat();
            this.Thermostat5 = new Thermostat();
            this.Thermostat6 = new Thermostat();
            this.ToxicGas = new ToxicGas();

            //依次设置温控表的站地址
            this.Thermostat1.StationAddress = 5;
            this.Thermostat2.StationAddress = 6;
            this.Thermostat3.StationAddress = 7;
            this.Thermostat4.StationAddress = 8;
            this.Thermostat5.StationAddress = 9;
            this.Thermostat6.StationAddress = 10;
        }

        //public void GetValue()
        //{
        //    var type = this.GetType();
        //    var BaseType = type.Assembly.GetType("ISensor<>");
            
        //    var types = type.Assembly.GetTypes()
        //            .Where(a => BaseType.IsAssignableFrom(a) && a != BaseType
        //                        && a.BaseType == BaseType).ToList();
        //    PropertyInfo[] propertyInfos = this.GetType().AllProperties().Where(
        //        u =>  BaseType.IsAssignableFrom(u.GetType()) && u.GetType() != BaseType
        //                        && u.GetType().BaseType == BaseType).ToArray();

        //    foreach (var temp in propertyInfos)
        //    {
        //        var iEquipment = temp.GetValue(this, null) as IEquipment;
        //        sensorClient.client.Send(iEquipment.CommandCode);
                

        //    }

        //}






    }
}
