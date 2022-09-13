using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// BaseAsyncAash 的摘要说明
    /// </summary>
    public class BaseAsyncAash : HttpTaskAsyncHandler
    {
        public override async Task ProcessRequestAsync(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        public override bool IsReusable
        {
            get
            {
                return false;
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