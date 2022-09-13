using NanXingService_WMS.Helper.APS;
using NanXingService_WMS.Managers;
using NanXingService_WMS.Services;
using NanXingService_WMS.Services.APS;
using NanXingService_WMS.Services.WMS;
using NanXingService_WMS.Services.WMS.AGV;
using NanXingService_WMS.Utils.RedisUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace NanXingKanBan.ashx
{
    /// <summary>
    /// BaseAshx 的摘要说明
    /// </summary>
    public class BaseAshx : IHttpHandler
    {
        public virtual void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write("success");
        }
        
        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected RedisHelper RedisHelper
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

        protected CRMPlanHeadService CRMPlanHeadService
        {
            get
            {
                string keyName = "_CRMPlanHeadService";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    CRMPlanHeadService temp = new CRMPlanHeadService();

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as CRMPlanHeadService;
                //return new ProPlanOrderheaderService();
            }
        }
        protected CRMPlanListService CRMPlanListService
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
                //return new ProPlanOrderheaderService();
            }
        }

        protected CRMFilesService CRMFilesService
        {
            get
            {
                string keyName = "_CRMFilesService";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    CRMFilesService temp = new CRMFilesService();

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as CRMFilesService;
                //return new ProPlanOrderheaderService();
            }
        }

        protected CRMPlanManager CRMPlanManager
        {
            get
            {
                string keyName = "_CRMPlanManager";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    CRMPlanManager temp = new CRMPlanManager(CRMPlanHeadService, CRMPlanListService ,
           ProPlanOrderlistsService , CRMFilesService );

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as CRMPlanManager;
                //return new ProPlanOrderheaderService();
            }
        }


        protected ProPlanOrderheaderService ProPlanOrderheaderService
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
        protected ProPlanOrderlistsService ProPlanOrderlistsService
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

        protected ProductOrderheadersService ProductOrderheadersService
        {
            get
            {
                string keyName = "_ProductOrderheadersService";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    ProductOrderheadersService temp = new ProductOrderheadersService();

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as ProductOrderheadersService;
            }
        }

        protected ProductOrderlistsService ProductOrderlistsService
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

        protected ProductUploadHistoryService ProductUploadHistoryService
        {
            get
            {
                string keyName = "_ProductUploadHistoryService";
                //http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!HttpContext.Current.Items.Contains(keyName))
                {
                    ProductUploadHistoryService temp = new ProductUploadHistoryService();

                    HttpContext.Current.Items[keyName] = temp;
                }
                return HttpContext.Current.Items[keyName] as ProductUploadHistoryService;
            }
        }

        protected ProductOrderManager ProductOrderManager
        {
            get
            {
                string keyName = "_LiuShuiHaoService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new ProductOrderManager(
                        ProductOrderheadersService, ProductOrderlistsService,
                        ProPlanOrderlistsService, ProductUploadHistoryService);
                }
                return context.Items[keyName] as ProductOrderManager;
            }
        }

        protected SensorDataService SensorDataService
        {
            get
            {
                string keyName = "__NanXingKanBan_SensorDataService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new SensorDataService();
                }
                return context.Items[keyName] as SensorDataService;
            }
        }
        protected ProductionService ProductionService
        {
            get
            {
                string keyName = "__NanXingKanBan_ProductionService";
                HttpContext context = HttpContext.Current;
                if (context == null)
                    context = HttpRuntime.Cache.Get("context") as HttpContext;
                // http://stackoverflow.com/questions/6334592/one-dbcontext-per-request-in-asp-net-mvc-without-ioc-container
                if (!context.Items.Contains(keyName))
                {
                    context.Items[keyName] = new ProductionService();
                }
                return context.Items[keyName] as ProductionService;
            }
        }



        /// <summary>
        /// 从content里取出json数据，不能是数组
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Dic</returns>
        protected Dictionary<string, string> GetDicInJson(HttpContext context)
        {
            System.IO.Stream sm = context.Request.InputStream;
            int len = (int)sm.Length;
            byte[] inputByts = new byte[len];
            sm.Read(inputByts, 0, len);
            sm.Close();
            string data = Encoding.GetEncoding("utf-8").GetString(inputByts);
            Debug.WriteLine(data);
            Dictionary<string, string> jsonDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            return jsonDict;
        }
       

        /// <summary>
        /// 计算使用时间
        /// </summary>
        /// <param name="dt1">开始时间</param>
        /// <param name="dt2">结束时间</param>
        /// <returns>相隔的秒数</returns>
        public string ReckonSeconds(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = (dt2 - dt1).Duration();

            double second = 0;
            if (ts.Hours > 0)
            {
                second += ts.Hours * 3600;
            }
            if (ts.Minutes > 0)
            {
                second += ts.Minutes * 60;
            }
            second += ts.Seconds;
            second += (ts.Milliseconds * 0.001);

            return second.ToString();

        }
    }
}