using Microsoft.VisualBasic;
using NanXingData_WMS.Dao;
using NanXingData_WMS.DaoUtils;
using NanXingService_WMS.Entity;
using NanXingService_WMS.Entity.CRMEntity;
using NanXingService_WMS.Entity.CRMEntity.CRMAppleNoEntity;
using NanXingService_WMS.Entity.CRMEntity.CRMQueueEntitys.QueueInputEntitys;
using NanXingService_WMS.Entity.ProductEntity;
using NanXingService_WMS.Services.APS;
using NanXingService_WMS.Threads.CRMThreads;
using NanXingService_WMS.Utils;
using NanXingService_WMS.Utils.RabbitMQ;
using NanXingService_WMS.Utils.RedisUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UtilsSharp;
using UtilsSharp.Standard;

namespace NanXingService_WMS.Services
{

    public class ProductOrderManager
    {
        ProductOrderheadersService productOrderheaderService = null;
        ProductOrderlistsService productOrderlistService = null;
        ProductUploadHistoryService _productUploadHistoryService = null;
        ProPlanOrderlistsService planListService = null;

        RedisHelper redisHelper = new RedisHelper();

        public ProductOrderManager(ProductOrderheadersService ProductOrderheaderService,
            ProductOrderlistsService productOrderService, ProPlanOrderlistsService planListService,
            ProductUploadHistoryService productUploadHistoryService
            )
        {
            this.productOrderheaderService = ProductOrderheaderService;
            this.productOrderlistService = productOrderService;
            this.planListService = planListService;
            _productUploadHistoryService = productUploadHistoryService;
        }

        #region Query


        public IQueryable<ProductIndexData> GetProductIndex(Expression<Func<ProductOrderheaders, bool>> whereLambda)
        {
            List<ProductIndexData> list = productOrderheaderService.SelectToList(whereLambda,
                u => new ProductIndexData
                {
                    ID = u.ID,
                    ProductOrderNo = u.ProductOrderNo,
                    ItemName = u.ItemNameStr,
                    PcCount = 0,
                    NoWorkCount = 0,
                    WorkCount = 0,
                    Present_Work = 0,
                    Remark = u.Remark,
                    Workshops = u.Workshops,
                    Newdate = u.Newdate ?? DateTime.Now,
                    PrintState = u.PrintState ?? "未打印",
                    ProductState = u.ProductOrder_State,
                    ProductOrderlists = u.ProductOrderlists
                });
            list.ForEach((item) =>
            {
                item.ProductOrderlists.ForEach((orderItem) =>
                {
                    if (string.IsNullOrEmpty(item.JingBanRen))
                        item.JingBanRen = orderItem.Jingbanren;
                    if (item.PlanDate == null)
                    {
                        item.PlanDate = orderItem.PlanDate;
                        item.PlanTime = orderItem.PlanTime;
                    }
                    item.PcCount += orderItem.PcCount ?? 0;
                    item.WorkCount += orderItem.ProCount ?? 0;
                });
                item.NoWorkCount = item.PcCount - item.WorkCount;
                item.Present_Work = item.PcCount == 0 ? 0 :
                    Math.Round(item.WorkCount * 100 / item.PcCount, 2);
                //item.InitItemNameStr();
                //decimal noworkcount = item.PcCount - item.ProPlanOrderlists.Production.Count;

                //item.NoWorkCount += noworkcount < 0 ? 0 : noworkcount;
                //if (item.NoWorkCount <= 0)
                //    item.ProductState = "已完成";
                //else if (item.PcCount == item.NoWorkCount)
                //    item.ProductState = "未生产";
                //else
                //    item.ProductState = "生产中";
            });

            var q = list.AsQueryable();
            return q;
        }

        public List<PrintData_SmallBox> GetPrintItem(
            Expression<Func<ProductOrderlists, bool>> exp,
            Expression<Func<ProductOrderlists, string>> ordering,
            string path)
        {
            var q = productOrderlistService.SelectToList(exp,
               u => new PrintData_SmallBox
               {
                   ID = u.ID,
                   PlanOrderNo = u.ProductOrderheaders.ProductOrderNo,
                   PlanOrder_XuHao = u.ProductOrder_XuHao,
                   ItemNo = u.Itemno,
                   ItemName = u.ItemName,
                   Spec = u.Spec,
                   Unit = u.Unit,
                   BoxNo = u.BoxNo,
                   BoxName = u.BoxName,
                   ClientName = u.Clientname,
                   PcCount = (u.PcCount ?? 0),
                   NoWorkCount = (u.PcCount ?? 0) - (u.ProCount ?? 0),
                   NoWorkCount_OrderHeader = 0,
                   Priority = u.Priority,
                   Workshops = u.Chejianclass,
                   Remark = u.Remark??String.Empty,
                   PlanDate = u.PlanDate ?? DateTime.Now,
                   DeliveryDate = u.ProPlanOrderlists == null ? DateTime.Now :
                        u.ProPlanOrderlists.crmPlanList.DeliveryDate ?? DateTime.Now,
                   ImageUrl = "~/images/" + u.ProductOrder_XuHao + ".jpg",
                   ImageUrl_All = "~/images/" + u.ProductOrder_XuHao + ".jpg",
                   ProductState = u.ProOrderList_State
               });
            var qSum = q.GroupBy(u => u.PlanOrderNo).Select((u, g) => new
            {
                PlanOrderNo = u.Key,
                NoWorkCount_OrderHeader = u.Sum(item => (int)item.NoWorkCount)
            }).ToList();

            q.ForEach((item) =>
            {
                if (!File.Exists(path + item.PlanOrderNo + ".jpg"))
                {
                    QRCodeHandler.CreateQRCode(item.PlanOrderNo, "Byte", 5, 0, "H", path + item.PlanOrderNo + ".jpg", false, string.Empty);
                }

                if (!File.Exists(path + item.PlanOrder_XuHao + ".jpg"))
                {
                    QRCodeHandler.CreateQRCode(item.PlanOrder_XuHao, "Byte", 5, 0, "H", path + item.PlanOrder_XuHao + ".jpg", false, string.Empty);
                }

                //decimal allCount= item.
                //decimal noworkcount = item.PcCount - item.ProPlanOrderlists.Production.Count;

                item.NoWorkCount_OrderHeader = qSum.Where(
                    u => u.PlanOrderNo == item.PlanOrderNo).FirstOrDefault()
                    .NoWorkCount_OrderHeader;

            });
            //string Path2 = "http://192.168.1.118:8019/images/" + lbProsn.Text + ".jpg";

            //List<PrintData_SmallBox> list= (List<PrintData_SmallBox>)AutoMapperHelper.MapTo<ProPlanOrderlists, PrintData_SmallBox>(q);
            return q;
        }



