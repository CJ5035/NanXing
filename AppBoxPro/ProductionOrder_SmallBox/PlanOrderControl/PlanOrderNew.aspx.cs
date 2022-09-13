using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingGuoRen_WMS.Business.Helper;
using Newtonsoft.Json.Linq;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanOrderControl
{
    public partial class PlanOrderNew : PageBase
    {
        private bool AppendToEnd = true;

        #region PageLoad
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
                btnNew.OnClientClick = Grid1.GetAddNewRecordReference(defaultObj, AppendToEnd);
                // 重置表格
                btnReset.OnClientClick = Confirm.GetShowReference("确定要重置表格数据？", String.Empty, Grid1.GetRejectChangesReference(), String.Empty);
                // 删除选中行按钮
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference("请至少选择一项！") + deleteScript;
                //LoadExcel();
                LoadData();
            }
        }
        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, Grid1.GetDeleteSelectedRowsReference(), String.Empty);
        }

        private void LoadExcel()
        {
            //DataTable dt = ExcelUtils.ReadExcel(Server.MapPath(Request.ApplicationPath + "/res/files/排产工艺名.xls"));
            //ddlname.DataTextField = "物料名称";
            //ddlname.DataValueField = "物料名称";
            //ddlname.DataSource = dt;
            //ddlname.DataBind();
        }

        private void LoadData()
        {
            //int id = int.Parse(GetQueryValue("id"));
            BindGrid2();
        }

        private void BindGrid2()
        {
            Expression<Func<ItemInfo, bool>> expression = DbBaseExpand.True<ItemInfo>();
            if (tbxSearchItem.Text.Trim().Length > 0)
            {
                string txt = tbxSearchItem.Text.Trim();
                //expression = expression.And(
                //    u => u.ItemNo.Contains(txt) || u.ItemName.Contains(txt) || u.MaterialItem.Contains(txt)
                //       || u.Spec.Contains(txt) || u.SlaveUtil.Contains(txt)
                //    );

                expression = expression.And(
                    u => u.ItemName.Contains(txt) 
                    );
            }
            var q = itemService.GetIQueryable(expression);
            if (q.Count() > 0)
            {
                Grid2.PageSize=1000;
                Grid2.RecordCount = q.Count();
                q = SortAndPage(q, Grid2);
                Grid2.DataSource = q;
                Grid2.DataBind();
            }
        }


        private void LoadMergeCellsValue(ProPlanOrderheaders ProPlanOrderheaders)
        {
            // 后台更新下拉框的值，需要同时设置Text和Value
            if (!string.IsNullOrEmpty(ProPlanOrderheaders.mergeCells))
            {
                DropDownBox1.Text = ProPlanOrderheaders.mergeCells;
                DropDownBox1.Value = ProPlanOrderheaders.mergeCellsValue; // 或者：DropDownBox1.Values = new string[] { "php", "basic" };
            }
            if (!string.IsNullOrEmpty(ProPlanOrderheaders.Workshops))
            {
                string[] arr = ProPlanOrderheaders.Workshops.Split(',');
                
                CheckBoxList2.SelectedValueArray = arr;
                CheckBoxList3.SelectedValueArray = arr;
                CheckBoxList4.SelectedValueArray = arr;
                CheckBoxList5.SelectedValueArray = arr;
                CheckBoxList6.SelectedValueArray = arr;

            }
        }
        #endregion

        #region Event
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
                sb.Append(string.Join(",", item));
                //sb.Append(item);
                if (item.Length > 0)
                    sb.Append(",");
            }
            return sb.ToString().TrimEnd(',');
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string[] positionArr = CheckBoxList2.SelectedValueArray.
                Concat(CheckBoxList3.SelectedValueArray).ToArray();
            
            if (positionArr.Length==0)
            {
                Alert.Show("请选择排产车间");
                return;
            }
            //新增数据

            List<Dictionary<string, object>> newAddedList = Grid1.GetNewAddedList();

            if (newAddedList.Count>0)
            {
                List<ProPlanOrderheaders> headerList = new List<ProPlanOrderheaders>(newAddedList.Count);

                DateTime nowDt = DateTime.Now;
                string result = liuShuiHaoService.GetPlanOrderLSH();
                for (int i = 0; i < newAddedList.Count; i++)
                {
                    ProPlanOrderheaders ProPlanOrderheaders = new ProPlanOrderheaders();
                    
                    ProPlanOrderheaders.PlanOrderNo = $"{result}-{(i + 1).ToString("D2")}";
                    ProPlanOrderheaders.Optdate = nowDt;
                    ProPlanOrderheaders.Newdate = nowDt;
                    ProPlanOrderheaders.Moddate = nowDt;
                    //ProPlanOrderheaders.orderNo = orderNo.Text.Trim();
                    //ProPlanOrderheaders.positionClass = ddl_Class.SelectedValue;
                    ProPlanOrderheaders.mergeCells = DropDownBox1.Text;
                    ProPlanOrderheaders.mergeCellsValue = string.Join(",", DropDownBox1.Values);
                    ProPlanOrderheaders.Workshops = GetCheckedValuesString(new string[5][] { CheckBoxList2.SelectedValueArray, CheckBoxList3.SelectedValueArray ,CheckBoxList4.SelectedValueArray,
                        CheckBoxList5.SelectedValueArray, CheckBoxList6.SelectedValueArray});
                    ProPlanOrderheaders.ProPlanOrderlists = new List<ProPlanOrderlists>(newAddedList.Count);
                    ProPlanOrderheaders.PositionClass = "小包装排产单";
                    ProPlanOrderheaders.Jingbanren= GetIdentityName();
                    ProPlanOrderheaders.OrderNo = result;
                    //表头成品信息记录
                    if (newAddedList[i].ContainsKey("Itemno"))
                        ProPlanOrderheaders.Itemno = newAddedList[i]["Itemno"].ToString();
                    if (newAddedList[i].ContainsKey("ItemName"))
                        ProPlanOrderheaders.ItemName = newAddedList[i]["ItemName"].ToString();
                    if (newAddedList[i].ContainsKey("PcCount"))
                        ProPlanOrderheaders.PcCount= decimal.Parse(newAddedList[i]["PcCount"].ToString());
                    if (newAddedList[i].ContainsKey("Unit"))
                        ProPlanOrderheaders.Unit = newAddedList[i]["Unit"].ToString();
                    if (newAddedList[i].ContainsKey("Spec")) 
                        ProPlanOrderheaders.Spec = newAddedList[i]["Spec"].ToString();
                    if (newAddedList[i].ContainsKey("BatchNo"))
                        ProPlanOrderheaders.BatchNo = newAddedList[i]["BatchNo"].ToString();
                    if (newAddedList[i].ContainsKey("PlanDate"))
                        ProPlanOrderheaders.PlanDate = DateTime.Parse(newAddedList[i]["PlanDate"].ToString()).Date.AddDays(1);
                    if (newAddedList[i].ContainsKey("Biaozhun"))
                        ProPlanOrderheaders.Biaozhun = newAddedList[i]["Biaozhun"].ToString();
                    if (newAddedList[i].ContainsKey("BoxNo"))
                        ProPlanOrderheaders.BoxNo = newAddedList[i]["BoxNo"].ToString();
                    if (newAddedList[i].ContainsKey("BoxName"))
                        ProPlanOrderheaders.BoxName = newAddedList[i]["BoxName"].ToString();
                    if (newAddedList[i].ContainsKey("BoxRemark"))
                        ProPlanOrderheaders.BoxRemark = newAddedList[i]["BoxRemark"].ToString();
                    if (newAddedList[i].ContainsKey("Remark"))
                        ProPlanOrderheaders.Remark = newAddedList[i]["Remark"].ToString();

                    //根据选择的车间数量执行数据插入
                    for (int index= 0;index< positionArr.Length;index++)
                    {
                        //得到缩写
                        string sx= GetPositionOrderName(positionArr[index]);
                        ProPlanOrderlists item = GetProPlanOrderlistsInGrid1(newAddedList, i, positionArr[index]);
                        item.PlanOrder_XuHao= $"{ProPlanOrderheaders.PlanOrderNo}-{sx}";
                        item.Chejianclass=positionArr[index];
                        item.ProPlanOrderheaders = ProPlanOrderheaders;
                        item.ERPOrderNo = ProPlanOrderheaders.PlanOrderNo;
                        ProPlanOrderheaders.ProPlanOrderlists.Add(item);
                    }

                    //执行存储过程，返回流水号
                    //item.PlanOrder_XuHao = $"{result}-" + (i + 1).ToString("D2");


                    headerList.Add(ProPlanOrderheaders);
                }
                
                bool ret=proPlanOrderManager.AddProOrders(headerList);
                if (ret)
                {
                    Alert.Show("保存成功");
                }
                else
                {
                    Alert.Show("保存失败");
                }

            }
            else
            {
                Alert.Show("没有新增的排产单明细，请重新输入排产单明细信息");
                return;
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private ProPlanOrderlists GetProPlanOrderlistsInGrid1(
            List<Dictionary<string, object>> newAddedList,int i,string position)
        {
            ProPlanOrderlists item = new ProPlanOrderlists();
            item.Newdate = DateTime.Now;
            item.Moddate = DateTime.Now;
            if (newAddedList[i].ContainsKey("Itemno")) item.Itemno = newAddedList[i]["Itemno"].ToString();
            if (newAddedList[i].ContainsKey("ItemName")) item.ItemName = newAddedList[i]["ItemName"].ToString();
            if (newAddedList[i].ContainsKey("ItemName1")) item.InName = newAddedList[i]["ItemName1"].ToString();

            if (newAddedList[i].ContainsKey("Spec")) item.Spec = newAddedList[i]["Spec"].ToString();
            if (newAddedList[i].ContainsKey("Biaozhun")) item.Biaozhun = newAddedList[i]["Biaozhun"].ToString();
            if (newAddedList[i].ContainsKey("Clientname")) item.Clientname = newAddedList[i]["Clientname"].ToString();
            if (newAddedList[i].ContainsKey("ProductRecipe")) item.ProductRecipe = newAddedList[i]["ProductRecipe"].ToString();
            if (newAddedList[i].ContainsKey("BoxNo")) item.BoxNo = newAddedList[i]["BoxNo"].ToString();
            if (newAddedList[i].ContainsKey("BoxName")) item.BoxName = newAddedList[i]["BoxName"].ToString();
            if (newAddedList[i].ContainsKey("BoxRemark")) item.BoxRemark = newAddedList[i]["BoxRemark"].ToString(); ;
            if (newAddedList[i].ContainsKey("Priority")) item.Priority = newAddedList[i]["Priority"].ToString();

            if (newAddedList[i].ContainsKey("ItemName1")) item.InName = newAddedList[i]["ItemName1"].ToString();
            if (newAddedList[i].ContainsKey("ItemName2")) item.MaterialItem = newAddedList[i]["ItemName2"].ToString();
            if (newAddedList[i].ContainsKey("Color")) item.Color = newAddedList[i]["Color"].ToString();
            if (newAddedList[i].ContainsKey("PlanDate")) item.PlanDate = DateTime.Parse(newAddedList[i]["PlanDate"].ToString());
            //if (newAddedList[i].ContainsKey("PcCount")) item.PcCount = decimal.Parse(newAddedList[i]["PcCount"].ToString());
            if (newAddedList[i].ContainsKey("Unit")) item.Unit = newAddedList[i]["Unit"].ToString();
            if (newAddedList[i].ContainsKey("BatchNo")) item.BatchNo = newAddedList[i]["BatchNo"].ToString();
            if (newAddedList[i].ContainsKey("GiveDept")) item.GiveDept = newAddedList[i]["GiveDept"].ToString();
            if (newAddedList[i].ContainsKey("Ingredients")) item.Ingredients = newAddedList[i]["Ingredients"].ToString();
            if (newAddedList[i].ContainsKey("BoxNo")) item.BoxNo = newAddedList[i]["BoxNo"].ToString();
            if (newAddedList[i].ContainsKey("BoxName")) item.BoxName = newAddedList[i]["BoxName"].ToString();
            if (newAddedList[i].ContainsKey("BoxRemark")) item.BoxRemark = newAddedList[i]["BoxRemark"].ToString();
            if (newAddedList[i].ContainsKey("Remark")) item.Remark = newAddedList[i]["Remark"].ToString();
            if (newAddedList[i].ContainsKey("PlanTime")) item.PlanTime = newAddedList[i]["PlanTime"].ToString();
            
            string columnName = GetPositionPcCount(position);

            if (newAddedList[i].ContainsKey(columnName)) 
                item.PcCount = decimal.Parse(newAddedList[i][columnName].ToString());
            
            item.Jingbanren = GetIdentityName();
            item.PlanOrder_State = "已排产";
            return item;
        }

       

        protected void ddl_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            btnChange.Enabled = false;
            Panel99.Enabled = true;
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
            DropDownBox1.Enabled = true;
        }

        string arrStr = "Itemno ItemName Spec Unit PcCount BatchNo BatchNo BoxNo BoxName ERPOrderNo PlanDate Remark";
        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            string[] arr = arrStr.Split(' ');
            foreach(string temp in arr)
            {
                RenderField rfTemp = Grid1.FindColumn(temp) as RenderField;
                if(rfTemp!=null)
                e.CellCssClasses[rfTemp.ColumnIndex] = "f-grid-cell-uneditable";
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid2();
        }

        #endregion
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
    }
}