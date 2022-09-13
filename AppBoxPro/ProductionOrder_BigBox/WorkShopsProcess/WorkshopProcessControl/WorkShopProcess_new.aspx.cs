using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUIPro;
using NanXingData_WMS.Dao;

namespace NanXingGuoRen_WMS.ProductionOrder.WorkShopsProcess.WorkShopProcessControl
{
    public partial class WorkShopProcess_new : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreTitleNew";
            }
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            LoadDDL();
        }
        private void LoadDDL()
        {
            var q = workshopProcessService.GetProcessClassQuery();
            ddl_ProcessClass.DataTextField = "ProcessClassSortName";
            ddl_ProcessClass.DataValueField = "ID";
            ddl_ProcessClass.DataSource = q;
            ddl_ProcessClass.DataBind();
        }

        #endregion

        #region Events

        private void SaveJobTitle()
        {
            WorkShopProcess item = new WorkShopProcess();
            item.WorkShopName = tbxName.Text.Trim();
            //item.WHPosition = tbxPosition.Text.Trim();
            item.WorkShopSort = int.Parse(tbxSort.Text.Trim());
            item.ProcessClass_Id = int.Parse(ddl_ProcessClass.SelectedValue.Trim());
            item.processClass = workshopProcessService.FindProcessClassById(item.ProcessClass_Id, NanXingData_WMS.DaoUtils.DbMainSlave.Master);

            workshopProcessService.AddWorkShopProcess(item);
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveJobTitle();

            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

    }
}
