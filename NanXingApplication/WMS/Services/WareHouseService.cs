using NanXingModel.Models;
using NanXingApplication.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NanXingApplication.Services
{
    public class WareHouseService : ApplicationService, IWareHouseService
    {
        //public IRepository<WareHouse, int> Repository => 
        //    LazyServiceProvider.LazyGetRequiredService<IRepository<WareHouse, int>>();
        //private readonly IRepository<WareHouse> _WareRepo;
        //public WareHouseService(IRepository<WareHouse> WareRepo)
        //{
        //    _WareRepo = WareRepo;
        //}
        public WareHouseService()
        {
        }
        //public async Task<string> GetWHById(int ID)
        //{
        //    //WareHouse wareHouse=await _WareRepo.GetAsync(U => U.Id == ID);
        //    //return wareHouse.Whname??string.Empty;
        //}
        public void Get()
        {

        }
    }
}
