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
using NanXingGuoRen_WMS.Business.Helper;
using NanXingData_WMS.Dao;
using System.Threading;
using System.Buffers;
using NanXingService_WMS.Entity.ProductEntity;
using NanXingData_WMS.DaoUtils;

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanOrderControl
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
            SetPanel01();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
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
                u => u.ProductOrderheaders_ID == header_ID,
                u => new ProductOrderlists { PrintState = hasPrint });

            ProductOrderheadersService.UpdateByPlus(
                u => u.ID == header_ID,
                u => new ProductOrderheaders { PrintState = hasPrint });
        }
        protected object ChangeState()
        {
            if (!IsPostBack)
            {
                return null;
            }

            string ids = GetQueryValue("id");
            int header_ID = Convert.ToInt32(ids);
            string[] idsStr = ids.Split(new char[1] { ',' });
            int[] idsInt = Array.ConvertAll(idsStr, s => int.Parse(s));
            string hasPrint = "已打印";
            //List<ProPlanOrderlists> list=ProPlanOrderlistsService.GetList(
            //    u => idsInt.Contains(u.ID),true,DbMainSlave.Master);

            //list.ForEach((item)=>{ item.PrintState = hasPrint; });
            ProductOrderlistsService.UpdateByPlus(
                u => idsInt.Contains((int)u.ProductOrderheaders_ID),
                u => new ProductOrderlists { PrintState = hasPrint });

            ProductOrderheadersService.UpdateByPlus(
                u => u.ID == header_ID,
                u => new ProductOrderheaders { PrintState = hasPrint });
            return null;
        }
        protected void btnPrint2_Click(object sender, EventArgs e)
        {
            ChangeState();
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
            

            SetPanel01();


        }

        string labTitle = "小包装车间生产安排单";
        string dateStr = "日期：" + DateTime.Now.ToString("yyyy-MM-dd");
        private void SetPanel01()
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
        
        

    }
}