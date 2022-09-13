using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUIPro;
using NanXingData_WMS.DaoUtils;
using UtilsSharp.Standard;

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanToProControl
{
    public partial class PlanToProConfirm : PageBase
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
            if (!dp1.SelectedDate.HasValue)
            {
                Alert.Show("请选择计划生产日期");
                return;
            }

            string[] idStrs = GetQueryValue("ids").Split(',');
            string position = GetQueryValue("position");
            string isPrint = GetQueryValue("isPrint");
            DateTime dateTime = dp1.SelectedDate.Value;
            int[] arr=new int[idStrs.Length];
            arr=Array.ConvertAll(idStrs, new Converter<string, int>(int.Parse));
            //将ids的计划单下推生产单

            var planList = ProPlanOrderlistsService.GetList(u => arr.Contains(u.ID),
                false, DbMainSlave.Master);

            foreach (var temp in planList)
            {
                if (temp.PlanOrder_State=="已下推")
                {
                    Alert.Show("已下推的任务不能重复进行下推");
                    return;
                }
            }

            string time = ddlPlanTime.SelectedValue;
            string orderNo = liuShuiHaoService.GetProOrderLSH();
            //string position = ddlPosition.SelectedValue;
            string pushUser= GetIdentityName()+":"+GetIdentityChineseName();
            BaseResult<string> ret = productOrderManager.PushToProOrder
                (orderNo, planList, position, pushUser, dateTime, time);
            if (ret.Code == 200)
            {
                Alert.Show("下推成功");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("下推失败");
            }
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {

        }
    }
}