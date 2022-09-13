using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NanXingApplication.Services;
using NanXingModel.Models;
using NanXingService.IService;
using System.Diagnostics;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace NanXingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : AbpController
    {
        private readonly IWareHouseService _service;
        public WareHouseController(IWareHouseService service)
        {
            _service =service;
        }

        [HttpGet]
        public void GetWHById(int ID)
        {
            Debug.WriteLine(24);
            //return _service.GetWHById(ID);
        }
    }
}
