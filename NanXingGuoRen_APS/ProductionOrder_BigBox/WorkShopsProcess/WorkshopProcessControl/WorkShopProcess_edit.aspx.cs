using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUIPro;
using NanXingData_WMS.Dao;

namespace NanXingGuoRen_APS.ProductionOrder.WorkShopsProcess.WorkShopProcessControl
{
    public partial class WorkShopProcess_edit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "ProcessClassEdit";
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

            int id = GetQueryIntValue("id");
            WorkShopProcess processClass = workshopProcessService.FindWorkShopProcessById(id);
            if (processClass == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！请刷新页面后重试", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            tbxName.Text = processClass.WorkShopName;
            //tbxPosition.Text = wareHouse.WHPosition;
            tbxSort.Text = processClass.WorkShopSort.ToString();

            ddl_ProcessClass.SelectedValue = processClass.ProcessClass_Id.ToString();

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

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            WorkShopProcess workShopProcess = workshopProcessService.FindWorkShopProcessById(id, NanXingData_WMS.DaoUtils.DbMainSlave.Master);
            workShopProcess.WorkShopName= tbxName.Text;
            //tbxPosition.Text = wareHouse.WHPosition;
            workShopProcess.WorkShopSort= int.Parse(tbxSort.Text);

            workShopProcess.ProcessClass_Id= int.Parse(ddl_ProcessClass.SelectedValue);
            workShopProcess.processClass = workshopProcessService.FindProcessClassById(workShopProcess.ProcessClass_Id, NanXingData_WMS.DaoUtils.DbMainSlave.Master);


            workshopProcessService.UpdateWorkShopProcess(workShopProcess);

            //FineUIPro.Alert.Show("保存成功！", String.Empty, FineUIPro.Alert.DefaultIcon, FineUIPro.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
