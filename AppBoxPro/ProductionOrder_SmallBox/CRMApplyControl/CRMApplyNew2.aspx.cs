using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingGuoRen_WMS.Business.Helper;
using NanXingService_WMS.Entity;
using NanXingService_WMS.Entity.CRMEntity.CRMAppleNoEntity;
using NanXingService_WMS.Utils;
using Newtonsoft.Json.Linq;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilsSharp;

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox.CRMApplyControl
{
    public partial class CRMApplyNew2: PageBase
    {
        //private bool AppendToEnd = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //datepicker1.SelectedDate = DateTime.Now;
                // 删除选中单元格的客户端脚本
                string deleteScript = GetDeleteScript();

                // 新增数据初始值
                JObject defaultObj = new JObject();

                // 在第一行新增一条数据
                //btnNew.OnClientClick = Grid1.GetAddNewRecordReference(defaultObj, AppendToEnd);

                // 重置表格
                //btnReset.OnClientClick = Confirm.GetShowReference("确定要重置表格数据？", String.Empty, Grid1.GetRejectChangesReference(), String.Empty);

                // 删除选中行按钮
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference("请至少选择一项！") + deleteScript;

                LoadData();
            }
        }

        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, Grid1.GetDeleteSelectedRowsReference(), String.Empty);
        }
        string redisKey_List = string.Empty;
        private void LoadData()
        {
            Lab_PCY.Text = GetIdentityName();
            //清楚Redis数据(包括新增)
            string ipAddress = GetLocalIp();
            string[] idStrs = GetQueryValue("ids").Split(',');

            redisKey_List = $"{ipAddress}{Lab_PCY.Text}:ADDOrderList";
            string redisKey_Header = $"{ipAddress}{Lab_PCY.Text}:ADDOrderHeader";

            if(idStrs.Length==0)
            {
                idStrs[0] = "0";
            }
            
            foreach (string temp in idStrs)
            {
                if (redisHelper.HashExists(redisKey_List, temp))
                {
                    redisHelper.HashDelete(redisKey_List, temp);
                }
                if (redisHelper.HashExists(redisKey_Header, temp))
                {
                    redisHelper.HashDelete(redisKey_Header, temp);
                }
            }

            hbDate.SelectedDate = DateTime.Now;
            BindGrid1();
        }

        private void BindGrid1()
        {
            string[] idStrs = GetQueryValue("ids").Split(',');
            long[] ids = Array.ConvertAll<string, long>(idStrs, s => long.Parse(s));
            var q = crmPlanManager.GetMissionControlIndex(u =>ids.Contains( u.ID));
            List<CRMApplyIndexData> qlist = q.ToList();
            List<ProPlanOrderlists> proList = new List<ProPlanOrderlists>(qlist.Count);
            string Priority = "正常";

            //因为不能识别外包装箱号、箱名是否已有数据，先清空再Upate BoxNo、BoxName这两列
            qlist.ForEach((item)=>{
                

                //组成ProPlanOrderlists放进去、
                ProPlanOrderlists ProPlanOrderlists = new ProPlanOrderlists();
                ProPlanOrderlists.ItemName = item.ItemName;
                ProPlanOrderlists.InName = item.ItemName;
                ProPlanOrderlists.CRMPlanList_ID = item.ID;
                ProPlanOrderlists.PcCount = item.OrderCount;
                ProPlanOrderlists.Unit = item.Unit;
                ProPlanOrderlists.BoxNo = item.BoxNo;
                ProPlanOrderlists.BoxName = item.BoxName;
                ProPlanOrderlists.BoxRemark = item.BoxRemark;
                ProPlanOrderlists.Priority = Priority;
                proList.Add(ProPlanOrderlists);

                item.BoxNo = string.Empty;
                item.BoxName = string.Empty;

            });
            var qParse = qlist.AsQueryable();

            Grid1.RecordCount = qParse.Count();
            
            Grid1.DataSource = qParse;
            Grid1.DataBind();




            qlist = q.ToList();
            for (int index = 0; index < Grid1.RecordCount; index++)
            {
                Grid1.UpdateCellValue(index, "PcCount", qlist[index].OrderCount.ToString());
                Grid1.UpdateCellValue(index, "PcUnit", qlist[index].Unit??string.Empty);
                Grid1.UpdateCellValue(index, "BoxNo", qlist[index].BoxNo ?? string.Empty);
                Grid1.UpdateCellValue(index, "BoxName", qlist[index].BoxName ?? string.Empty);
                Grid1.UpdateCellValue(index, "Priority", Priority);

                Grid1.UpdateCellValue(index, "PcCount_03", qlist[index].OrderCount.ToString());
                Grid1.UpdateCellValue(index, "PcCount_07", qlist[index].OrderCount.ToString());

            }

        }

        private string ReplaceTeShu(string str)
        {
            str = str.Replace(" ", ",");
            str = str.Replace("，", ",");
            str = str.Replace("、", ",");
            str = str.Replace("；", ",");
            str = str.Replace(";", ",");
            return str;
        }
        private string GetCheckedValuesString(string[][] array)
        {
            if (array.Length == 0)
            {
                return "无";
            }

            StringBuilder sb = new StringBuilder();
            foreach (string[] item in array)
            {
                sb.Append( string.Join(",", item));
                //sb.Append(item);
                if(item.Length>0)
                    sb.Append(",");
            }
            return sb.ToString().TrimEnd(',');
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, object>> modDic = Grid1.GetModifiedDict();
            if (modDic.Count <= 0)
            {
                Alert.Show("没有需要合并的任务申请单，请重新选择需要合并的申请单");
                return;
            }

            string positionStr = GetCheckedValuesString(new string[2][] { 
                CheckBoxList2.SelectedValueArray, CheckBoxList3.SelectedValueArray });
            if (string.IsNullOrEmpty(positionStr))
            {
                Alert.Show("请选择排产车间");
                return;
            }
            List<object[]> keys=Grid1.DataKeys;
            
            List<int> modDicIndex = modDic.Keys.ToList();
            List<Dictionary<string, object>> modDicValue = modDic.Values.ToList();

            //ProPlanOrderheaders ProPlanOrderheaders = new ProPlanOrderheaders();
            //执行存储过程，返回流水号
           
            string result = liuShuiHaoService.GetPlanOrderLSH() ;

            DateTime nowDt = DateTime.Now;
            

            string[] colstr=new string[] { "crmListStatus" };
            List<string> arr = new List<string>(CheckBoxList2.SelectedValueArray.Length + CheckBoxList3.SelectedValueArray.Length);
            foreach (string temp in CheckBoxList2.SelectedValueArray)
                arr.Add(temp);
            foreach (string temp in CheckBoxList3.SelectedValueArray)
                arr.Add(temp);

            List<ProPlanOrderheaders> headerList = new List<ProPlanOrderheaders>(modDic.Count);

            for (int i = 0; i < modDic.Count; i++)
            {
                //一行一个表头，并记录成品信息

                int index = modDicIndex[i];
                int ID=Convert.ToInt32(keys[index][0]);
                Dictionary<string, object> dic = modDicValue[i];
                List<string> columnList = dic.Keys.ToList();

                CRMPlanList cpl=crmPlanManager.GetList(ID);

                ProPlanOrderheaders ProPlanOrderheaders = new ProPlanOrderheaders();

                ProPlanOrderheaders.OrderNo = result;
                ProPlanOrderheaders.PlanOrderNo = $"{ProPlanOrderheaders.OrderNo}-{(i + 1).ToString("D2")}";

                ProPlanOrderheaders.Optdate = nowDt;
                ProPlanOrderheaders.Newdate = nowDt;
                ProPlanOrderheaders.Moddate = nowDt;
                //ProPlanOrderheaders.orderNo = orderNo.Text.Trim();
                //ProPlanOrderheaders.positionClass = ddl_Class.SelectedValue;
                ProPlanOrderheaders.mergeCells = DropDownBox1.Text;
                ProPlanOrderheaders.mergeCellsValue = string.Join(",", DropDownBox1.Values);
                ProPlanOrderheaders.Workshops = string.Join(",",arr.ToArray());
                ProPlanOrderheaders.ProPlanOrderlists = new List<ProPlanOrderlists>(arr.Count);
                ProPlanOrderheaders.PositionClass = "小包装排产单";
                ProPlanOrderheaders.Jingbanren = GetIdentityName();
                ProPlanOrderheaders.OrderNo = result;
                ProPlanOrderheaders.CRMPlanList_ID = ID;
                ProPlanOrderheaders.DeliveryDate = cpl.DeliveryDate;
                ProPlanOrderheaders.Itemno = cpl.ItemNo;
                ProPlanOrderheaders.ItemName = cpl.ItemName;
                ProPlanOrderheaders.Spec = cpl.Spec;
                ProPlanOrderheaders.Biaozhun = cpl.Biaozhun;
                ProPlanOrderheaders.Clientname = cpl.CRMPlanHead.ClientName;
                ProPlanOrderheaders.Remark = cpl.Remark;
                if (dic.ContainsKey("PcCount")) 
                    ProPlanOrderheaders.PcCount = decimal.Parse(dic["PcCount"].ToString());
                if (dic.ContainsKey("PcUnit")) 
                    ProPlanOrderheaders.Unit = dic["PcUnit"].ToString();
                if (dic.ContainsKey("BatchNo"))
                    ProPlanOrderheaders.BatchNo = dic["BatchNo"].ToString();
                if (dic.ContainsKey("BoxNo"))
                    ProPlanOrderheaders.BoxNo = dic["BoxNo"].ToString();
                if (dic.ContainsKey("BoxName"))
                    ProPlanOrderheaders.BoxName = dic["BoxName"].ToString();
                if (dic.ContainsKey("BoxRemark"))
                    ProPlanOrderheaders.BoxRemark = dic["BoxRemark"].ToString();
                for (int index_Position = 0; index_Position < arr.Count; index_Position++)
                {
                    string sx = GetPositionOrderName(arr[index_Position]);
                    ProPlanOrderlists item = GetOrderlist(dic, cpl, arr[index_Position]);
                    item.ProPlanOrderheaders = ProPlanOrderheaders;
                    

                    item.PlanOrder_XuHao = $"{ProPlanOrderheaders.PlanOrderNo}-{sx}";
                    item.Chejianclass = arr[index_Position];
                    item.ProPlanOrderheaders = ProPlanOrderheaders;
                    item.ERPOrderNo = ProPlanOrderheaders.PlanOrderNo;
                    ProPlanOrderheaders.ProPlanOrderlists.Add(item);
                }

                headerList.Add(ProPlanOrderheaders);


            }

            bool  ret= proPlanOrderManager.AddProOrders(headerList,true);
            if (ret)
                Alert.Show("保存成功");
            else
                Alert.Show("保存失败");
            //DB2.SaveChanges();
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            
        }
        private ProPlanOrderlists GetOrderlist(Dictionary<string, object> dic, CRMPlanList cpl,string position)
        {
            ProPlanOrderlists item = new ProPlanOrderlists();
            item.Newdate = DateTime.Now;
            item.Moddate = DateTime.Now;

            item.Itemno = cpl.ItemNo;
            item.ItemName = cpl.ItemName;
            item.Spec = cpl.Spec;
            item.Biaozhun = cpl.Biaozhun;
            item.Clientname = cpl.CRMPlanHead.ClientName;
            item.ProductRecipe = cpl.ProductRecipe;
            item.BoxNo = cpl.BoxNo;
            item.BoxName = cpl.BoxName;
            item.BoxRemark = cpl.BoxRemark;


            if (dic.ContainsKey("ItemName1")) item.InName = dic["ItemName1"].ToString();
            if (dic.ContainsKey("ItemName2")) item.MaterialItem = dic["ItemName2"].ToString();
            if (dic.ContainsKey("Color")) item.Color = dic["Color"].ToString();
            if (dic.ContainsKey("PlanDate")) item.PlanDate = DateTime.Parse(dic["PlanDate"].ToString());
            if (dic.ContainsKey("PlanTime")) item.PlanTime = dic["PlanTime"].ToString();
            if (dic.ContainsKey("PcCount")) item.PcCount = decimal.Parse(dic["PcCount"].ToString());
            if (dic.ContainsKey("PcUnit")) item.Unit = dic["PcUnit"].ToString();
            if (dic.ContainsKey("BatchNo")) item.BatchNo = dic["BatchNo"].ToString();
            if (dic.ContainsKey("GiveDept")) item.GiveDept = dic["GiveDept"].ToString();
            if (dic.ContainsKey("Ingredients")) item.Ingredients = dic["Ingredients"].ToString();
            if (dic.ContainsKey("BoxNo")) item.BoxNo = dic["BoxNo"].ToString();
            if (dic.ContainsKey("BoxName")) item.BoxName = dic["BoxName"].ToString();
            if (dic.ContainsKey("BoxRemark")) item.BoxRemark = dic["BoxRemark"].ToString();
            if (dic.ContainsKey("PcRemark")) item.Remark = dic["PcRemark"].ToString();
            if (dic.ContainsKey("Priority")) item.Priority = dic["Priority"].ToString();

            string columnName = GetPositionPcCount(position);

            if (dic.ContainsKey(columnName))
                item.PcCount = decimal.Parse(dic[columnName].ToString());
            item.PrintState = "未打印";
            item.Jingbanren = GetIdentityName();
            item.CRMPlanList_ID = cpl.ID;
            item.PlanOrder_State = "已排产";
            return item;
        }
        private string GetPositionOrderName(string name)
        {

            string positionName = string.Empty;
            if (name == "03小包装-小袋")
                positionName = "03XD";
            else if (name == "03小包装-罐")
                positionName = "03G";
            else if (name == "03小包装-每日坚果")
                positionName = "03MRJG";
            else if (name == "07小包装-小袋")
                positionName = "07XD";
            else if (name == "07小包装-罐")
                positionName = "07G";
            else if (name == "07小包装-每日坚果")
                positionName = "07MRJG";
            return positionName;
        }
        private string GetPositionPcCount(string name)
        {
            string positionName = string.Empty;
            if (name == "03小包装-小袋")
                positionName = "PcCount_03_Bag";
            else if (name == "03小包装-罐")
                positionName = "PcCount_03_Tank";
            else if (name == "03小包装-每日坚果")
                positionName = "PcCount_03_Box";
            else if (name == "07小包装-小袋")
                positionName = "PcCount_07_Bag";
            else if (name == "07小包装-罐")
                positionName = "PcCount_07_Tank";
            else if (name == "07小包装-每日坚果")
                positionName = "PcCount_07_Box";
            return positionName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //BindGrid1();
        }

       

        protected void jiaoFuDate_DateSelect(object sender, EventArgs e)
        {
            if(jiaoFuDate.Enabled)
            {
                if (jiaoFuDate.SelectedDate!=null)
                {
                    for (int index = 0; index < Grid1.RecordCount; index++)
                        Grid1.UpdateCellValue(index, "Plandate", jiaoFuDate.SelectedDate?.ToString("yyyy-MM-dd"));
                    List<Dictionary<string, object>> list = Grid1.GetNewAddedList();
                    for (int index2 = 0; index2 < list.Count; index2++)
                    {
                        Grid1.UpdateCellValue(index2, "Plandate", jiaoFuDate.SelectedDate?.ToString("yyyy-MM-dd"));
                    }
                }
                else
                {
                    
                }
            }
            
        }

        protected void Cb_JFD_CheckedChanged(object sender, CheckedEventArgs e)
        {
            Panel98.Enabled = Cb_JFD.Checked;
        }

        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePositionCheckBox();

        }

        protected void CheckBoxList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePositionCheckBox();
        }

        private void ChangePositionCheckBox()
        {
            Dictionary<int, Dictionary<string, object>> modDic = Grid1.GetModifiedDict();
            List<Dictionary<string, object>> modDicValue = modDic.Values.ToList();
            string[] temp1 = CheckBoxList2.SelectedValueArray;
            string[] temp2 = CheckBoxList3.SelectedValueArray;

            if (temp1.Length > 0)
            {
                if (temp1.Contains("03小包装-小袋"))
                    PcCount_03_Bag.Hidden = false;
                else
                    PcCount_03_Bag.Hidden = true;
                if (temp1.Contains("03小包装-罐"))
                    PcCount_03_Tank.Hidden = false;
                else
                    PcCount_03_Tank.Hidden = true;
                if (temp1.Contains("03小包装-每日坚果"))
                    PcCount_03_Box.Hidden = false;
                else
                    PcCount_03_Box.Hidden = true;
            }
            else
            {
                PcCount_03_Bag.Hidden = true;
                PcCount_03_Tank.Hidden = true;
                PcCount_03_Box.Hidden = true;
            }

            if (temp2.Length > 0)
            {

                if (temp2.Contains("07小包装-小袋"))
                    PcCount_07_Bag.Hidden = false;
                else
                    PcCount_07_Bag.Hidden = true;
                if (temp2.Contains("07小包装-罐"))
                    PcCount_07_Tank.Hidden = false;
                else
                    PcCount_07_Tank.Hidden = true;
                if (temp2.Contains("07小包装-每日坚果"))
                    PcCount_07_Box.Hidden = false;
                else
                    PcCount_07_Box.Hidden = true;
            }
            else
            {
                PcCount_07_Bag.Hidden = true;
                PcCount_07_Tank.Hidden = true;
                PcCount_07_Box.Hidden = true;
            }

            if ((temp1.Length > 0 && temp2.Length > 0)
                || temp1.Length > 1 || temp2.Length > 1)
            {
                for (int index = 0; index < Grid1.RecordCount; index++)
                {
                    Grid1.UpdateCellValue(index, "PcCount_03_Bag", "0");
                    Grid1.UpdateCellValue(index, "PcCount_03_Tank", "0");
                    Grid1.UpdateCellValue(index, "PcCount_03_Box", "0");

                    Grid1.UpdateCellValue(index, "PcCount_07_Bag", "0");
                    Grid1.UpdateCellValue(index, "PcCount_07_Tank", "0");
                    Grid1.UpdateCellValue(index, "PcCount_07_Box", "0");
                }
            }
            else if (temp1.Length == 1)
            {
                string controlsName = string.Empty;
                if (temp1.Contains("03小包装-小袋"))
                    controlsName = "PcCount_03_Bag";
                else if (temp1.Contains("03小包装-罐"))
                    controlsName = "PcCount_03_Tank";
                else if (temp1.Contains("03小包装-每日坚果"))
                    controlsName = "PcCount_03_Box";

                for (int index = 0; index < Grid1.RecordCount; index++)
                {
                    Dictionary<string, object> dic = modDicValue[index];
                    Grid1.UpdateCellValue(index, controlsName, dic["PcCount"].ToString());
                }
            }
            else if (temp2.Length == 1)
            {
                string controlsName = string.Empty;
                if (temp2.Contains("07小包装-小袋"))
                    controlsName = "PcCount_07_Bag";
                else if (temp2.Contains("07小包装-罐"))
                    controlsName = "PcCount_07_Tank";
                else if (temp2.Contains("07小包装-每日坚果"))
                    controlsName = "PcCount_07_Box";
                for (int index = 0; index < Grid1.RecordCount; index++)
                {
                    Dictionary<string, object> dic = modDicValue[index];
                    Grid1.UpdateCellValue(index, controlsName, dic["PcCount"].ToString());
                }
            }

        }

        private string GetSuoXie(string position, Dictionary<string, object> dic, ProPlanOrderlists item)
        {
            if (position == "03小包装-小袋")
            {
                item.PcCount_03_Bag = decimal.Parse(dic["PcCount_03_Bag"].ToString());
                item.PcCount = item.PcCount_03_Bag;
                return "03XD";
            }
            else if (position == "03小包装-罐")
            {
                item.PcCount_03_Tank = decimal.Parse(dic["PcCount_03_Tank"].ToString());
                item.PcCount = item.PcCount_03_Tank;

                return "03G";
            }
            else if (position == "03小包装-每日坚果")
            {
                item.PcCount_03_Box = decimal.Parse(dic["PcCount_03_Box"].ToString());
                item.PcCount = item.PcCount_03_Box;

                return "03MRJG";
            }
            else if (position == "07小包装-小袋")
            {
                item.PcCount_07_Bag = decimal.Parse(dic["PcCount_07_Bag"].ToString());
                item.PcCount = item.PcCount_07_Bag;
                return "07XD";
            }
            else if (position == "07小包装-罐")
            {
                item.PcCount_07_Tank = decimal.Parse(dic["PcCount_07_Tank"].ToString());
                item.PcCount = item.PcCount_07_Tank;
                return "07G";
            }
            else if (position == "07小包装-每日坚果")
            {
                item.PcCount_07_Box = decimal.Parse(dic["PcCount_07_Box"].ToString());
                item.PcCount = item.PcCount_07_Box;
                return "07MRJG";
            }
            return string.Empty;
        }

        protected void Btn_SaveExit_Click(object sender, EventArgs e)
        {

        }
    }
}