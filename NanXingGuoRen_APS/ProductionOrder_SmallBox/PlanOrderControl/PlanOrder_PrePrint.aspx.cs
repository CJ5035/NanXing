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

namespace NanXingGuoRen_APS.ProductionOrder_SmallBox.PlanOrderControl
{
    public partial class PlanOrder_PrePrint : PageBase
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

        private void BindForm()
        {
            string IDs = GetQueryValue("id");
            int id = int.Parse(IDs);

            ProPlanOrderheaders poh = proPlanOrderManager.GetProOrder(id);
            if (!IsPostBack)
            {
                BindCheckBoxList(poh.Workshops);
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
            //string IDs = GetQueryValue("id");

            ////Panel_01.Hidden = false;

            //string[] arr = CheckBoxList1.SelectedValueArray;
            //PageContext.RegisterStartupScript(
            //    Window1.GetShowReference("~/ProductionOrder/ProductOrderControl/ProductionOrder_Print.aspx?id=" + IDs + $"&Position={arr[0]}", "打印", 900, 700));
            ////btnPrint2_Click(sender, e);
            //foreach (string temp in arr)
            //{
            //    Debug.WriteLine(temp);

            //    Thread.Sleep(2000);
            //}


        }

        protected void btnPrint2_Click(object sender, EventArgs e)
        {

           //Debug.WriteLine(hf_DefectId1.Text);
            Debug.WriteLine(hdf.Value);
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
            if (DropDownBox1.Values != null)
            {
                string ids = GetQueryValue("id");
                int id = int.Parse(ids);
                ProPlanOrderheaders poh = proPlanOrderManager.GetProOrder(id);
                List<ProPlanOrderlists> q = poh.ProPlanOrderlists;

                string []arr=DropDownBox1.Values;

                for(int i= 0;i<arr.Length;i++)
                {
                    if (i == 0)
                        SetPanel01(poh, q, arr[i]);
                    else if( i==1)
                        SetPanel02(poh, q, arr[i]);
                    else if (i == 2)
                        SetPanel03(poh, q, arr[i]);
                    else if (i == 3)
                        SetPanel04(poh, q, arr[i]);
                    else if (i == 4)
                        SetPanel05(poh, q, arr[i]);
                    else if (i == 5)
                        SetPanel06(poh, q, arr[i]);
                    else if (i == 6)
                        SetPanel07(poh, q, arr[i]);
                    else if (i == 7)
                        SetPanel08(poh, q, arr[i]);
                    else if (i == 8)
                        SetPanel09(poh, q, arr[i]);
                    else if (i == 9)
                        SetPanel10(poh, q, arr[i]);
                }
                for (int i = arr.Length+1; i <= 10; i++)
                {
                    if (i == 1)
                        SetPanel01(null, null,string.Empty);
                    else if (i == 2)
                        SetPanel02(null, null, string.Empty);
                    else if (i == 3)
                        SetPanel03(null, null, string.Empty);
                    else if (i == 4)
                        SetPanel04(null, null, string.Empty);
                    else if (i == 5)
                        SetPanel05(null, null, string.Empty);
                    else if (i == 6)
                        SetPanel06(null, null, string.Empty);
                    else if (i == 7)
                        SetPanel07(null, null, string.Empty);
                    else if (i == 8)
                        SetPanel08(null, null, string.Empty);
                    else if (i == 9)
                        SetPanel09(null, null, string.Empty);
                    else if (i == 10)
                        SetPanel10(null, null, string.Empty);
                }

            }
        }

        private void SetPanel01(ProPlanOrderheaders poh, List<ProPlanOrderlists> q,string positionClass)
        {
            if (poh==null)
            {
                Panel1.Hidden = true;
            }
            else
            {
                Panel1.Hidden = false;

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
                else if (positionClass.Contains("烘焗") || positionClass.Contains("油炸"))
                {
                    title1.Text = positionClass.Contains("烘焗") ? "烘烤车间生产安排单" : "油炸＆捞味车间生产安排单";
                    lbPosition1.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass : "油炸车间:";
                    BatchNo1.Hidden = false;
                    Ingredients1.Hidden = false;
                    GiveDept1.Hidden = false;

                    BoxNo1.Hidden = true;
                    BoxName1.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title1.Text = positionClass+"生产安排单";
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
                lbOptdate1.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway1.Text = user.ChineseName;
                lbProsn1.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn1.Text + ".jpg";
                //string Path2 = "http://192.168.1.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode1.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn1.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode1.ImageUrl = Path;
                }
                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid1);
                Grid1.DataSource = q2;
                Grid1.DataBind();
            }
        }
        private void SetPanel02(ProPlanOrderheaders poh, List<ProPlanOrderlists> q, string positionClass)
        {
            if (poh == null)
            {
                Panel2.Hidden = true;
            }
            else
            {
                Panel2.Hidden = false;
                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title2.Text = "原料车间生产安排单";
                    lbPosition2.Text = positionClass;
                    BatchNo2.Hidden = true;
                    BoxNo2.Hidden = true;
                    BoxName2.Hidden = true;
                    Ingredients2.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title2.Text = "烘烤车间生产安排单";
                    lbPosition2.Text = "烘烤车间:" + positionClass;
                    BatchNo2.Hidden = false;
                    Ingredients2.Hidden = false;
                    BoxNo2.Hidden = true;
                    BoxName2.Hidden = true;
                }
                else if (positionClass.Contains("烘焗") || positionClass.Contains("油炸"))
                {
                    title2.Text = positionClass.Contains("烘焗") ? "烘烤车间生产安排单" : "油炸＆捞味车间生产安排单";
                    lbPosition2.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass : "油炸车间:";
                    BatchNo2.Hidden = false;
                    Ingredients2.Hidden = false;
                    GiveDept2.Hidden = false;

                    BoxNo2.Hidden = true;
                    BoxName2.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title2.Text = positionClass+"生产安排单";
                    lbPosition2.Text = positionClass;
                    BatchNo2.Hidden = false;
                    BoxNo2.Hidden = false;
                    BoxName2.Hidden = false;
                    Ingredients2.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title2.Text = "小包装车间生产安排单";
                    lbPosition2.Text = "小包装车间";
                    BatchNo2.Hidden = false;
                    BoxNo2.Hidden = false;
                    BoxName2.Hidden = false;
                    Ingredients2.Hidden = true;
                }
                lbOptdate2.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway2.Text = user.ChineseName;
                lbProsn2.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn1.Text + ".jpg";
                //string Path2 = "http://192.168.1.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode2.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn1.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode2.ImageUrl = Path;
                }
                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid2);
                Grid2.DataSource = q2;
                Grid2.DataBind();
            }
        }
        private void SetPanel03(ProPlanOrderheaders poh, List<ProPlanOrderlists> q, string positionClass)
        {
            if (poh == null)
            {
                Panel3.Hidden = true;
            }
            else
            {
                Panel3.Hidden = false;

                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title3.Text = "原料车间生产安排单";
                    lbPosition3.Text = positionClass;
                    BatchNo3.Hidden = true;
                    BoxNo3.Hidden = true;
                    BoxName3.Hidden = true;
                    Ingredients3.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title3.Text = "烘烤车间生产安排单";
                    lbPosition3.Text = "烘烤车间:" + positionClass;
                    BatchNo3.Hidden = false;
                    Ingredients3.Hidden = false;
                    BoxNo3.Hidden = true;
                    BoxName3.Hidden = true;
                }
                else if (positionClass.Contains("烘焗") || positionClass.Contains("油炸"))
                {
                    title3.Text = positionClass.Contains("烘焗") ? "烘烤车间生产安排单" : "油炸＆捞味车间生产安排单";
                    lbPosition3.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass : "油炸车间:";
                    BatchNo3.Hidden = false;
                    Ingredients3.Hidden = false;
                    GiveDept3.Hidden = false;

                    BoxNo3.Hidden = true;
                    BoxName3.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title3.Text = positionClass+"生产安排单";
                    lbPosition3.Text = positionClass;
                    BatchNo3.Hidden = false;
                    BoxNo3.Hidden = false;
                    BoxName3.Hidden = false;
                    Ingredients3.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title3.Text = "小包装车间生产安排单";
                    lbPosition3.Text = "小包装车间";
                    BatchNo3.Hidden = false;
                    BoxNo3.Hidden = false;
                    BoxName3.Hidden = false;
                    Ingredients3.Hidden = true;
                }
                lbOptdate3.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway3.Text = user.ChineseName;
                lbProsn3.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn1.Text + ".jpg";
                //string Path2 = "http://192.168.1.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode3.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn1.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode3.ImageUrl = Path;
                }
                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid3);
                Grid3.DataSource = q2;
                Grid3.DataBind();
            }
        }
        private void SetPanel04(ProPlanOrderheaders poh, List<ProPlanOrderlists> q, string positionClass)
        {
            if (poh == null)
            {
                Panel4.Hidden = true;
            }
            else
            {
                Panel4.Hidden = false;

                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title4.Text = "原料车间生产安排单";
                    lbPosition4.Text = positionClass;
                    BatchNo4.Hidden = true;
                    BoxNo4.Hidden = true;
                    BoxName4.Hidden = true;
                    Ingredients4.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title4.Text = "烘烤车间生产安排单";
                    lbPosition4.Text = "烘烤车间:" + positionClass;
                    BatchNo4.Hidden = false;
                    Ingredients4.Hidden = false;
                    BoxNo4.Hidden = true;
                    BoxName4.Hidden = true;
                }
                else if (positionClass.Contains("烘焗") || positionClass.Contains("油炸"))
                {
                    title4.Text = positionClass.Contains("烘焗") ? "烘烤车间生产安排单" : "油炸＆捞味车间生产安排单";
                    lbPosition4.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass : "油炸车间:";
                    BatchNo4.Hidden = false;
                    Ingredients4.Hidden = false;
                    GiveDept4.Hidden = false;

                    BoxNo4.Hidden = true;
                    BoxName4.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title4.Text = positionClass+"生产安排单";
                    lbPosition4.Text = positionClass;
                    BatchNo4.Hidden = false;
                    BoxNo4.Hidden = false;
                    BoxName4.Hidden = false;
                    Ingredients4.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title4.Text = "小包装车间生产安排单";
                    lbPosition4.Text = "小包装车间";
                    BatchNo4.Hidden = false;
                    BoxNo4.Hidden = false;
                    BoxName4.Hidden = false;
                    Ingredients4.Hidden = true;
                }
                lbOptdate4.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway4.Text = user.ChineseName;
                lbProsn4.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn4.Text + ".jpg";
                //string Path2 = "http://192.168.4.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode4.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn4.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode4.ImageUrl = Path;
                }

                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid4);
                Grid4.DataSource = q2;
                Grid4.DataBind();
            }
        }
        private void SetPanel05(ProPlanOrderheaders poh, List<ProPlanOrderlists> q, string positionClass)
        {
            if (poh == null)
            {
                Panel5.Hidden = true;
            }
            else
            {
                Panel5.Hidden = false;

                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title5.Text = "原料车间生产安排单";
                    lbPosition5.Text = positionClass;
                    BatchNo5.Hidden = true;
                    BoxNo5.Hidden = true;
                    BoxName5.Hidden = true;
                    Ingredients5.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title5.Text = "烘烤车间生产安排单";
                    lbPosition5.Text = "烘烤车间:" + positionClass;
                    BatchNo5.Hidden = false;
                    Ingredients5.Hidden = false;
                    BoxNo5.Hidden = true;
                    BoxName5.Hidden = true;
                }
                else if (positionClass.Contains("烘焗") || positionClass.Contains("油炸"))
                {
                    title5.Text = positionClass.Contains("烘焗") ? "烘烤车间生产安排单" : "油炸＆捞味车间生产安排单";
                    lbPosition5.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass : "油炸车间:";
                    BatchNo5.Hidden = false;
                    Ingredients5.Hidden = false;
                    GiveDept5.Hidden = false;

                    BoxNo5.Hidden = true;
                    BoxName5.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title5.Text = positionClass+"生产安排单";
                    lbPosition5.Text = positionClass;
                    BatchNo5.Hidden = false;
                    BoxNo5.Hidden = false;
                    BoxName5.Hidden = false;
                    Ingredients5.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title5.Text = "小包装车间生产安排单";
                    lbPosition5.Text = "小包装车间";
                    BatchNo5.Hidden = false;
                    BoxNo5.Hidden = false;
                    BoxName5.Hidden = false;
                    Ingredients5.Hidden = true;
                }
                lbOptdate5.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway5.Text = user.ChineseName;
                lbProsn5.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn5.Text + ".jpg";
                //string Path2 = "http://192.168.5.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode5.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn5.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode5.ImageUrl = Path;
                }
                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid5);
                Grid5.DataSource = q2;
                Grid5.DataBind();
            }
        }
        private void SetPanel06(ProPlanOrderheaders poh, List<ProPlanOrderlists> q, string positionClass)
        {
            if (poh == null)
            {
                Panel6.Hidden = true;
            }
            else
            {
                Panel6.Hidden = false;

                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title6.Text = "原料车间生产安排单";
                    lbPosition6.Text = positionClass;
                    BatchNo6.Hidden = true;
                    BoxNo6.Hidden = true;
                    BoxName6.Hidden = true;
                    Ingredients6.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title6.Text = "烘烤车间生产安排单";
                    lbPosition6.Text = "烘烤车间:" + positionClass;
                    BatchNo6.Hidden = false;
                    Ingredients6.Hidden = false;
                    BoxNo6.Hidden = true;
                    BoxName6.Hidden = true;
                }
                else if (positionClass.Contains("烘焗") || positionClass.Contains("油炸"))
                {
                    title6.Text = positionClass.Contains("烘焗") ? "烘烤车间生产安排单" : "油炸＆捞味车间生产安排单";
                    lbPosition6.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass : "油炸车间:";
                    BatchNo6.Hidden = false;
                    Ingredients6.Hidden = false;
                    GiveDept6.Hidden = false;

                    BoxNo6.Hidden = true;
                    BoxName6.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title6.Text = positionClass+"生产安排单";
                    lbPosition6.Text = positionClass;
                    BatchNo6.Hidden = false;
                    BoxNo6.Hidden = false;
                    BoxName6.Hidden = false;
                    Ingredients6.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title6.Text = "小包装车间生产安排单";
                    lbPosition6.Text = "小包装车间";
                    BatchNo6.Hidden = false;
                    BoxNo6.Hidden = false;
                    BoxName6.Hidden = false;
                    Ingredients6.Hidden = true;
                }
                lbOptdate6.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway6.Text = user.ChineseName;
                lbProsn6.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn6.Text + ".jpg";
                //string Path2 = "http://192.168.6.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode6.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn6.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode6.ImageUrl = Path;
                }
                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid6);
                Grid6.DataSource = q2;
                Grid6.DataBind();
            }
        }
        private void SetPanel07(ProPlanOrderheaders poh, List<ProPlanOrderlists> q, string positionClass)
        {
            if (poh == null)
            {
                Panel7.Hidden = true;
            }
            else
            {
                Panel7.Hidden = false;

                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title7.Text = "原料车间生产安排单";
                    lbPosition7.Text = positionClass;
                    BatchNo7.Hidden = true;
                    BoxNo7.Hidden = true;
                    BoxName7.Hidden = true;
                    Ingredients7.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title7.Text = "烘烤车间生产安排单";
                    lbPosition7.Text = "烘烤车间:" + positionClass;
                    BatchNo7.Hidden = false;
                    Ingredients7.Hidden = false;
                    BoxNo7.Hidden = true;
                    BoxName7.Hidden = true;
                }
                else if (positionClass.Contains("烘焗") || positionClass.Contains("油炸"))
                {
                    title7.Text = positionClass.Contains("烘焗") ? "烘烤车间生产安排单" : "油炸＆捞味车间生产安排单";
                    lbPosition7.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass : "油炸车间:";
                    BatchNo7.Hidden = false;
                    Ingredients7.Hidden = false;
                    GiveDept7.Hidden = false;

                    BoxNo7.Hidden = true;
                    BoxName7.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title7.Text = positionClass+"生产安排单";
                    lbPosition7.Text = positionClass;
                    BatchNo7.Hidden = false;
                    BoxNo7.Hidden = false;
                    BoxName7.Hidden = false;
                    Ingredients7.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title7.Text = "小包装车间生产安排单";
                    lbPosition7.Text = "小包装车间";
                    BatchNo7.Hidden = false;
                    BoxNo7.Hidden = false;
                    BoxName7.Hidden = false;
                    Ingredients7.Hidden = true;
                }
                lbOptdate7.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway7.Text = user.ChineseName;
                lbProsn7.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn7.Text + ".jpg";
                //string Path2 = "http://192.168.7.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode7.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn7.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode7.ImageUrl = Path;
                }
                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid7);
                Grid7.DataSource = q2;
                Grid7.DataBind();
            }
        }
        private void SetPanel08(ProPlanOrderheaders poh, List<ProPlanOrderlists> q, string positionClass)
        {
            if (poh == null)
            {
                Panel8.Hidden = true;
            }
            else
            {
                Panel8.Hidden = false;

                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title8.Text = "原料车间生产安排单";
                    lbPosition8.Text = positionClass;
                    BatchNo8.Hidden = true;
                    BoxNo8.Hidden = true;
                    BoxName8.Hidden = true;
                    Ingredients8.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title8.Text = "烘烤车间生产安排单";
                    lbPosition8.Text = "烘烤车间:" + positionClass;
                    BatchNo8.Hidden = false;
                    Ingredients8.Hidden = false;
                    BoxNo8.Hidden = true;
                    BoxName8.Hidden = true;
                }
                else if (positionClass.Contains("烘焗") || positionClass.Contains("油炸"))
                {
                    title8.Text = positionClass.Contains("烘焗") ? "烘烤车间生产安排单" : "油炸＆捞味车间生产安排单";
                    lbPosition8.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass : "油炸车间:";
                    BatchNo8.Hidden = false;
                    Ingredients8.Hidden = false;
                    GiveDept8.Hidden = false;

                    BoxNo8.Hidden = true;
                    BoxName8.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title8.Text = positionClass+"生产安排单";
                    lbPosition8.Text = positionClass;
                    BatchNo8.Hidden = false;
                    BoxNo8.Hidden = false;
                    BoxName8.Hidden = false;
                    Ingredients8.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title8.Text = "小包装车间生产安排单";
                    lbPosition8.Text = "小包装车间";
                    BatchNo8.Hidden = false;
                    BoxNo8.Hidden = false;
                    BoxName8.Hidden = false;
                    Ingredients8.Hidden = true;
                }
                lbOptdate8.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway8.Text = user.ChineseName;
                lbProsn8.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn8.Text + ".jpg";
                //string Path2 = "http://192.168.8.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode8.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn8.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode8.ImageUrl = Path;
                }
                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid8);
                Grid8.DataSource = q2;
                Grid8.DataBind();
            }
        }
        private void SetPanel09(ProPlanOrderheaders poh, List<ProPlanOrderlists> q, string positionClass)
        {
            if (poh == null)
            {
                Panel9.Hidden = true;
            }
            else
            {
                Panel9.Hidden = false;

                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title9.Text = "原料车间生产安排单";
                    lbPosition9.Text = positionClass;
                    BatchNo9.Hidden = true;
                    BoxNo9.Hidden = true;
                    BoxName9.Hidden = true;
                    Ingredients9.Hidden = true;
                    GiveDept9.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title9.Text = "烘烤车间生产安排单";
                    lbPosition9.Text = "烘烤车间:" + positionClass;
                    BatchNo9.Hidden = false;
                    Ingredients9.Hidden = false;
                    BoxNo9.Hidden = true;
                    BoxName9.Hidden = true;
                    GiveDept9.Hidden = true;

                }
                else if (positionClass.Contains("烘焗")|| positionClass.Contains("油炸"))
                {
                    title9.Text = positionClass.Contains("烘焗")? "烘烤车间生产安排单":"油炸＆捞味车间生产安排单";
                    lbPosition9.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass: "油炸车间:";
                    BatchNo9.Hidden = false;
                    Ingredients9.Hidden = false;
                    GiveDept9.Hidden = false;

                    BoxNo9.Hidden = true;
                    BoxName9.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title9.Text = positionClass+"生产安排单";
                    lbPosition9.Text = positionClass;
                    BatchNo9.Hidden = false;
                    BoxNo9.Hidden = false;
                    BoxName9.Hidden = false;
                    Ingredients9.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title9.Text = "小包装车间生产安排单";
                    lbPosition9.Text = "小包装车间";
                    BatchNo9.Hidden = false;
                    BoxNo9.Hidden = false;
                    BoxName9.Hidden = false;
                    Ingredients9.Hidden = true;
                }
                lbOptdate9.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway9.Text = user.ChineseName;
                lbProsn9.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn9.Text + ".jpg";
                //string Path2 = "http://192.168.9.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode9.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn9.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode9.ImageUrl = Path;
                }
                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid9);
                Grid9.DataSource = q2;
                Grid9.DataBind();
            }
        }
        private void SetPanel10(ProPlanOrderheaders poh, List<ProPlanOrderlists> q, string positionClass)
        {
            if (poh == null)
            {
                Panel10.Hidden = true;
            }
            else
            {
                Panel10.Hidden = false;

                if (positionClass.Contains("原料") || positionClass.Contains("夏果出仁车间"))
                {
                    title10.Text = "原料车间生产安排单";
                    lbPosition10.Text = positionClass;
                    BatchNo10.Hidden = true;
                    BoxNo10.Hidden = true;
                    BoxName10.Hidden = true;
                    Ingredients10.Hidden = true;
                }
                else if (positionClass.Contains("烘烤"))
                {
                    title10.Text = "烘烤车间生产安排单";
                    lbPosition10.Text = "烘烤车间:" + positionClass;
                    BatchNo10.Hidden = false;
                    Ingredients10.Hidden = false;
                    BoxNo10.Hidden = true;
                    BoxName10.Hidden = true;
                }
                else if (positionClass.Contains("烘焗") || positionClass.Contains("油炸"))
                {
                    title10.Text = positionClass.Contains("烘焗") ? "烘烤车间生产安排单" : "油炸＆捞味车间生产安排单";
                    lbPosition10.Text = positionClass.Contains("烘焗") ? "烘烤车间:" + positionClass : "油炸车间:";
                    BatchNo10.Hidden = false;
                    Ingredients10.Hidden = false;
                    GiveDept10.Hidden = false;

                    BoxNo10.Hidden = true;
                    BoxName10.Hidden = true;
                }
                else if (positionClass.Contains("大包装")|| positionClass.Contains("夏果包装车间"))
                {
                    title10.Text = positionClass+"生产安排单";
                    lbPosition10.Text = positionClass;
                    BatchNo10.Hidden = false;
                    BoxNo1.Hidden = false;
                    BoxName10.Hidden = false;
                    Ingredients10.Hidden = true;
                }
                else if (positionClass.Contains("小包装"))
                {
                    title10.Text = "小包装车间生产安排单";
                    lbPosition10.Text = "小包装车间";
                    BatchNo10.Hidden = false;
                    BoxNo10.Hidden = false;
                    BoxName10.Hidden = false;
                    Ingredients10.Hidden = true;
                }
                lbOptdate1.Text = "日期：" + q[0].Newdate?.ToString("yyyy-MM-dd");
                string jbr = q[0].Jingbanren;
                Users user = userService.GetByName(jbr);
                lbPayway1.Text = user.ChineseName;
                lbProsn1.Text = poh.PlanOrderNo;
                string Path = "~/images/" + lbProsn1.Text + ".jpg";
                //string Path2 = "http://192.168.1.118:8019/images/" + lbProsn.Text + ".jpg";

                string serverPath = Server.MapPath(Path);
                if (File.Exists(serverPath))
                {
                    imgBarcode1.ImageUrl = Path;
                }
                else
                {
                    QRCodeHandler.CreateQRCode(lbProsn1.Text, "Byte", 5, 0, "H", serverPath, false, "");
                    imgBarcode1.ImageUrl = Path;
                }
                var q2 = q.AsQueryable();
                q2 = SortAndPage(q2, Grid10);
                Grid10.DataSource = q2;
                Grid10.DataBind();
            }
        }
        

    }
}