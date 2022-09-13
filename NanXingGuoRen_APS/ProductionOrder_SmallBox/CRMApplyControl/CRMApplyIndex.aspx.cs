using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingService_WMS.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NanXingGuoRen_APS.ProductionOrder_SmallBox.CRMApplyControl
{
    public partial class CRMApplyIndex : PageBase
    {
        //key-列名  value-值
        static Dictionary<string, string> dictClickColsName = new Dictionary<string, string>();

        #region Page_Load
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
            DateTime startTime= DateTime.Now.AddDays(-15);
            DateTime endTime = DateTime.Now.AddDays(15);
            dp1.SelectedDate = DateTime.Parse(startTime.ToString("yyyy-MM-dd"));
            dp2.SelectedDate = DateTime.Parse(endTime.ToString("yyyy-MM-dd"));
            BindGrid1();
        }
        private void BindGrid1()
        {
            DateTime dt1 = dp1.SelectedDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dt2 = dp2.SelectedDate ?? DateTime.Now;
            dt2 = dt2.AddDays(1);

            //筛选条件
            Expression<Func<CRMPlanList, bool>> expression = DbBaseExpand.True<CRMPlanList>();
           
            expression = expression.And(
                u => u.DeliveryDate >= dt1 && u.DeliveryDate <= dt2
                && u.CRMPlanHead.MakeClass=="小包装");

            if (tbxApplyNo.Text.Trim().Length>0)
            {
                expression = expression.And(u => u.CRMPlanHead.CRMApplyNo.Contains( tbxApplyNo.Text));
            }
            if (tbxName.Text.Trim().Length > 0)
            {
                expression = expression.And(u => u.ItemName.Contains(tbxName.Text));
            }
            if (ddlState.SelectedText.Trim().Length>0)
            {
                if(ddlState.SelectedText.Trim()!="全部")
                    expression = expression.And(u => u.crmListStatus == ddlState.SelectedText.Trim());
            }
            var q = crmPlanManager.QueryIndex(expression);
            Expression<Func<CRMApplyIndexData, bool>> indexExpression = DbBaseExpand.True<CRMApplyIndexData>();
            if (tbxSearch.Text.Trim().Length > 0)
            {
                string value = tbxSearch.Text.Trim();
                indexExpression = indexExpression.And(u => u.CRMApplyNo.Contains(value) 
                                        || u.ItemName.Contains(value) || u.ItemNo.Contains(value) 
                                        || u.InName.Contains(value) || u.MaterialItem.Contains(value)
                                        || u.ClientName.Contains(value) || u.ApplyNoState.Contains(value)
                                        || u.EmergencyDegree.Contains(value) || u.BatchNo.Contains(value));
            }
            q = q.Where(indexExpression);


            Grid1.RecordCount = q.Count();
            q = SortAndPage(q, Grid1);
            Grid1.DataSource = q;
            Grid1.DataBind();
        }
        #endregion

        #region 绑定行功能与样式
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            string prosn = GetSelectedDataKey(Grid1, 1);

            if (e.CommandName == "Print")
            {
                //Print(prosn);
                PageContext.RegisterStartupScript(Window1.GetShowReference("~/ProductionOrder/ProductionOrder_Print.aspx?prosn=" + prosn, "打印", 900, 700));
            }
        }
        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            //crmPlanManager.ConvertToDataTable();

            //DataRowView row = (DataRowView) ;
           
            string applyNoState = ((CRMApplyIndexData)e.DataItem).crmListStatus.ToString();
            FineUIPro.BoundField cApplyNoState = Grid1.FindColumn("crmListStatus") as FineUIPro.BoundField;
            if (applyNoState == "未排产")
            {
                e.CellAttributes[cApplyNoState.ColumnIndex]["data-color"] = "color2";
            }
            else if (applyNoState == "已下推") { e.CellAttributes[cApplyNoState.ColumnIndex]["data-color"] = "color1"; }

        }
        #endregion

        #region 打印

        private void Print(string prosn)
        {
            //PurchaseOrderPrintItem popi = new PurchaseOrderPrintItem();
            //List<ProPlanOrderlists> q = DB2.ProPlanOrderlists.Where(u => u.ProPlanOrderheaders.prosn == prosn).ToList();
            //List<ProPlanOrderlists> q = productOrderManager.GetList(u => u.ProPlanOrderheaders.PlanOrderNo == prosn, u => u.ID.ToString());
            //if (q.Count > 0)
            //{
            //    if (q[0].ProPlanOrderheaders.PositionClass.Contains("原料"))
            //    {
            //        popi.title = "原料车间生产安排单";
            //    }
            //    else if (q[0].ProPlanOrderheaders.PositionClass.Contains("烘烤"))
            //    {
            //        popi.title = "烘烤车间生产安排单";
            //    }
            //    else if (q[0].ProPlanOrderheaders.PositionClass.Contains("大包装"))
            //    {
            //        popi.title = "烘烤车间生产安排单";
            //    }
            //    else if (q[0].ProPlanOrderheaders.PositionClass.Contains("小包装"))
            //    {
            //        popi.title = "烘烤车间生产安排单";
            //    }
            //    popi.orderNo = "编号：" + q[0].ProPlanOrderheaders.orderNo;
            //    popi.optdate = "日期：" + q[0].Optdate?.ToString("yyyy-MM-dd");
            //    popi.jingbanren = q[0].Jingbanren;
            //    popi.pol = q;
            //}

            //PageContext.RegisterStartupScript("Print(" + JsonConvert.SerializeObject(popi, Formatting.None,
            //            new JsonSerializerSettings()
            //            {
            //                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //            }) + ")");
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

        #region 事件
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
            ExportExcel("CRM申请单明细", Grid1);
        }

        protected void Grid1_RowDoubleClick(object sender, FineUIPro.GridRowClickEventArgs e)
        {
            int s = GetSelectedDataKeyID( Grid1);
            object[] arr=GetSelectedAllDataKeys(Grid1, 1);
            bool ret = true;
            foreach(object item in arr)
            {
                Debug.WriteLine(item);
                if (item != null && item.ToString().Length > 0)
                {
                    ret = false;
                    break;
                }
            };
            if (ret)
                //s[0] 选中的行id, s[1] 选中的ColumnID
                PageContext.RegisterStartupScript(Window1.GetShowReference("~/ProductionOrder_SmallBox/ProductionOrderEdit.aspx?id=" + s, "编辑", 1500, 900));            
            else
                Alert.Show("该任务单已合并为排产单");
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
            List<int> ids = GetSelectedDataKeyIDs(Grid1);
            if (ids.Count <= 0)
            {
                Alert.Show("请选择合并的申请单");
                return;
            }
            //List<object[]> list = Grid1.DataKeys;
            object[] arr=GetSelectedAllDataKeys(Grid1, 1);
            if (arr!=null)
            {
                foreach (object item in arr)
                {
                    if (item != null && item.ToString().Length > 0)
                    {
                        Alert.Show("该任务单已合并为排产单");
                        return;
                    }
                };
            }

            arr = GetSelectedAllDataKeys(Grid1, 2);
            string state = "冻结";
            if (arr != null)
            {
                foreach (object item in arr)
                {
                    if (item != null && item.ToString()== state)
                    {
                        Alert.Show("冻结中的任务，不能进行合并排产");
                        return;
                    }
                };
            }
            PageContext.RegisterStartupScript(
                 Window2.GetShowReference("~/ProductionOrder_SmallBox/CRMApplyControl/CRMApplyNew.aspx?ids=" + string.Join(",", ids.ToArray()), "合并排产单"));

        }
        protected void btnAddOrder2_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid1);
            if (ids.Count <= 0)
            {
                Alert.Show("请选择合并的申请单");
                return;
            }
            object[] arr = GetSelectedAllDataKeys(Grid1, 1);
            if (arr != null)
            {
                foreach (object item in arr)
                {
                    if (item != null && item.ToString().Length > 0)
                    {
                        Alert.Show("该任务单已合并为排产单");
                        return;
                    }
                };
            }

            arr = GetSelectedAllDataKeys(Grid1, 2);
            string state = "冻结";
            if (arr != null)
            {
                foreach (object item in arr)
                {
                    if (item != null && item.ToString() == state)
                    {
                        Alert.Show("冻结中的任务，不能进行合并排产");
                        return;
                    }
                };
            }

            PageContext.RegisterStartupScript(
                Window2.GetShowReference("~/ProductionOrder_SmallBox/CRMApplyControl/CRMApplyNew2.aspx?ids=" + string.Join(",", ids.ToArray()), "合并排产单"));
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //List<int> ids = GetSelectedDataKeyIDs(Grid1);
            //if (ids.Count<=0)
            //{
            //    Alert.Show("请选中记录再删除");
            //    return;
            //}
            //foreach(int temp in ids)
            //{
            //    ProPlanOrderheaders poh= DB2.ProPlanOrderheaders.Where(u => u.ID == temp).FirstOrDefault();
            //    List<ProPlanOrderlists> list = poh.ProPlanOrderlists.ToList();
            //    for (int index= list.Count-1; index >= 0; index--)
            //        DB2.ProPlanOrderlists.Remove(list[index]);
            //    DB2.ProPlanOrderheaders.Remove(poh);
            //}
            //DB2.SaveChanges();
            //BindGrid1();
        }

        #endregion

        
    }
}