        /// <summary>
        /// 获取产品生产数据
        /// </summary>
        /// <param name="proOrderNo">排产单号</param>
        /// <returns></returns>
        public RunResult<object> GetOrderProCount(string proOrderNo)
        {
            ProductOrderlists proList = productOrderlistService.GetList(u => u.ProductOrder_XuHao == proOrderNo)
                .FirstOrDefault();
            if (proList == null)
            {
                return RunResult<object>.False("没有找到该排产单号的数据");
            }
            ProductOrderReport productOrderEntity = new ProductOrderReport();

            productOrderEntity.ID = proList.ID;
            productOrderEntity.OrderNo = proOrderNo;
            productOrderEntity.BoxNo = proList.BoxNo ?? string.Empty;
            productOrderEntity.Unit = proList.Unit ?? string.Empty;
            productOrderEntity.ItemName = proList.ItemName;
            productOrderEntity.CheJianName = proList.Chejianclass;
            productOrderEntity.PlanDate = (proList.PlanDate ?? DateTime.Now).ToLongDateString();
            productOrderEntity.ClientName = proList.Clientname ?? string.Empty;
            productOrderEntity.Spec = proList.Spec ?? string.Empty;
            productOrderEntity.PcCount = proList.PcCount ?? 0;
            productOrderEntity.ProCount = proList.ProCount ?? 0;
            productOrderEntity.UploadBatch = proList.UploadBatch;
            productOrderEntity.NoWorkCount = productOrderEntity.PcCount - productOrderEntity.ProCount;
            productOrderEntity.Statue = proList.ProOrderList_State;
            productOrderEntity.Precent_Pro = productOrderEntity.PcCount == 0 ? 0 :
                Math.Round(productOrderEntity.ProCount * 100 / productOrderEntity.PcCount, 2);

            return RunResult<object>.True(productOrderEntity);
        }

        /// <summary>
        /// 获取产品生产数据
        /// </summary>
        /// <param name="proOrderNo">排产单号</param>
        /// <returns></returns>
        public RunResult<object> GetOrderProCount1(string proOrderNo)
        {
            List<ProductOrderlists> proList = productOrderlistService.GetList(u => u.ProductOrder_XuHao == proOrderNo);
            if (proList == null || proList.Count == 0)
            {
                return RunResult<object>.False("没有找到该排产单号的数据");
            }
            ProductOrderEntity productOrderEntity = new ProductOrderEntity();

            productOrderEntity.OrderNo = proOrderNo;
            productOrderEntity.CheJianName = proList[0].Chejianclass;
            productOrderEntity.OrderList = new List<ProductOrderListEntity>
                (proList.Count);
            ProductOrderListEntity productOrderListEntity = null;
            proList.ForEach((item) =>
            {
                productOrderEntity.ID = item.ID;
                productOrderEntity.Count_ALL += item.PcCount ?? 0;
                productOrderEntity.Count_HasPro += item.ProCount ?? 0;

                productOrderListEntity = new ProductOrderListEntity();
                productOrderListEntity.ID = item.ID;
                productOrderListEntity.ClientName = item.Clientname ?? string.Empty;
                productOrderListEntity.ItemName = item.ItemName ?? string.Empty;
                productOrderListEntity.PlanTime = (item.PlanDate ?? DateTime.Now).ToString("yyyy-MM-dd");
                productOrderListEntity.PlanCount = item.PcCount ?? 0;
                productOrderListEntity.Count_HasPro += item.ProCount ?? 0;
                productOrderListEntity.Count_NoPro = (item.PcCount ?? 0) - item.ProCount ?? 0;
                productOrderEntity.OrderList.Add(productOrderListEntity);
            });
            productOrderEntity.Count_NoPro = productOrderEntity.Count_ALL - productOrderEntity.Count_HasPro;
            if (productOrderEntity.Count_ALL > 0)
                productOrderEntity.Precent_HasPro = Math.Round(productOrderEntity.Count_HasPro * 100 / productOrderEntity.Count_ALL, 2); ;

            return RunResult<object>.True(productOrderEntity);
        }

        public RunResult<object> GetOrderAddCountHis(string proOrderNo)
        {
            var productOrderEntity =
                _productUploadHistoryService.GetIQueryable(
                    u => u.ProductOrder_XuHao == proOrderNo)
                .OrderByDescending(u => u.Newdate).ToList();
            if (productOrderEntity == null || productOrderEntity.Count == 0)
            {
                return RunResult<object>.False("没有找到该排产单号的数据");
            }


            return RunResult<object>.True(productOrderEntity);
        }


