using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingGuoRen_APS.Business.Helper;
using NanXingService_WMS.Entity;
using Newtonsoft.Json.Linq;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NanXingGuoRen_APS.ProductionOrder.CRMApplyControl
{
    public partial class CRMApplyNew : PageBase
    {
        //private bool AppendToEnd = true;

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
                //btnNew.OnClientClick = Grid1.GetAddNewRecordReference(defaultObj, AppendToEnd);

                // 重置表格
                //btnReset.OnClientClick = Confirm.GetShowReference("确定要重置表格数据？", String.Empty, Grid1.GetRejectChangesReference(), String.Empty);

                // 删除选中行按钮
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference("请至少选择一项！") + deleteScript;
                LoadExcel();
                LoadData();

                BindDDLClient();
            }
        }

        private void BindDDLClient()
        {
           
        }

        private void LoadExcel()
        {
            
            //DataTable dt=ExcelUtils.ReadExcel(Server.MapPath(Request.ApplicationPath + "/res/files/排产工艺名.xls"));
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
            Lab_PCY.Text = GetIdentityName();
            hbDate.SelectedDate = DateTime.Now;
            BindGrid1();
        }

        private void BindGrid1()
        {
          
            string[] idStrs = GetQueryValue("ids").Split(',');
            long[] ids = Array.ConvertAll<string, long>(idStrs, s => long.Parse(s));
            var q = crmPlanManager.GetMissionControlIndex(u =>ids.Contains( u.ID));
            List<CRMApplyIndexData> qlist = q.ToList();
            //因为不能识别外包装箱号、箱名是否已有数据，先清空再Upate BoxNo、BoxName这两列
            qlist.ForEach((item)=>{
                item.BoxNo = string.Empty;
                item.BoxName = string.Empty;
            });
            var qParse = qlist.AsQueryable();

            Grid1.RecordCount = qParse.Count();
            qParse = SortAndPage(qParse, Grid1);
            Grid1.DataSource = qParse;
            Grid1.DataBind();

            qlist = q.ToList();
            string Priority = "正常";
            for (int index = 0; index < Grid1.RecordCount; index++)
            {
                Grid1.UpdateCellValue(index, "PcCount", qlist[index].OrderCount.ToString());
                Grid1.UpdateCellValue(index, "PcUnit", qlist[index].Unit??string.Empty);
                Grid1.UpdateCellValue(index, "BoxNo", qlist[index].BoxNo ?? string.Empty);
                Grid1.UpdateCellValue(index, "BoxName", qlist[index].BoxName ?? string.Empty);
                Grid1.UpdateCellValue(index, "Priority", Priority);
            }

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
        private string GetCheckedValuesString(string[][] array)
        {
            if (array.Length == 0)
            {
                return "无";
            }

            StringBuilder sb = new StringBuilder();
            foreach (string[] item in array)
            {
                sb.Append( string.Join(",", item));
                //sb.Append(item);
                if(item.Length>0)
                    sb.Append(",");
            }
            return sb.ToString().TrimEnd(',');
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, object>> modDic = Grid1.GetModifiedDict();
            if (modDic.Count <= 0)
            {
                Alert.Show("没有需要合并的任务申请单，请重新选择需要合并的申请单");
                return;
            }

            string positionStr = GetCheckedValuesString(new string[5][] { CheckBoxList2.SelectedValueArray, CheckBoxList3.SelectedValueArray ,CheckBoxList4.SelectedValueArray,
             CheckBoxList5.SelectedValueArray, CheckBoxList6.SelectedValueArray});
            if (string.IsNullOrEmpty(positionStr))
            {
                Alert.Show("请选择排产车间");
                return;
            }

           

            List<object[]> keys=Grid1.DataKeys;
            
            List<int> modDicIndex = modDic.Keys.ToList();
            List<Dictionary<string, object>> modDicValue = modDic.Values.ToList();

            ProPlanOrderheaders ProPlanOrderheaders = new ProPlanOrderheaders();
            //执行存储过程，返回流水号
           
            string result = liuShuiHaoService.GetPlanOrderLSH() ;

            DateTime nowDt = DateTime.Now;
            ProPlanOrderheaders.PlanOrderNo = result.ToString();
            ProPlanOrderheaders.Optdate = hbDate.SelectedDate;
            ProPlanOrderheaders.Newdate = nowDt;
            ProPlanOrderheaders.Moddate = nowDt;
            //ProPlanOrderheaders.orderNo = orderNo.Text.Trim();
            ProPlanOrderheaders.PositionClass = "小包装排产单";
            ProPlanOrderheaders.mergeCells = DropDownBox1.Text;
            ProPlanOrderheaders.mergeCellsValue = string.Join(",", DropDownBox1.Values);
            ProPlanOrderheaders.Workshops = GetCheckedValuesString(new string[5][] { CheckBoxList2.SelectedValueArray, CheckBoxList3.SelectedValueArray ,CheckBoxList4.SelectedValueArray,
             CheckBoxList5.SelectedValueArray, CheckBoxList6.SelectedValueArray});

            ProPlanOrderheaders.ProPlanOrderlists = new List<ProPlanOrderlists>();
            string[] colstr=new string[] { "crmListStatus" };
            for (int i = 0; i < modDic.Count; i++)
            {
                int index = modDicIndex[i];
                int ID=Convert.ToInt32(keys[index][0]);
                Dictionary<string, object> dic = modDicValue[i];
                List<string> columnList = dic.Keys.ToList();

                CRMPlanList cpl=crmPlanManager.GetList(ID);

                ProPlanOrderlists item = new ProPlanOrderlists();
                item.Newdate = nowDt;
                item.Moddate = nowDt;
                item.PlanOrder_XuHao = $"{result}-" + (i + 1).ToString("D2");

                item.Itemno = cpl.ItemNo;
                item.ItemName = cpl.ItemName;
                item.Spec = cpl.Spec;
                item.Biaozhun = cpl.Biaozhun;
                item.Clientname = cpl.CRMPlanHead.ClientName;
                item.ProductRecipe = cpl.ProductRecipe;
                item.BoxNo = cpl.BoxNo;
                item.BoxName = cpl.BoxName;
                item.BoxRemark = cpl.BoxRemark;

                if (dic.ContainsKey("ItemName1")) item.InName = dic["ItemName1"].ToString();
                if (dic.ContainsKey("ItemName2")) item.MaterialItem = dic["ItemName2"].ToString();
                if (dic.ContainsKey("Color")) item.Color = dic["Color"].ToString();
                if (dic.ContainsKey("PlanDate")) item.PlanDate = DateTime.Parse(dic["PlanDate"].ToString());
                if (dic.ContainsKey("PlanTime")) item.PlanTime = dic["PlanTime"].ToString();
                if (dic.ContainsKey("PcCount")) item.PcCount = decimal.Parse(dic["PcCount"].ToString());
                if (dic.ContainsKey("PcUnit")) item.Unit = dic["PcUnit"].ToString();
                if (dic.ContainsKey("BatchNo")) item.BatchNo = dic["BatchNo"].ToString();
                if (dic.ContainsKey("GiveDept")) item.GiveDept = dic["GiveDept"].ToString();
                if (dic.ContainsKey("Ingredients")) item.Ingredients = dic["Ingredients"].ToString();
                if (dic.ContainsKey("BoxNo")) item.BoxNo = dic["BoxNo"].ToString();
                if (dic.ContainsKey("BoxName")) item.BoxName = dic["BoxName"].ToString();
                if (dic.ContainsKey("BoxRemark")) item.BoxRemark = dic["BoxRemark"].ToString();
                if (dic.ContainsKey("PcRemark")) item.Remark = dic["PcRemark"].ToString();
                if (dic.ContainsKey("Priority")) item.Priority = dic["Priority"].ToString();
                
                item.Jingbanren = GetIdentityName();
                item.ProPlanOrderheaders = ProPlanOrderheaders;
                item.CRMPlanList_ID = ID;
                //item.crmPlanList = cpl;
                ProPlanOrderheaders.ProPlanOrderlists.Add(item);

                //cpl.crmListStatus = "已排产";
                //crmPlanManager.chan

                crmPlanManager.ChangeCRMStatue(ID, "已排产");
            }

            proPlanOrderManager.AddProOrder(ProPlanOrderheaders);
            //DB2.SaveChanges();

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //BindGrid2();
        }

       

        protected void jiaoFuDate_DateSelect(object sender, EventArgs e)
        {
            if(jiaoFuDate.Enabled)
            {
                if (jiaoFuDate.SelectedDate!=null)
                {
                    for (int index = 0; index < Grid1.RecordCount; index++)
                        Grid1.UpdateCellValue(index, "Plandate", jiaoFuDate.SelectedDate?.ToString("yyyy-MM-dd"));
                    List<Dictionary<string, object>> list = Grid1.GetNewAddedList();
                    for (int index2 = 0; index2 < list.Count; index2++)
                    {
                        Grid1.UpdateCellValue(index2, "Plandate", jiaoFuDate.SelectedDate?.ToString("yyyy-MM-dd"));
                    }
                }
                else
                {
                    
                }
            }
            
        }

        protected void Cb_JFD_CheckedChanged(object sender, CheckedEventArgs e)
        {
            Panel98.Enabled = Cb_JFD.Checked;
        }

    }
}