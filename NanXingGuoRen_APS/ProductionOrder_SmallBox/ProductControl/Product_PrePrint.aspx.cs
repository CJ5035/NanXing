using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUIPro;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

using System.Diagnostics;
using NanXingGuoRen_APS.Business.Helper;
using NanXingData_WMS.Dao;
using System.Threading;
using System.Buffers;
using NanXingService_WMS.Entity.ProductEntity;
using NanXingData_WMS.DaoUtils;

namespace NanXingGuoRen_APS.ProductionOrder_SmallBox.PlanOrderControl
{
    public partial class Product_PrePrint : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        #region BindCheckBoxList

        public class TestClass
        {
            private string _id;

            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private bool _select;

            public bool Selected
            {
                get { return _select; }
                set { _select = value; }
            }

            public TestClass(string id, string name, bool select)
            {
                _id = id;
                _name = name;
                _select = select;
            }

        }
        private string[] positionArr = { "原料挑选车间", "夏果出仁车间", "", "", "", "" };
        private void BindCheckBoxList(string values)
        {
            string[] arr = values.Split(',');
            List<TestClass> myList = new List<TestClass>();
            foreach (string temp in arr)
            {
                myList.Add(new TestClass(temp, temp, true));
            }
            CheckBoxList1.DataEnabledField = "Selected";
            CheckBoxList1.DataTextField = "Name";
            CheckBoxList1.DataValueField = "Id";
            CheckBoxList1.DataSource = myList;
            CheckBoxList1.DataBind();

           
        }
        #endregion

        private void LoadData()
        {
            BindForm();
            BindGrid();
        }
        /// <summary>
        /// 绑定所有车间
        /// </summary>
        private void BindForm()
        {
            string IDs = GetQueryValue("id");
            
            List<string> positionList = new List<string>();
            char separator = ',';
            if (IDs.Length>0)
            {
                string[] idsStr = IDs.Split(new char[1] { separator });
                int[] idsInt = Array.ConvertAll(idsStr, s => int.Parse(s));
                
                //获取所有所有排产单明细
                List<ProPlanOrderheaders> posList = ProPlanOrderlistsService.GetIQueryable(
                    u => idsInt.Contains(u.ID)).GroupBy(u => u.ProPlanOrderheaders)
                    .Select(u => u.Key).ToList();
                //得到所有的车间
                foreach (ProPlanOrderheaders temp in posList)
                {
                    string[] tempArr = temp.Workshops.Split(new char[1] { separator });
                    foreach (string str in tempArr)
                    {
                        if (!positionList.Contains(str))
                            positionList.Add(str);
                    }
                }

                if (!IsPostBack)
                {
                    BindCheckBoxList(string.Join(separator.ToString(), positionList.ToArray()));
                }
            }
           
            
        }

        private void BindGrid()
        {
            //string prosn =GetQueryValue("prosn");

            //var q = from a in DB.po_items
            //         where a.PO.ID == ID
            //         select new
            //         {
            //             a.ID,
            //             a.name,
            //             a.spec,
            //             a.model,
            //             a.length,
            //             a.width,
            //             a.high,
            //             a.unit,
            //             a.count,
            //             a.price,
            //             a.Class,
            //             a.remark,
            //             a.usingObj,
            //             a.purpose,
            //             Heji=a.count*a.price
            //         };
            //decimal totalCount=0;
            //decimal totalPrice = 0;
            //foreach(var item in q)
            //{
            //    totalCount += item.count;
            //    totalPrice += item.count * item.price;
            //}

            //if (q.Any(u => u.Class == "标签材料"||u.Class=="碳带"))
            //{
            //    width.Hidden = false;
            //    length.Hidden = false;
            //    high.Hidden = false;
            //}

            
            


            //Grid1.RecordCount = q.Count();

            //JObject jObject = new JObject();
            //jObject.Add("count", totalCount);
            //jObject.Add("Heji", totalPrice.ToString("F2"));

            //Grid1.SummaryData = jObject;

            //q = SortAndPage(q, Grid1);

            //Grid1.DataSource = q;
            //Grid1.DataBind();


        }