        public RunResult<IQueryable<ProlistReport>> GetOrderReport(string dateType, DateTime sPlanTime, DateTime ePlanTime,
            string[] cheJianName, string proNo, string pcNo, string itemName, string itemNo,
            string proSate, string proCQ, string jfCQ)
        {
            //车间、物料编码、物料名称、排产日期起止、客户交付日期起止、计划生产日期起止、
            //实际完成日期起止、生产超期、交付超期、生产状态；	

            Expression<Func<ProductOrderlists, bool>> expression = DbBaseExpand.True<ProductOrderlists>();

            if (cheJianName!=null && cheJianName.Length > 0)
                expression = expression.And(u => cheJianName.Contains(u.Chejianclass));
            if (!string.IsNullOrEmpty(itemName))
                expression = expression.And(u => u.ItemName != null && u.ItemName.Contains(itemName));
            if (!string.IsNullOrEmpty(itemNo))
                expression = expression.And(u => u.Itemno != null && u.Itemno.Contains(itemNo));
            if (!string.IsNullOrEmpty(proNo))
                expression = expression.And(u => u.ProductOrder_XuHao.Contains(proNo));
            if (!string.IsNullOrEmpty(pcNo))
                expression = expression.And(u => u.ProPlanOrderlists.PlanOrder_XuHao.Contains(pcNo));
            if (!string.IsNullOrEmpty(proSate))
                expression = expression.And(u => u.ProOrderList_State != null && u.ProOrderList_State.StartsWith(proSate));

            if (dateType == "计划日期")
                expression = expression.And(u => u.ProPlanOrderlists.PlanDate >= sPlanTime && u.ProPlanOrderlists.PlanDate <= ePlanTime);
            else if (dateType == "交付日期")
                expression = expression.And(u => u.ProPlanOrderlists.crmPlanList != null &&
                u.ProPlanOrderlists.crmPlanList.DeliveryDate >= sPlanTime && u.ProPlanOrderlists.crmPlanList.DeliveryDate <= ePlanTime);
            else if (dateType == "完成日期")
                expression = expression.And(u => u.FinishTime != null && u.FinishTime >= sPlanTime
                && u.FinishTime <= ePlanTime);
            else if (dateType == "生产日期")
                expression = expression.And(u => u.PlanDate != null && u.PlanDate >= sPlanTime
                && u.PlanDate <= ePlanTime);
            expression = expression.And(u => u.ProOrderList_State != PlanOrderState.HasDeleted);
            var prolistQuery = productOrderlistService.GetIQueryable(expression)
                .Select(u => new ProlistReport
                {
                    ID = u.ID,
                    ProductOrder_XuHao = u.ProductOrder_XuHao,
                    ProPlanOrder_XuHao = u.ProPlanOrderlists.PlanOrder_XuHao,
                    Itemno = u.Itemno,
                    ItemName = u.ItemName,
                    CheJianName = u.Chejianclass,

                    ApplyTime = u.ProPlanOrderlists.crmPlanList.CRMPlanHead.ApplyTime,
                    PlanDate = u.ProPlanOrderlists.PlanDate,
                    DeliveryDate = u.ProPlanOrderlists.crmPlanList.DeliveryDate,
                    PlanProDate = u.PlanDate,
                    FinishTime = u.FinishTime,

                    //PcCQ = (u.FinishTime ?? DateTime.Now) 
                    //    > (u.PlanDate.HasValue ? u.PlanDate.Value.AddDays(1) : DateTime.Now) ? "是" : "否",
                    //JFCQ = (u.FinishTime ?? DateTime.Now) > (u.ProPlanOrderlists.crmPlanList.DeliveryDate ?? DateTime.Now) ? "是" : "否",
                    Spec = u.Spec,
                    ConvertRate = u.ProPlanOrderlists.crmPlanList == null ? "0" :
                    u.ProPlanOrderlists.crmPlanList.ConvertRate,
                    PcCount = u.PcCount ?? 0,
                    ProCount = u.ProCount ?? 0,

                    PcCountOnKg = 0,
                    ProCountOnKg = 0,

                    Unit = u.Unit,
                    WCL = (u.PcCount ?? 0) == 0 ? 0 : ((u.ProCount ?? 0) * 100 / (u.PcCount ?? 0)),

                    ProOrderList_State = u.ProOrderList_State,
                    PlanProTime = u.PlanTime
                }); ;
            var prolistNos = prolistQuery.Select(u => u.ProductOrder_XuHao).ToArray();
            var uploadHisQuery = _productUploadHistoryService.GetIQueryable(
                u => prolistNos.Contains(u.ProductOrder_XuHao))
                .GroupBy(u => u.ProductOrder_XuHao)
                .Select(u => new
                {
                    ProductOrder_XuHao = u.Key,
                    Moddate = u.Max(x => x.Moddate)
                });
            var uploadHisQuery2 = _productUploadHistoryService.GetAllQueryable();

            var uploadHisUser = from u in uploadHisQuery
                                from b in uploadHisQuery2
                                where u.ProductOrder_XuHao == b.ProductOrder_XuHao
                                && u.Moddate == b.Moddate
                                select new ProOrderNewestUploadInfo
                                {
                                    ProOrderNo = u.ProductOrder_XuHao,
                                    UploadTime = u.Moddate,
                                    UploadUser = b.ModUser,
                                };

            var list = prolistQuery.ToList();
            var uploadUser = uploadHisUser.ToList();

            if (!string.IsNullOrEmpty(proCQ) && list.Count > 0)
                list = list.Where(u => u.PcCQ == proCQ).ToList();

            if (!string.IsNullOrEmpty(jfCQ) && list.Count > 0)
                list = list.Where(u => u.JFCQ == jfCQ).ToList();

            for (int i=0;i<list.Count;i++)
            {
                list[i].Index=i+1;
                list[i].WCL = Math.Round(list[i].WCL, 2);
                var convertRate = Convert.ToDecimal(list[i].ConvertRate);
                list[i].PcCountOnKg = convertRate * list[i].PcCount;
                list[i].ProCountOnKg = convertRate * list[i].ProCount;

                var uploadData = uploadUser.FirstOrDefault(u => u.ProOrderNo == 
                    list[i].ProductOrder_XuHao);
                list[i].UploadRen = uploadData == null ? string.Empty : uploadData.UploadUser;
                list[i].UploadTime = uploadData == null ? null : uploadData.UploadTime;


                list[i].PcCQ = (list[i].FinishTime ?? DateTime.Now)
                       > (list[i].PlanProDate.HasValue ? list[i].PlanProDate.Value.AddDays(1) : DateTime.Now) ? "是" : "否";
                list[i].JFCQ = (list[i].FinishTime ?? DateTime.Now) >
                   (list[i].DeliveryDate.HasValue ? list[i].DeliveryDate.Value.AddDays(1) : DateTime.Now) ? "是" : "否";
            }

            return RunResult<IQueryable<ProlistReport>>.True(list.AsQueryable());
        }


        public RunResult<IQueryable<OrderPcCountReport>> GetOrderCountReport(
            DateTime sPlanTime, DateTime ePlanTime,
            string[] cheJianName, string itemNo, string itemName)
        {
            //1、获取到时间段内的上报符合条件的次数与生产单号
            //2、包含某些生产单的物料编码与计划产量、实际产量



            //时间段内某些车间的上报次数与上报数量   
            var addCountList = _productUploadHistoryService.GetIQueryable(
                u => u.Newdate >= sPlanTime && u.Newdate <= ePlanTime && u.ProCount > 0
                && cheJianName.Contains(u.Chejianclass)
                && u.ItemName.Contains(itemName))
                .GroupBy(u => u.ProductOrder_XuHao)
                .Select(u => new
                {
                    ProductOrder_XuHao = u.Key,
                    ProCount = u.Sum(k => k.ProCount)
                }).ToList();

            //时间段内某些车间的上报单号
            var orderNoArray = addCountList
                .GroupBy(u => u.ProductOrder_XuHao).Select(u => u.Key).ToArray();

            //上报单号的生产单
            var orderList = productOrderlistService.GetIQueryable(
                u => orderNoArray.Contains(u.ProductOrder_XuHao)
                 && u.Itemno.Contains(itemNo)).
                 Select(u => new
                 {
                     u.ProductOrder_XuHao,
                     u.Itemno,
                     u.ItemName,
                     u.Spec,
                     u.Chejianclass,
                     u.Unit,
                     u.PcCount,
                     u.ProCount,
                     ConvertRate = (u.ProPlanOrderlists.crmPlanList == null ? "0" : u.ProPlanOrderlists.crmPlanList.ConvertRate),

                 }).ToList();


            //.GroupBy(u => u.Itemno)
            //.Select(u => new ItemNoPcCount { ItemNo=u.Key, 
            //    PcCount=u.Sum(i=>i.PcCount)??0});

            var addCountQuery = addCountList.AsQueryable();
            var orderQuery = orderList.AsQueryable();

            //两表关联
            //表一：生产单号、区间产量
            //表二：生产单号、生产品名
            var oneToOneQuery = from a in addCountQuery
                                from b in orderQuery
                                where a.ProductOrder_XuHao == b.ProductOrder_XuHao
                                select new
                                {
                                    ProductOrder_XuHao = b.ProductOrder_XuHao,
                                    ItemNo = b.Itemno,
                                    ItemName = b.ItemName,
                                    CheJianName = b.Chejianclass,
                                    Unit = b.Unit,
                                    Spec = b.Spec,
                                    PcCount = b.PcCount ?? 0,
                                    AllProCount = b.ProCount ?? 0,
                                    ProCount = a.ProCount,
                                    ProPrecent = (b.PcCount ?? 0) == 0 ? 0 :
                                        (b.ProCount ?? 0) * 100 / (b.PcCount ?? 0),
                                    ConvertRate = b.ConvertRate,
                                    PcCountOnKg = (b.PcCount ?? 0) * Convert.ToDecimal(b.ConvertRate),
                                    AllProCountOnKg = (b.ProCount ?? 0) * Convert.ToDecimal(b.ConvertRate),
                                    ProCountOnKg = a.ProCount * Convert.ToDecimal(b.ConvertRate),
                                };

            var query = oneToOneQuery.GroupBy(u => new
            {
                u.ItemNo,
                u.ItemName,
                u.CheJianName,
                u.Unit,
                u.Spec,
                u.ConvertRate,
            }).Select(u => new OrderPcCountReport
            {
                ItemNo = u.Key.ItemNo,
                ItemName = u.Key.ItemName,
                CheJianName = u.Key.CheJianName,
                Unit = u.Key.Unit,
                Spec = u.Key.Spec,
                ConvertRate = u.Key.ConvertRate,
                PcCount = u.Sum(k => k.PcCount),
                ProCount = u.Sum(k => k.ProCount),
                AllProCount = u.Sum(k => k.AllProCount),
                ProCountOnKg = u.Sum(k => k.ProCountOnKg),
                PcCountOnKg = u.Sum(k => k.PcCountOnKg),
                AllProCountOnKg = u.Sum(k => k.AllProCountOnKg),
                ProPrecent = u.Sum(k => k.PcCount) == 0 ? 0 :
                    u.Sum(k => k.ProCount) * 100 / u.Sum(k => k.PcCount)
            });
            //var list = query.ToList();
            return RunResult<IQueryable<OrderPcCountReport>>.True(query);
        }

       


