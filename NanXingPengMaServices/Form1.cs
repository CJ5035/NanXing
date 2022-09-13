using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NanXingWMS_old.Entity;
using NanXingWMS_old.Model;
using NanXingWMS_old.Tasks;
using NanXingWMS_old.Utils;
using Newtonsoft.Json;
using SQLHelper;
using ZigBeePrint.Utils;

namespace NanXingWMS_old
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        InStockHelper ish = new InStockHelper();
        AGVInfUtils au = new AGVInfUtils();
        BarTenderUtils btu = null;
     
        AGVMissionThread amt = new AGVMissionThread();
        //批号, 型号, 标准,日期,箱数, 品名
        DataTable outDt = null;
        DataTable inDt = null;
        int inIndex = 0;
        int spId = 0;
        StockPlan f1sp = null;
        TiShengJiHelper tsjh = null;
        FloorMissionHelper fmh = null;

        public static TiShengJiState tsjs1 = null;
        private void Form1_Load(object sender, EventArgs e)
        {


            //string result = "{\"code\":1000,\"data\":{\"areaId\":1,\"createTime\":1636445222,\"taskOrderDetail\":[{\"deviceNum\":\"0183\",\"qrContent\":\"20000759\",\"shelfNumber\":\"\",\"time\":1636446106,\"status\":8}],\"fromSystem\":\"WMS\",\"status\":8},\"desc\":\"success\"}";
            //MissionStates rb = JsonConvert.DeserializeObject<MissionStates>(result);

            Btn_MissionF5_Click(null,null);
            button9_Click(null,null);


            //Thread.Sleep(2000);
            //Debug.WriteLine(tsjh.ClientTcp._endPointendPoint);

            //SETLocaltion();
            //au.GetMissionState(3215440);

            //au.GetAGVState("1", "0", "");

            //SendOrderTest("2021090200005", "20000771,20000356");
            //SendOrderTest("2021090200006", "20000776,20000352");
            //SendOrderTest("2021090200043", "20000140,20000360");

            //Thread.Sleep(500);

            //SendOrderTest("3215448", "20000078,20000091");

            //Thread.Sleep(500);
            //au.CancelMission(3215447);
            //PenMaUtils.StrToHex("P2021052500001010100005");
            //S7SmartCommUtils scu = new S7SmartCommUtils("127.0.0.1",502);
            //string prosn = "P2021052500001010100005";
            //Debug.WriteLine(prosn.Substring(14, 2));
            //string s = scu.ReadBatch("V200", "17");
            //Debug.WriteLine(s);
            //byte[] buff = new byte[s.Length / 2];
            //int index = 0;
            //for (int i = 0; i < s.Length; i += 2)
            //{
            //    buff[index] = Convert.ToByte(s.Substring(i, 2), 16);
            //    ++index;
            //}
            //string result = Encoding.Default.GetString(buff);
            //Debug.WriteLine(result);
            //P2021052400001
            //scu.ClosePLC();

            //手持机插入数据

            //一个线程读数据库，然后调用接口
            //string result = "{\"code\":1000,\"data\":\"3215435\",\"desc\":\"请求成功\"}";
            //Dictionary<string, object> dd = result.Trim(new char[] { '{', '}', ']', '[' }).Replace("[", "").Replace("{", "").Replace("\"", "").Split(',').ToDictionary(s => s.Split(':')[0].Trim(), s => (object)s.Split(':')[1].Trim());
            //foreach(string temp in dd.Keys)
            //{
            //    Debug.WriteLine(temp + ":"+dd[temp].ToString());

            //}
            //Debug.WriteLine(dd["code"].ToString());
            //Debug.WriteLine(dd["data"].ToString());
            //Debug.WriteLine(dd["desc"].ToString());

        }


        private void SETLocaltion()
        {
            for (int i = 2; i <= 115; i++)
            {
                string sql = "insert [NanXingGuoRen_WMS].[dbo].[WareLocation] values(";
                sql += string.Format("'2000{0}','1','49','1','2000{0}',NULL)", i.ToString("D4"));
                Debug.WriteLine(sql);
            }

            for (int i = 727; i <= 747; i++)
            {
                string sql2 = "insert [NanXingGuoRen_WMS].[dbo].[WareLocation] values(";
                sql2 += string.Format("'2000{0}','1','49','1','2000{0}',NULL)", i.ToString("D4"));
                Debug.WriteLine(sql2);
            }


            for (int i = 6381; i <= 6404; i++)
            {
                string sql3 = "insert [NanXingGuoRen_WMS].[dbo].[WareLocation] values(";
                sql3 += string.Format("'2000{0}','1','49','1','2000{0}',NULL)", i.ToString("D4"));
                Debug.WriteLine(sql3);
            }

            for (int i = 532; i <= 726; i++)
            {
                string sql4 = "insert [NanXingGuoRen_WMS].[dbo].[WareLocation] values(";
                sql4 += string.Format("'2000{0}','1','49','1','2000{0}',NULL)", i.ToString("D4"));
                Debug.WriteLine(sql4);
            }

            for (int i = 192; i <= 299; i++)
            {
                string sql5 = "insert [NanXingGuoRen_WMS].[dbo].[WareLocation] values(";
                sql5 += string.Format("'2000{0}','1','49','1','2000{0}',NULL)", i.ToString("D4"));
                Debug.WriteLine(sql5);
            }

            for (int i = 300; i <= 371; i++)
            {
                string sql6 = "insert [NanXingGuoRen_WMS].[dbo].[WareLocation] values(";
                sql6 += string.Format("'2000{0}','1','49','1','2000{0}',NULL)", i.ToString("D4"));
                Debug.WriteLine(sql6);
            }

            for (int i = 468; i <= 531; i++)
            {
                string sql7 = "insert [NanXingGuoRen_WMS].[dbo].[WareLocation] values(";
                sql7 += string.Format("'2000{0}','1','49','1','2000{0}',NULL)", i.ToString("D4"));
                Debug.WriteLine(sql7);
            }

            for (int i = 372; i <= 467; i++)
            {
                string sql8 = "insert [NanXingGuoRen_WMS].[dbo].[WareLocation] values(";
                sql8 += string.Format("'2000{0}','1','49','1','2000{0}',NULL)", i.ToString("D4"));
                Debug.WriteLine(sql8);
            }

            for (int i = 6437; i <= 6466; i++)
            {
                string sql9 = "insert [NanXingGuoRen_WMS].[dbo].[WareLocation] values(";
                sql9 += string.Format("'2000{0}','1','49','1','2000{0}',NULL)", i.ToString("D4"));
                Debug.WriteLine(sql9);
            }

            //Program.DB2.SaveChanges();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId">3215443</param>
        /// <param name="path">"20000091,20000078"</param>
        private void SendOrderTest(string orderId, string path, string orderGroupId,params string[] modelProcess)
        {
            //
            MissionOrder mo = new MissionOrder();
            if (modelProcess.Length == 0)
                modelProcess[0] = "1";
            mo.modelProcessCode = modelProcess[0];
            mo.priority = "6";
            mo.fromSystem = "WMS";
            mo.orderId = orderId;
            mo.orderGroupId = orderGroupId;
            TaskOrderDetails taskOrderDetails = new TaskOrderDetails(path, "", "", "");
            List<TaskOrderDetails> list = new List<TaskOrderDetails>();
            list.Add(taskOrderDetails);
            mo.taskOrderDetail = list;

            au.SendMissionOrder(mo);
        }

        private void CB_PRName_DropDown(object sender, EventArgs e)
        {
            DataTable dt = ExcelUtils.ReadExcel(Directory.GetCurrentDirectory() + "/排产工艺名.xls");
            CB_PRName.DataSource = dt;
            CB_PRName.ValueMember = "物料名称";
            CB_PRName.DisplayMember = "物料名称";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != string.Empty)
            {
                int index = int.Parse(textBox3.Text.Trim());
                for (int i1 = 0; i1 < index; i1++)
                {
                    //
                    //string boxNo = DateTime.Now.ToString("yyMMdd") +;

                    //执行存储过程，返回流水号
                    Type t = typeof(string);
                    SqlParameter[] sqlParms = new SqlParameter[1];
                    sqlParms[0] = new SqlParameter("@MaintainCate", "PrintTest");

                    var result = "2" + Program.DB2.Database.SqlQuery(t, "exec GetSeq_2 @MaintainCate", sqlParms).Cast<string>().First();

                    //生成新托盘
                    TrayState ts = new TrayState();
                    ts.TrayNO = result;
                    ts.OnlineCount = int.Parse(textBox2.Text.Trim());
                    ts.optdate = DateTime.Now;

                    Program.DB2.TrayState.Add(ts);
                    //Program.DB2.SaveChanges();

                    DateTime dt = DateTime.Now;
                    //插入production表
                    int num = int.Parse(textBox2.Text);
                    for (int i = 0; i < num; i++)
                    {

                        Production pd = new Production();
                        pd.prosn = result + (i + 1).ToString("D5");
                        pd.proname = CB_PRName.Text.Trim();
                        pd.prodate = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        pd.ProductOrderlistsID = 2;
                        pd.batchNo = Text_BatchNo.Text.Trim();
                        pd.ProductOrderlists = Program.DB2.ProductOrderlists.Where(u => u.ID == 3).FirstOrDefault();
                        pd.ProductOrderlistsID = 3;
                        pd.boxNo = "B0001";
                        pd.boxName = CB_baocai.Text.Trim();
                        pd.@class = "大包装车间";
                        pd.itemno = string.Empty;
                        pd.protype = CB_type.Text.Trim();
                        pd.color = CB_guose.Text.Trim();
                        pd.probiaozhun = CB_biaozhun.Text.Trim();
                        pd.spec = CB_Spec.Text.Trim();
                        pd.yuanliaobatchNo = Text_YLBatchNo.Text.Trim();
                        pd.remark1 = Text_Remark.Text.Trim();
                        Program.DB2.Production.Add(pd);

                        //插入关联表
                        TrayPro tp = new TrayPro();
                        tp.prosn = pd.prosn;
                        tp.TrayState = ts;
                        tp.TrayStateID = ts.ID;
                        tp.optdate = dt;
                        Program.DB2.TrayPro.Add(tp);
                    }

                    Program.DB2.SaveChanges();

                    PrintItem printItem =
                        new PrintItem(CB_PRName.Text.Trim(), result, dateTimePicker1.Value.ToString("yyyy-MM-dd"), textBox2.Text.Trim(), Text_BatchNo.Text.Trim()
                        , Text_YLBatchNo.Text.Trim(), CB_guose.Text.Trim(), CB_biaozhun.Text.Trim(), CB_baocai.Text.Trim()
                        , Text_Remark.Text.Trim(), CB_Spec.Text.Trim());
                    //print
                    if (btu != null)
                    {
                        btu.PrintLabel(printItem);
                    }
                    else
                        MessageBox.Show("bartender打印组件未初始化，请重启软件");
                }
            }


            //PrintNewUtils pnu = new PrintNewUtils();
            //pnu.Print(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool ret = false;
            if (Text_ScanProsn.Text.Trim() != string.Empty)
            {
                var q = Program.DB2.AGVMissionInfo.Where(u => u.TrayNo == Text_ScanProsn.Text.Trim() && u.Mark == "02" && u.SendState == "成功" && u.RunState != "已取消" && u.RunState != "已完成");
                if (q.Count() > 0)
                {

                    MessageBox.Show("该条码已在入库任务中");
                    return;
                }

                TrayState q1 = Program.DB2.TrayState.Where(u => u.TrayNO == Text_ScanProsn.Text.Trim()).FirstOrDefault();
                if (q1 != null)
                {
                    if (q1.WareLocation != null)
                    {
                        MessageBox.Show("该条码已入仓");
                        return;
                    }
                }

                //插入数据
                AGVMissionInfo mission = new AGVMissionInfo();

                //执行存储过程，返回流水号
                Type t = typeof(string);
                SqlParameter[] sqlParms = new SqlParameter[1];
                sqlParms[0] = new SqlParameter("@MaintainCate", "MissionNo");

                var result = Program.DB2.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();
                WareLocation swl = Program.DB2.WareLocation.Where(u => u.WareLocaNo == CB_StartPo.Text.Trim()).FirstOrDefault();
                WareLocation ewl = Program.DB2.WareLocation.Where(u => u.WareLocaNo == CB_EndPo.Text.Trim()).FirstOrDefault();

                if (swl != null)
                {
                    mission.MissionNo = result;
                    mission.AreaClass = result;
                    mission.OrderTime = DateTime.Now;
                    mission.SortIndex = 1;
                    mission.StartLocation = swl.AGVPosition.Trim();
                    mission.EndLocation = ewl.AGVPosition.Trim();
                    mission.RunState = string.Empty;
                    mission.Mark = "02";
                    mission.TrayNo = Text_ScanProsn.Text.Trim();
                    mission.StockPlan_ID = spId;
                    mission.StockPlan = f1sp;
                    Program.DB2.AGVMissionInfo.Add(mission);
                    Program.DB2.SaveChanges();
                    string lineOrder = inDt.Rows[inIndex]["lie"].ToString() + f1sp.PlanNo;
                    //开线程读
                    SendOrderTest(result, swl.AGVPosition + "," + ewl.AGVPosition, lineOrder);
                    inIndex = inIndex + 1;
                    button2.Enabled = false;
                }
                Btn_MissionF5_Click(null, null);
            }

            Text_ScanProsn.Text = string.Empty;
            Lab_BatchNo.Text = string.Empty;
            Lab_ScanProName.Text = string.Empty;
            Lab_SCDate.Text = string.Empty;
            Lab_Num.Text = string.Empty;
            CB_StartPo.Text = string.Empty;
            CB_EndPo.Text = string.Empty;
            Text_ScanProsn.Focus();
        }

        private void SendAGVOrder(string startPo, string endPo)
        {
            AGVMissionInfo mission = new AGVMissionInfo();

            //执行存储过程，返回流水号
            Type t = typeof(string);
            SqlParameter[] sqlParms = new SqlParameter[1];
            sqlParms[0] = new SqlParameter("@MaintainCate", "MissionNo");

            var result = Program.DB2.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();
            WareLocation wl = Program.DB2.WareLocation.Where(u => u.AGVPosition == startPo).FirstOrDefault();
            if (wl != null)
            {
                mission.MissionNo = result;
                mission.AreaClass = result;
                mission.OrderTime = DateTime.Now;
                mission.SortIndex = 1;
                mission.StartLocation = wl.AGVPosition.Trim();
                mission.EndLocation = endPo;
                mission.Mark = "02";
                mission.TrayNo = Text_ScanProsn.Text.Trim();

                Program.DB2.AGVMissionInfo.Add(mission);
                Program.DB2.SaveChanges();

                //开线程读
                //SendOrderTest(result, wl.AGVPosition + "," + endPo);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int kc = e.KeyChar;
            if ((kc < 48 || kc > 57) && kc != 8)
                e.Handled = true;
        }

        private void Text_ScanProsn_Enter(object sender, EventArgs e)
        {
            if (Text_ScanProsn.Text.Trim() != string.Empty)
            {
                //查询条码前确定是否有入库计划
                if (f1sp == null)
                {
                    MessageBox.Show("请先新增入库计划再扫描条码进仓");
                }
                else
                {
                    //查询条码信息
                    TrayState ts = Program.DB2.TrayState.Where(u => u.TrayNO == Text_ScanProsn.Text.Trim()).FirstOrDefault();
                    if (ts != null)
                    {
                        ICollection<TrayPro> list = ts.TrayPro;

                        List<TrayPro> list2 = new List<TrayPro>();
                        foreach (var i in list)
                        {
                            TrayPro t = i as TrayPro;
                            if (t != null)
                            {
                                list2.Add(t);
                            }
                        }
                        if (list2.Count > 0)
                        {
                            string ps = list2[0].prosn;
                            Production pd = Program.DB2.Production.Where(u => u.prosn == ps).FirstOrDefault();
                            Lab_BatchNo.Text = pd.batchNo;
                            Lab_ScanProName.Text = pd.proname;
                            Lab_SCDate.Text = pd.prodate.ToString("yyyy-MM-dd");
                            Lab_Num.Text = ts.OnlineCount.ToString();
                            if (pd.proname== f1sp.proname &&pd.batchNo== f1sp.batchNo )
                            {
                                Debug.WriteLine(inDt.Rows[inIndex]["lie"] + inDt.Rows[inIndex]["xuhao"].ToString() + "::" + inDt.Rows[inIndex]["AGVPosition"].ToString());
                             
                                CB_EndPo.Text = inDt.Rows[inIndex]["lie"] + inDt.Rows[inIndex]["xuhao"].ToString();


                                button2.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("扫描的产品与入库计划不符，请重新扫描正确的产品或重新新增入库计划");
                            }
                           
                        }
                    }
                    else
                    {
                        Lab_BatchNo.Text = string.Empty;
                        Lab_ScanProName.Text = string.Empty;
                        Lab_SCDate.Text = string.Empty;
                        Lab_Num.Text = string.Empty;
                        CB_StartPo.Text = string.Empty;
                        CB_EndPo.Text = string.Empty;
                    }

                }
            }
            else
            {
                Lab_BatchNo.Text = string.Empty;
                Lab_ScanProName.Text = string.Empty;
                Lab_SCDate.Text = string.Empty;
                Lab_Num.Text = string.Empty;
                CB_StartPo.Text = string.Empty;
                CB_EndPo.Text = string.Empty;
            }

        }
        private void Text_ScanProsn_Leave(object sender, EventArgs e)
        {
            Text_ScanProsn_Enter(sender, e);
        }

        private void ShowDT2()
        {
            string sql = @"select d.WareLocaNo 仓位号,b.batchNo 批号,c.TrayNO 托号,c.OnlineCount 箱数,proname 品名
                from TrayPro a,Production b,TrayState c,WareLocation d 
               where a.prosn=b.prosn and c.WareLocation_ID=d.ID and c.ID=a.TrayStateID
               group by TrayStateID, proname,d.WareLocaNo,OnlineCount,d.AGVPosition,c.TrayNO,b.batchNo";

            Type t = typeof(DataTable);
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);

            DGV_OutStock.DataSource = dt;
            DGV_OutStock.CurrentCell = null;
        }

        private void DGV_OutStock_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (DGV_OutStock.SelectedCells.Count > 0)
            {
                //批号,型号,标准,日期,箱数,品名
                DataTable dt = (DataTable)DGV_OutStock.DataSource;
                int row = DGV_OutStock.SelectedCells[0].RowIndex;
                int column = DGV_OutStock.SelectedCells[0].ColumnIndex;
                string str = dt.Rows[row][1].ToString();


                OutStockItem osi = new OutStockItem();
                osi.batchNo = dt.Rows[row]["批号"].ToString();
                osi.probiaozhun = dt.Rows[row]["标准"].ToString();
                osi.spec = dt.Rows[row]["型号"].ToString();
                osi.prodate = Convert.ToDateTime(dt.Rows[row]["日期"].ToString());
                osi.proName = dt.Rows[row]["品名"].ToString();
                osi.count = int.Parse(dt.Rows[row]["理论箱数"].ToString());
                osi.color = dt.Rows[row]["颜色"].ToString();
                osi.usableCount = int.Parse(dt.Rows[row]["可用箱数"].ToString());
                OutStockForm osf = new OutStockForm(osi);
                osf.ShowDialog();
                Btn_MissionF5_Click(null, null);
                //Lab_CangWei.Text = dt.Rows[row]["批号"].ToString();
                //Lab_SelectTrayNo.Text = dt.Rows[row][2].ToString();
                //button3.Enabled = true;
            }
            else
                Btn_CancelMission.Enabled = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (Lab_CangWei.Text.Trim() != string.Empty && CB_OutEndPo.Text.Trim() != string.Empty)
            //{
            //    //插入数据
            //    AGVMissionInfo mission = new AGVMissionInfo();

            //    //执行存储过程，返回流水号
            //    Type t = typeof(string);
            //    SqlParameter[] sqlParms = new SqlParameter[1];
            //    sqlParms[0] = new SqlParameter("@MaintainCate", "MissionNo");

            //    var result = Program.DB2.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();
            //    WareLocation wl = Program.DB2.WareLocation.Where(u => u.WareLocaNo == CB_OutEndPo.Text.Trim()).FirstOrDefault();

            //    mission.MissionNo = result;
            //    mission.AreaClass = result;
            //    mission.OrderTime = DateTime.Now;
            //    mission.SortIndex = 1;
            //    mission.StartLocation = Lab_CangWei.Text.Trim();
            //    mission.EndLocation = wl.AGVPosition;
            //    mission.Mark = "03";
            //    mission.TrayNo = Lab_SelectTrayNo.Text.Trim();

            //    Program.DB2.AGVMissionInfo.Add(mission);
            //    Program.DB2.SaveChanges();
            //    //开线程读
            //    SendOrderTest(result, Lab_CangWei.Text.Trim() + "," + wl.AGVPosition.Trim());
            //    button3.Enabled = false;
            //    Lab_CangWei.Text = string.Empty;
            //    Lab_SelectTrayNo.Text = string.Empty;
            //    CB_OutEndPo.Text = string.Empty;
            //}

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void CB_StartPo_DropDown(object sender, EventArgs e)
        {
            var q = from a in Program.DB2.WareLocation.Where(u => 
            u.WareArea.WareAreaClass.AreaClass=="入库位" && u.WareArea.WareHouse_ID == 2)
                    select new ListClass
                    {
                        temp = a.WareLocaNo
                    };
            DataTable dt = ShowMission.ConvertToDataTable<ListClass>(q);
            List<string> list = new List<string>();
            if (dt != null && dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                    list.Add(dr[0].ToString());

            CB_StartPo.DataSource = list;
        }

        private void CB_EndPo_DropDown(object sender, EventArgs e)
        {
            //var q = from a in Program.DB2.WareLocation.Where(u => u.WareArea.WareAreaClass.AreaClass.Contains("成品区") && u.WareLocaState == true)
            //        select new ListClass
            //        {
            //            temp = a.WareLocaNo
            //        };
            //DataTable dt = ShowMission.ConvertToDataTable<ListClass>(q);
            //List<string> list = new List<string>();
            //if (dt != null && dt.Rows.Count > 0)
            //    foreach (DataRow dr in dt.Rows)
            //        list.Add(dr[0].ToString());
            //CB_EndPo.DataSource = list;
        }

        private void CB_OutEndPo_DropDown(object sender, EventArgs e)
        {
            //var q = from a in Program.DB2.WareLocation.Where(u => !u.WareArea.WareAreaClass.AreaClass.Contains("成品区") && u.WareLocaState == true)
            //        select new ListClass
            //        {
            //            temp = a.WareLocaNo
            //        };
            //DataTable dt = ShowMission.ConvertToDataTable<ListClass>(q);
            //List<string> list = new List<string>();
            //if (dt != null && dt.Rows.Count > 0)
            //    foreach (DataRow dr in dt.Rows)
            //        list.Add(dr[0].ToString());
            //CB_OutEndPo.DataSource = list;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "出仓")
            {
                Btn_SearchPro_Click(sender, e);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int kc = e.KeyChar;
            if ((kc < 48 || kc > 57) && kc != 8)
                e.Handled = true;
        }

        private void Btn_SearchPro_Click(object sender, EventArgs e)
        {
            string sql = string.Format(@"
                select 批号,型号,标准,日期,箱数 理论箱数,箱数-isnull(b.prepareCount,0) 可用箱数,品名,颜色 from
                (select batchNo 批号,spec 型号,probiaozhun 标准,
                convert(nvarchar,prodate,23) 日期,count(TrayState.OnlineCount) 箱数,proname 品名,color 颜色
                from TrayState,TrayPro,Production,WareLocation
                where TrayState.ID=TrayPro.TrayStateID and TrayPro.prosn=production.prosn and WareLocation_ID=WareLocation.ID
                and len(proname) >0
                and proname like '%{0}%' and spec like '%{1}%' and probiaozhun like '%{2}%' and batchNo like '%{3}%'
                group by proname,spec,probiaozhun,batchNo,prodate,color
                )a
                left join (
                select c.proname ,c.probiaozhun,c.batchNo,c.color,c.spec,SUM(OnlineCount) prepareCount,e.prodate
                from  AGVMissionInfo a,StockPlan c,
                (select b.trayno,e.proname ,e.probiaozhun,e.batchNo,e.color,e.spec,e.prodate,COUNT(d.prosn) OnlineCount
                 from TrayState b,TrayPro d,Production e 
                where  b.ID=d.TrayStateID and d.prosn=e.prosn
                group by b.trayno,e.proname ,e.probiaozhun,e.batchNo,e.color,e.spec,e.prodate)e
                where a.mark='03' and a.TrayNo=e.TrayNO and  a.StockPlan_ID=c.ID
                and SendState='成功'  and (RunState !='已完成' and RunState!='已取消' and RunState!='执行失败'
                and RunState!='发送失败')
                GROUP BY 
                c.proname ,c.probiaozhun,c.batchNo,c.color,c.spec,e.prodate)
                b
                on a.品名=b.proname and a.型号=b.spec and a.批号=b.batchNo and a.标准=b.probiaozhun
                ORDER BY prodate ASC,proname,spec,probiaozhun"
                , CB_OutProName.Text.Trim(), Text_Spec.Text.Trim(), Text_ProBiaoZhun.Text.Trim(), Text_CPBatchNo.Text.Trim());

            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            outDt = dt;
            DGV_OutStock.DataSource = dt;
            DGV_OutStock.CurrentCell = null;
        }

        private void CB_OutProName_DropDown(object sender, EventArgs e)
        {
            DataTable dt = GetPronameInStock();
            CB_OutProName.DataSource = dt;
            CB_OutProName.ValueMember = "proname";
            CB_OutProName.DisplayMember = "proname";
        }

        private DataTable GetPronameInStock()
        {
            string sql = @"select e.proname 
                 from TrayState b,TrayPro d,Production e 
                where  b.ID=d.TrayStateID and d.prosn=e.prosn
                and len(b.WareLocation_ID)>0
                group by e.proname ";
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            return dt;
        }

        private void Btn_NewPlan_Click(object sender, EventArgs e)
        {
            NewInStockForm nisf = new NewInStockForm(this);
            if (nisf.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine(Lab_PlanNum.Text.Trim());
                //inDt = ish.In(Convert.ToInt32(Lab_PlanNum.Text.Trim()));
            }
        }

        public void SetIn(int count)
        {
            inDt = ish.In(count);
        }

        //更改Form1信息的委托
        public delegate void MyInvoke(int type, string str,params TiShengJiState[] ts);
        //控制器更改Form信息
        public void ChangeStatus(int type, string str, params TiShengJiState[] ts)
        {
            MyInvoke mi = new MyInvoke(UpdateUI);
            this.BeginInvoke(mi, type, str, ts);

        }

        private void UpdateUI(int type, string str, params TiShengJiState[] ts)
        {
            if (type == 1)
            {
                //格式:品名;批号;预计数量
                string[] arr = str.Split(';');
                Lab_PlanProName.Text = arr[0];
                Lab_PlanBatchNo.Text = arr[1];
                Lab_PlanNum.Text = arr[2];
                spId = InsertStockPlan(arr[0], arr[1], arr[2]);
                //ShowChange();
            }else if (type == 2)
            {
                tsjs1 = ts[0];
            }
            else if (type == 3)
            {
                Lab_Tip.Text = str;
            }
            else if (type == 4)
            {
                button12_Click(null, null);
            }

        }
        private int InsertStockPlan(string name, string batchNo, string count)
        {
            StockPlan sp = new StockPlan();
            Type t = typeof(string);
            SqlParameter[] sqlParms = new SqlParameter[1];
            sqlParms[0] = new SqlParameter("@MaintainCate", "Out");

            var result = Program.DB2.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();
            sp.PlanNo = result;
            sp.proname = name;
            sp.batchNo = batchNo;
            sp.count = Convert.ToInt32(count);
            sp.mark = "02";
            sp.states = "0";
            sp.plantime = DateTime.Now;
            sp.position = ConfigurationManager.AppSettings["position"];
            Program.DB2.StockPlan.Add(sp);
            Program.DB2.SaveChanges();
            this.f1sp = sp;
            return sp.ID;
        }

        private void Text_ScanProsn_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_MissionF5_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse("1900-01-01");
            var q = (from a in Program.DB2.AGVMissionInfo
                    orderby a.OrderTime descending
                    select new ShowMission
                    {
                        任务单号 = a.MissionNo,
                        任务时间 = a.OrderTime ?? dt,
                        任务起点 = a.StartLocation,
                        任务终点 = a.EndLocation,
                        发送结果 = a.SendState ?? "",
                        执行结果 = a.RunState ?? "",
                        执行设备=a.AGVCarId??""
                    }).Take(10);
            //DataTable cDt = ShowMission.ConvertToDataTable<ShowMission>(q);
            //cDt.Columns[0].ColumnName = "任务单号";
            //cDt.Columns[1].ColumnName = "任务时间";
            //cDt.Columns[2].ColumnName = "任务起点";
            //cDt.Columns[3].ColumnName = "任务终点";
            //cDt.Columns[4].ColumnName = "发送结果";
            //cDt.Columns[5].ColumnName = "执行结果";
            //cDt.Columns[6].ColumnName = "执行设备";

            DGV_MissionRecord.DataSource = ShowMission.ConvertToDataTable<ShowMission>(q);
            DGV_MissionRecord.CurrentCell = null;
        }

        private void Btn_CancelMission_Click(object sender, EventArgs e)
        {
            if (DGV_MissionRecord.SelectedRows.Count>0)
            {
                List<string> orderIDs = new List<string>();
                //DataTable dt= DGV_MissionRecord.select
                foreach (DataGridViewRow row in DGV_MissionRecord.SelectedRows)
                {
                    orderIDs.Add(row.Cells[0].Value.ToString());
                }
                
            }
        }

        private void F3T1_Click(object sender, EventArgs e)
        {
            tsjh.WriteToTcp(TiShengOrder.F3T2On1);
            Thread.Sleep(500);
            tsjh.WriteToTcp("0100000000000000");
        }
        private void F1T2_Click(object sender, EventArgs e)
        {
            tsjh.WriteToTcp(TiShengOrder.F1T2On2);
            Thread.Sleep(500);
            tsjh.WriteToTcp("0100000000000000");
        }
        private void F2T3_Click(object sender, EventArgs e)
        {
            tsjh.WriteToTcp(TiShengOrder.F2T1On2);
            Thread.Sleep(500);
            tsjh.WriteToTcp("0100000000000000");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SendOrderTest("2021090399977", 22006567 + "," + 22000710 + "," + 22000710 + "," + 22000710, string.Empty, "3");
            //SendOrderTest("2021090399989", 22000400 + "," + 22006567 + "," + 22006567 + "," + 22006567, string.Empty, "4");

            //SendOrderTest("2021090399984", 11000001 + "," + 11000091 + "," + 11000091 + "," + 11000091, string.Empty, "713");
            //SendOrderTest("2021090399984", 11000091 + "," + 11000001 + "," + 11000001 + "," + 11000001, string.Empty, "714");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //tsjh.CloseTcp();
            //tsjh.OpenTcp("192.168.0.54", 9232);
            if(tsjh!=null && tsjh.ClientTcp!=null && tsjh.ClientTcp._isConnected)
                tsjh.WriteToTcp(TiShengOrder.Check);

            var q= Program.DB2.TiShengJiState.OrderByDescending(u => u.InputTime).Take(5).AsQueryable();
            DataTable dt = ShowMission.ConvertToDataTable<TiShengJiState>(q);
            
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell = null;

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            tsjh = new TiShengJiHelper(this);
            fmh = new FloorMissionHelper(tsjh);
            au.ip = "192.168.3.180";

            btu = new BarTenderUtils();

            InOutThread iot = new InOutThread();
            Thread thread = new Thread(new ThreadStart(iot.Init));
            thread.IsBackground = true;
            thread.Start();

            Thread thread2 = new Thread(new ThreadStart(amt.Init));
            thread2.IsBackground = true;
            thread2.Start();

            tsjh.OpenTcp(ConfigurationManager.AppSettings["tsj-2-IP"], int.Parse(ConfigurationManager.AppSettings["tsj-2-Port"]));

            //tsjh.OpenTcp("127.0.0.1", 60000);

            Task.Run(() => fmh.Init());
            hzu.form1 = this;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tsjh.WriteToTcp("0004000400040000");
            Thread.Sleep(500);
            tsjh.WriteToTcp("0100000000000000");
        }
        HuanZhuanUtils hzu = new HuanZhuanUtils();
        Thread thread = null;
        private void button11_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(hzu.GetHuiZhuan));
            thread.IsBackground = true;
            thread.Start();
            button11.Enabled = false; 
            button12.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                hzu.Close();
                button12.Enabled = false;
                button11.Enabled = true;
                //thread.Abort();
            }
            catch
            {

            }
        }
    }
}
