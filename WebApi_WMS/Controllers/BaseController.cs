using NanXingService_WMS.Managers;
using NanXingService_WMS.Services;
using NanXingService_WMS.Services.APS;
using NanXingService_WMS.Services.WMS;
using NanXingService_WMS.Services.WMS.AGV;
using System.Web;
using System.Web.Http;
using System.Runtime.Remoting.Messaging;
using WebApi_WMS.Models;
using WebApi_WMS.Utils;

namespace WebApi_WMS.Controllers
{
    public class BaseController : ApiController
    {
        //public static NanXingGuoRen_WMSEntities1 DB2
        //{
        //    get
        //    {
        //        string keyName = "__NanXingGuoRen_WMSEntities";
        //        HttpContext context = HttpContext.Current;
        //        if (context == null)
        //        {
        //            context = HttpRuntime.Cache.Get("context") as HttpContext;
        //        }
        //        // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
        //        if (!context.Items.Contains(keyName))
        //        {
        //            context.Items[keyName] = new NanXingGuoRen_WMSEntities1();
        //        }
        //        return context.Items[keyName] as NanXingGuoRen_WMSEntities1;
        //    }
        //}


        public static UserService UserService
        {
            get
            {
                string keyName = "__NanXingAPI_UserService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = CallContext.GetData("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new UserService();
                }
                return context.Items[keyName] as UserService;
            }
        }
        public static BaseService BaseService
        {
            get
            {
                string keyName = "__NanXingAPI_BaseService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new BaseService();
                }
                return context.Items[keyName] as BaseService;
            }
        }
        public static AGVRunModelService AGVRunModelService
        {
            get
            {
                string keyName = "__NanXingAPI_AGVRunModelService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new AGVRunModelService();
                }
                return context.Items[keyName] as AGVRunModelService;
            }
        }

        public static AGVMissionService MissionService
        {
            get
            {
                string keyName = "__NanXingAPI_AGVMissionService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get(keyName) as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new AGVMissionService();
                }
                return context.Items[keyName] as AGVMissionService;
            }
        }
        public static AGVMissionFloorService FloorService
        {
            get
            {
                string keyName = "__NanXingAPI_AGVMissionFloorService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new AGVMissionFloorService();
                }
                return context.Items[keyName] as AGVMissionFloorService;
            }
        }
        public static TrayStateService TrayStateService
        {
            get
            {
                string keyName = "__NanXingAPI_TrayStateService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new TrayStateService();
                }
                return context.Items[keyName] as TrayStateService;
            }
        }
        public static WareLocationService WareLocationService
        {
            get
            {
                string keyName = "__NanXingAPI_WareLocationService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new WareLocationService();
                }
                return context.Items[keyName] as WareLocationService;
            }
        }
        public static WareLocationLockHisService WareLocationLockHisService
        {
            get
            {
                string keyName = "__NanXingAPI_WareLocationLockHisService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new WareLocationLockHisService();
                }
                return context.Items[keyName] as WareLocationLockHisService;
            }
        }

        public static TiShengJiInfoService TiShengJiInfoService
        {
            get
            {
                string keyName = "__NanXingAPI_TiShengJiInfoService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new TiShengJiInfoService();
                }
                return context.Items[keyName] as TiShengJiInfoService;
            }
        }

        public static StockRecordService StockRecordService
        {
            get
            {
                string keyName = "__NanXingAPI_StockRecordService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new StockRecordService();
                }
                return context.Items[keyName] as StockRecordService;
            }
        }

        public static WareLocationTrayManager WareLocationTrayManager
        {
            get
            {
                string keyName = "__NanXingAPI_WareLocationTrayManager";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new WareLocationTrayManager(
                    TrayStateService, WareLocationService, WareLocationLockHisService);
                }
                return context.Items[keyName] as WareLocationTrayManager;
            }
        }

        public static AGVApiManager AGVApiManager
        {
            get
            {
                string keyName = "__NanXingAPI_AGVApiManager";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new AGVApiManager(MissionService, FloorService,
                    TrayStateService, WareLocationService, DeviceStatesService, AlarmLogService
                    ,AGVRunModelService, WareLocationLockHisService, TiShengJiInfoService,StockRecordService, WareLocationTrayManager);
                }
                return context.Items[keyName] as AGVApiManager;
            }
        }

        public static DeviceStatesService DeviceStatesService
        {
            get
            {
                string keyName = "__NanXingAPI_DeviceStatesService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new DeviceStatesService();
                }
                return context.Items[keyName] as DeviceStatesService;
            }
        }
        public static AGVAlarmLogService AlarmLogService
        {
            get
            {
                string keyName = "__NanXingAPI_AGVAlarmLogService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                }
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new AGVAlarmLogService();
                }
                return context.Items[keyName] as AGVAlarmLogService;
            }
        }

       
    }


    //#region CRM
    //public static ProPlanOrderheaderService ProPlanOrderheaderService
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_ProPlanOrderheaderService";
    //        HttpContext context = HttpContext.Current;
    //        if (context == null)
    //        {
    //            context = HttpRuntime.Cache.Get("context") as HttpContext;
    //        }
    //        // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!context.Items.Contains(keyName))
    //        {
    //            context.Items[keyName] = new ProPlanOrderheaderService();
    //        }
    //        return context.Items[keyName] as ProPlanOrderheaderService;
    //    }
    //}

    //public static ProPlanOrderlistsService ProPlanOrderlistsService
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_ProPlanOrderlistsService";
    //        HttpContext context = HttpContext.Current;
    //        if (context == null)
    //        {
    //            context = HttpRuntime.Cache.Get("context") as HttpContext;
    //        }
    //        // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!context.Items.Contains(keyName))
    //        {
    //            context.Items[keyName] = new ProPlanOrderlistsService();
    //        }
    //        return context.Items[keyName] as ProPlanOrderlistsService;
    //    }
    //}
    //protected static CRMPlanHeadService crmPlanHeadService
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_CRMPlanHeadService";
    //        HttpContext context = HttpContext.Current;
    //        if (context == null)
    //        {
    //            context = HttpRuntime.Cache.Get("context") as HttpContext;
    //        }
    //        //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!HttpContext.Current.Items.Contains(keyName))
    //        {
    //            CRMPlanHeadService temp = new CRMPlanHeadService();

    //            context.Items[keyName] = temp;
    //        }
    //        return HttpContext.Current.Items[keyName] as CRMPlanHeadService;
    //    }
    //}
    //protected static CRMPlanListService crmPlanListService
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_CRMPlanListService";
    //        HttpContext context = HttpContext.Current;
    //        if (context == null)
    //        {
    //            context = HttpRuntime.Cache.Get("context") as HttpContext;
    //        }
    //        //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!HttpContext.Current.Items.Contains(keyName))
    //        {
    //            CRMPlanListService temp = new CRMPlanListService();

    //            context.Items[keyName] = temp;
    //        }
    //        return HttpContext.Current.Items[keyName] as CRMPlanListService;
    //    }
    //}
    //protected static CRMFilesService crmFilesService
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_CRMFilesService";
    //        HttpContext context = HttpContext.Current;
    //        if (context == null)
    //        {
    //            context = HttpRuntime.Cache.Get("context") as HttpContext;
    //        }
    //        //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!HttpContext.Current.Items.Contains(keyName))
    //        {
    //            CRMFilesService temp = new CRMFilesService();

    //            context.Items[keyName] = temp;
    //        }
    //        return HttpContext.Current.Items[keyName] as CRMFilesService;
    //    }
    //}
    //public static ProPlanOrderManager ProPlanOrderManager
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_ProPlanOrderManager";
    //        HttpContext context = HttpContext.Current;
    //        if (context == null)
    //        {
    //            context = HttpRuntime.Cache.Get("context") as HttpContext;
    //        }
    //        // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!context.Items.Contains(keyName))
    //        {
    //            context.Items[keyName] = new ProPlanOrderManager(
    //                ProPlanOrderheaderService, ProPlanOrderlistsService, crmPlanListService);
    //        }
    //        return context.Items[keyName] as ProPlanOrderManager;
    //    }
    //}

    //protected static ProductOrderheadersService ProductOrderheadersService
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_ProductOrderheadersService";
    //        //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!HttpContext.Current.Items.Contains(keyName))
    //        {
    //            ProductOrderheadersService temp = new ProductOrderheadersService();

    //            HttpContext.Current.Items[keyName] = temp;
    //        }
    //        return HttpContext.Current.Items[keyName] as ProductOrderheadersService;
    //    }
    //}

    //protected static ProductOrderlistsService ProductOrderlistsService
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_ProductOrderlistsService";
    //        //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!HttpContext.Current.Items.Contains(keyName))
    //        {
    //            ProductOrderlistsService temp = new ProductOrderlistsService();

    //            HttpContext.Current.Items[keyName] = temp;
    //        }
    //        return HttpContext.Current.Items[keyName] as ProductOrderlistsService;
    //    }
    //}
    //public static ProductOrderManager ProductOrderManager
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_ProductOrderManager";
    //        HttpContext context = HttpContext.Current;
    //        if (context == null)
    //        {
    //            context = HttpRuntime.Cache.Get("context") as HttpContext;
    //        }
    //        // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!context.Items.Contains(keyName))
    //        {
    //            context.Items[keyName] = new ProductOrderManager(
    //                ProductOrderheadersService, ProductOrderlistsService, ProPlanOrderlistsService);
    //        }
    //        return context.Items[keyName] as ProductOrderManager;
    //    }
    //}

    //public static CRMPlanManager crmPlanManager
    //{
    //    get
    //    {
    //        string keyName = "__NanXingAPI_CRMPlanService";
    //        HttpContext context = HttpContext.Current;
    //        if (context == null)
    //        {
    //            context = HttpRuntime.Cache.Get("context") as HttpContext;
    //        }
    //        // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
    //        if (!context.Items.Contains(keyName))
    //        {
    //            context.Items[keyName] = new CRMPlanManager
    //                (crmPlanHeadService, crmPlanListService, ProPlanOrderlistsService, crmFilesService);
    //        }
    //        return context.Items[keyName] as CRMPlanManager;
    //    }
    //}

    //#endregion
}
