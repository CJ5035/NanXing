using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
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
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilsSharp;

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox
{
    public partial class PlanOrderEdit2 : PageBase
    {
        private bool AppendToEnd = true;
        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //datepicker1.SelectedDate = DateTime.Now;

                //LoadExcel();

                LoadData();
            }
        }
        private void LoadData()
        {
            
            BindGrid0();
            BindGrid1();

            TabStrip1.ActiveTabIndex = 6;
            string[] temp2 = CheckBoxList2.SelectedValueArray;
            Tab1.Hidden = !temp2.Contains(Tab1.Title);
            Tab2.Hidden = !temp2.Contains(Tab2.Title);
            Tab3.Hidden = !temp2.Contains(Tab3.Title);
            string[] temp3 = CheckBoxList3.SelectedValueArray;
            Tab4.Hidden = !temp3.Contains(Tab4.Title);
            Tab5.Hidden = !temp3.Contains(Tab5.Title);
            Tab6.Hidden = !temp3.Contains(Tab6.Title);
        }
        private void BindGrid0()
        {
            int id = int.Parse(GetQueryValue("id"));
            //显示成品信息
            var q = ProPlanOrderheaderService.GetIQueryable(u => u.ID == id);

            Grid0.RecordCount = q.Count();
            var qParse0 = SortAndPage(q, Grid0);

            Grid0.DataSource = qParse0;
            Grid0.DataBind();

        }

        private void BindGrid1()
        {
            string pcy = GetIdentityName();
            string ipAddress = GetLocalIp();
            int id = int.Parse(GetQueryValue("id"));

            string redisKeyStart = $"{ipAddress}{pcy}";
            string redisKey_AddList = $"{redisKeyStart}:ADDOrderList";
            string redisKey_EditList = $"{redisKeyStart}:EditOrderList";
            string redisKey_Count = $"{redisKeyStart}:CRMADDCount:{id}";

           

            RemoveRedis(redisKey_AddList, id);
            RemoveRedis(redisKey_EditList, id);
            if (redisHelper.KeyExists(redisKey_Count))
            {
                redisHelper.KeyDelete(redisKey_Count);
            }
            var qList = proPlanOrderManager.GetList(u => u.ProPlanOrderheaders_ID == id, u => u.PlanOrder_XuHao);
            //qList.ForEach((item)=> { item.Itemno = "004.05.13.08.04.0007"; });

           
            if (qList.Count > 0)
            {
                ProPlanOrderheaders ProPlanOrderheaders = qList[0].ProPlanOrderheaders;
                LoadMergeCellsValue(ProPlanOrderheaders);


                List<ProPlanOrderlists> list1 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(qList);
                List<ProPlanOrderlists> list2 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(qList);
                List<ProPlanOrderlists> list3 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(qList);
                List<ProPlanOrderlists> list4 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(qList);
                List<ProPlanOrderlists> list5 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(qList);
                List<ProPlanOrderlists> list6 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(qList);

                ProOrderGrid_UC1.OrderList = list1.AsQueryable(); ;
                ProOrderGrid_UC1.RedisKey = redisKeyStart;
                ProOrderGrid_UC1.ProductHeader_ID = id;
                ProOrderGrid_UC1.UserName = pcy;

                ProOrderGrid_UC2.OrderList = list2.AsQueryable(); ;
                ProOrderGrid_UC2.RedisKey = redisKeyStart;
                ProOrderGrid_UC2.UserName = pcy;
                ProOrderGrid_UC2.ProductHeader_ID = id;

                ProOrderGrid_UC3.OrderList = list3.AsQueryable(); ;
                ProOrderGrid_UC3.RedisKey = redisKeyStart;
                ProOrderGrid_UC3.UserName = pcy;
                ProOrderGrid_UC3.ProductHeader_ID = id;

                ProOrderGrid_UC4.OrderList = list4.AsQueryable(); ;
                ProOrderGrid_UC4.RedisKey = redisKeyStart;
                ProOrderGrid_UC4.UserName = pcy;
                ProOrderGrid_UC4.ProductHeader_ID = id;

                ProOrderGrid_UC5.OrderList = list5.AsQueryable(); ;
                ProOrderGrid_UC5.RedisKey = redisKeyStart;
                ProOrderGrid_UC5.UserName = pcy;
                ProOrderGrid_UC5.ProductHeader_ID = id;

                ProOrderGrid_UC6.OrderList = list6.AsQueryable(); ;
                ProOrderGrid_UC6.RedisKey = redisKeyStart;
                ProOrderGrid_UC6.UserName = pcy;
                ProOrderGrid_UC6.ProductHeader_ID = id;
            }
        }

       
        string[] positionArr ={"03小包装-小袋","03小包装-罐","03小包装-每日坚果",
                "07小包装-小袋","07小包装-罐", "07小包装-每日坚果" };
        private void RemoveRedis(string redisList,int id)
        {
            string keyList = redisList + ":" + id;
        
            foreach (string poTemp in positionArr)
            {
                if (redisHelper.HashExists(keyList, poTemp))
                {
                    redisHelper.HashDelete(keyList, poTemp);
                }
            }
        }
        private void LoadMergeCellsValue(ProPlanOrderheaders ProPlanOrderheaders)
        {
            // 后台更新下拉框的值，需要同时设置Text和Value
            if (!string.IsNullOrEmpty(ProPlanOrderheaders.mergeCells))
            {
                //DropDownBox1.Text = ProPlanOrderheaders.mergeCells;
                //DropDownBox1.Value = ProPlanOrderheaders.mergeCellsValue; // 或者：DropDownBox1.Values = new string[] { "php", "basic" };
            }
            if (!string.IsNullOrEmpty(ProPlanOrderheaders.Workshops))
            {
                string[] arr = ProPlanOrderheaders.Workshops.Split(',');
                
                CheckBoxList2.SelectedValueArray = arr;
                CheckBoxList3.SelectedValueArray = arr;
            }
        }
        #endregion

        #region Event
        
        private string GetCheckedValuesString(string[][] array)
        {
            if (array.Length == 0)
            {
                return "无";
            }

            StringBuilder sb = new StringBuilder();
            foreach (string[] item in array)
            {
                sb.Append(string.Join(",", item));
                //sb.Append(item);
                if (item.Length > 0)
                    sb.Append(",");
            }
            return sb.ToString().TrimEnd(',');
        }
        protected void Btn_SaveExit_Click(object sender, EventArgs e)
        {
            
            string pcy = GetIdentityName();
            //清楚Redis数据(包括新增)
            string ipAddress = GetLocalIp();
            string redisKeyStart = $"{ipAddress}{pcy}";
           
            string[] temp2 = CheckBoxList2.SelectedValueArray;
            string[] temp3 = CheckBoxList3.SelectedValueArray;
            string[] tempAll = temp2.Concat(temp3).ToArray();
            int id = int.Parse(GetQueryValue("id"));
            var qList = proPlanOrderManager.GetList(u => u.ProPlanOrderheaders_ID == id
            && tempAll.Contains(u.Chejianclass),null);
            var header = ProPlanOrderheaderService.FindById(id);
            decimal count = qList.Where(u => u.PlanOrder_State != "已删除").Sum(u => u.PcCount ?? 0);
            string redisKey_Count = $"{redisKeyStart}:CRMADDCount:{id}";
            decimal addcount=redisHelper.StringGet<decimal>(redisKey_Count);




            decimal allCount = count + addcount;

            if (allCount<= header.PcCount)
            {
                Save();
            }
            else
            {
                PageContext.RegisterStartupScript(Confirm.GetShowReference(
                    $"下推的小包装排产数大于申请单排产数，是否继续保存？",
                    String.Empty,
                    MessageBoxIcon.Question,
                    PageManager1.GetCustomEventReference(false, "Confirm_OK"), // 第一个参数 false 用来指定当前不是AJAX请求
                    PageManager1.GetCustomEventReference("Confirm_Cancel")));
            }
        }

        protected void PageManager1_CustomEvent(object sender, CustomEventArgs e)
        {
            if (e.EventArgument == "Confirm_OK")
            {
                // 非AJAX回发
                Save();
            }
        }

        private void Save()
        {
            string[] temp2 = CheckBoxList2.SelectedValueArray;
            string[] temp3 = CheckBoxList3.SelectedValueArray;
            string[] tempAll = temp2.Concat(temp3).ToArray();
            DateTime nowTime = DateTime.Now;

            //判断是否全部已锁定 并且Redis中有数据
            string pcy = GetIdentityName();
            //清楚Redis数据(包括新增)
            string ipAddress = GetLocalIp();
            string redisKeyStart = $"{ipAddress}{pcy}";


            List<ProPlanOrderlists> addlist = new List<ProPlanOrderlists>();
            List<ProPlanOrderlists> editlist = new List<ProPlanOrderlists>();
            //编辑页面，所以ProPlanOrderheaders已存在
            //直接取得
            int id = int.Parse(GetQueryValue("id"));
            ProPlanOrderheaders ProPlanOrderheaders = proPlanOrderManager.GetProOrder(id, DbMainSlave.Master);

            foreach (string temp in tempAll)
            {
                if (Session[$"EditFinish-{temp}"] == null
                    || Convert.ToBoolean(Session[$"EditFinish-{temp}"]) != true)
                {
                    Alert.Show($"{temp}车间的排产数据没有输入完成");
                    return;
                }
                //检查Reids是否存在
                if (ProPlanOrderheaders.Workshops.Contains(temp) &&
                    !IsRedisExistAndGetData(redisKeyStart, temp, addlist, editlist))
                {
                    Alert.Show($"{temp}车间的排产数据没有保存成功，请关闭窗口重试");
                    return;
                }
            }
            List<string> positionList = null;

            var oldPositionArr = ProPlanOrderheaders.Workshops.Split(',');
            foreach (string temp in oldPositionArr)
            {
                if (!tempAll.Contains(temp))
                {
                    if (positionList == null)
                        positionList = new List<string>();
                    positionList.Add(temp);
                }
            }
            ProPlanOrderheaders.Workshops = string.Join(",", tempAll);
            //新增List,直接关联已有ProPlanOrderheaders
            addlist.ForEach(item => {
                item.ERPOrderNo = ProPlanOrderheaders.PlanOrderNo;
                item.Clientname = ProPlanOrderheaders.Clientname;
                item.PlanOrder_XuHao = item.ERPOrderNo + $"-{item.PlanOrder_XuHao}";
                item.ProPlanOrderheaders_ID = ProPlanOrderheaders.ID;
            });

            //编辑List,
            editlist.ForEach(item => {
                item.ERPOrderNo = ProPlanOrderheaders.PlanOrderNo;
                item.Clientname = ProPlanOrderheaders.Clientname;
                //item.PlanOrder_XuHao = item.ERPOrderNo + $"-{item.PlanOrder_XuHao}";
                item.ProPlanOrderheaders_ID = ProPlanOrderheaders.ID;
            });

            //修改list状态为已删除
            if (positionList != null && positionList.Count > 0)
            {
                var arr = positionList.ToArray();
                string deleteState = "已删除";
                var list = ProPlanOrderheaders.ProPlanOrderlists.Where(u => arr.Contains(u.Chejianclass)).ToList();
                list.ForEach((item) => {
                    item.PlanOrder_State = deleteState;
                    editlist.Add(item);
                });
            }

            bool ret = proPlanOrderManager.EditProOrders(ProPlanOrderheaders, addlist, editlist);
            if (!ret)
            {
                Alert.Show("保存数据失败，请关闭页面重新新增");
                return;
            }
            Alert.Show("保存成功");

            foreach (string temp in tempAll)
            {
                Session[$"EditFinish-{temp}"] = null;
                IsRedisExistAndGetData(redisKeyStart, temp, null, null, true);
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }


        protected void btnChange_Click(object sender, EventArgs e)
        {
            //btnChange.Enabled = false;
            //Panel99.Enabled = true;
            //btnNew.Enabled = true;
            //btnSave.Enabled = true;
            //btnDelete.Enabled = true;
            //btnReset.Enabled = true;
            //DropDownBox1.Enabled = true;
            //DropDownBox2.Enabled = true;
        }

        #endregion

        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] temp2 = CheckBoxList2.SelectedValueArray;
            Tab1.Hidden = !temp2.Contains(Tab1.Title);
            Tab2.Hidden = !temp2.Contains(Tab2.Title);
            Tab3.Hidden = !temp2.Contains(Tab3.Title);
        }

        protected void CheckBoxList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] temp2 = CheckBoxList3.SelectedValueArray;
            Tab4.Hidden = !temp2.Contains(Tab4.Title);
            Tab5.Hidden = !temp2.Contains(Tab5.Title);
            Tab6.Hidden = !temp2.Contains(Tab6.Title);
        }

        /// <summary>
        /// 判断Redis中是否含有某车间的数据
        /// </summary>
        /// <param name="redisKey_List">redis前缀</param>
        /// <param name="poTemp">车间名称</param>
        /// <param name="list">返回数据</param>
        /// <param name="removeRedis">是否删除掉键值</param>
        /// <returns></returns>
        private bool IsRedisExistAndGetData(string redisKey_List,
            string poTemp, List<ProPlanOrderlists> addlist, List<ProPlanOrderlists> editlist,
            bool removeRedis = false)
        {
            
            string[] idStrs = GetQueryValue("id").Split(',');
            string redisKey_AddList = $"{redisKey_List}:ADDOrderList";
            string redisKey_EditList = $"{redisKey_List}:EditOrderList";
            string redisKey_BeforeList = $"BeforeEdit";

            if (idStrs.Length > 0)
            {
                foreach (string temp in idStrs)
                {
                    string keyList_Add = redisKey_AddList + ":" + temp;
                    string keyList_Edit = redisKey_EditList + ":" + temp;
                    string keyList_BeforeEdit = redisKey_BeforeList + ":" + temp;

                    //string keyHead = redisKey_Header + ":" + temp;
                    bool retAdd = redisHelper.HashExists(keyList_Add, poTemp);
                    bool retEdit = redisHelper.HashExists(keyList_Edit, poTemp);


                    if (!retAdd && !retEdit)
                    {
                        if (!removeRedis)
                            return false;
                        else
                            continue;
                    }
                    else if (removeRedis)
                    {
                        if(retAdd)
                            redisHelper.HashDelete(keyList_Add, poTemp);
                        else
                        {
                            redisHelper.HashDelete(keyList_Edit, poTemp);
                            redisHelper.KeyDelete(keyList_BeforeEdit+":"+ poTemp);
                        }
                    }
                    else
                    {
                        if (retAdd && addlist != null)
                            addlist.Add(redisHelper.HashGet<ProPlanOrderlists>(keyList_Add, poTemp));
                        else if (retEdit && editlist != null)
                            editlist.Add(redisHelper.HashGet<ProPlanOrderlists>(keyList_Edit, poTemp));
                    }
                }
                return true;
            }
            return false;
        }

        
    }
}