using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUIPro;
using NanXingData_WMS.Dao;

namespace NanXingGuoRen_APS.ProductionOrder.ItemInfoControl
{
    public partial class ItemInfo_edit : PageBase
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
            BindDataTableToDropDownList();
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            int id = GetQueryIntValue("id");
            ItemInfo itemInfo = itemService.FindById(id);
            if (itemInfo == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！请刷新页面后重试", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            tbxItemNo.Text = itemInfo.ItemNo;
            tbxItemName.Text = itemInfo.ItemName;
            tbxInName.Text = itemInfo.InName;
            tbxMaterialItem.Text = itemInfo.MaterialItem;
            DropDownList1.SelectedValueArray = itemInfo.Workshops == null ? new string[0]: itemInfo.Workshops.Split(',');
            //tbxPosition.Text = wareHouse.WHPosition;
            //tbxSort.Text = processClass.ProcessSort.ToString();

            //tbxRemark.Text = processClass.ProcessReamrk;
            
        }
        private void BindDataTableToDropDownList()
        {
            var q= workshopProcessService.GetWorkShopProcessQuery();

            DropDownList1.DataGroupField = "ProcessClass_Id";
            //DropDownList1.DataDisplayFields = new string[] { "Name", "Desc" };
            //DropDownList1.DataDisplayFormatString = "<div class=\"item-text\">{0}</div><div class=\"item-desc\">{1}</div>";
            DropDownList1.DataTextField = "WorkShopName";
            DropDownList1.DataValueField = "WorkShopName";
            DropDownList1.DataSource = q;
            DropDownList1.DataBind();
        }


        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            ItemInfo itemInfo = itemService.FindById(id);
            
            itemInfo.ItemNo= tbxItemNo.Text ;
            itemInfo.ItemName =tbxItemName.Text ;
            itemInfo.InName= tbxInName.Text  ;
            itemInfo.MaterialItem=tbxMaterialItem.Text;
            itemInfo.Workshops = string.Join(",",DropDownList1.SelectedValueArray);
            //processClass.ProcessClassName=tbxName.Text ;
            ////tbxPosition.Text = wareHouse.WHPosition;
            //processClass.ProcessSort = int.Parse(tbxSort.Text );
            itemService.Update(itemInfo);
            //processClass.ProcessReamrk = tbxRemark.Text ;

            ////FineUIPro.Alert.Show("保存成功！", String.Empty, FineUIPro.Alert.DefaultIcon, FineUIPro.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
