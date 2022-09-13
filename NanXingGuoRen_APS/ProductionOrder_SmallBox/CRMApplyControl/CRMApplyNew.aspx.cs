using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingGuoRen_APS.Business.Helper;
using NanXingService_WMS.Entity;
using NanXingService_WMS.Entity.CRMEntity.CRMAppleNoEntity;
using NanXingService_WMS.Utils;
using NanXingService_WMS.Utils.RabbitMQ;
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
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilsSharp;

namespace NanXingGuoRen_APS.ProductionOrder_SmallBox.CRMApplyControl
{
    public partial class CRMApplyNew : PageBase
    {
        //private bool AppendToEnd = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //datepicker1.SelectedDate = DateTime.Now;
              
                LoadData();
            }
        }

        string redisKeyStart = string.Empty;
        string redisKey_List = string.Empty;

        private void LoadData()
        {
            string pcy= GetIdentityName();
            //清楚Redis数据(包括新增)
            string ipAddress = GetLocalIp();
            string[] idStrs = GetQueryValue("ids").Split(',');
            redisKeyStart = $"{ipAddress}{pcy}";
            redisKey_List = $"{redisKeyStart}:ADDOrderList";
            string redisKey_Header = $"{redisKeyStart}:ADDOrderHeader";

            if(idStrs.Length==0)
            {
                idStrs[0] = "0";
            }
            string[] positionArr ={"03小包装-小袋","03小包装-罐","03小包装-每日坚果",
                "07小包装-小袋","07小包装-罐", "07小包装-每日坚果" };
            foreach (string temp in idStrs)
            {
                string keyList = redisKey_List + ":" + temp;
                string keyHead = redisKey_Header + ":" + temp;

                foreach (string poTemp in positionArr)
                {
                    if (redisHelper.HashExists(keyList, poTemp))
                    {
                        redisHelper.HashDelete(keyList, poTemp);
                    }
                    if (redisHelper.HashExists(keyHead, poTemp))
                    {
                        redisHelper.HashDelete(keyHead, poTemp);
                    }
                }
            }

            TabStrip1.ActiveTabIndex = 6;
            BindGrid1();
        }

        private void BindGrid1()
        {
            string[] idStrs = GetQueryValue("ids").Split(',');
            long[] ids = Array.ConvertAll<string, long>(idStrs, s => long.Parse(s));
            var q = crmPlanManager.GetMissionControlIndex(u =>ids.Contains( u.ID));
            List<CRMApplyIndexData> qlist = q.ToList();
            List<ProPlanOrderlists> proList = new List<ProPlanOrderlists>(qlist.Count);
            string Priority = "正常";

            //因为不能识别外包装箱号、箱名是否已有数据，先清空再Upate BoxNo、BoxName这两列
            qlist.ForEach((item)=>{
                

                //组成ProPlanOrderlists放进去、
                ProPlanOrderlists ProPlanOrderlists = new ProPlanOrderlists();
                ProPlanOrderlists.ItemName = item.ItemName;
                ProPlanOrderlists.InName = item.ItemName;
                ProPlanOrderlists.CRMPlanList_ID = item.ID;
                ProPlanOrderlists.PcCount = item.OrderCount;
                ProPlanOrderlists.Unit = item.Unit;
                ProPlanOrderlists.BoxNo = item.BoxNo;
                ProPlanOrderlists.BoxName = item.BoxName;
                ProPlanOrderlists.BoxRemark = item.BoxRemark;
                ProPlanOrderlists.Priority = Priority;
                proList.Add(ProPlanOrderlists);

                item.BoxNo = string.Empty;
                item.BoxName = string.Empty;

            });
            var qParse = qlist.AsQueryable();

           
            Grid0.RecordCount = qParse.Count();
            var qParse0 = SortAndPage(qParse, Grid0);

            Grid0.DataSource = qParse0;
            Grid0.DataBind();
            List<ProPlanOrderlists> list1 =MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(proList);
            List<ProPlanOrderlists> list2 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(proList);
            List<ProPlanOrderlists> list3 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(proList);
            List<ProPlanOrderlists> list4 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(proList);
            List<ProPlanOrderlists> list5 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(proList);
            List<ProPlanOrderlists> list6 = MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.MapList(proList);

            string pcy = GetIdentityName();
            ProOrderGrid_UC1.OrderList = list1.AsQueryable();
            ProOrderGrid_UC1.RedisKey = redisKeyStart;
            ProOrderGrid_UC1.UserName = pcy;


            ProOrderGrid_UC2.OrderList = list2.AsQueryable();
            ProOrderGrid_UC2.RedisKey = redisKeyStart;
            ProOrderGrid_UC2.UserName = pcy;

            ProOrderGrid_UC3.OrderList = list3.AsQueryable();
            ProOrderGrid_UC3.RedisKey = redisKeyStart;
            ProOrderGrid_UC3.UserName = pcy;

            ProOrderGrid_UC4.OrderList = list4.AsQueryable();
            ProOrderGrid_UC4.RedisKey = redisKeyStart;
            ProOrderGrid_UC4.UserName = pcy;

            ProOrderGrid_UC5.OrderList = list5.AsQueryable();
            ProOrderGrid_UC5.RedisKey = redisKeyStart;
            ProOrderGrid_UC5.UserName = pcy;

            ProOrderGrid_UC6.OrderList = list6.AsQueryable();
            ProOrderGrid_UC6.RedisKey = redisKeyStart;
            ProOrderGrid_UC6.UserName = pcy;

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
      

        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChangePositionCheckBox();
            string[] temp2 = CheckBoxList2.SelectedValueArray;
            Tab1.Hidden = !temp2.Contains(Tab1.Title);
            Tab2.Hidden = !temp2.Contains(Tab2.Title);
            Tab3.Hidden = !temp2.Contains(Tab3.Title);
        }

        protected void CheckBoxList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChangePositionCheckBox();
            string[] temp2 = CheckBoxList3.SelectedValueArray;
            Tab4.Hidden = !temp2.Contains(Tab4.Title);
            Tab5.Hidden = !temp2.Contains(Tab5.Title); 
            Tab6.Hidden = !temp2.Contains(Tab6.Title);
        }

        private void ChangePositionCheckBox()
        {
            //Dictionary<int, Dictionary<string, object>> modDic = Grid1.GetModifiedDict();
            //List<Dictionary<string, object>> modDicValue = modDic.Values.ToList();
            string[] temp1 = CheckBoxList2.SelectedValueArray;
            string[] temp2 = CheckBoxList3.SelectedValueArray;

            if (temp1.Length > 0)
            {
                if (temp1.Contains("03小包装-小袋"))
                    Button1.EnablePress = true;
                else
                    Button1.EnablePress = false;
                if (temp1.Contains("03小包装-罐"))
                    Button2.EnablePress = true;
                else
                    Button2.EnablePress = false;
                if (temp1.Contains("03小包装-每日坚果"))
                    Button3.EnablePress = true;
                else
                    Button3.EnablePress = false;
            }
            else
            {
                Button1.EnablePress = false;
                Button2.EnablePress = false;
                Button3.EnablePress = false;
            }

            if (temp2.Length > 0)
            {
                if (temp2.Contains("07小包装-小袋"))
                    Button4.EnablePress = true;
                else
                    Button4.EnablePress = false;
                if (temp2.Contains("07小包装-罐"))
                    Button5.EnablePress = true;
                else
                    Button5.EnablePress = false;
                if (temp2.Contains("07小包装-每日坚果"))
                    Button6.EnablePress = true;
                else
                    Button6.EnablePress = false;
            }
            else
            {
                Button4.EnablePress = false;
                Button5.EnablePress = false;
                Button6.EnablePress = false;
            }
        }

        private string GetSuoXie(string position, Dictionary<string, object> dic, ProPlanOrderlists item)
        {
            if (position == "03小包装-小袋")
            {
                item.PcCount_03_Bag = decimal.Parse(dic["PcCount_03_Bag"].ToString());
                item.PcCount = item.PcCount_03_Bag;
                return "03XD";
            }
            else if (position == "03小包装-罐")
            {
                item.PcCount_03_Tank = decimal.Parse(dic["PcCount_03_Tank"].ToString());
                item.PcCount = item.PcCount_03_Tank;

                return "03G";
            }
            else if (position == "03小包装-每日坚果")
            {
                item.PcCount_03_Box = decimal.Parse(dic["PcCount_03_Box"].ToString());
                item.PcCount = item.PcCount_03_Box;

                return "03MRJG";
            }
            else if (position == "07小包装-小袋")
            {
                item.PcCount_07_Bag = decimal.Parse(dic["PcCount_07_Bag"].ToString());
                item.PcCount = item.PcCount_07_Bag;
                return "07XD";
            }
            else if (position == "07小包装-罐")
            {
                item.PcCount_07_Tank = decimal.Parse(dic["PcCount_07_Tank"].ToString());
                item.PcCount = item.PcCount_07_Tank;
                return "07G";
            }
            else if (position == "07小包装-每日坚果")
            {
                item.PcCount_07_Box = decimal.Parse(dic["PcCount_07_Box"].ToString());
                item.PcCount = item.PcCount_07_Box;
                return "07MRJG";
            }
            return string.Empty;
        }
        DateTime nowTime = DateTime.Now;
        protected void Btn_SaveExit_Click(object sender, EventArgs e)
        {
            string[] temp2 = CheckBoxList2.SelectedValueArray;
            string[] temp3 = CheckBoxList3.SelectedValueArray;
            string[] tempAll = temp2.Concat(temp3).ToArray();
            if (tempAll.Length == 0)
            {
                Alert.Show("请选中车间进行排产数据填写，或直接右上角退出");
                return;
            }

            nowTime = DateTime.Now;
            List<ProPlanOrderlists> list=new List<ProPlanOrderlists>();
            //判断是否全部已锁定 并且Redis中有数据
            foreach (string temp in tempAll)
            {
                if (Session[$"EditFinish-{temp}"]==null
                    || Convert.ToBoolean(Session[$"EditFinish-{temp}"])!=true)
                {
                    Alert.Show($"{temp}车间的排产数据没有输入完成");
                    return;
                }
                //检查Reids是否存在
                if (!IsRedisExist(temp,list))
                {
                    Alert.Show($"{temp}车间的排产数据没有保存");
                    return;
                }
            }

            //从Grid0中取出CRMID
            string[] idStrs = GetQueryValue("ids").Split(',');
            long[] ids = Array.ConvertAll<string, long>(idStrs, s => long.Parse(s));
            var q = crmPlanManager.GetMissionControlIndex(u => ids.Contains(u.ID)).ToList();

            string pcy = GetIdentityName();
            //清楚Redis数据(包括新增)
            string ipAddress = GetLocalIp();
            redisKeyStart = $"{ipAddress}{pcy}";
            redisKey_List = $"{redisKeyStart}:ADDOrderList";
            List<ProPlanOrderheaders> headerList = new List<ProPlanOrderheaders>(q.Count);
            string orderNo = liuShuiHaoService.GetPlanOrderLSH();
            for (int i=0;i<q.Count;i++)
            { 
                ProPlanOrderheaders ProPlanOrderheaders = new ProPlanOrderheaders();
                MapperHelper<CRMApplyIndexData, ProPlanOrderheaders>.Map(q[i], ProPlanOrderheaders);
                ProPlanOrderheaders.OrderNo = orderNo;
                ProPlanOrderheaders.PlanOrderNo = ProPlanOrderheaders.OrderNo
                    + "-"+(i+1).ToString("D2");
                ProPlanOrderheaders.Workshops = string.Join(",", tempAll);
                ProPlanOrderheaders.Moddate = nowTime;
                ProPlanOrderheaders.Newdate = nowTime;
                ProPlanOrderheaders.PositionClass = "小包装排产单";
                ProPlanOrderheaders.Optdate = nowTime;
                ProPlanOrderheaders.PcCount=q[i].OrderCount;
                ProPlanOrderheaders.Clientname = q[i].ClientName;
                ProPlanOrderheaders.CRMPlanList_ID = q[i].ID;
                //CRM成品信息

                string key = redisKey_List + $":{q[i].ID}";
                List<ProPlanOrderlists> ProPlanOrderlists 
                    = redisHelper.HashValues<ProPlanOrderlists>(key);

                ProPlanOrderlists.ForEach(item => {
                    item.ERPOrderNo = ProPlanOrderheaders.PlanOrderNo;
                    item.Clientname = q[i].ClientName;
                    item.ProductRecipe = q[i].ProductRecipe;
                    item.PlanOrder_XuHao = item.ERPOrderNo + $"-{item.PlanOrder_XuHao}";
                    
                });
                ProPlanOrderheaders.ProPlanOrderlists = ProPlanOrderlists;
                headerList.Add(ProPlanOrderheaders);
               
            }
            bool ret= proPlanOrderManager.AddProOrders(headerList, true);
            //将数据取出来，然后生成ProPlanOrderheaders与ProductOrderList

            if (!ret)
            {
                Alert.Show("保存数据失败，请关闭页面重新新增");
                return;
            } 
            Alert.Show("保存成功");
            //long[] arr= crmList.ToArray();
            //RabbitMQUtils.Send("",)
            crmPlanListService.UpdateByPlus(u => ids.Contains(u.ID),
                u => new CRMPlanList
                {
                    crmListStatus = "已下推"

                }) ;
            foreach (string temp in tempAll)
            {
                Session[$"EditFinish-{temp}"] = null;
                IsRedisExist(temp, null, true);
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poTemp"></param>
        /// <returns></returns>
        private bool IsRedisExist(string poTemp, List<ProPlanOrderlists> list, bool removeRedis = false)
        {
            if (string.IsNullOrEmpty(redisKey_List))
            {
                string pcy = GetIdentityName();
                //清楚Redis数据(包括新增)
                string ipAddress = GetLocalIp();
                redisKeyStart = $"{ipAddress}{pcy}";
            }
            string redisKey = $"{redisKeyStart}:ADDOrderList";
            //string redisKey_Header = $"{redisKey}:{keyName}";
            string[] idStrs = GetQueryValue("ids").Split(',');
            if (idStrs.Length > 0)
            {
                foreach (string temp in idStrs)
                {
                    string keyList = redisKey + ":" + temp;
                    //string keyHead = redisKey_Header + ":" + temp;

                    if (!redisHelper.HashExists(keyList, poTemp))
                    {
                        if (!removeRedis)
                            return false;
                        else
                            continue;
                    }
                    else if(removeRedis)
                        redisHelper.HashDelete(keyList, poTemp);
                    if (list!=null&&!removeRedis)
                        list.Add(redisHelper.HashGet<ProPlanOrderlists>(keyList, poTemp));
                    
                }
                return true;
            }
            return false;
        }
    }
}