using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Messaging;

namespace WebApi_Aps.Utils
{
    public static class CallContextUtils
    {
        public static void SetContext()
        {
            if (CallContext.GetData("context") == null)
            {

                HttpContext context = HttpContext.Current;
                CallContext.SetData("context", context);
            }
        }

    }
}