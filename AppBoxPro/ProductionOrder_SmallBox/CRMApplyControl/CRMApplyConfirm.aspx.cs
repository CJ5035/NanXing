using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUIPro;
using NanXingData_WMS.DaoUtils;
using UtilsSharp.Standard;

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox.CRMApplyControl
{
    public partial class CRMApplyConfirm : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDLDept();
            }
        }

        private void BindDDLDept()
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextArea_Remark.Text))
            {
                Alert.Show("请输入不需排产原因");
                return;
            }

            string[] idStrs = GetQueryValue("ids").Split(',');
            string remark = TextArea_Remark.Text;
            long[] arr=new long[idStrs.Length];
            arr=Array.ConvertAll(idStrs, new Converter<string, long>(long.Parse));
            //将ids的计划单下推生产单

            var crmPlanList = crmPlanListService.GetList(u => arr.Contains(u.ID),
                false, DbMainSlave.Master);

            foreach (var temp in crmPlanList)
            {
                if (temp.crmListStatus=="已排产")
                {
                    Alert.Show("任务已排产");
                    return;
                }
            }
            crmPlanManager.ChangeCRMStatueOverApi(arr, "不需排产",TextArea_Remark.Text);
            Alert.Show("修改成功");
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            //if (ret.Code == 200)
            //{
            //    Alert.Show("下推成功");
            //    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            //}
            //else
            //{
            //    Alert.Show("下推失败");
            //}
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {

        }
    }
}