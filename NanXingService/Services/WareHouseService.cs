using NanXingModel.Models;
using NanXingService.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NanXingService.Services
{
    public class WareHouseService : ApplicationService, IWareHouseService
    {
        public IRepository<WareHouse, int> Repository => 
            LazyServiceProvider.LazyGetRequiredService<IRepository<WareHouse, int>>();

        public async Task<string> GetWHById(int ID)
        {
            WareHouse wareHouse=await Repository.GetAsync(U => U.Id == ID);
            return wareHouse.Whname??string.Empty;
        }
        
    }
}
