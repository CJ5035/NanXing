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

namespace NanXingGuoRen_APS.ProductionOrder
{
    public partial class ProductionOrder_Print : PageBase
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

            private bool _enabled;

            public bool Enabled
            {
                get { return _enabled; }
                set { _enabled = value; }
            }

            public TestClass(string id, string name, bool enabled)
            {
                _id = id;
                _name = name;
                _enabled = enabled;
            }

        }
        private string[] positionArr = { "原料挑选车间", "夏果出仁车间", "", "", "", "" };
        private void BindCheckBoxList(string values)
        {
            string[] arr = values.Split(',');

            List<TestClass> myList = new List<TestClass>();
            myList.Add(new TestClass("1", "数据绑定值 1", false));
            myList.Add(new TestClass("2", "数据绑定值 2", false));
            myList.Add(new TestClass("3", "数据绑定值 3", true));
            myList.Add(new TestClass("4", "数据绑定值 4", true));

            CheckBoxList2.DataEnabledField = "Enabled";
            CheckBoxList2.DataTextField = "Name";
            CheckBoxList2.DataValueField = "Id";
            CheckBoxList2.DataSource = myList;
            CheckBoxList2.DataBind();

            CheckBoxList2.SelectedValueArray = new string[] { "1", "3" };
        }
        #endregion

        private void LoadData()
        {
            BindForm();
            //BindGrid();
        }

        private void BindForm()
        {
            string ids = GetQueryValue("id");
            string positionClass = GetQueryValue("Position");

            int id = int.Parse(ids);
            ProPlanOrderheaders poh = proPlanOrderManager.GetProOrder(id);
            List <ProPlanOrderlists> q = poh.ProPlanOrderlists;
            //lbProvider.Text = q.provider;
            if (q.Count > 0)
            {
                mCells.Value = poh.mergeCellsValue;
                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title1.Text = "原料车间生产安排单";
                    lbPosition1.Text = positionClass;
                    BatchNo1.Hidden = true;
                    BoxNo1.Hidden = true;
                    BoxName1.Hidden = true;
                    Ingredients1.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title1.Text = "烘烤车间生产安排单";
                    lbPosition1.Text = "烘烤车间:" + positionClass;
                    BatchNo1.Hidden = false;
                    Ingredients1.Hidden = false;
                    BoxNo1.Hidden = true;
                    BoxName1.Hidden = true;
                }
                else if (positionClass.Contains("大包装"))
                {
                    title1.Text = "大包装车间生产安排单";
                    lbPosition1.Text = positionClass;
                    BatchNo1.Hidden = false;
                    BoxNo1.Hidden = false;
                    BoxName1.Hidden = false;
                    Ingredients1.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title1.Text = "小包装车间生产安排单";
                    lbPosition1.Text = "小包装车间";
                    BatchNo1.Hidden = false;
                    BoxNo1.Hidden = false;
                    BoxName1.Hidden = false;
                    Ingredients1.Hidden = true;
                }
                //orderNo.Text = "编号：" + q[0].ProPlanOrderheaders.orderNo;
                lbOptdate1.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway1.Text = user.ChineseName;
                lbProsn1.Text =poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn1.Text + ".jpg";
                //string Path2 = "http://192.168.1.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                Debug.WriteLine(serverPath);
                if (File.Exists(serverPath))
                {
                    imgBarcode1.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn1.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode1.ImageUrl = Path;
                }
            }

            //var q2 = from a in DB2.ProPlanOrderlists
            //         where a.ProPlanOrderheaders.prosn == prosn
            //         select new
            //         {
            //             a.ID,
            //             a.name,
            //             a.spec,
            //             a.model,
            //             a.inName,
            //             a.Class,
            //             a.count,
            //             a.unit,
            //             a.batchNo,
            //             a.boxNo,
            //             a.boxName,
            //             a.ingredients,
            //             remark1= a.remark1,
            //             a.ProPlanOrderheaders.prosn,
            //             //a.ProPlanOrderheaders.orderNo,
            //             a.ProPlanOrderheaders.optdate,
            //             a.ProPlanOrderheaders.positionClass
            //         };

            var q2 = q.AsQueryable();
            q2 = SortAndPage(q2, Grid1);
            Grid1.DataSource = q2;
            Grid1.DataBind();


            //if (!IsPostBack)
            //{
            //    BindCheckBoxList( values)
            //}
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
        }

        protected void btnPrint2_Click(object sender, EventArgs e)
        {

           //Debug.WriteLine(hf_DefectId1.Text);
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
    }
}