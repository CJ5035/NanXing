using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingGuoRen_WMS.Business.Helper;
using Newtonsoft.Json.Linq;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanOrderControl
{
    public partial class PlanOrderNew1 : PageBase
    {
        private bool AppendToEnd = true;

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
                LoadExcel();
                LoadData();

                BindDDLClient();
            }
        }

        private void BindDDLClient()
        {
            var q = from a in DB.telenClients
                    select a;

            ddlClient.DataTextField = "Name";
            ddlClient.DataValueField = "ID";
            ddlClient.DataSource = q;
            ddlClient.DataBind();
        }

        private void LoadExcel()
        {
            //DataTable dt = ExcelUtils.ReadExcel(Server.MapPath(Request.ApplicationPath + "/res/files/排产工艺名.xls"));
            //ddlname.DataTextField = "物料名称";
            //ddlname.DataValueField = "物料名称";
            //ddlname.DataSource = dt;
            //ddlname.DataBind();
        }

        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, Grid1.GetDeleteSelectedRowsReference(), String.Empty);
        }

        private void LoadData()
        {
            //BindGrid2();
            BindGridDDLProvider();
        }

        private void BindGridDDLProvider()
        {
            var q = DB.Depts.Where(u => u.Parent.Name == "生产部");
            ddl_Class.DataTextField = "Name";
            ddl_Class.DataValueField = "Name";
            ddl_Class.DataSource = q;
            ddl_Class.DataBind();
        }


        private string ReplaceTeShu(string str)
        {
            str = str.Replace(" ", ",");
            str = str.Replace("，", ",");
            str = str.Replace("、", ",");
            str = str.Replace("；", ",");
            str = str.Replace(";", ",");
            return str;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Grid1.GetNewAddedList().Count <= 0)
            {
                Alert.Show("没有新增的数据");
                return;
            }

            if (!datepicker1.SelectedDate.HasValue || datepicker1.SelectedDate?.ToString("yyyy-MM-dd") == "1900-01-01")
            {
                Alert.Show("请选择下单日期");
                return;
            }

            //新增数据
            List<Dictionary<string, object>> newAddedList = Grid1.GetNewAddedList();
            //Debug.WriteLine(newAddedList[i]["clientname"].ToString());
            ProPlanOrderheaders ProPlanOrderheaders = new ProPlanOrderheaders();
            //执行存储过程，返回流水号

            string result = liuShuiHaoService.GetPlanOrderLSH();

            DateTime nowDt = DateTime.Now;
            ProPlanOrderheaders.PlanOrderNo = result.ToString();
            ProPlanOrderheaders.Newdate = nowDt;
            ProPlanOrderheaders.Moddate = nowDt;

            ProPlanOrderheaders.Optdate = datepicker1.SelectedDate;
            ProPlanOrderheaders.PositionClass = ddl_Class.SelectedValue;
            ProPlanOrderheaders.mergeCells = DropDownBox1.Text;
            ProPlanOrderheaders.mergeCellsValue = string.Join(",", DropDownBox1.Values);
          
            ProPlanOrderheaders.ProPlanOrderlists = new List<ProPlanOrderlists>();
            for (int i = 0; i < newAddedList.Count; i++)
            {
                ProPlanOrderlists item = new ProPlanOrderlists();
                item.Newdate = nowDt;
                item.Moddate = nowDt;
                if (newAddedList[i].ContainsKey("itemno")) item.Itemno = newAddedList[i]["itemno"].ToString();
                if (newAddedList[i].ContainsKey("name")) item.ItemName = newAddedList[i]["name"].ToString();
                if (newAddedList[i].ContainsKey("spec")) item.Spec = newAddedList[i]["spec"].ToString();
                if (newAddedList[i].ContainsKey("model")) item.Model = newAddedList[i]["model"].ToString();
                if (newAddedList[i].ContainsKey("inName")) item.InName = newAddedList[i]["inName"].ToString();
                if (newAddedList[i].ContainsKey("color")) item.Color = newAddedList[i]["color"].ToString();
                if (newAddedList[i].ContainsKey("material")) item.MaterialItem = newAddedList[i]["material"].ToString();
                if (newAddedList[i].ContainsKey("Class")) item.Class = ddl_Class.SelectedValue;
                if (newAddedList[i].ContainsKey("ERPOrderNo")) item.ERPOrderNo = newAddedList[i]["ERPOrderNo"].ToString();
                if (newAddedList[i].ContainsKey("PlanDate")) item.PlanDate = DateTime.Parse(newAddedList[i]["PlanDate"].ToString());

                //卷数
                if (newAddedList[i].ContainsKey("count"))
                {
                    if (item.Unit == "平方米")
                    {
                        if (newAddedList[i].ContainsKey("area")) item.PcCount = decimal.Parse(newAddedList[i]["area"].ToString());
                    }
                    else
                    {
                        item.PcCount = decimal.Parse(newAddedList[i]["count"].ToString());
                    }
                }

                if (newAddedList[i].ContainsKey("remark1"))
                {
                    string remark = newAddedList[i]["remark1"].ToString().Replace(";\r\n", ";").Replace(";", ";\r\n");
                    item.Remark = remark;
                }
                if (newAddedList[i].ContainsKey("ingredients")) item.Ingredients = newAddedList[i]["ingredients"].ToString();
                if (newAddedList[i].ContainsKey("boxName")) item.BoxName = newAddedList[i]["boxName"].ToString();
                if (newAddedList[i].ContainsKey("batchNo")) item.BatchNo = newAddedList[i]["batchNo"].ToString();
                if (newAddedList[i].ContainsKey("boxNo")) item.BoxNo = newAddedList[i]["boxNo"].ToString();
               
                item.Jingbanren = GetIdentityName();
                //item.PlanDate = datepicker1.SelectedDate;
                item.Class = ddl_Class.SelectedValue;
                item.Chejianclass = ddlCheJian.Text.Trim();
                item.ProPlanOrderheaders = ProPlanOrderheaders;
                ProPlanOrderheaders.ProPlanOrderlists.Add(item);
            }

            proPlanOrderManager.AddProOrder(ProPlanOrderheaders);

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //BindGrid2();
        }


        protected void ddl_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddl_Class.SelectedValue == "原料车间")
            //{
            //    Ingredients.Hidden = true;
            //    BoxName.Hidden = true;
            //    BoxNo.Hidden = true;
            //    ddlCheJian.Hidden = true;
            //}
            //else if (ddl_Class.SelectedValue == "烘烤车间")
            //{
            //    ingredients.Hidden = false;
            //    boxName.Hidden = true;
            //    boxNo.Hidden = true;
            //    ddlCheJian.Hidden = false;
            //}
            //else if (ddl_Class.SelectedValue.Contains("包装车间"))
            //{
            //    ingredients.Hidden = true;
            //    boxName.Hidden = false;
            //    boxNo.Hidden = false;
            //    ddlCheJian.Hidden = true;

            //}

        }
    }
}