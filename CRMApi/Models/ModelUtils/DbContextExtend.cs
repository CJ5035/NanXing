using CRMApi.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.ModelUtils
{
    public static class DbContextExtend
    {
        public static DbContext SetCurrentConnString(this DbContext dbContext, string conn)
        {
            if (dbContext is NanXingGuoRen_Context)
            {

                var context =(NanXingGuoRen_Context)dbContext; // context 是 EFCoreContext 实例；

                return context.SetCurrentConnString(conn);
            }
            else
                throw new Exception();
        }
    }
}
