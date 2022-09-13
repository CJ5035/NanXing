using FineUIPro;
using NanXingData_WMS.Dao;
using NanXingService_WMS.Entity.ProductEntity;
using NanXingService_WMS.Services;
using NanXingService_WMS.Services.APS;
using NanXingService_WMS.Utils.RedisUtils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UtilsSharp;

namespace NanXingGuoRen_WMS.ProductionOrder_SmallBox.PlanOrderControl.UserControls
{
    public partial class ProOrderGrid_UC : UserControlBase
    {
        #region 变量

        private IQueryable<ProPlanOrderlists> _OrderList;
        public IQueryable<ProPlanOrderlists> OrderList
        {
            get { return _OrderList; }
            set { _OrderList = value; }
        }

        private int _ProductHeader_ID;
        public int ProductHeader_ID
        {
            get { return _ProductHeader_ID; }
            set { _ProductHeader_ID = value; }
        }

        private string _Position;
        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }


        private string _RedisKey;
        public string RedisKey
        {
            get { return _RedisKey; }
            set { _RedisKey = value; }
        }

        private string _SetValue;
        public string SetValue
        {
            get { return _SetValue; }
            set { _SetValue = value; }
        }

        #endregion

        private bool AppendToEnd = true;

        /*
        
        新增功能：
        1、传入成品信息进行显示
        2、保存时存进Redis    

        修改功能
        1、传入原有排产单进行显示
        2、筛选没有本车间的排产单，则执行新增功能的显示方法
        3、保存时
            判断是新增OR修改，存进Redis

        功能：

        0、外部页面进行排产单获取
            0-1、CRM下推新增。有CRM号，无Header_ID
            0-2、手动新增。无CRM号，无Header_ID

            0-3、CRM下推修改。有CRM号，有Header_ID
            0-4、手动修改。无CRM号，有Header_ID
            本控件只管数据的保存，不管Header_ID的关联
            
            无排产单号则放进 新增的队列中，
            有排产单号则放进 修改的队列中
        1、显示排产单信息
        2、判断是否含有排产单号，没有则排进新增队列

        判断方法：
        1、Grid的ID是否存在
        2、Grid的排产单号是否存在
        
        */


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 删除选中单元格的客户端脚本
                string deleteScript = GetDeleteScript();

                // 新增数据初始值
                JObject defaultObj = new JObject();

                // 在第一行新增一条数据
                //btnNew.OnClientClick = Grid1.GetAddNewRecordReference(defaultObj, AppendToEnd);

                // 重置表格
                btnReset.OnClientClick = Confirm.GetShowReference("确定要重置表格数据？", String.Empty, Grid1.GetRejectChangesReference(), String.Empty);


                // 删除选中行按钮
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference("请至少选择一项！") + deleteScript;

