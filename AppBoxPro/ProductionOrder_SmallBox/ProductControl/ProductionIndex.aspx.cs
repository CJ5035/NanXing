using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingService_WMS.Entity;
using NanXingService_WMS.Entity.ProductEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox.ProductControl
{
    public partial class ProductionIndex : PageBase
    {
        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "ProOrderManagerment-SmallBox";
            }
        }


        //key-列名  value-值
        static Dictionary<string, string> dictClickColsName = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dictClickColsName.Clear();
                LoadData();
            }
        }

        private void LoadData()
        {

            dp1.SelectedDate = DateTime.Now.AddDays(-7);
            dp2.SelectedDate = DateTime.Now.AddDays(7);
            BindDDLPosition();
            BindGrid1();
        }

        string[] positionArr = new string[] {
            "03小包装-小袋", "03小包装-罐", "03小包装-每日坚果",
            "07小包装-小袋", "07小包装-罐", "07小包装-每日坚果"
            };

        private void BindDDLPosition()
        {
            List<string> vs = new List<string>() { "全部" };
            //获取权限

            List<string> list=GetRolePowerNames();
            if (list.Contains("ProOrderManagerment-SmallBox-03"))
            {
                var arr = positionArr.Where(u => u.Contains("03")).ToArray();
                foreach (var temp in arr)
                    vs.Add(temp);
            }
            if (list.Contains("ProOrderManagerment-SmallBox-07"))
            {
                var arr = positionArr.Where(u => u.Contains("07")).ToArray();
                foreach (var temp in arr)
                    vs.Add(temp);
            }
            ddlPosition.DataSource = vs;
            ddlPosition.DataBind();
            ddlPosition.SelectedIndex = 0;
        }

        private void BindGrid1()
        {
            //筛选条件
            Expression<Func<ProductOrderheaders, bool>> expression = DbBaseExpand.True<ProductOrderheaders>();
            if (dp1.SelectedDate.HasValue)
            {
                DateTime dt1 = dp1.SelectedDate.Value.Date;
                expression = expression.And(u => u.Moddate >= dt1);
            }

            if (dp2.SelectedDate.HasValue)
            {
                DateTime dt2 = dp2.SelectedDate.Value.Date.AddDays(1).AddSeconds(-1);
                expression=expression.And(u => u.Moddate <= dt2);
            }
            if (tbxOrderNo.Text.Trim().Length > 0)
            {
                expression = expression.And(u => u.ProductOrderNo.Contains(tbxOrderNo.Text.Trim()));
            }
            if (ddlPosition.SelectedValue!=null &&
                ddlPosition.SelectedValue.Length > 0)
            {
                if (ddlPosition.SelectedValue == "全部")
                {
                    string[] arr = ddlPosition.Items.Select(u=>u.Value).ToArray();
                    expression = expression.And(u => arr.Contains(u.Workshops));
                }
                else 
                    expression = expression.And(u => u.Workshops==ddlPosition.SelectedValue);
            }
            if (ddlPrintState.SelectedValue.Length > 0)
            {
                if (ddlPrintState.SelectedValue != "全部")
                    expression = expression.And(u => u.PrintState == ddlPrintState.SelectedValue);
            }

            //expression = expression.And(u => u.Chejianclass == "小包装排产单");

            //var q = ProductOrderheadersService.GetIQueryable(expression, true, DbMainSlave.Master);
            var q = productOrderManager.GetProductIndex(expression);
            if (ddlProductState.SelectedValue.Length > 0)
            {
                if (ddlProductState.SelectedValue != "全部")
                    q = q.Where(u => u.ProductState== ddlProductState.SelectedValue);
            }
            if (tbxname.Text.Trim().Length > 0)
            {
                q = q.Where(u => u.ItemName.Contains(tbxname.Text.Trim()));
            }
            if (tbxSearch.Text.Trim().Length > 0)
            {
                string txt = tbxSearch.Text;
                q = q.Where(u => u.ProductOrderNo.Contains(txt) 
                || u.Workshops.Contains(txt) 
                || u.ItemName.Contains(txt)
                || u.JingBanRen.Contains(txt)
                || u.PlanTime.Contains(txt));
            }
            if (ddlProductState.SelectedIndex >= 0)
            {
                string value = ddlProductState.SelectedValue;
                if (value != "全部")
                    q.Where(u => u.ProductState.Contains(value));
            }
            if (ddlPrintState.SelectedIndex >= 0)
            {
                string value = ddlPrintState.SelectedValue;
                if (value != "全部")
                    q.Where(u => u.PrintState.Contains(value));
            }
            Grid1.RecordCount = q.Count();

            q = SortAndPage(q, Grid1);
            Grid1.DataSource = q;
            Grid1.DataBind();
        }

        protected void Grid1_PageIndexChange(object sender, FineUIPro.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid1();
        }

        protected void Grid1_Sort(object sender, FineUIPro.GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;
            BindGrid1();
        }

        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid1();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Grid1.PageSize = 1000;
            BindGrid1();
            ExportExcel(Grid1.Title, Grid1);
        }

        protected void Grid1_RowDoubleClick(object sender, FineUIPro.GridRowClickEventArgs e)
        {
            int s = GetSelectedDataKeyID( Grid1);
            //s[0] 选中的行id, s[1] 选中的ColumnID
            PageContext.RegisterStartupScript(Window1.GetShowReference("~/ProductionOrder/PlanOrderControl/ProductionOrderEdit.aspx?id=" + s, "编辑", 1500, 900));
            //BindGrid1();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //移除最后一个key
            if (dictClickColsName.Count > 0)
            {
                string lastKey = dictClickColsName.Last().Key;
                dictClickColsName.Remove(lastKey);
                BindGrid1();
            }
            else
            {
                BindGrid1();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            dictClickColsName.Clear();
            BindGrid1();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            string id = GetSelectedDataKey(Grid1, 0);

            if (e.CommandName == "Print")
            {
                //Print(prosn);
                PageContext.RegisterStartupScript(Window1.GetShowReference("~/ProductionOrder/PlanOrderControl/ProductionOrder_PrePrint.aspx?id=" + id, "打印",800, 900));
            }
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            BindGrid1();
        }

        protected void Window2_Close(object sender, WindowCloseEventArgs e)
        {
            BindGrid1();
        }
        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window2.GetShowReference("~/ProductionOrder/PlanOrderControl/ProductionOrderNew.aspx", "新增排产单"));

        }

        #region 打印

        private void Print(int id)
        {
            PurchaseOrderPrintItem popi = new PurchaseOrderPrintItem();
            //List<ProPlanOrderlists> q = productOrderManager.GetList(u => u.ProPlanOrderheaders.PlanOrderNo == prosn).ToList();
            ProPlanOrderheaders q = proPlanOrderManager.GetProOrder(id);

            if (q!=null)
            {
                if (q.PositionClass.Contains("原料"))
                {
                    popi.title = "原料车间生产安排单";
                }
                else if (q.PositionClass.Contains("烘烤"))
                {
                    popi.title = "烘烤车间生产安排单";
                }
                else if (q.PositionClass.Contains("大包装"))
                {
                    popi.title = "烘烤车间生产安排单";
                }
                else if (q.PositionClass.Contains("小包装"))
                {
                    popi.title = "烘烤车间生产安排单";
                }
                //popi.orderNo = "编号：" + q.orderNo;
                popi.optdate = "日期：" + q.Optdate?.ToString("yyyy-MM-dd");
                popi.jingbanren = q.ProPlanOrderlists[0].Jingbanren;
                popi.pol = q.ProPlanOrderlists;
            }

            PageContext.RegisterStartupScript("Print(" + JsonConvert.SerializeObject(popi, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }) + ")");
        }

        public class PurchaseOrderPrintItem
        {
            public string title { get; set; }
            public string orderNo { get; set; }
            public string optdate { get; set; }
            public string jingbanren { get; set; }
            public List<ProPlanOrderlists> pol { get; set; }
        }
        #endregion

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid1);
            if (ids.Count<=0)
            {
                Alert.Show("请选中记录再删除");
                return;
            }
            productOrderManager.DeleteProOrderAll(ids, GetIdentityChineseName());          
            BindGrid1();
        }

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            object obj = ((ProductIndexData)e.DataItem).ProductState;
            string productState = obj == null?"未生产":
                obj.ToString();
            FineUIPro.BoundField productStateField = Grid1.FindColumn("ProductState") as FineUIPro.BoundField;
            if (productState == "暂停生产")
            {
                e.CellAttributes[productStateField.ColumnIndex]["data-color"] = "color1";
            }
            else if (productState.Contains( "异常") )
            { 
                e.CellAttributes[productStateField.ColumnIndex]["data-color"] = "color2";
            }
            else if (productState == "已完结")
            { 
                e.CellAttributes[productStateField.ColumnIndex]["data-color"] = "color3"; 
            }
            else if (productState == "生产中")
            {
                e.CellAttributes[productStateField.ColumnIndex]["data-color"] = "color4";
            }
            else if (productState == "未生产")
            {
                e.CellAttributes[productStateField.ColumnIndex]["data-color"] = "color5";
            }
            obj = ((ProductIndexData)e.DataItem).PrintState;
            string printState = obj == null ? "未打印" :
                obj.ToString(); 
            FineUIPro.BoundField printStateField = Grid1.FindColumn("PrintState") as FineUIPro.BoundField;
            if (printState == "未打印")
            {
                e.CellAttributes[printStateField.ColumnIndex]["data-color"] = "color1";
            }
            else if (printState == "已打印")
            {
                e.CellAttributes[printStateField.ColumnIndex]["data-color"] = "color3";
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            

            //List<int> list=GetSelectedDataKeyIDs(Grid1);
            int id =GetSelectedDataKeyID(Grid1);
            if (id>0)
            {
                PageContext.RegisterStartupScript(Window1.GetShowReference(
               "~/ProductionOrder_SmallBox/ProductControl/Product_PrePrint.aspx?id=" + id,
               "打印小包装生产单", 1100, 900));
            }
           
        }

        protected void btnPushProOrder_Click(object sender, EventArgs e)
        {
            int id =GetSelectedDataKeyID(Grid1);
            if (id > 0)
            {
                PageContext.RegisterStartupScript(Window2.GetShowReference(
                "~/ProductionOrder_SmallBox/ProductControl/ProductOrderEdit.aspx?id="+ id.ToString()
                , "编辑生产单"));
            }
            

        }
    }
}