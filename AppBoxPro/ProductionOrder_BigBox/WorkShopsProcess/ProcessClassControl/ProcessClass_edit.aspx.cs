using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUIPro;
using NanXingData_WMS.Dao;

namespace NanXingGuoRen_WMS.ProductionOrder.WorkShopsProcess.ProcessClassControl
{
    public partial class ProcessClass_edit : PageBase
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

            int id = GetQueryIntValue("id");
            ProcessClass processClass = workshopProcessService.FindProcessClassById(id);
            if (processClass == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！请刷新页面后重试", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            tbxName.Text = processClass.ProcessClassName;
            //tbxPosition.Text = wareHouse.WHPosition;
            tbxSort.Text = processClass.ProcessSort.ToString();

            tbxRemark.Text = processClass.ProcessReamrk;

        }

     
        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            ProcessClass processClass = workshopProcessService.FindProcessClassById(id, NanXingData_WMS.DaoUtils.DbMainSlave.Master);
            processClass.ProcessClassName=tbxName.Text ;
            //tbxPosition.Text = wareHouse.WHPosition;
            processClass.ProcessSort = int.Parse(tbxSort.Text );

            processClass.ProcessReamrk = tbxRemark.Text ;
            workshopProcessService.UpdateProcessClass(processClass);

            //FineUIPro.Alert.Show("保存成功！", String.Empty, FineUIPro.Alert.DefaultIcon, FineUIPro.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
