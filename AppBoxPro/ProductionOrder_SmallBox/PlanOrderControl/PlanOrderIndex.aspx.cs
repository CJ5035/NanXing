using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingService_WMS.Entity;
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

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanOrderControl
{
    public partial class PlanOrderIndex : PageBase
    {
        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "PlanOrderManagement-SmallBox";
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
          
            dp1.SelectedDate = DateTime.Now.AddDays(-15);
            dp2.SelectedDate = DateTime.Now.AddDays(15);

            BindGrid1();
        }


        private void BindGrid1()
        {
            //筛选条件
            Expression<Func<ProPlanOrderheaders, bool>> expression = DbBaseExpand.True<ProPlanOrderheaders>();
            if (dp1.SelectedDate.HasValue)
            {
                DateTime dt1 = dp1.SelectedDate.Value.Date;
                expression = expression.And(u => u.Optdate >= dt1);
            }

            if (dp2.SelectedDate.HasValue)
            {
                DateTime dt2 = dp2.SelectedDate.Value.Date.AddDays(1).AddSeconds(-1);
                expression=expression.And(u => u.Optdate <= dt2);
            }
            if (tbxOrderNo.Text.Trim().Length > 0)
            {
                expression = expression.And(u => (u.PlanOrderNo??String.Empty).Contains(tbxOrderNo.Text.Trim()));
            }

            if (ddlPosition.SelectedValue.Length > 0)
            {
                if (ddlPosition.SelectedValue != "全部")
                    expression = expression.And(u => (u.Workshops??String.Empty).Contains( ddlPosition.SelectedValue));
            }
            expression = expression.And(u =>u.PositionClass== "小包装排产单");
            

            var q = ProPlanOrderheaderService.QueryIndex(expression);
            //if (ddlPlanState.SelectedIndex >-1)
            //{
            //    q = q.Where(u => u.ProductState??String.Empty).Contains(ddlPlanState.SelectedValue.Trim()));

            //}
            if (tbxname.Text.Trim().Length > 0)
            {
                q = q.Where(u => (u.ItemNameStr??String.Empty).Contains(tbxname.Text.Trim()));
            }
            if (tbxSearch.Text.Trim().Length > 0)
            {
                string txt = tbxSearch.Text;
                q = q.Where(u => ((u.PlanOrderNo??String.Empty).Contains(txt) 
                || (u.Workshops??String.Empty).Contains(txt) 
                || (u.ItemNameStr??String.Empty).Contains(txt)
                || (u.CRMXuHao??String.Empty).Contains(txt) 
                || (u.JingBanRen??String.Empty).Contains(txt) 
                || (u.Remark??String.Empty).Contains(txt) 
                || (u.CRMHeadNo??String.Empty).Contains(txt)));
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
            if (s >0)
            //s[0] 选中的行id, s[1] 选中的ColumnID
                PageContext.RegisterStartupScript(Window1.GetShowReference(
                    "~/ProductionOrder_SmallBox/PlanOrderControl/PlanOrderEdit2.aspx?id=" + s, "编辑", 1600, 900));
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
                PageContext.RegisterStartupScript(Window1.GetShowReference("~/ProductionOrder/PlanOrderControl/ProductionOrder_PrePrint.aspx?id=" + id, "打印",1200, 900));
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
            PageContext.RegisterStartupScript
                (Window2.GetShowReference
                ("~/ProductionOrder_SmallBox/PlanOrderControl/PlanOrderNew.aspx", "新增排产单"));

        }

        #region 打印

        private void Print(int id)
        {
            PurchaseOrderPrintItem popi = new PurchaseOrderPrintItem();
            //List<ProPlanOrderlists> q = productOrderManager.GetList(u => u.ProPlanOrderheaders.PlanOrderNo == prosn).ToList();
            ProPlanOrderheaders q = proPlanOrderManager.GetProOrder(id);

            if (q!=null)
            {
                if ((q.PositionClass??String.Empty).Contains("原料"))
                {
                    popi.title = "原料车间生产安排单";
                }
                else if ((q.PositionClass??String.Empty).Contains("烘烤"))
                {
                    popi.title = "烘烤车间生产安排单";
                }
                else if ((q.PositionClass??String.Empty).Contains("大包装"))
                {
                    popi.title = "烘烤车间生产安排单";
                }
                else if ((q.PositionClass??String.Empty).Contains("小包装"))
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
            var ret =proPlanOrderManager.DeleteProOrderAll(ids);
            string result = ret.message==ResultMsg.success ? "成功" :
                "失败\r\n该排产单下推的生产单未删除";
            Alert.Show($"删除排产单{result}");
            BindGrid1();
        }

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            string productState = ((ProductOrderIndexData)e.DataItem).ProductState.ToString();
            FineUIPro.BoundField productStateField = Grid1.FindColumn("ProductState") as FineUIPro.BoundField;
            if (productState == "已排产")
            {
                e.CellAttributes[productStateField.ColumnIndex]["data-color"] = "color1";
            }
            else if (productState == "已下推")
            {
                e.CellAttributes[productStateField.ColumnIndex]["data-color"] = "color2";
            }

            else if (productState == "生产中") 
            { 
                e.CellAttributes[productStateField.ColumnIndex]["data-color"] = "color2";
            }
            else if (productState == "已完成")
            { 
                e.CellAttributes[productStateField.ColumnIndex]["data-color"] = "color3"; 
            }

            //string printState = ((ProductOrderIndexData)e.DataItem).PrintState.ToString();
            //FineUIPro.BoundField printStateField = Grid1.FindColumn("PrintState") as FineUIPro.BoundField;
            //if (printState == "未打印")
            //{
            //    e.CellAttributes[printStateField.ColumnIndex]["data-color"] = "color1";
            //}
            //else if (printState == "已打印")
            //{
            //    e.CellAttributes[printStateField.ColumnIndex]["data-color"] = "color3";
            //}
        }
    }
}