using NanXingWMS_old.Model;
using NanXingWMS_old.Utils.TCP;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NanXingWMS_old.Utils
{
    public class TiShengJiHelper
    {
        /// <summary>
        /// 网络心跳包，用于客户端与服务端通讯，客戶端連接對象
        /// </summary>
        public SocketClientManager ClientTcp = null;
        Form1 f1 = null;

        private NanXingGuoRen_WMSEntities1 nw12 = null;
        private NanXingGuoRen_WMSEntities1 DB4
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
        public TiShengJiHelper(Form1 f1)
        {
            this.f1 = f1;
        }

        #region 打开关闭TCP连接
        public void OpenTcp(string ip, int port)
        {
            ClientTcp = new SocketClientManager(ip, port, 3600);
            ClientTcp.OnReceiveMsg += ReceiveTcpMsg;
            ClientTcp.OnConnected += NetworkResponseClientTcpOnConnected;
            ClientTcp.OnFaildConnect += NetworkResponseClientTcpOnFaildConnect;
            ClientTcp.onServerDisconnected += DisconnectedEvent;
            //ClientTcp.OnCommuuicationOutTime += CommuuicationOutTime;
            ClientTcp.Start();
        }
        /// <summary>
        /// 断开后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NetworkResponseClientTcpOnConnected()
        {
            Debug.WriteLine("Online");
            f1.ChangeStatus(3, "已连接");

            WriteToTcp("0100000000000000");
        }

        void NetworkResponseClientTcpOnFaildConnect()
        {
            Debug.WriteLine("失败");
            f1.ChangeStatus(3, "连接失败");

            WriteToTcp("0100000000000000");
        }
        void DisconnectedEvent()
        {
            Debug.WriteLine("断开");
            f1.ChangeStatus(3, "连接断开");

            WriteToTcp("0100000000000000");
        }

        public void CloseTcp()
        {
            if (ClientTcp._isConnected)
            {
                ClientTcp.Close();
            }
        }

        #endregion

        #region 读写指令

        public void WriteToTcp(string msg)
        {
            ClientTcp.SendMsg(msg);
            Debug.WriteLine($"{DateTime.Now.ToString("G")}发送:{msg}");
        }

        void ReceiveTcpMsg(string strMsg)
        {
            Debug.WriteLine($"{DateTime.Now.ToString("G")}收到:{strMsg}");
            ParseMsg(strMsg);
        }

        #endregion

        #region 数据解析
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void ParseMsg(string msg)
        {
            msg = msg.Trim();
            if (msg.Length == 40)
            {
                try
                {
                    string[] msgArr = new string[msg.Length / 2];
                    for (int i = 0; i < msgArr.Length; i++)
                    {
                        msgArr[i] = msg.Substring(2 * i, 2);
                    }

                    TiShengJiState tsjs = new TiShengJiState();


                    tsjs.InputTime = DateTime.Now;
                    //1、获取是否故障
                    if (msgArr[3] == TiShengReceive.State00)
                        tsjs.deviceState = "正常";
                    else if (msgArr[3] == TiShengReceive.State01)
                        tsjs.deviceState = "故障";
                    else if (msgArr[3] == TiShengReceive.State02)
                        tsjs.deviceState = "急停";
                    else if (msgArr[3] == TiShengReceive.State03)
                        tsjs.deviceState = "暂停";

                    //2、获取升降小车状态
                    if (msgArr[6] == TiShengReceive.State00)
                    {
                        tsjs.carState = TiShengCarState.NoJob;
                        tsjs.carTarget = string.Empty;
                    }
                    else if (msgArr[6] == TiShengReceive.State01)
                    {
                        tsjs.carState = TiShengCarState.Running;
                        if (int.Parse(msgArr[9]) > 0)
                            tsjs.carTarget = msgArr[9].Substring(1, 1) + "L";
                        else if (int.Parse(msgArr[12]) > 0)
                            tsjs.carTarget = msgArr[12].Substring(1, 1) + "L";
                        else if (int.Parse(msgArr[15]) > 0)
                            tsjs.carTarget = msgArr[15].Substring(1, 1) + "L";
                    }

                    //3、有多少的货物在
                    tsjs.CarCount = int.Parse(msgArr[5]);
                    tsjs.F1Count = int.Parse(msgArr[8]);
                    tsjs.F2Count = int.Parse(msgArr[11]);
                    tsjs.F3Count = int.Parse(msgArr[14]);

                    if (msgArr[4] == TiShengReceive.State00)
                        tsjs.CarState2 = GunZhouState.NoBox;
                    else if (msgArr[4] == TiShengReceive.State01)
                        tsjs.CarState2 = GunZhouState.InBox;
                    else if (msgArr[4] == TiShengReceive.State02)
                        tsjs.CarState2 = GunZhouState.OutBox;
                    else if (msgArr[4] == TiShengReceive.State03)
                        tsjs.CarState2 = "料箱到位";

                    tsjs.F1State = ParseGunTongState(msgArr, 7);
                    tsjs.F2State = ParseGunTongState(msgArr, 10);
                    tsjs.F3State = ParseGunTongState(msgArr, 13);
                    tsjs.F1DuiJieWei = ParseDuiJieDianState(msgArr, 16);
                    tsjs.F2DuiJieWei = ParseDuiJieDianState(msgArr, 17);
                    tsjs.F3DuiJieWei = ParseDuiJieDianState(msgArr, 18);

                    tsjs.OrderReceive = msgArr[19] == "01" ? "接收到数据" : "没有接收到";

                    if (Form1.tsjs1 == null || !IsEqual(Form1.tsjs1, tsjs))
                    {
                        DB4.TiShengJiState.Add(tsjs);
                        DB4.SaveChanges();
                    }

                    f1.ChangeStatus(2, string.Empty, tsjs);
                }
                catch (Exception ex)
                {
                    Logger.Default.Process(new Log("Info", msg));
                    Logger.Default.Process(new Log("Info", ex.ToString()));

                    //throw ex;
                    WriteToTcp(TiShengOrder.Init);
                    Thread.Sleep(100);
                    WriteToTcp(TiShengOrder.Check);
                }

            }
        }

        private bool IsEqual(TiShengJiState ts1, TiShengJiState ts2)
        {
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(TiShengJiState)))
            {
                if (pd.GetValue(ts1) != pd.GetValue(ts2))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 解析滚筒上货物的状态
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string ParseGunTongState(string[] arr, int index)
        {
            string msg = string.Empty;
            if (arr[index] == TiShengReceive.State00)
                msg = GunZhouState.NoBox;
            else if (arr[index] == TiShengReceive.State01)
                msg = GunZhouState.InBox;
            else if (arr[index] == TiShengReceive.State02)
                msg = GunZhouState.OutBox;
            else if (arr[index] == TiShengReceive.State03)
                msg = GunZhouState.PutBoxOK;
            else if (arr[index] == TiShengReceive.State04)
                msg = GunZhouState.PushBoxOK;
            return msg;
        }


        private string ParseDuiJieDianState(string[] arr, int index)
        {
            string msg = string.Empty;
            if (arr[index] == TiShengReceive.State00)
                msg = GunZhouState.NoBox;
            else if (arr[index] == TiShengReceive.State01)
                msg = GunZhouState.HasBox;
            return msg;
        }


        string F1 = "1";
        string F2 = "2";
        string F3 = "3";
        /// <summary>
        /// 发送提升机命令
        /// </summary>
        /// <param name="startPo">仓位起始点</param>
        /// <param name="endPo">仓位结束点</param>
        /// <param name="count">数量</param>
        public void SendTSJOrder(string startPo, string endPo, int count)
        {
            Logger.Default.Process(new Log("Info", "发送提升机指令"));
            if (count == 1)
            {
                if (startPo.StartsWith(F1) && endPo.StartsWith(F2))
                    WriteToTcp(TiShengOrder.F1T2On1);
                else if (startPo.StartsWith(F1) && endPo.StartsWith(F3))
                    WriteToTcp(TiShengOrder.F1T3On1);
                else if (startPo.StartsWith(F2) && endPo.StartsWith(F1))
                    WriteToTcp(TiShengOrder.F2T1On1);
                else if (startPo.StartsWith(F2) && endPo.StartsWith(F3))
                    WriteToTcp(TiShengOrder.F2T3On1);
                else if (startPo.StartsWith(F3) && endPo.StartsWith(F1))
                    WriteToTcp(TiShengOrder.F3T1On1);
                else if (startPo.StartsWith(F3) && endPo.StartsWith(F2))
                    WriteToTcp(TiShengOrder.F3T2On1);

            }
            else if (count == 2) {
                if (startPo.StartsWith(F1) && endPo.StartsWith(F2))
                    WriteToTcp(TiShengOrder.F1T2On2);
                else if (startPo.StartsWith(F1) && endPo.StartsWith(F3))
                    WriteToTcp(TiShengOrder.F1T3On2);
                else if (startPo.StartsWith(F2) && endPo.StartsWith(F1))
                    WriteToTcp(TiShengOrder.F2T1On2);
                else if (startPo.StartsWith(F2) && endPo.StartsWith(F3))
                    WriteToTcp(TiShengOrder.F2T3On2);
                else if (startPo.StartsWith(F3) && endPo.StartsWith(F1))
                    WriteToTcp(TiShengOrder.F3T1On2);
                else if (startPo.StartsWith(F3) && endPo.StartsWith(F2))
                    WriteToTcp(TiShengOrder.F3T2On2);
            }
            Thread.Sleep(200);

            WriteToTcp(TiShengOrder.Init);
            Thread.Sleep(100);
            WriteToTcp(TiShengOrder.Check);


        }
        #endregion

    } 
    
    public class TiShengCarState {
        public static string NoJob = "空闲中";
        public static string Running = "任务中";
    }

    /// <summary>
    /// 提升机状态变量
    /// </summary>
    public class TiShengReceive
    {
        public static string State00 = "00";
        public static string State01 = "01";
        public static string State02 = "02";
        public static string State03 = "03";
        public static string State04 = "04";
        public static string State05 = "05";

    }
    /// <summary>
    /// 提升机命令变量
    /// </summary>
    public class TiShengOrder
    {
        public static string Init = "0000000000000000";
        public static string Check = "0100000000000000";


        public static string F1T2On2 = "0102020000000001";
        public static string F1T3On2 = "0103020000000001";
        public static string F2T1On2 = "0100000102000001";
        public static string F2T3On2 = "0100000302000001";
        public static string F3T1On2 = "0100000000010201";
        public static string F3T2On2 = "0100000000020201";

        public static string F1T2On1 = "0102010000000001";
        public static string F1T3On1 = "0103010000000001";
        public static string F2T1On1 = "0100000101000001";
        public static string F2T3On1 = "0100000301000001";
        public static string F3T1On1 = "0100000000010101";
        public static string F3T2On1 = "0100000000020101";
    }

    /// <summary>
    /// 滚筒状态变量
    /// </summary>
    public class GunZhouState
    {
        public static string HasBox = "有料箱";
        public static string NoBox = "无料箱";
        public static string InBox = "进货中";
        public static string OutBox = "出货中";
        public static string PutBoxOK = "叉车放料箱到位";
        public static string PushBoxOK = "升降机出料箱到位";
    }
}
