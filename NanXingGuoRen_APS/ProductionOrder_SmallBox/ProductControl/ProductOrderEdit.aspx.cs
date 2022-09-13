using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingGuoRen_APS.Business.Helper;
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

namespace NanXingGuoRen_APS.ProductionOrder_SmallBox.ProductControl
{
    public partial class ProductOrderEdit : PageBase
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

                //ChangePositionCheckBox();

            }
        }
        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("解绑选中的生产单子单？", String.Empty, MessageBoxIcon.Question, Grid1.GetDeleteSelectedRowsReference(), String.Empty);
        }


        private void LoadData()
        {
            BindGrid2();
            int id = int.Parse(GetQueryValue("id"));
            var qList= ProductOrderlistsService.GetList(u => u.ProductOrderheaders_ID ==id
            && u.ProOrderList_State!="已删除",
                true,DbMainSlave.Slave,u=>u.ProductOrder_XuHao);
            //qList.ForEach((item)=> { item.Itemno = "004.05.13.08.04.0007"; });
            if (qList.Count>0)
            {
                ProductOrderheaders ProductOrderheaders = qList[0].ProductOrderheaders;
                //LoadMergeCellsValue(ProductOrderheaders);
                var q = qList.AsQueryable();
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


       
        #endregion

        #region Event
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


        protected void btnChange_Click(object sender, EventArgs e)
        {
            btnChange.Enabled = false;
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
            DropDownBox1.Enabled = true;
            DropDownBox2.Enabled = true;
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

            int ID = int.Parse(GetQueryValue("id"));

            //修改数据
            Dictionary<int, Dictionary<string, object>> modDic = Grid1.GetModifiedDict();
            List<object[]> keys = Grid1.DataKeys;

            List<int> modDicIndex = modDic.Keys.ToList();
            List<Dictionary<string, object>> modDicValue = modDic.Values.ToList();
            List<string> headModColumns = new List<string>();
            ProductOrderheaders ProductOrderheaders = ProductOrderheadersService.FindById(ID, DbMainSlave.Master);
            ProductOrderheaders.Moddate = DateTime.Now;

            if (ProductOrderheaders.mergeCells != DropDownBox1.Text)
            {
                headModColumns.Add("mergeCells");
                headModColumns.Add("mergeCellsValue");

                ProductOrderheaders.mergeCells = DropDownBox1.Text;
                ProductOrderheaders.mergeCellsValue = string.Join(",", DropDownBox1.Values);
            }

            if (modDic.Count > 0)
            {
                for (int i = 0; i < modDic.Count; i++)
                {
                    int index = modDicIndex[i];
                    int listId = Convert.ToInt32(keys[index][0]);
                    Dictionary<string, object> dic = modDicValue[i];
                    List<string> columnList = dic.Keys.ToList();

                    ProductOrderlists item = ProductOrderheaders.ProductOrderlists.Where(u => u.ID == listId).FirstOrDefault();
                    //pos.GetProList();
                    if (dic.ContainsKey("Itemno")) item.Itemno = dic["Itemno"].ToString();
                    if (dic.ContainsKey("ItemName")) item.ItemName = dic["ItemName"].ToString();

                    if (dic.ContainsKey("ItemName1")) item.InName = dic["ItemName1"].ToString();
                    if (dic.ContainsKey("ItemName2")) item.MaterialItem = dic["ItemName2"].ToString();
                    if (dic.ContainsKey("Color")) item.Color = dic["Color"].ToString();
                    if (dic.ContainsKey("PlanDate")) item.PlanDate = DateTime.Parse(dic["PlanDate"].ToString());
                    if (dic.ContainsKey("PcCount")) item.PcCount = decimal.Parse(dic["PcCount"].ToString());
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

                    item.Jingbanren = GetIdentityName();
                }
            }
            if (headModColumns.Count > 0)
                productOrderManager.UpdateProOrder(ProductOrderheaders, headModColumns);

            //删除数据
            List<int> rowids = Grid1.GetDeletedList();

            foreach (int rowsId in rowids)
            {
                int id = int.Parse(keys[rowsId][0].ToString());
                productOrderManager.UnBindingProOrder(id,GetIdentityName());
            }
            //var qList = proPlanOrderManager.GetList(u => u.ProPlanOrderheaders_ID == ID, u => u.PlanOrder_XuHao, DbMainSlave.Master);
            //if (qList.Count == 0)
            //{
            //    productOrderManager.DeleteProOrderAll(new List<int>(1) { ID });
            //}

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }



        #endregion




    }
}