        /// <summary>
        /// 看板小包装车间分车间产量
        /// </summary>
        /// <param name="sPlanTime"></param>
        /// <param name="ePlanTime"></param>
        /// <returns></returns>
        public RunResult<IQueryable<ProKanBanChart>> GetCheJianReport( DateTime sPlanTime, DateTime ePlanTime)
        {
            //车间、物料编码、物料名称、排产日期起止、客户交付日期起止、计划生产日期起止、
            //实际完成日期起止、生产超期、交付超期、生产状态；	

            Expression<Func<ProductOrderlists, bool>> expression = DbBaseExpand.True<ProductOrderlists>();

            expression = expression.And(u => u.Chejianclass.Contains("小包装"));
            
            expression = expression.And(u => u.PlanDate != null && u.PlanDate >= sPlanTime
                && u.PlanDate <= ePlanTime);
            expression = expression.And(u => u.ProOrderList_State != PlanOrderState.HasDeleted);

            //获取到所有生产单的数量
            var prolist = productOrderlistService.GetIQueryable(expression)
                .Select(u => new ProlistReport
                {
                    ID = u.ID,
                    ProductOrder_XuHao = u.ProductOrder_XuHao,
                    ProPlanOrder_XuHao = u.ProPlanOrderlists.PlanOrder_XuHao,
                    Itemno = u.Itemno,
                    ItemName = u.ItemName,
                    CheJianName = u.Chejianclass,

                    ApplyTime = u.ProPlanOrderlists.crmPlanList.CRMPlanHead.ApplyTime,
                    PlanDate = u.ProPlanOrderlists.PlanDate,
                    DeliveryDate = u.ProPlanOrderlists.crmPlanList.DeliveryDate,
                    PlanProDate = u.PlanDate,
                    FinishTime = u.FinishTime,

                    PcCQ = (u.FinishTime ?? DateTime.Now) > (u.PlanDate ?? DateTime.Now) ? "是" : "否",
                    JFCQ = (u.FinishTime ?? DateTime.Now) > (u.ProPlanOrderlists.crmPlanList.DeliveryDate ?? DateTime.Now) ? "是" : "否",
                    Spec = u.Spec,
                    ConvertRate = u.ProPlanOrderlists.crmPlanList == null ? "0" :
                    u.ProPlanOrderlists.crmPlanList.ConvertRate,
                    PcCount = u.PcCount ?? 0,
                    ProCount = u.ProCount ?? 0,

                    PcCountOnKg = 0,
                    ProCountOnKg = 0,

                    Unit = u.Unit,
                    WCL = (u.PcCount ?? 0) == 0 ? 0 : ((u.ProCount ?? 0) * 100 / (u.PcCount ?? 0)),

                    ProOrderList_State = u.ProOrderList_State,
                    PlanProTime = u.PlanTime
                }).ToList();
             
            prolist.ForEach(temp =>
            {
                temp.WCL = Math.Round(temp.WCL, 2);
                var convertRate = Convert.ToDecimal(temp.ConvertRate);
                temp.PcCountOnKg = convertRate * temp.PcCount;
                temp.ProCountOnKg = convertRate * temp.ProCount;

            });
            var proListQuery = prolist.AsQueryable();
            var prolistNos = proListQuery.GroupBy(u=>new { u.CheJianName, u.PlanDate })
                .Select(u => new
                {
                    CheJianName=u.Key.CheJianName,
                    PlanDate = (u.Key.PlanDate != null ? u.Key.PlanDate.Value.Date : DateTime.Now.AddYears(3)),
                    PlanCountOnKg= u.Sum(x => x.PcCountOnKg),
                }).ToArray();
            var uploadHis = _productUploadHistoryService.GetList(
                u => u.Newdate >= sPlanTime && u.Newdate <= ePlanTime);
            var proListXuHao = uploadHis.Select(u => u.ProductOrder_XuHao).ToArray();
            var proLists = productOrderlistService.GetList(u =>
                    u.ProOrderList_State!=ProOrderState.HasDeleted &&
                    proListXuHao.Contains(u.ProductOrder_XuHao)).Select(u => new
            {
                u.ProductOrder_XuHao,
                ConvertRate = 
                //u.ProPlanOrderlists==null? "0" :
                (u.ProPlanOrderlists.crmPlanList == null ? "0" :u.ProPlanOrderlists.crmPlanList.ConvertRate)
            }) ;

            var uploadHisQuery = uploadHis.AsQueryable();
            var proCountQuery =
                 from a in uploadHisQuery
                 from b in proLists
                 where a.ProductOrder_XuHao == b.ProductOrder_XuHao
                 //group b by new { a.ProductOrder_XuHao, a.Newdate, b.ConvertRate } into g
                 select new
                 {
                     CheJianName = a.Chejianclass,
                     Newdate = a.Newdate.HasValue?a.Newdate.Value.Date:DateTime.Now.Date,
                     ProCountOnKg = a.ProCount* Convert.ToDecimal(b.ConvertRate)
                 };

            //var proCountQuery2 = proCountQuery1.GroupBy(u => new { u.CheJianName, u.Newdate })
            //    .Select(u =>new {
            //        u.Key.CheJianName,
            //        u.Key.Newdate,
            //        ProCountOnKg =u.Sum(k => k.ProCountOnKg) });
            var cheJianQuery= from a in proCountQuery
                              group a by new { a.CheJianName, a.Newdate } into g
                              select new
                              {
                                  CheJianName = g.Key.CheJianName,
                                  Newdate = g.Key.Newdate,
                                  ProCountOnKg = g.Sum(x => x.ProCountOnKg) 
                              };
            //var uploadHisQuery2 = _productUploadHistoryService.GetAllQueryable();

            //C#转出近7天的日期，然后用日期去做关联
            var dateArr = DateUtils.GetAllDates(sPlanTime, ePlanTime).AsQueryable();
            string[] arr = { "03小包装-小袋", "03小包装-罐", "03小包装-每日坚果"
            ,  "07小包装-小袋", "07小包装-罐", "07小包装-每日坚果"};
            var cheJianArr = from a in dateArr
                             from b in arr.AsQueryable()
                             select new
                             {
                                 Date = a.Date,
                                 CheJianName = b
                             };
            List<ProKanBanChart> chartList = new List<ProKanBanChart>(arr.Length);
            foreach (var c in arr)
            {
                chartList.Add(new ProKanBanChart(c));
            }
            var uploadHisUser = (from a in cheJianArr
                                join u in prolistNos
                                on new { a.Date,a.CheJianName } equals new { Date = u.PlanDate, u.CheJianName }
                                into stationRealTimeInfo1   //划重点划重点
                                from str1 in stationRealTimeInfo1.DefaultIfEmpty()
                                 join b in cheJianQuery
                                 on new { A = a.Date, CheJianName = a.CheJianName }
                                 equals new { A = b.Newdate, b.CheJianName }
                                 into stationRealTimeInfo2  //划重点划重点
                                 from str2 in stationRealTimeInfo2.DefaultIfEmpty()
                                 select new 
                                {
                                    CheJianName= a.CheJianName,
                                    XData = a.Date.ToString("MMdd"),
                                    YData1 = str2 == null ? "0" : str2.ProCountOnKg.ToString(),
                                    YData2 = str1 == null ? "0" : str1.PlanCountOnKg.ToString(),
                                }).ToList();

            for( int i=0;i< uploadHisUser.Count;i++)
            {
                ProKanBanChart proKanBanChart = chartList.Find(u => u.CheJianName == uploadHisUser[i].CheJianName);
                proKanBanChart.XData.Add(uploadHisUser[i].XData);
                proKanBanChart.YData1.Add(uploadHisUser[i].YData1);
                proKanBanChart.YData2.Add(uploadHisUser[i].YData2);
            }


            return RunResult<IQueryable<ProKanBanChart>>.True(chartList.AsQueryable());
        }
        /// <summary>
        /// 看板小包装车间总产量
        /// </summary>
        /// <param name="sPlanTime"></param>
        /// <param name="ePlanTime"></param>
        /// <returns></returns>
        public RunResult<IQueryable<ProKanBanChart>> GetSmallBoxReport(DateTime sPlanTime, DateTime ePlanTime)
        {
            //排产KG与生产KG分开统计，最后用日期进行左外连接关联

            #region 排产明细数据（提供转换系数进行计算KG）
            var planList = productOrderlistService.GetIQueryable(
               u =>u.PlanDate >= sPlanTime && u.PlanDate <= ePlanTime 
               && u.Chejianclass.Contains("小包装")
               && u.ProOrderList_State != PlanOrderState.HasDeleted).
                Select(u => new
                {
                    u.ProductOrder_XuHao,
                    u.PlanDate,
                    ConvertRate = (u.ProPlanOrderlists.crmPlanList == null ? "0" : u.ProPlanOrderlists.crmPlanList.ConvertRate),
                    u.PcCount
                }).ToList();
            var planList2= planList.Select(
                u =>new 
                {
                    u.ProductOrder_XuHao,
                    u.PlanDate.Value.Date,
                    ConvertRate = Convert.ToDecimal(u.ConvertRate),
                    PcCountOnKg = (u.PcCount??0)* Convert.ToDecimal(u.ConvertRate)
                });

            #endregion 

            #region 排产KG
            var planListOnKg = planList2.GroupBy(u => u.Date)
                .Select(u => new
                {
                    Date = u.Key,
                    PcCountOnKg=u.Sum(k=>k.PcCountOnKg)
                });
            #endregion 

            #region 生产KG
            //时间段内某些车间的上报次数与上报数量   
            var uploadList = _productUploadHistoryService.GetIQueryable(
                u => u.Newdate >= sPlanTime && u.Newdate <= ePlanTime && u.ProCount > 0
                && u.Chejianclass.Contains("小包装")).ToList();

            var addCountList = uploadList.GroupBy(u => new { u.ProductOrder_XuHao, u.Newdate.Value.Date })
                .Select(u => new
                {
                    ProductOrder_XuHao = u.Key.ProductOrder_XuHao,
                    u.Key.Date,
                    ProCount = u.Sum(k => k.ProCount)
                });
            var addCountOnKgList = from a in addCountList
                                   join b in planList2
                                   on a.ProductOrder_XuHao equals b.ProductOrder_XuHao
                                   into g
                                   from str in g.DefaultIfEmpty()
                                   select new
                                   {
                                       a.ProductOrder_XuHao,
                                       a.Date,
                                       ProCountOnKg= str==null? 0:
                                        a.ProCount*str.ConvertRate ,
                                   };

            var proCountOnKgDateList = addCountOnKgList.GroupBy(u=>u.Date)
                        .Select(u=>new {
                            Date=u.Key,
                            ProCountOnKg= u.Sum(k=>k.ProCountOnKg)
                        });

            #endregion

            var dateQuery = DateUtils.GetAllDates(sPlanTime, ePlanTime).AsQueryable();

            //时间段内某些车间的上报次数与上报数量   

            var q = (from a in dateQuery
                    join b in planListOnKg.AsQueryable()
                    on a.Date equals b.Date 
                    into stationRealTimeInfo1   //划重点划重点
                    from str1 in stationRealTimeInfo1.DefaultIfEmpty()
                     join c in proCountOnKgDateList.AsQueryable()
                     on a.Date equals c.Date
                     into stationRealTimeInfo2   //划重点划重点
                     from str2 in stationRealTimeInfo2.DefaultIfEmpty()
                     select new
                    {
                        a.Date,
                        PcCountOnKg = str1 == null ? 0:str1.PcCountOnKg,
                        ProCountOnKg = str2 == null ? 0:str2.ProCountOnKg,
                    }).ToList();
            ProKanBanChart proKanBanChart = new ProKanBanChart(string.Empty);
            for (int i = 0; i < q.Count(); i++)
            {
                proKanBanChart.XData.Add(q[i].Date.ToString("MMdd"));
                proKanBanChart.YData1.Add(q[i].ProCountOnKg.ToString());
                proKanBanChart.YData2.Add(q[i].PcCountOnKg.ToString());
            }
            var query = new List<ProKanBanChart>(1) { proKanBanChart }.AsQueryable();
            return RunResult<IQueryable<ProKanBanChart>>.True(query);
        }
        #endregion

