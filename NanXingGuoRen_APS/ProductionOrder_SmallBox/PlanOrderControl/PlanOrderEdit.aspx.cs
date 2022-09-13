using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingGuoRen_APS.Business.Helper;
using NanXingService_WMS.Entity.ProductEntity;
using NanXingService_WMS.Entity.ProPlanEntity;
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
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilsSharp;

namespace NanXingGuoRen_APS.ProductionOrder_SmallBox
{
    public partial class PlanOrderEdit : PageBase
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

                ChangePositionCheckBox();

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
            BindGrid2();
            int id = int.Parse(GetQueryValue("id"));
            var qList= proPlanOrderManager.GetList(u => u.ProPlanOrderheaders_ID ==id,u=>u.PlanOrder_XuHao);
            //qList.ForEach((item)=> { item.Itemno = "004.05.13.08.04.0007"; });
            var header = proPlanOrderManager.GetPlanEdit_Small(id);
          
            List<ProPlanEditDto_Small> headerList = new List<ProPlanEditDto_Small>(1);
            if (qList.Count>0)
            {
                //遍历lists，然后将车间选中，并将数据放进相应位置
                LoadMergeCellsValue(header);
                headerList.Add(header);

                var q = headerList.AsQueryable();
                Grid1.RecordCount = q.Count();
                q = SortAndPage(q, Grid1);
                Grid1.DataSource = q;
                Grid1.DataBind();
            }
        }

        
        private void BindGrid2()
        {
            Expression<Func<ItemInfo, bool>> expression = DbBaseExpand.True<ItemInfo>();
            if (tbxSearchItem.Text.Trim().Length > 0)
            {
                string txt = tbxSearchItem.Text.Trim();
                expression = expression.And(
                    u => u.ItemNo.Contains(txt) || u.ItemName.Contains(txt) || u.MaterialItem.Contains(txt)
                       || u.Spec.Contains(txt) || u.SlaveUtil.Contains(txt)
                    );
            }
            var q = itemService.GetIQueryable(expression);
            if (q.Count() > 0)
            {
                Grid2.PageSize = 1000;
                Grid2.RecordCount = q.Count();
                q = SortAndPage(q, Grid2);
                Grid2.DataSource = q;
                Grid2.DataBind();
            }
        }


        private void LoadMergeCellsValue(ProPlanEditDto_Small ProPlanOrderheaders)
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
            /*
             if (!datepicker1.SelectedDate.HasValue ||datepicker1.SelectedDate?.ToString("yyyy-MM-dd") == "1900-01-01")
             {
                 Alert.Show("请选择下单日期");
                 return;
             }
             int id = int.Parse(GetQueryValue("id"));*/

            string[] positionArr = CheckBoxList2.SelectedValueArray.
                Concat(CheckBoxList3.SelectedValueArray).ToArray();

            if (positionArr.Length==0)
            {
                Alert.Show("请选择排产车间");
                return;
            }
            int ID = int.Parse(GetQueryValue("ID"));

            //修改数据
            Dictionary<int, Dictionary<string, object>> modDic = Grid1.GetModifiedDict();
            List<object[]> keys = Grid1.DataKeys;

            List<int> modDicIndex = modDic.Keys.ToList();
            List<Dictionary<string, object>> modDicValue = modDic.Values.ToList();
            List<string> headModColumns = new List<string>();
            ProPlanOrderheaders ProPlanOrderheaders = proPlanOrderManager.GetProOrder(ID, DbMainSlave.Master);
            ProPlanOrderheaders.Moddate = DateTime.Now;

            if (ProPlanOrderheaders.mergeCells != DropDownBox1.Text)
            {
                headModColumns.Add("mergeCells");
                headModColumns.Add("mergeCellsValue");

                ProPlanOrderheaders.mergeCells = DropDownBox1.Text;
                ProPlanOrderheaders.mergeCellsValue = string.Join(",", DropDownBox1.Values);
            }
            var arr_Old = ProPlanOrderheaders.Workshops.Split(',');
            string positionStr = string.Join(",", positionArr);
            if (ProPlanOrderheaders.Workshops != positionStr)
            {
                headModColumns.Add("Workshops");
                ProPlanOrderheaders.Workshops = positionStr;
            }

            List<ProPlanOrderlists> proPlanOrderlists = ProPlanOrderheaders.ProPlanOrderlists;

            List<ProPlanOrderlists> addList = new List<ProPlanOrderlists>();
            List<ProPlanOrderlists> editAndDelList = new List<ProPlanOrderlists>();
            var header = proPlanOrderManager.GetPlanEdit_Small(ID);
            CRMPlanList cRMPlanList = null;
            if (header.CRMPlanList_ID != null)
                cRMPlanList = crmPlanListService.FindById(header.CRMPlanList_ID);
            //第一步，遍历车间
            //车间有修改，则有新增删除
            foreach (var temp in positionArr)
            {
                ProPlanOrderlists item = null;
                item = proPlanOrderlists.FirstOrDefault(u => u.Chejianclass == temp);
                if (item==null)
                {
                    item = new ProPlanOrderlists();
                    MapperHelper<ProPlanEditDto_Small, ProPlanOrderlists>.Map(header,item);
                    item.ID = 0;
                    item.Chejianclass = temp;
                    item.PlanOrder_State = ProductPlanOrderState.HasPlan;
                    item.PrintState = "未打印";
                   
                    if(cRMPlanList !=null && string.IsNullOrEmpty(cRMPlanList.ProductRecipe))
                        item.ProductRecipe = cRMPlanList.ProductRecipe;
                    item.ERPOrderNo = header.PlanOrderNo;
                    item.PlanOrder_XuHao = header.PlanOrderNo + $"-{GetPositionOrderName(temp)}";
                }
                if (modDic.Count > 0)
                {
                    for (int i = 0; i < modDic.Count; i++)
                    {
                        int index = modDicIndex[i];
                        Dictionary<string, object> dic = modDicValue[i];
                        GetChange(item, dic,header);
                    }
                }
                if (item.ID == 0)
                    addList.Add(item);
                else
                    editAndDelList.Add(item);
            }
            foreach(var temp in arr_Old)
            {
                if (!positionArr.Contains(temp))
                {
                    ProPlanOrderlists item = proPlanOrderlists.FirstOrDefault(u => u.Chejianclass == temp);
                 
                    string deleteState = "已删除";
                    item.PlanOrder_State = deleteState;
                    editAndDelList.Add(item);
                }
            }

          
            proPlanOrderManager.EditProOrders(ProPlanOrderheaders, addList, editAndDelList);

            /*
            //新增数据
            List<Dictionary<string, object>> newAddedList = Grid1.GetNewAddedList();
            for (int i = 0; i < newAddedList.Count; i++)
            {
                //Debug.WriteLine(newAddedList[i]["clientname"].ToString());

                //执行存储过程，返回流水号
                //Type t = typeof(string);
                //SqlParameter[] sqlParms = new SqlParameter[1];
                //sqlParms[0] = new SqlParameter("@MaintainCate", "Product");
                //var result = DB2.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();

                //ProPlanOrderheaders.prosn = result.ToString();

                //int clientid = int.Parse(newAddedList[i]["clientname"].ToString());
                //TelenClient tc = DB.telenClients.Where(u => u.ID == clientid).FirstOrDefault();
                //purchaseStockheader.telenClient = tc;
                ////Debug.WriteLine(tc.Name);
                //purchaseStockheader.clientname = tc.Name;
                //purchaseStockheader.remark = newAddedList[i]["remark"].ToString();
                //DB.purchaseStockheaders.Add(purchaseStockheader);


                ProPlanOrderlists item = new ProPlanOrderlists();
                if (newAddedList[i].ContainsKey("itemno")) item.itemno = newAddedList[i]["itemno"].ToString();
                if (newAddedList[i].ContainsKey("name")) item.name = newAddedList[i]["name"].ToString();
                if (newAddedList[i].ContainsKey("spec")) item.spec = newAddedList[i]["spec"].ToString();
                if (newAddedList[i].ContainsKey("model")) item.model = newAddedList[i]["model"].ToString();
                if (newAddedList[i].ContainsKey("inName")) item.inName = newAddedList[i]["inName"].ToString();
                if (newAddedList[i].ContainsKey("color")) item.color = newAddedList[i]["color"].ToString();
                if (newAddedList[i].ContainsKey("material")) item.material = newAddedList[i]["material"].ToString();
                if (newAddedList[i].ContainsKey("Class")) item.Class = newAddedList[i]["Class"].ToString();
                if (newAddedList[i].ContainsKey("PlanDate")) item.PlanDate = DateTime.Parse(newAddedList[i]["PlanDate"].ToString());

                //长度
                if (newAddedList[i].ContainsKey("length")) item.length = decimal.Parse(newAddedList[i]["length"].ToString());
                //宽度
                if (newAddedList[i].ContainsKey("width")) item.width = decimal.Parse(newAddedList[i]["width"].ToString());
                if (newAddedList[i].ContainsKey("unit")) item.unit = newAddedList[i]["unit"].ToString();
                if (newAddedList[i].ContainsKey("ERPOrderNo")) item.ERPOrderNo = newAddedList[i]["ERPOrderNo"].ToString();
                //卷数
                if (newAddedList[i].ContainsKey("count"))
                {
                    if (item.unit == "平方米")
                    {
                        item.high = decimal.Parse(newAddedList[i]["count"].ToString());
                        if (newAddedList[i].ContainsKey("area")) item.count = decimal.Parse(newAddedList[i]["area"].ToString());
                    }
                    else
                    {
                        item.count = decimal.Parse(newAddedList[i]["count"].ToString());
                    }
                }

                if (newAddedList[i].ContainsKey("remark1"))
                {
                    string remark = newAddedList[i]["remark1"].ToString().Replace(";\r\n", ";").Replace(";", ";\r\n");
                    item.remark1 = remark;
                }
                if (newAddedList[i].ContainsKey("ingredients")) item.ingredients = newAddedList[i]["ingredients"].ToString();
                if (newAddedList[i].ContainsKey("boxName")) item.boxName = newAddedList[i]["boxName"].ToString();
                if (newAddedList[i].ContainsKey("batchNo")) item.batchNo = newAddedList[i]["batchNo"].ToString();
                if (newAddedList[i].ContainsKey("boxNo")) item.boxNo = newAddedList[i]["boxNo"].ToString();

                //item.mark = "03";
                item.jingbanren = GetIdentityName();
                item.optdate = datepicker1.SelectedDate;
                item.ProPlanOrderheaders = ProPlanOrderheaders;
                DB2.ProPlanOrderlists.Add(item);
                DB2.SaveChanges();
            }

            */

                //删除数据
            List<int> rowids = Grid1.GetDeletedList();

            foreach (int rowsId in rowids)
            {
                int id = int.Parse(keys[rowsId][0].ToString());
                productOrderManager.DeleteProOrderList(id);
            }
            //var qList = proPlanOrderManager.GetList(u => u.ProPlanOrderheaders_ID == ID, u => u.PlanOrder_XuHao,DbMainSlave.Master);
            //if (qList.Count==0)
            //{
            //    productOrderManager.DeleteProOrderAll(new List<int>(1) {ID });
            //}

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void GetChange(ProPlanOrderlists item, Dictionary<string, object> dic, ProPlanEditDto_Small header)
        {
            if (dic.ContainsKey("Itemno")) item.Itemno = dic["Itemno"].ToString();
            if (dic.ContainsKey("ItemName")) item.ItemName = dic["ItemName"].ToString();

            if (dic.ContainsKey("ItemName1")) item.InName = dic["ItemName1"].ToString();
            if (dic.ContainsKey("ItemName2")) item.MaterialItem = dic["ItemName2"].ToString();
            if (dic.ContainsKey("Color")) item.Color = dic["Color"].ToString();
            if (dic.ContainsKey("PlanDate")) item.PlanDate = DateTime.Parse(dic["PlanDate"].ToString());
            //if (dic.ContainsKey("PcCount")) item.PcCount = decimal.Parse(dic["PcCount"].ToString());
            if (dic.ContainsKey("Spec")) item.Spec = dic["Spec"].ToString();

            if (dic.ContainsKey("Unit")) item.Unit = dic["Unit"].ToString();
            if (dic.ContainsKey("BatchNo")) item.BatchNo = dic["BahitchNo"].ToString();
            if (dic.ContainsKey("GiveDept")) item.GiveDept = dic["GiveDept"].ToString();
            if (dic.ContainsKey("Ingredients")) item.Ingredients = dic["Ingredients"].ToString();
            if (dic.ContainsKey("BoxNo")) item.BoxNo = dic["BoxNo"].ToString();
            if (dic.ContainsKey("BoxName")) item.BoxName = dic["BoxName"].ToString();
            if (dic.ContainsKey("BoxRemark")) item.BoxRemark = dic["BoxRemark"].ToString();
            if (dic.ContainsKey("Remark")) item.Remark = dic["Remark"].ToString();
            if (dic.ContainsKey("PlanTime")) item.PlanTime = dic["PlanTime"].ToString();
            if (dic.ContainsKey("Priority")) item.Priority = dic["Priority"].ToString();

            string columnName = GetPositionPcCount(item.Chejianclass);

            if (dic.ContainsKey(columnName))
                item.PcCount = decimal.Parse(dic[columnName].ToString());
            else
            {
                Type type = header.GetType();
                PropertyInfo property = type.GetProperty(columnName);
                object fieldValue = property.GetValue(header, null);

                item.PcCount = (decimal?)fieldValue??0;
            }
                
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
        protected void ddl_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddl_Class.SelectedValue== "原料车间")
            //{
            //    ingredients.Hidden = true;
            //    boxName.Hidden = true;
            //    boxNo.Hidden = true;
            //}
            //else if (ddl_Class.SelectedValue == "烘烤车间")
            //{
            //    ingredients.Hidden = false;
            //    boxName.Hidden = true;
            //    boxNo.Hidden = true;
            //}
            //else if (ddl_Class.SelectedValue.Contains( "包装车间"))
            //{
            //    ingredients.Hidden = true;
            //    boxName.Hidden = false;
            //    boxNo.Hidden = false;
            //}
            
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
            DropDownBox2.Enabled = true;
        }

        string arrStr = "Itemno Itemno2 ItemName Spec Unit PcCount PcCount_03_Bag PcCount_03_Tank PcCount_03_Box PcCount_07_Bag PcCount_07_Tank PcCount_07_Box BatchNo BoxNo BoxName CRMPlanList_ID PlanDate Remark PlanTime Priority";
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
            //int id = int.Parse(GetQueryValue("id"));
            //var qList = proPlanOrderManager.GetList(u => u.ProPlanOrderheaders_ID == id, u => u.PlanOrder_XuHao);
            //if (qList.Count == 0)
            //{
            //    return;
            //}
            //var q = qList.AsQueryable();
            //q = SortAndPage(q, Grid1);
            //qList = q.ToList();
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

            //if ((temp1.Length+ temp2.Length)>1)
            //{
            //    for (int index = 0; index < Grid1.RecordCount; index++)
            //    {
            //        Grid1.UpdateCellValue(index, "PcCount_03_Bag", (qList[index].PcCount_03_Bag??0).ToString());
            //        Grid1.UpdateCellValue(index, "PcCount_03_Tank", (qList[index].PcCount_03_Tank ?? 0).ToString());
            //        Grid1.UpdateCellValue(index, "PcCount_03_Box", (qList[index].PcCount_03_Box ?? 0).ToString());

            //        Grid1.UpdateCellValue(index, "PcCount_07_Bag", (qList[index].PcCount_07_Bag ?? 0).ToString());
            //        Grid1.UpdateCellValue(index, "PcCount_07_Tank", (qList[index].PcCount_07_Tank ?? 0).ToString());
            //        Grid1.UpdateCellValue(index, "PcCount_07_Box", (qList[index].PcCount_07_Box ?? 0).ToString());
            //    }
            //}
            //else if (temp1.Length == 1)
            //{
            //    string controlsName = string.Empty;
            //    if (temp1.Contains("03小包装-小袋"))
            //        controlsName = "PcCount_03_Bag";
            //    else if (temp1.Contains("03小包装-罐"))
            //        controlsName = "PcCount_03_Tank";
            //    else if (temp1.Contains("03小包装-每日坚果"))
            //        controlsName = "PcCount_03_Box";

            //    for (int index = 0; index < Grid1.RecordCount; index++)
            //    {
            //        //Dictionary<string, object> dic = modDicValue[index];
            //        Grid1.UpdateCellValue(index, controlsName, qList[index].PcCount.ToString());
            //    }
            //}
            //else if (temp2.Length == 1)
            //{
            //    string controlsName = string.Empty;
            //    if (temp2.Contains("07小包装-小袋"))
            //        controlsName = "PcCount_07_Bag";
            //    else if (temp2.Contains("07小包装-罐"))
            //        controlsName = "PcCount_07_Tank";
            //    else if (temp2.Contains("07小包装-每日坚果"))
            //        controlsName = "PcCount_07_Box";
            //    for (int index = 0; index < Grid1.RecordCount; index++)
            //    {
            //        Grid1.UpdateCellValue(index, controlsName, qList[index].PcCount.ToString());
            //    }
            //}
        }

    }
}