        protected void Grid1_Sort(object sender, FineUIPro.GridSortEventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (DropDownBox1.Values != null)
            {
                string ids = GetQueryValue("id");
                //string[] idsStr = ids.Split(new char[1] { ',' });
                //int[] idsInt = Array.ConvertAll(idsStr, s => int.Parse(s));
                string hasPrint = "已打印";
                int header_ID = Convert.ToInt32(ids);

               
                //List<ProPlanOrderlists> list=ProPlanOrderlistsService.GetList(
                //    u => idsInt.Contains(u.ID),true,DbMainSlave.Master);

                //list.ForEach((item)=>{ item.PrintState = hasPrint; });
                ProductOrderlistsService.UpdateByPlus(
                    u => u.ProductOrderheaders_ID==header_ID,
                    u=>new ProductOrderlists { PrintState = hasPrint });
            }
        }
        protected object ChangeState()
        {
            if (DropDownBox1.Values != null)
            {
                string ids = GetQueryValue("id");
                string[] idsStr = ids.Split(new char[1] { ',' });
                int[] idsInt = Array.ConvertAll(idsStr, s => int.Parse(s));
                string hasPrint = "已打印";
                //List<ProPlanOrderlists> list=ProPlanOrderlistsService.GetList(
                //    u => idsInt.Contains(u.ID),true,DbMainSlave.Master);

                //list.ForEach((item)=>{ item.PrintState = hasPrint; });
                ProPlanOrderlistsService.UpdateByPlus(
                    u => idsInt.Contains(u.ID),
                    u => new ProPlanOrderlists { PrintState = hasPrint });
            }
            return null;
        }
        protected void btnPrint2_Click(object sender, EventArgs e)
        {
            if (DropDownBox1.Values != null)
            {
                string ids = GetQueryValue("id");
                string[] idsStr = ids.Split(new char[1] { ',' });
                int[] idsInt = Array.ConvertAll(idsStr, s => int.Parse(s));
                string hasPrint = "已打印";
                //List<ProPlanOrderlists> list=ProPlanOrderlistsService.GetList(
                //    u => idsInt.Contains(u.ID),true,DbMainSlave.Master);

                //list.ForEach((item)=>{ item.PrintState = hasPrint; });
                ProPlanOrderlistsService.UpdateByPlus(
                    u => idsInt.Contains(u.ID),
                    u => new ProPlanOrderlists { PrintState = hasPrint });
            }
        }

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            foreach(KeyValuePair<string,JToken> temp in e.CellAttributes[0])
            {
                Debug.WriteLine(temp.Key);
                Debug.WriteLine(temp.Value);

            }
        }

        protected void Grid1_DataBinding(object sender, EventArgs e)
        {

        }
        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            //BindGrid1();
        }

        protected void btnSure_Click(object sender, EventArgs e)
        {
            string ids = GetQueryValue("id");
            string[] idsStr = ids.Split(new char[1] { ',' });
            int[] idsInt = Array.ConvertAll(idsStr, s => int.Parse(s));
            string Path = "~/images/";
            string serverPath = Server.MapPath(Path);
            int ID = Convert.ToInt32(ids);
            Debug.WriteLine(ID);
            var list2 = ProductOrderlistsService.FirstOrDefault(u => u.ProductOrderheaders_ID == ID);
            string position = list2.Chejianclass;
            var q = productOrderManager.GetPrintItem(
                u => u.ProductOrderheaders_ID == ID, u => u.ProductOrder_XuHao
                , serverPath);

            SetPanel01(q, position);


            if (DropDownBox1.Values != null )
            {
                


                //string []arr=DropDownBox1.Values;

                //for(int i= 0;i<arr.Length;i++)
                //{
                //    if (i == 0)
                //        SetPanel01( q, position);
                //    else if (i == 1)
                //        SetPanel02(q, arr[i]);
                //    else if (i == 2)
                //        SetPanel03(q, arr[i]);
                //    else if (i == 3)
                //        SetPanel04(q, arr[i]);
                //    else if (i == 4)
                //        SetPanel05(q, arr[i]);
                //    else if (i == 5)
                //        SetPanel06(q, arr[i]);
                //    else if (i == 6)
                //        SetPanel07(q, arr[i]);
                //    else if (i == 7)
                //        SetPanel08(q, arr[i]);
                //    else if (i == 8)
                //        SetPanel09(q, arr[i]);
                //    else if (i == 9)
                //        SetPanel10(q, arr[i]);
                //}
                //for (int i = arr.Length+1; i <= 10; i++)
                //{
                //    if (i == 1)
                //        SetPanel01( null,string.Empty);
                //    else if (i == 2)
                //        SetPanel02( null, string.Empty);
                //    else if (i == 3)
                //        SetPanel03( null, string.Empty);
                //    else if (i == 4)
                //        SetPanel04( null, string.Empty);
                //    else if (i == 5)
                //        SetPanel05( null, string.Empty);
                //    else if (i == 6)
                //        SetPanel06( null, string.Empty);
                //    else if (i == 7)
                //        SetPanel07( null, string.Empty);
                //    else if (i == 8)
                //        SetPanel08( null, string.Empty);
                //    else if (i == 9)
                //        SetPanel09( null, string.Empty);
                //    else if (i == 10)
                //        SetPanel10( null, string.Empty);
                //}

            }
        }

        string labTitle = "小包装车间生产安排单";
        string dateStr = "日期：" + DateTime.Now.ToString("yyyy-MM-dd");
        private void SetPanel01(List<PrintData_SmallBox> q,string position)
        {
            if (q==null || q.Count== 0)
            {
                Panel1.Hidden = true;
            }
            else
            {
                Panel1.Hidden = false;
                title1.Text = labTitle;
                lbPosition1.Text = position;
                lbOptdate1.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                //var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid1);
                Grid1.DataSource = q2;
                Grid1.DataBind();
            }
        }
        private void SetPanel02(List<PrintData_SmallBox> q,string position)
        {
            if (q == null || q.Count == 0)
            {
                Panel2.Hidden = true;
            }
            else
            {
                Panel2.Hidden = false;
                title2.Text = labTitle;
                lbPosition2.Text = position;
                lbOptdate2.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid2);
                Grid2.DataSource = q2;
                Grid2.DataBind();
            }
        }
        private void SetPanel03( List<PrintData_SmallBox> q,string position)
        {
            if (q == null || q.Count == 0)
            {
                Panel3.Hidden = true;
            }
            else
            {
                Panel3.Hidden = false;
                title3.Text = labTitle;
                lbPosition3.Text = position;
                lbOptdate3.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid3);
                Grid3.DataSource = q2;
                Grid3.DataBind();
            }
        }
        private void SetPanel04( List<PrintData_SmallBox> q,string position)
        {
            if (q == null || q.Count == 0)
            {
                Panel4.Hidden = true;
            }
            else
            {
                Panel4.Hidden = false;
                title4.Text = labTitle;
                lbPosition4.Text = position;
                lbOptdate4.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid4);
                Grid4.DataSource = q2;
                Grid4.DataBind();
            }
        }
        private void SetPanel05( List<PrintData_SmallBox> q,string position)
        {
            if (q == null || q.Count == 0)
            {
                Panel5.Hidden = true;
            }
            else
            {
                Panel5.Hidden = false;
                title5.Text = labTitle;
                lbPosition5.Text = position;
                lbOptdate5.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid5);
                Grid5.DataSource = q2;
                Grid5.DataBind();
            }
        }
        private void SetPanel06(List<PrintData_SmallBox> q,string position)
        {
            if (q == null || q.Count == 0)
            {
                Panel6.Hidden = true;
            }
            else
            {
                Panel6.Hidden = false;
                title6.Text = labTitle;
                lbPosition6.Text = position;
                lbOptdate6.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid6);
                Grid6.DataSource = q2;
                Grid6.DataBind();
            }
        }
        private void SetPanel07( List<PrintData_SmallBox> q,string position)
        {
            if (q == null || q.Count == 0)
            {
                Panel7.Hidden = true;
            }
            else
            {
                Panel7.Hidden = false;
                title7.Text = labTitle;
                lbPosition7.Text = position;
                lbOptdate7.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid7);
                Grid7.DataSource = q2;
                Grid7.DataBind();
            }
        }
        private void SetPanel08( List<PrintData_SmallBox> q,string position)
        {
            if (q == null || q.Count == 0)
            {
                Panel8.Hidden = true;
            }
            else
            {
                Panel8.Hidden = false;
                title8.Text = labTitle;
                lbPosition8.Text = position;
                lbOptdate8.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid8);
                Grid8.DataSource = q2;
                Grid8.DataBind();
            }
        }
        private void SetPanel09(List<PrintData_SmallBox> q,string position)
        {
            if (q == null || q.Count == 0)
            {
                Panel9.Hidden = true;
            }
            else
            {
                Panel9.Hidden = false;
                title9.Text = labTitle;
                lbPosition9.Text = position;
                lbOptdate9.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid9);
                Grid9.DataSource = q2;
                Grid9.DataBind();
            }
        }
        private void SetPanel10( List<PrintData_SmallBox> q,string position)
        {
            if (q == null || q.Count == 0)
            {
                Panel10.Hidden = true;
            }
            else
            {
                Panel10.Hidden = false;
                title10.Text = labTitle;
                lbPosition10.Text = position;
                lbOptdate10.Text = dateStr;

                var q2 = q.Where(u => u.Workshops.Contains(position)).AsQueryable();
                q2 = SortAndPage(q2, Grid10);
                Grid10.DataSource = q2;
                Grid10.DataBind();
            }
        }
        

    }
}