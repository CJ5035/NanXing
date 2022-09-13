using NanXingModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace NanXingApplication.IService
{
    public interface IWareHouseService : IApplicationService
    {
        //Task<string> GetWHById(int ID);

        void Get();
             
    }
}
