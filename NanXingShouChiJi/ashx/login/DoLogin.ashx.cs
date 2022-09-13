
using NanXingData_WMS.Dao;
using NanXingShouChiJi.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace NanXingShouChiJi.ashx
{
    /// <summary>
    /// DoLogin 的摘要说明
    /// </summary>
    public class DoLogin :BaseAshx
    {
        public override void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> jsonDict = GetDicInJson(context);
            string loginId = jsonDict["name"];
            string passw = jsonDict["password"];
            Users user = userService.GetByName(loginId);

            //context.Response.ContentType = "text/plain";

            if (PasswordUtil.ComparePasswords(user.Password, passw))
            {
                if (!Convert.ToBoolean(user.Enabled))
                {
                    context.Response.Write("用户未启用，请联系管理员！");
                }
                else
                {
                    // 登录成功
                    //logger.Info(String.Format("登录成功：用户“{0}”", user.Name));
                    context.Response.Write("success");
                    return;
                }
            }
            else
            {
                context.Response.Write("fail");
            }

        }

        
        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}