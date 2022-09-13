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
    public partial class ProductCountReport : PageBase
    {
        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "ProOrderCountReport-SmallBox";
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
            if (list.Contains("ProOrderCountReport-SmallBox-03"))
            {
                var arr = positionArr.Where(u => u.Contains("03")).ToArray();
                foreach (var temp in arr)
                    vs.Add(temp);
            }
            if (list.Contains("ProOrderCountReport-SmallBox-07"))
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

            //expression = expression.And(u => u.Chejianclass == "小包装排产单");

            //var q = ProductOrderheadersService.GetIQueryable(expression, true, DbMainSlave.Master);
            string[] arr = null;
            if (ddlPosition.SelectedValue == "全部")
                arr = ddlPosition.Items.Select(u => u.Value).ToArray();
            else
                arr = new string[1] { ddlPosition.SelectedValue };


            var result = productOrderManager.GetOrderCountReport(
                dp1.SelectedDate.Value, dp2.SelectedDate.Value.Date.AddDays(1).AddSeconds(-1), arr,
                tbxItemNo.Text.Trim(), tbxItemName.Text.Trim());

            var q = result.desc;


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
            BindGrid1();
            Grid1.PageSize = Grid1.RecordCount;
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

      

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
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