        #region Add
        /// <summary>
        /// 下推生产单
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="planList"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public BaseResult<string> PushToProOrder(string orderNo, List<ProPlanOrderlists> planList,
            string position, string updateUser, DateTime planDate, string planTime)
        {
            var result = new BaseResult<string>();
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    ProductOrderheaders productOrderheaders = new ProductOrderheaders();
                    productOrderheaders.ProductOrderNo = orderNo;
                    productOrderheaders.Newdate = DateTime.Now;
                    productOrderheaders.Moddate = DateTime.Now;
                    productOrderheaders.Optdate = DateTime.Now;

                    productOrderheaders.OrderClass = "小包装生产单";

                    productOrderheaders.Workshops = position;
                    productOrderheaders.PrintState = "未打印";
                    productOrderheaders.ProductOrder_State = "未生产";

                    //ProductOrderheadersService.Insert(productOrderheaders);
                    //ProductOrderheadersService.SaveChanges();
                    List<ProductOrderlists> list = new List<ProductOrderlists>(planList.Count);
                    List<string> itemNames = new List<string>(planList.Count);
                    List<long> proList = new List<long>();

                    for (int index = 0; index < planList.Count; index++)
                    {
                        ProductOrderlists productOrderlists = new ProductOrderlists();
                        MapperHelper<ProPlanOrderlists, ProductOrderlists>.Map(planList[index], productOrderlists);
                        productOrderlists.ProductOrder_XuHao = productOrderheaders.ProductOrderNo + "-" + (index + 1).ToString("D2");
                        productOrderlists.OrderNo = productOrderheaders.ProductOrderNo;
                        productOrderlists.ID = 0;
                        productOrderlists.ProPlanOrderlists = planList[index];
                        productOrderlists.ProPlanOrderlists_ID = planList[index].ID;
                        productOrderlists.ProductOrderheaders = productOrderheaders;
                        productOrderlists.ProductOrderheaders_ID = productOrderheaders.ID;
                        productOrderlists.Newdate = DateTime.Now;
                        productOrderlists.Moddate = DateTime.Now;
                        productOrderlists.UploadBatch = DateTime.Now.ToString("yyyy");
                        productOrderlists.PlanDate = planDate;
                        productOrderlists.PlanTime = planTime;
                        productOrderlists.Jingbanren = updateUser;
                        productOrderlists.ProOrderList_State = "未生产";

                        if (!itemNames.Contains(productOrderlists.ItemName))
                        {
                            itemNames.Add(productOrderlists.ItemName);
                        }
                        //ProductOrderlistsService.Insert(productOrderlists);
                        list.Add(productOrderlists);

                        planList[index].PlanOrder_State = PlanOrderState.HasPlanPro;

                        if (planList[index].crmPlanList != null &&
                            !string.IsNullOrEmpty(planList[index].crmPlanList.CRMApplyList_InCode))
                        {
                            proList.Add(planList[index].CRMPlanList_ID.Value
                            //new CRMWriteEntity(
                            //    WriteTypeEnum.CRMPushPro.GetEnumDescription(),
                            //    new CRMProEntity()
                            //    {
                            //        crm_ID = planList[index].crmPlanList.CRMApplyList_InCode,
                            //        planOrderNo_XuHao=planList[index].PlanOrder_XuHao,
                            //        proOrderNo = productOrderlists.ProductOrder_XuHao,
                            //        taskName = productOrderlists.Chejianclass,
                            //        updateUser = updateUser,
                            //        planTime=UnixDateTImeUtils.ConvertDateTimeInt            (productOrderlists.PlanDate??DateTime.Now),
                            //        crmState = PlanOrderState.HasPlanPro, 
                            //        proState = ProOrderState.NoWork
                            //})
                            ); ;
                        }
                    }
                    productOrderheaders.ProductOrderlists = list;
                    productOrderheaders.ItemNameStr = string.Join(",", itemNames);
                    AddProOrder(productOrderheaders);
                    productOrderheaderService.SaveChanges();

                    //ProductOrderlistsService.InsertRange(list);
                    //ProductOrderlistsService.SaveChanges();

                    planListService.UpdateAll(planList);
                    tran.Complete();

                    if (proList != null && proList.Count > 0)
                    {
                        RabbitMQUtils.Send(CRMReturnWriteThread.queueName_CRMReturnWrite,
                           proList);
                    }
                    Logger.Default.Process(new Log(LevelType.Debug, $"ID：{productOrderheaders.ID.ToString()}:{productOrderheaders.ProductOrderNo}"));
                    int id = productOrderheaders.ID;
                    result.SetOkResult(id.ToString());
                }
                catch (Exception ex)
                {

                    Logger.Default.Process(new Log(LevelType.Info, $"下推排产单失败：\r\n{ex.ToString()}"));
                    result.SetError(ex.ToString()); ;
                }

            }
            return result;
        }

        /// <summary>
        /// 解绑生产单
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public BaseResult<string> UnBindingProOrder(int prolistId, string userName)
        {
            var result = new BaseResult<string>();
            long cRMProTask = 0;
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    ProductOrderlists productOrderlists = productOrderlistService.FindById(prolistId, DbMainSlave.Master);
                    if (productOrderlists != null)
                    {
                        cRMProTask = productOrderlists.ProPlanOrderlists.CRMPlanList_ID??0;
                        productOrderlists.ProOrderList_State = ProOrderState.HasDeleted;
                        int headerId = (int)productOrderlists.ProductOrderheaders_ID;
                        //与Header解除绑定
                        productOrderlists.ProductOrderheaders = null;
                        productOrderlists.ProductOrderheaders_ID = null;



                        //更新Header的ItemName
                        ProductOrderheaders productOrderheaders = productOrderheaderService.FindById(headerId, DbMainSlave.Master);
                        if (productOrderheaders.ProductOrderlists.Count == 0)
                        {
                            productOrderheaderService.Delete(productOrderheaders);
                            productOrderheaderService.SaveChanges();
                        }
                        else
                        {
                            List<string> itemNames = new List<string>(productOrderheaders.ProductOrderlists.Count);

                            productOrderheaders.ProductOrderlists.ForEach((item) =>
                            {
                                if (!itemNames.Contains(item.ItemName))
                                    itemNames.Add(item.ItemName);
                            });
                            productOrderheaders.ItemNameStr = string.Join(",", itemNames.ToArray());
                            productOrderheaderService.Update(productOrderheaders);
                            productOrderheaderService.SaveChanges();
                        }
                        //planlists状态变更
                        ProPlanOrderlists planList = productOrderlists.ProPlanOrderlists;
                        planList.PlanOrder_State = PlanOrderState.HasPlan;

                        planListService.Update(planList);
                        planListService.SaveChanges();
                        productOrderlists.ProPlanOrderlists_ID = null;
                        productOrderlists.ProPlanOrderlists = null;

                        productOrderlistService.Update(productOrderlists);
                        productOrderlistService.SaveChanges();
                        //productOrderlistService.Delete(productOrderlists);
                        //productOrderlistService.SaveChanges();
                        tran.Complete();
                    }
                    result.SetOkResult("生产单解绑成功");
                    RabbitMQUtils.Send(CRMReturnWriteThread.queueName_CRMReturnWrite,
                        cRMProTask);
                }
                catch
                {
                    result.SetError("生产单解绑失败");
                }
            }
            return result;
        }

        /// <summary>
        /// 新增排产单及明细
        /// </summary>
        /// <param name="pro">排产单示例</param>
        /// <returns>执行结果</returns>
        public int AddProOrder(ProductOrderheaders pro)
        {
            pro.ProductOrderlists.ForEach((item) =>
            {
                item.ProductOrderheaders_ID = pro.ID;
                item.ProductOrderheaders = pro;
            });
            productOrderheaderService.Insert(pro);
            productOrderlistService.InsertRange(pro.ProductOrderlists);
            return productOrderheaderService.SaveChanges();
        }

        public bool AddProOrders(List<ProductOrderheaders> list)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    foreach (var pro in list)
                    {
                        pro.ProductOrderlists.ForEach((item) =>
                        {
                            item.ProductOrderheaders_ID = pro.ID;
                            item.ProductOrderheaders = pro;
                        });
                        productOrderheaderService.Insert(pro);
                        productOrderlistService.InsertRange(pro.ProductOrderlists);
                    }

                    productOrderheaderService.SaveChanges();

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    //执行错误处理
                    Logger.Default.Process(new Log(LevelType.Error, ex.ToString()));
                    return false;
                }
            }
            return true;

        }

        public bool EditProOrders(ProductOrderheaders ProductOrderheaders,
            List<ProductOrderlists> addlist, List<ProductOrderlists> editlist)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    addlist.ForEach((item) =>
                    {
                        item.ProductOrderheaders_ID = ProductOrderheaders.ID;
                        item.ProductOrderheaders = ProductOrderheaders;
                    });
                    productOrderlistService.InsertRange(addlist);

                    editlist.ForEach((item) =>
                    {
                        item.ProductOrderheaders_ID = ProductOrderheaders.ID;
                        item.ProductOrderheaders = ProductOrderheaders;
                    });
                    productOrderheaderService.Update(ProductOrderheaders);
                    productOrderlistService.UpdateAll(editlist);
                    productOrderheaderService.SaveChanges();
                    productOrderlistService.SaveChanges();
                    tran.Complete();
                }
                catch (Exception ex)
                {
                    //执行错误处理
                    Logger.Default.Process(new Log(LevelType.Error, ex.ToString()));
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 新增排产单及明细
        /// </summary>
        /// <param name="pro">排产单示例</param>
        /// <returns>执行结果</returns>
        public async Task<int> AddProOrderAsync(ProductOrderheaders pro)
        {
            pro.ProductOrderlists.ForEach((item) =>
            {
                item.ProductOrderheaders_ID = pro.ID;
                item.ProductOrderheaders = pro;
            });
            productOrderheaderService.Insert(pro);
            productOrderlistService.InsertRange(pro.ProductOrderlists);
            return await productOrderheaderService.SaveChangesAsync();
        }
        #endregion

        #region Update

        public RunResult<string> UpdateProOrderStatue(int prolist_ID, string statue)
        {
            //using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    var list = productOrderlistService.FindById(prolist_ID, DbMainSlave.Master);
                    List<string> changeList = new List<string>(1)
                        {
                            "ProOrderList_State",
                        };
                    list.ProOrderList_State = statue;
                    if (statue == "生产中" && list.StartTime == null)
                    {
                        changeList.Add("StartTime");
                        list.StartTime = DateTime.Now;
                    }
                    else if (statue.Contains("停止") || statue.Contains("完结") || statue.Contains("完成"))
                    {
                        list.FinishTime = DateTime.Now;
                        changeList.Add("FinishTime");
                    }
                    productOrderlistService.Update(list, changeList);
                    productOrderlistService.SaveChanges();

                    var header = list.ProductOrderheaders;
                    //修改总单状态
                    string headerState = string.Empty;
                    //生产中、暂停、停止、异常-：总单进行中
                    //异常完结、异常完成、已完成：查询总单其他分单的状态
                    if (statue == "生产中" || statue.Contains("暂停") || statue.Contains("停止") || statue.Contains("异常-"))
                        headerState = "生产中";
                    else
                    {
                        var allList = header.ProductOrderlists;
                        if (!allList.Any(u => u.ProOrderList_State == "生产中" || u.ProOrderList_State == "未生产"
                        || u.ProOrderList_State.Contains("暂停") || u.ProOrderList_State.Contains("停止")
                        || u.ProOrderList_State.Contains("异常-")))
                            headerState = "已完结";
                    }
                    if (!string.IsNullOrEmpty(headerState))
                    {
                        header.ProductOrder_State = headerState;
                        productOrderheaderService.Update(header, new List<string>(1) { "ProductOrder_State" });
                        productOrderheaderService.SaveChanges();
                    }
                    //tran.Complete();

                    if (list.ProPlanOrderlists.crmPlanList != null &&
                        !string.IsNullOrEmpty(list.ProPlanOrderlists.crmPlanList.CRMApplyList_InCode))
                    {
                        Logger.Default.Process(new Log(LevelType.Info,
                            $"修改状态发送到队列：生产明细单ID：{list.ProPlanOrderlists.crmPlanList.CRMApplyList_InCode}" +
                            $"生产状态：{statue}"));

                        RabbitMQUtils.Send(CRMReturnWriteThread.queueName_CRMReturnWrite,
                            list.ProPlanOrderlists.CRMPlanList_ID.Value
                             );
                    }
                    return RunResult<string>.True();
                }
                catch (Exception ex)
                {
                    Logger.Default.Process(new Log(LevelType.Error, $"生产明细单ID：{prolist_ID}修改为{statue}状态失败：\r\n{ex.ToString()}"));
                    return RunResult<string>.False(ex.ToString());
                }

            }


        }

        /// <summary>
        /// 单纯修改排产单及明细
        /// </summary>
        /// <param name="pro">排产单实例</param>
        /// <param name="headModColumnsList">排产单修改的列名集合</param>
        /// <returns>执行结果</returns>
        public int UpdateProOrder(ProductOrderheaders pro, List<string> headModColumnsList)
        {
            productOrderheaderService.Update(pro, headModColumnsList);
            productOrderlistService.UpdateAll(pro.ProductOrderlists); ;
            return productOrderheaderService.SaveChanges();
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        /// <returns></returns>
        public RunResult<string> UpdateOrderAddProCount(int prolist_ID, int addCount,
            string uploadUser, string uploadBatch, string liuShuiHao)
        {
            using (redisHelper.CreateLock("AddProCount", TimeSpan.FromSeconds(300),
                TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(500)))
            {
                try
                {
                    var list = productOrderlistService.FirstOrDefault(u => u.ID == prolist_ID, true,
                        DbMainSlave.Master);
                    using (TransactionScope tran = new TransactionScope())
                    {
                        bool ret = _productUploadHistoryService.AddHis(list, addCount,
                            uploadUser, uploadBatch, liuShuiHao);
                        UpdateOrderListProCount(list.ProductOrder_XuHao, uploadUser, uploadBatch, list);
                        tran.Complete();
                    }
                    return RunResult<string>.True();
                }
                catch (Exception ex)
                {
                    Logger.Default.Process(new Log(LevelType.Error, $"生产明细单ID：{prolist_ID}上报数量失败：\r\n{ex.ToString()}"));
                    return RunResult<string>.False(ex.ToString());
                }
            }
        }
        /// <summary>
        /// 修改生产数据
        /// </summary>
        /// <returns></returns>
        private RunResult<string> UpdateOrderProData(int prolist_ID, int addCount)
        {
            using (redisHelper.CreateLock("UpdateProCount", TimeSpan.FromSeconds(300),
                TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(500)))
            {
                try
                {
                    //var proCount = productOrderlistService.FirstOrDefault(u => u.ID == prolist_ID, true,
                    //    DbMainSlave.Master).ProCount;
                    //decimal allCount = (proCount ?? 0) + addCount;
                    productOrderlistService.UpdateByPlus(u => u.ID == prolist_ID,
                       u => new ProductOrderlists() { ProCount = addCount });
                    return RunResult<string>.True();
                }
                catch (Exception ex)
                {
                    Logger.Default.Process(new Log(LevelType.Error, $"生产明细单修改数量失败：\r\n{ex.ToString()}"));
                    return RunResult<string>.False(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 修改生产单次上报的数据
        /// </summary>
        /// <returns></returns>
        public RunResult<string> UpdateOrderProDataList(List<ProOrderAddCount> lists)
        {
            if (lists == null || lists.Count == 0)
                return RunResult<string>.False("传值不能为空");
            using (redisHelper.CreateLock("UpdateProCount", TimeSpan.FromSeconds(300),
                TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(500)))
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    try
                    {
                        //var proCount = productOrderlistService.FirstOrDefault(u => u.ID == prolist_ID, true,
                        //    DbMainSlave.Master).ProCount;
                        //decimal allCount = (proCount ?? 0) + addCount;
                        int[] arr = lists.Select(u => u.OrderID).ToArray();
                        List<ProductUploadHistory> hisList = _productUploadHistoryService.GetList(u => arr.Contains(u.ID),
                            false, DbMainSlave.Master);
                        string orderNo = hisList[0].ProductOrder_XuHao;
                        string userId = hisList[0].UploadUser;
                        //string uploadBatch= hisList[0].UploadBatch;
                        foreach (var temp in lists)
                        {
                            ProductUploadHistory productUploadHistory = hisList.Find(u => u.ID == temp.OrderID);
                            productUploadHistory.ProCount = temp.Count;
                            productUploadHistory.ModUser = temp.ControlUser;
                            productUploadHistory.Moddate = DateTime.Now;
                        }
                        _productUploadHistoryService.UpdateAll(hisList);
                        _productUploadHistoryService.SaveChanges();

                        UpdateOrderListProCount(orderNo, userId, string.Empty);

                        tran.Complete();
                        return RunResult<string>.True();
                    }
                    catch (Exception ex)
                    {
                        Logger.Default.Process(new Log(LevelType.Error, $"生产明细单修改数量失败：\r\n{ex.ToString()}"));
                        return RunResult<string>.False(ex.ToString());
                    }
                }

            }
        }

        /// <summary>
        /// 根据单次上报的数据进行统计，修改生产明细的数量
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="userID">修改人</param>
        /// <param name="orderlist"></param>
        /// <returns></returns>
        public bool UpdateOrderListProCount(string orderNo, string userID, string uploadBatch,
            ProductOrderlists orderlist = null
            )
        {
            int allCount = _productUploadHistoryService.GetAllCount(orderNo);
            if (orderlist == null)
                orderlist = productOrderlistService.FirstOrDefault(u => u.ProductOrder_XuHao == orderNo, false,
           DbMainSlave.Master);
            orderlist.ProCount = allCount;
            if (uploadBatch != string.Empty)
            {
                orderlist.UploadBatch = uploadBatch;
                productOrderlistService.Update(orderlist,
                    new List<string>(3) { "ProCount", "UploadBatch" });
            }
            else
            {
                productOrderlistService.Update(orderlist,
                    new List<string>(2) { "ProCount" });
            }

            productOrderlistService.SaveChanges();
            if (orderlist.ProPlanOrderlists.CRMPlanList_ID != null &&
                !string.IsNullOrEmpty(orderlist.ProPlanOrderlists.crmPlanList.CRMApplyList_InCode))
                RabbitMQUtils.Send(CRMReturnWriteThread.queueName_CRMReturnWrite,
                    orderlist.ProPlanOrderlists.CRMPlanList_ID.Value);
            return true;
        }

        #endregion

        #region Delete
        /// <summary>
        /// 移除生产单明细
        /// </summary>
        /// <param name="id">排产单明细ID</param>
        public void DeleteProOrderList(int id)
        {
            ProductOrderlists proList = productOrderlistService.FindById(id, DbMainSlave.Master);

            if (proList.ProPlanOrderlists != null && proList.ProPlanOrderlists_ID > 0)
            {
                proList.ProPlanOrderlists.PlanOrder_State = PlanOrderState.HasPlanPro;
                planListService.Update(proList.ProPlanOrderlists,
                    new List<string>(1) { "PlanOrder_State" });
            }
            planListService.SaveChanges();
            productOrderlistService.Delete(u => u.ID == id);
        }

        /// <summary>
        /// 移除整个生产单数据
        /// </summary>
        /// <param name="pro">排产单表头</param>
        /// <returns>执行结果</returns>
        public int DeleteProOrderAll(ProductOrderheaders pro)
        {
            if (pro.ProductOrderlists != null && pro.ProductOrderlists.Count > 0)
            {
                pro.ProductOrderlists.ForEach(item =>
                {
                    UnBindingProOrder(item.ID, string.Empty);
                });
            }
            //productOrderlistService.Delete(u => u.ProPlanOrderheaders_ID == pro.ID);
            productOrderheaderService.Delete(pro);
            return productOrderheaderService.SaveChanges();
        }

        /// <summary>
        /// 移除多个排产单数据
        /// </summary>
        /// <param name="pro">多个排产ID</param>
        /// <returns>执行结果</returns>
        public int DeleteProOrderAll(List<int> ids, string userName)
        {
            int?[] ids2 = Array.ConvertAll<int, int?>(ids.ToArray(), s => s);
            List<ProductOrderlists> list = productOrderlistService.GetList(u =>
             ids2.Contains(u.ProductOrderheaders_ID), false, DbMainSlave.Master);


            if (list != null && list.Count > 0)
            {
                list.ForEach(item =>
                {
                    UnBindingProOrder(item.ID, userName);
                });
            }
            //proOrderListService.Delete(u => ids2.Contains(u.ProPlanOrderheaders_ID));
            productOrderheaderService.Delete(u => ids2.Contains(u.ID));
            return productOrderheaderService.SaveChanges();
        }

        #endregion
    }


}