                LoadData();
            }

        }
        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, Grid1.GetDeleteSelectedRowsReference(), String.Empty);
        }

        private void LoadData()
        {
            
            BindGrid1();
            UnEdit();
            btnEnableEdit.Enabled = true;
            hbDate.SelectedDate = DateTime.Now;
            Lab_PCY.Text = UserName;
            Lab_RedisKey.Text = RedisKey;
        }

        //情况一：完全新增，传CRM进来
        //情况二：修改新增，传Lists进来，包含多条多个车间


        //情况一，直接使用相同，不必筛选，存储时全部放进新增集合中
        //情况二，先筛选，有数据的直接显示，没有数据的车间，显示Header数据
        //        存储时没有订单号的放进新增集合中
        //        有订单号的放进修改集合中


        private void BindGrid1()
        {
            //int id = _ProductHeader_ID;
            if (_OrderList == null)
            {
               Lab_IsHandAdd.Text = "true";
            }
            else if (_OrderList != null)
            {
                //判断是下推新增还是修改
                //如果是新增的话，是没有该排产车间数据
                //如果不包含车间车间数据
                var type_Q = _OrderList.Any(u => u.Chejianclass == Position);
                IQueryable<ProPlanOrderlists> q_Where = null;
                if (type_Q)
                    q_Where = _OrderList.Where(u => u.Chejianclass == Position);
                else
                {
                    //判断Header_ID是否==0，==0则是没有Header，直接显示所有，新增
                    //判断Header_ID是否 >0，==1则是存在Header，直接显示header，新增
                    if (ProductHeader_ID == 0)
                        q_Where= _OrderList.AsQueryable();
                    else if (ProductHeader_ID > 0)
                    {
                        ProPlanOrderlists ProPlanOrderlists = new ProPlanOrderlists();
                        if (Position.Contains("小包装"))
                        {
                            //小包装复制原有
                            ProPlanOrderlists ProPlanOrderlists_Old = _OrderList.ElementAt(0);
                            MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.Map
                                (ProPlanOrderlists_Old, ProPlanOrderlists);
                        }
                        else
                        {
                            //大包装留空
                            ProPlanOrderheaders header = ProPlanOrderheaderService.FindById(ProductHeader_ID);
                            MapperHelper<ProPlanOrderheaders, ProPlanOrderlists>.Map
                                (header, ProPlanOrderlists);
                            ProPlanOrderlists.ProPlanOrderheaders_ID = header.ID;
                            
                        }
                        ProPlanOrderlists.ID = 0;
                        List<ProPlanOrderlists> list = new List<ProPlanOrderlists>(1) { ProPlanOrderlists };
                        q_Where = list.AsQueryable();

                    }

                }
                var q = q_Where.AsQueryable();
                List<ProPlanOrderlists> qlist = q.ToList();
                DataTable dt = ProPlanOrderlistsService.ConvertToDataTable(qlist);

                qlist.ForEach((item) =>
                {
                    Session[$"EditFinish-{Position}"] = false;
                    if (type_Q)
                    {
                        tbx_OrderNo.Text = item.PlanOrder_XuHao;
                        Session[$"EditFinish-{Position}"] = true;
                    }

                    //item.CRMPlanList_ID = null;
                    item.ProPlanOrderheaders_ID =  null;
                    //item.ItemName = String.Empty;
                    if (Position.Contains("小包装"))
                    {
                        item.InName = String.Empty;

                    }
                    if (string.IsNullOrEmpty(item.PlanOrder_XuHao))
                    {
                        item.PcCount = null;
                        item.Spec = null;
                        item.Unit = null;
                        item.BoxNo = null;
                        item.BoxName = null;
                        item.BoxRemark = null;
                        item.Priority = null;
                    }

                });
                var qParse = qlist.AsQueryable();
                Grid1.RecordCount = qParse.Count();
                qParse = SortAndPage(qParse, Grid1);
                Grid1.DataSource = qParse;
                Grid1.DataBind();

                for (int index = 0; index < Grid1.RecordCount; index++)
                {
                    if (dt.Rows[index]["CRMPlanList_ID"] != null)
                        Grid1.UpdateCellValue(index, "CRMPlanList_ID",
                            dt.Rows[index]["CRMPlanList_ID"].ToString());
                    if (dt.Rows[index]["ProPlanOrderheaders_ID"] != null)
                        Grid1.UpdateCellValue(index, "ProPlanOrderheaders_ID",
                          ProductHeader_ID.ToString()??dt.Rows[index]["ProPlanOrderheaders_ID"].ToString());

                    //Grid1.UpdateCellValue(index, "ItemName",
                    //      dt.Rows[index]["ItemName"].ToString());
                    if (Position.Contains("小包装"))
                    {
                        Grid1.UpdateCellValue(index, "ItemName1",
                               dt.Rows[index]["ItemName"].ToString());
                        ItemName1.Hidden = true;
                    }
                    if (string.IsNullOrEmpty(dt.Rows[index]["PlanOrder_XuHao"].ToString()))
                    {
                        Grid1.UpdateCellValue(index, "PcCount", dt.Rows[index]["PcCount"].ToString());
                        Grid1.UpdateCellValue(index, "Spec", dt.Rows[index]["Spec"] == null ? string.Empty
                            : dt.Rows[index]["Spec"].ToString());

                        Grid1.UpdateCellValue(index, "BoxNo", dt.Rows[index]["BoxNo"] == null ? string.Empty
                            : dt.Rows[index]["BoxNo"].ToString());
                        Grid1.UpdateCellValue(index, "BoxName", dt.Rows[index]["BoxName"] == null ? string.Empty
                             : dt.Rows[index]["BoxName"].ToString());
                        Grid1.UpdateCellValue(index, "BoxRemark", dt.Rows[index]["BoxRemark"] == null ? string.Empty
                             : dt.Rows[index]["BoxRemark"].ToString());
                        
                        Grid1.UpdateCellValue(index, "Priority", dt.Rows[index]["Priority"].ToString());
                    }
                    Grid1.UpdateCellValue(index, "PcUnit",
                       dt.Rows[index]["Unit"] == null ? string.Empty
                       : dt.Rows[index]["Unit"].ToString());
                    //Grid1.UpdateCellValue(index, "BoxNo", qlist[index].BoxNo ?? string.Empty);
                    //Grid1.UpdateCellValue(index, "BoxName", qlist[index].BoxName ?? string.Empty);
                    //Grid1.UpdateCellValue(index, "Priority", Priority);

                    //Grid1.UpdateCellValue(index, "PcCount_03", qlist[index].OrderCount.ToString());
                    //Grid1.UpdateCellValue(index, "PcCount_07", qlist[index].OrderCount.ToString());

                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Dictionary<int, Dictionary<string, object>> modDic = Grid1.GetModifiedDict();
            List<object[]> keys = Grid1.DataKeys;
            List<int> modDicIndex = modDic.Keys.ToList();
            List<Dictionary<string, object>> modDicValue = modDic.Values.ToList();

            //判断是否存在排产单号，如果不存在则新增，如果存在则修改
            string type = string.Empty;
            if (string.IsNullOrEmpty(tbx_OrderNo.Text.Trim()))
                type = "ADDOrderList";
            else
                type = "EditOrderList";

            string redisKey_List = $"{Lab_RedisKey.Text}:{type}";

            Dictionary<string,ProPlanOrderlists> keyValuePairs = new Dictionary<string, ProPlanOrderlists>(modDic.Count);
            if (modDic.Count > 0)
            {
                for (int i = 0; i < modDic.Count; i++)
                {
                    int index = modDicIndex[i];
                    int listId = Convert.ToInt32(keys[index][0]);

                    Dictionary<string, object> dic = modDicValue[i];

                    string[] tempColumn = { "PcCount", "PcUnit", "BoxNo", "BoxName", "PlanDate" };
                    string[] tempStr = { "排产数量", "排产单位", "箱号", "箱名", "排产日期" };
                    for (int tempIndex=0; tempIndex < tempColumn.Length; tempIndex++)
                    {
                        if (!dic.ContainsKey(tempColumn[tempIndex]))
                        {
                            int keyIndex= Array.IndexOf(Grid1.DataKeyNames, tempColumn[tempIndex]); 
                            if (Grid1.DataKeys[i][keyIndex]==null)                            {
                                Alert.Show($"{tempStr[tempIndex]}不能为空！");
                                return;
                            }
                        }
                    }
                    

                    List<string> columnList = dic.Keys.ToList();

                    ProPlanOrderlists item = null; ;
                    if (listId == 0)
                    {
                        item = new ProPlanOrderlists();
                        
                        int keyIndex = Array.IndexOf(Grid1.DataKeyNames, "CRMPlanList_ID");
                        item.ItemName = Grid1.DataKeys[i][keyIndex].ToString();
                        if (Position.Contains("小包装"))
                            item.InName = item.ItemName;
                    }
                    else
                    {
                        item = new ProPlanOrderlists();
                        ProPlanOrderlists item2 = ProPlanOrderlistsService.FindById(listId, NanXingData_WMS.DaoUtils.DbMainSlave.Master);
                        MapperHelper<ProPlanOrderlists, ProPlanOrderlists>.Map(item2,item);
                        item.crmPlanList = null;
                        item.ProPlanOrderheaders = null;
                        item.ProPlanOrderheaders_ID = item2.ProPlanOrderheaders_ID;
                    }
                        
                    //pos.GetProList();

                    item.Chejianclass = Position;
                   

                    item.ProPlanOrderheaders_ID = GetItemByName<int?>(dic, Grid1.DataKeys[i],"ProPlanOrderheaders_ID");

                    item.CRMPlanList_ID = GetItemByName<long?>(dic, Grid1.DataKeys[i], "CRMPlanList_ID");
                    item.Itemno = GetItemByName<string>(dic, Grid1.DataKeys[i], "Itemno");
                    item.ItemName = GetItemByName<string>(dic, Grid1.DataKeys[i], "ItemName");
                    item.InName = GetItemByName<string>(dic, Grid1.DataKeys[i], "ItemName1");
                    item.MaterialItem = GetItemByName<string>(dic, Grid1.DataKeys[i], "ItemName2");
                    item.Color = GetItemByName<string>(dic, Grid1.DataKeys[i], "Color");
                    item.PlanDate = GetItemByName<DateTime?>(dic, Grid1.DataKeys[i], "PlanDate");
                    item.PcCount = GetItemByName<decimal?>(dic, Grid1.DataKeys[i], "PcCount");
                    item.Spec = GetItemByName<string>(dic, Grid1.DataKeys[i],"Spec");
                    item.Unit = GetItemByName<string>(dic, Grid1.DataKeys[i], "PcUnit");
                    item.BatchNo = GetItemByName<string>(dic, Grid1.DataKeys[i],"BahitchNo");
                    item.GiveDept = GetItemByName<string>(dic, Grid1.DataKeys[i],"GiveDept");
                    item.Ingredients = GetItemByName<string>(dic, Grid1.DataKeys[i],"Ingredients");
                    item.BoxNo = GetItemByName<string>(dic, Grid1.DataKeys[i],"BoxNo");
                    item.BoxName = GetItemByName<string>(dic, Grid1.DataKeys[i],"BoxName");
                    item.BoxRemark = GetItemByName<string>(dic, Grid1.DataKeys[i],"BoxRemark");
                    item.Remark = GetItemByName<string>(dic, Grid1.DataKeys[i], "Remark");
                    item.PlanTime = GetItemByName<string>(dic, Grid1.DataKeys[i],"PlanTime");
                    item.Priority = GetItemByName<string>(dic, Grid1.DataKeys[i],"Priority");

                    

                    item.Jingbanren = Lab_PCY.Text;

                    item.Moddate = DateTime.Now;
                    item.Newdate = DateTime.Now;
                    if(item.PrintState==string.Empty)
                        item.PrintState = "未打印";
                    item.PlanOrder_State = PlanOrderState.HasPlan;
                    if(string.IsNullOrEmpty(item.PlanOrder_XuHao))
                        item.PlanOrder_XuHao =GetPositionOrderName(Position);

                    //dt = ProPlanOrderlistsService.ParseInDataTable(dt, item);
                    
                    string listIndex = (item.ProPlanOrderheaders_ID != null&&
                        item.ProPlanOrderheaders_ID>0) ? item.ProPlanOrderheaders_ID.ToString():
                        (item.CRMPlanList_ID == null ? $"-{i + 1}" : item.CRMPlanList_ID.ToString());

                    keyValuePairs.Add(redisKey_List + $"_{listIndex}_{Position}", item);
                }
            }
            foreach(KeyValuePair<string ,ProPlanOrderlists> temp in keyValuePairs)
            {
                string str= temp.Key;
                string[] arr = str.Split('_');
                
                using (redisHelper.CreateLock($"CRMADDCount:{arr[1]}"))
                {
                    //判断增加或修改
                    if (arr[0].Contains("ADD"))
                    {
                        decimal count = redisHelper.StringGet<decimal>
                            ($"{Lab_RedisKey.Text}:CRMADDCount:{arr[1]}");

                        redisHelper.StringSet($"{Lab_RedisKey.Text}:CRMADDCount:{arr[1]}",
                           count + temp.Value.PcCount ?? 0, TimeSpan.FromMinutes(60));
                    }
                    //判断增加或修改
                    else if (arr[0].Contains("Edit"))
                    {
                        ProPlanOrderlists list = ProPlanOrderlistsService.FindById(temp.Value.ID);

                        //当Redis中没有该ID时，判断是否已删除，
                        //当Redis中存在该ID时，修改前数量生效
                        decimal beforeCount = 0;
                        if(redisHelper.HashExists($"{arr[0]}:{arr[1]}", arr[2]))
                            beforeCount = redisHelper.StringGet<decimal>
                            ($"BeforeEdit:{arr[1]}:{Position}");
                        else
                            beforeCount = list.PlanOrder_State == "已删除" ? 0 : redisHelper.StringGet<decimal>
                            ($"BeforeEdit:{arr[1]}:{Position}");

                        decimal count = redisHelper.StringGet<decimal>
                            ($"{Lab_RedisKey.Text}:CRMADDCount:{arr[1]}");
                        decimal addCount = count + (temp.Value.PcCount ?? 0) - beforeCount;
                        
                        redisHelper.StringSet($"{Lab_RedisKey.Text}:CRMADDCount:{arr[1]}",
                         addCount, TimeSpan.FromMinutes(60));
                    }
                }

                redisHelper.HashSet($"{arr[0]}:{arr[1]}", arr[2],
                     temp.Value, TimeSpan.FromHours(1));
            }

            //if (headModColumns.Count > 0)
            //    ProPlanOrderheaderService.UpdateByPlus(u=>u.ID==ProPlanOrderheaders.ID, 
            //        u=>new ProPlanOrderheaders { Workshops= ProPlanOrderheaders .Workshops,
            //        Moddate=ProPlanOrderheaders.Moddate});
            //if (dt.Rows.Count > 0)
            //    ProPlanOrderlistsService.BatchUpdateData(dt, "ProPlanOrderlists");

            //删除数据
            //List<int> rowids = Grid1.GetDeletedList();

            //foreach (int rowsId in rowids)
            //{
            //    int id = int.Parse(keys[rowsId][0].ToString());
            //    productOrderManager.DeleteProOrderList(id);
            //}
            //var qList = productOrderManager.GetList(u => u.ProPlanOrderheaders_ID == ProductHeader_ID,
            //    u => u.PlanOrder_XuHao, DbMainSlave.Master);
            //if (qList.Count == 0)
            //{
            //    productOrderManager.DeleteProOrderAll(new List<int>(1) { ProductHeader_ID });
            //}
            UnEdit();
            Session[$"EditFinish-{Position}"] = true;
            Alert.Show($"{Position}车间排产单保存成功");

        }

        

       
        // 声明事件委托
        public delegate void PageChangeEventHandler(string psDeliver);
        // 定义事件
        public event PageChangeEventHandler MyPageChange;
        // 监视事件
        protected void OnPageChange(string psStr)
        {
            if (MyPageChange != null)
            {
                MyPageChange(psStr);
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            UnEdit();


            Dictionary<int, Dictionary<string, object>> modDic = Grid1.GetModifiedDict();
            List<object[]> keys = Grid1.DataKeys;
            List<int> modDicIndex = modDic.Keys.ToList();
            List<Dictionary<string, object>> modDicValue = modDic.Values.ToList();

            for (int i = 0; i < modDic.Count; i++)
            {
                int index = modDicIndex[i];
                int listId = Convert.ToInt32(keys[index][0]);
                Dictionary<string, object> dic = modDicValue[i];
                //记录修改前的数量

                decimal? PcCount = GetItemByName<decimal?>(dic, Grid1.DataKeys[i], "PcCount");

                int? ProPlanOrderheaders_ID= GetItemByName<int?>(dic, Grid1.DataKeys[i], "ProPlanOrderheaders_ID");
                long? CRMPlanList_ID = GetItemByName<long?>(dic, Grid1.DataKeys[i], "CRMPlanList_ID");

                string listIndex = (ProPlanOrderheaders_ID != null &&
                            ProPlanOrderheaders_ID > 0) ? ProPlanOrderheaders_ID.ToString() :
                            (CRMPlanList_ID == null ? $"-{i + 1}" : CRMPlanList_ID.ToString());

                string redisKey = $"BeforeEdit:{listIndex}:{Position}";

                redisHelper.StringSet<decimal>(redisKey, PcCount ?? 0,TimeSpan.FromHours(1));
            }

            //

            //btnChange.Enabled = false;
            //Panel99.Enabled = true;
            //btnNew.Enabled = true;

            //DropDownBox1.Enabled = true;
            //DropDownBox2.Enabled = true;
        }

        string arrStr = @"Itemno Itemno2 ItemName Spec Unit PcUnit PcCount BatchNo 
                BoxNo BoxName BoxRemark CRMPlanList_ID PlanDate Remark PlanTime Priority ";
        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            //int? ProPlanOrderheaders_ID = GetItemByName<int?>(dic, Grid1.DataKeys[i], "ProPlanOrderheaders_ID");
           
            UnEdit();
        }

        private void UnEdit()
        {
            if (Lab_IsHandAdd.Text == "true")
            {
                if (!arrStr.Contains("Spec"))
                    arrStr += " Spec";
            };

            string[] arr = arrStr.Split(' ');
            foreach (string temp in arr)
            {
                RenderField rfTemp = Grid1.FindColumn(temp) as RenderField;
                if (rfTemp != null)
                    rfTemp.EnableColumnEdit = !rfTemp.EnableColumnEdit;
            }
            btnSave.Enabled = !btnSave.Enabled;
            btnDelete.Enabled = !btnDelete.Enabled;
            btnReset.Enabled = !btnReset.Enabled;
            btnEnableEdit.Enabled = !btnEnableEdit.Enabled;
            if (btnEnableEdit.Enabled)
            {
                Session[$"EditFinish-{Position}"] = false;
            }
        }

        private string GetPositionOrderName(string name)
        {
            string positionName = string.Empty;
            if (name == "03小包装-小袋")
                positionName = "03XD";
            else if (name == "03小包装-罐")
                positionName = "03G";
            else if (name == "03小包装-每日坚果")
                positionName = "03MRJG";
            else if(name == "07小包装-小袋")
                positionName = "07XD";
            else if (name == "07小包装-罐")
                positionName = "07G";
            else if (name == "07小包装-每日坚果")
                positionName = "07MRJG";
            return positionName;
        }

        /// <summary>
        /// 从Grid修改Dic或DataKeys中取值
        /// </summary>
        /// <param name="dic">Grid的一行ModDic</param>
        /// <param name="dataKeys">Grid的一行DataKeys</param>
        /// <param name="keyName">ColumnID</param>
        /// <returns>object 类，有可能为空</returns>
        private T GetItemByName<T>(Dictionary<string, object> dic, object[] dataKeys, string keyName)
        {
            T obj = default(T);
            if (dic.ContainsKey(keyName))
            {
                if (typeof(T).ToString().Contains(typeof(DateTime).ToString()))
                    obj = (T)(object)DateTime.Parse(dic[keyName].ToString());
                else if (typeof(T).ToString().Contains(typeof(decimal).ToString()))
                    obj = (T)(object)decimal.Parse(dic[keyName].ToString());
                else if (typeof(T).ToString().Contains(typeof(int).ToString()))
                    obj = (T)(object)int.Parse(dic[keyName].ToString());
                else
                    obj = (T)dic[keyName];
            }
                
            else
            {
                int keyIndex = Array.IndexOf(Grid1.DataKeyNames, keyName);
                if (keyIndex > -1)
                {
                    if (typeof(T).ToString().Contains(typeof(DateTime).ToString()))
                        obj = (T)(object)DateTime.Parse(dataKeys[keyIndex].ToString());
                    else if (typeof(T).ToString().Contains(typeof(decimal).ToString()))
                        obj = (T)(object)decimal.Parse(dataKeys[keyIndex].ToString());
                    else if (typeof(T).ToString().Contains(typeof(int).ToString()))
                        obj = (T)(object)int.Parse(dataKeys[keyIndex].ToString());
                    else
                        obj = (T)dataKeys[keyIndex];
                }
            }
            return obj;
        }

        #region 
        protected RedisHelper redisHelper
        {
            get
            {
                string keyName = "_RedisHelper";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    RedisHelper temp = new RedisHelper();

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as RedisHelper;
                //return new ProPlanOrderheaderService();
            }
        }


        private ProPlanOrderheaderService ProPlanOrderheaderService
        {
            get
            {
                string keyName = "_ProPlanOrderheaderService";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    ProPlanOrderheaderService temp = new ProPlanOrderheaderService();

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as ProPlanOrderheaderService;
                //return new ProPlanOrderheaderService();
            }
        }
        private ProPlanOrderlistsService ProPlanOrderlistsService
        {
            get
            {
                string keyName = "_ProPlanOrderlistsService";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    ProPlanOrderlistsService temp = new ProPlanOrderlistsService();

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as ProPlanOrderlistsService;
            }
        }

        private ProductOrderlistsService ProductOrderlistsService
        {
            get
            {
                string keyName = "_ProductOrderlistsService";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    ProductOrderlistsService temp = new ProductOrderlistsService();

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as ProductOrderlistsService;
            }
        }
        private CRMPlanListService crmPlanListService
        {
            get
            {
                string keyName = "_CRMPlanListService";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    CRMPlanListService temp = new CRMPlanListService();

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as CRMPlanListService;
            }
        }
        private ProPlanOrderManager productOrderManager
        {
            get
            {
                string keyName = "_ProductOrderManager";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    ProPlanOrderManager temp = new ProPlanOrderManager(
                        ProPlanOrderheaderService, ProPlanOrderlistsService, crmPlanListService);

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as ProPlanOrderManager;
                //return new ProductOrderManager(ProPlanOrderheaderService, ProPlanOrderlistsService, cpls);
            }
        }

        #endregion

    }
}