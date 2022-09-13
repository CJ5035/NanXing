using NanXingService_WMS.Services;
using NanXingService_WMS.Services.APS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NanXingKanBan_Product.ashx
{
    public class BaseAshx : IHttpHandler
    {
        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public virtual void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write("success");
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
            Dictionary<string, string> jsonDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            return jsonDict;
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
                string keyName = "_ProductOrderManager";
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
    }
}